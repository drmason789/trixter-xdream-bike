#pragma once
#include <queue>
#include <vector>

class trixterxdreamv1
{
public:
	/**
	 * \brief Device state data: CSCS, heartrate and steering.
	 */
	struct state
	{
		/**
		 * \brief Steering value, from 0 (left) to 250 (right)
		 */
		unsigned char Steering;

		/**
		 * \brief Heart rate in beats per minute.
		 */
		unsigned char HeartRate;

		/**
		 * \brief The number of flywheel revolutions since the last reset event.
		 */
		unsigned int CumulativeWheelRevolutions;

		/**
		 * \brief The time of the last flywheel event. Unit:  1/1024 s
		 */
		unsigned short LastWheelEventTime;

		/**
		 * \brief The number of crank revolutions since the last reset event.
		 */
		unsigned short CumulativeCrankRevolutions;

		/**
		 * \brief  The time of the last crank event. Unit:  1/1024 s
		 */
		unsigned short LastCrankEventTime;
	};


private:
	unsigned char** resistanceMessages{};

	enum PacketState
	{
		None,
		Incomplete,
		Invalid,
		Complete
	};

	struct Packet
	{
		unsigned char Steering;
		unsigned short Flywheel;
		unsigned short Crank;
		unsigned char HeartRate;
	};

	struct state;

	unsigned long lastT=0;
	double flywheelRevolutions{}, crankRevolutions{};
	Packet lastPacket{};
	std::vector<char> inputBuffer;
	std::vector<unsigned char> byteBuffer;
	state lastState;

	/**
	 * \brief Clear the input buffer.
	 */
	void ResetBuffer();

	/**
	 * \brief Add the character to the input buffer and process to eventually read the next packet.
	 * \param c A text character '0'..'9' or 'a'..'f'
	 * \return
	 */
	PacketState ProcessChar(char c);

	void ConfigureResistanceMessages();
	

public:

	trixterxdreamv1();

	/**
	 * \brief Receives and processes a character of input from the device.
	 * \param c Should be '0' to '9' or 'a' to 'f' (lower case)
	 * \param t The time: the number of milliseconds since the last reset.
	 */
	void ReceiveChar(char c, unsigned long t);

	/**
	 * \brief Utility method to send bytes back to the device.
	 * \param bytes Binary data, not text as when receiving.
	 */
	void SendBytes(unsigned char* bytes);


	/**
	 * \brief Gets the state of the device as it was last read. This consists of CSCS data, steering and heartbeat.
	 * \return The last state.
	 */
	state getLastState() const;

	/**
	 * \brief Reset the Cycle Speed and Cadence information.
	 */
	void Reset();

	/**
	 * \brief Sends 1 packet indicating a specific resistance level to the device.
	 * \param level 0 to 250.
	 */
	void SendResistance(int level);
	
};

