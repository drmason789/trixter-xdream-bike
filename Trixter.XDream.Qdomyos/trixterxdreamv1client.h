#pragma once
#include <vector>
#include <cstdint>
#include <functional>
#include <mutex>

/**
 * @brief Basic functionality to interpret character data read from a Trixter X-Dream V1 bike via a serial port.
 * Intended to be free from any non-standard C++ library code.
 * Requires a time source callback (set_getTime) to timestamp packets and optionally
 * a callback to write resistance packets to the serial port.
 */
class trixterxdreamv1client {
public:
    /**
     * @brief Device state data: CSCS, heartrate and steering.
     */
    struct state {
        /**
         * @brief Steering Steering value, from 0 (left) to 250 (right)
         */
        uint8_t Steering;

        /**
         * @brief HeartRate Heart rate in beats per minute.
         */
        uint8_t HeartRate;

        /**
         * @brief CumulativeWheelRevolutions The number of flywheel revolutions since the last reset event.
         */
        uint32_t CumulativeWheelRevolutions;

        /**
         * @brief CumulativeCrankRevolutions The number of crank revolutions since the last reset event.
         */
        uint16_t CumulativeCrankRevolutions;

        /**
         * @brief LastEventTime The time of the last event. Unit:  1/1024 s
         */
        uint16_t LastEventTime;

        /**
         * @brief FlywheelRPM Flywheel speed. Units: revolutions per minute
         */
        uint16_t FlywheelRPM;

        /**
         * @brief CrankRPM Crank speed. Units: revolutions per minute
         */
        uint16_t CrankRPM;
    };

private:
    uint8_t** resistanceMessages{};

    enum PacketState { None, Incomplete, Invalid, Complete };

    /**
     * @brief Raw data selected from the incoming packet.
     */
    struct Packet {
        uint8_t Steering;
        uint16_t Flywheel;
        uint16_t Crank;
        uint8_t HeartRate;
    };

    std::function<uint32_t()> get_time_ms=nullptr;
    std::function<void(uint8_t*, int)> write_bytes=nullptr;
    std::mutex stateMutex, writeMutex;
    uint32_t lastT = 0;
    uint32_t t0 = 0;
    double flywheelRevolutions{}, crankRevolutions{};
    Packet lastPacket{};
    std::vector<uint8_t> inputBuffer;
    std::vector<uint8_t> byteBuffer;
    state lastState;

    /**
     * @brief Clear the input buffer.
     */
    void ResetBuffer();

    /**
     * @brief Add the character to the input buffer and process to eventually read the next packet.
     * @param c A text character '0'..'9' or 'a'..'f'
     */
    PacketState ProcessChar(char c);

    void ConfigureResistanceMessages();

public:
    /**
     * @brief MaxResistance The maximum resistance value supported by the device.
     */
    constexpr static uint8_t MaxResistance = 250;

    /**
     * @brief MaxSteering The maximum steering value supported by the device.
     */
    constexpr static uint8_t MaxSteering = 255;

    /**
     * @brief The time interval between sending resistance requests to the device.
     */
    constexpr static uint8_t ResistancePulseIntervalMilliseconds = 10;

    trixterxdreamv1client();

    /**
     * @brief Receives and processes a character of input from the device.
     * @param c Should be '0' to '9' or 'a' to 'f' (lower case)
     * @return true if a packet was completed and the state updated, otherwise false.
     */
    bool ReceiveChar(char c);

    /**
     * @brief set_WriteBytes Sets the function used to write bytes to the serial port.
     * @param write_bytes The function that writes bytes to the serial port.
     */
    void set_WriteBytes(std::function<void(uint8_t*, int)> write_bytes) { this->write_bytes = write_bytes; }

    /**
     * @brief set_GetTime Sets the function to get the time in milliseconds since
     * a starting point understood by the client.
     * @param get_time_ms A function to get the time.
     */
    void set_GetTime(std::function<uint32_t()> get_time_ms);

    /**
     * @brief Gets the state of the device as it was last read. This consists of CSCS data, steering and heartbeat.
     */
    state getLastState();

    /**
     * @brief Reset the Cycle Speed and Cadence information.
     */
    void Reset();

    /**
     * @brief Sends 1 packet indicating a specific resistance level to the device. Needs to be sent at the rate specified by ResistancePulseIntervalMilliseconds.
     * @param level 0 to 250.
     */
    void SendResistance(uint8_t level);
};
