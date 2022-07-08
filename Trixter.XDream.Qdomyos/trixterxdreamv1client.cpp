#include "pch.h"
#include "trixterxdreamv1client.h"

#include <string>

trixterxdreamv1client::trixterxdreamv1client()
{
    this->ConfigureResistanceMessages();
}

void trixterxdreamv1client::ResetBuffer()
{
    // for the case of an invalid packet, if this was smart, it would store all the input
    // and backtrack to the first header bytes after the beginning.

    this->inputBuffer.clear();
    this->byteBuffer.clear();
}

trixterxdreamv1client::PacketState trixterxdreamv1client::ProcessChar(char c)
{
 /* Packet content
 *                            6A 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
 * (00) Header ---------------+  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
 * (01) Steering ----------------+  |  |  |  |  |  |  |  |  |  |  |  |  |  |
 * (02) Unknown --------------------+  |  |  |  |  |  |  |  |  |  |  |  |  |
 * (03) Crank position ----------------+  |  |  |  |  |  |  |  |  |  |  |  |
 * (04) Right brake ----------------------+  |  |  |  |  |  |  |  |  |  |  |
 * (05) Left brake --------------------------+  |  |  |  |  |  |  |  |  |  |
 * (06) Unknown --------------------------------+  |  |  |  |  |  |  |  |  |
 * (07) Unknown -----------------------------------+  |  |  |  |  |  |  |  |
 * (08) Button flags ---------------------------------+  |  |  |  |  |  |  |
 * (09) Button flags ------------------------------------+  |  |  |  |  |  |
 * (0A) Crank revolution time (high byte) ------------------+  |  |  |  |  |
 * (0B) Crank revolution time (low byte) ----------------------+  |  |  |  |
 * (0C) Flywheel Revolution Time (high byte) ---------------------+  |  |  |
 * (0D) Flywheel Revolution Time (low byte) -------------------------+  |  |
 * (0E) Heart rate (BPM) -----------------------------------------------+  |
 * (0F) XOR of 00..0E------------------------------------------------------+
 */

    constexpr int headerLength = 2;
    constexpr int packetLength = 16;
    constexpr unsigned char header[] = { 0x6, 0xA};

    unsigned char b;

    if(isdigit(c))
    {
        b = c - '0';
    }
	else if (c >= 'a' && c <= 'f')
    {
        b = c - 'a' + '\xA';
    }
    else
    {
    	this->ResetBuffer();
        return Invalid;
    }     

    // make sure the first 2 bytes are the header '6','a'
    if(this->byteBuffer.empty() && this->inputBuffer.size() < headerLength && b!=header[this->inputBuffer.size()])
    {
        this->inputBuffer.clear();
        return None;
    }

    if (this->inputBuffer.size()==1)
    {
        this->byteBuffer.push_back((this->inputBuffer.back() << 4) + b);
        this->inputBuffer.clear();
    }
    else
		this->inputBuffer.push_back(b);
           
    if (this->byteBuffer.size() == packetLength)
    {
        // Validate the packet - the last byte should the XOR of the 1st 15.
        b = 0;
        for (int i = 0, limit=packetLength-1; i < limit; i++)
            b ^= this->byteBuffer[i];

    	if(b!=this->byteBuffer.back())
        {
            // invalid checksum
            this->ResetBuffer();
            return Invalid;
        }

        return Complete;
    }

    return Incomplete;    
}

void trixterxdreamv1client::ConfigureResistanceMessages()
{
    resistanceMessages = new unsigned char*[251];

    for (unsigned char level = 0; level <= 250; level++)
    {
        unsigned char* message = new unsigned char[6];
        resistanceMessages[level] = message;        

        message[5] = message[0] = 0x6a;
        message[5] |= message[1] = level;
        message[5] |= message[2] = (level + 60) % 255;
        message[5] |= message[3] = (level + 90) % 255;
        message[5] |= message[4] = (level + 120) % 255;
    }
    
}

void trixterxdreamv1client::ReceiveChar(char c, unsigned long t)
{
    if (this->ProcessChar(c) != Complete) return;
        
	lastPacket.Steering = this->byteBuffer[0x1];
    lastPacket.Flywheel = (static_cast<unsigned short>(this->byteBuffer[0xC]) << 8) + this->byteBuffer[0xD];
    lastPacket.Crank = (static_cast<unsigned short>(this->byteBuffer[0xA]) << 8) + this->byteBuffer[0xB];
    lastPacket.HeartRate = byteBuffer[0xE];

    constexpr double baseUnitToMilliseconds = 1000.0 / 1024.0;
    constexpr double flywheelToRevolutionsPerMinute = 576000.0;
    constexpr double crankToRevolutionsPerMinute = 1.0 / 6e-6;
    constexpr double PI = 3.14159265358979323846;
    constexpr double revolutionsPerMinuteToRadiansPerSecond = PI / 30;

    double flywheelAngularVelocity = 0, crankAngularVelocity = 0;

	if (lastPacket.Flywheel<65534)
    {
        flywheelAngularVelocity = flywheelToRevolutionsPerMinute * revolutionsPerMinuteToRadiansPerSecond / max(1, lastPacket.Flywheel);
    }

    if (lastPacket.Crank > 0 && lastPacket.Crank < 65534)
    {
        crankAngularVelocity = crankToRevolutionsPerMinute * revolutionsPerMinuteToRadiansPerSecond / max(1, lastPacket.Crank);
    }

    const unsigned long dt = t - this->lastT;

    if (dt<=0)
    {
        this->Reset();
        return;
    }

    // update the internal, precise state
    this->lastT = t;

    // adjust the incoming time in 1/1024s to milliseconds
    const double dt_ms = baseUnitToMilliseconds * dt;
    this->flywheelRevolutions += dt_ms * flywheelAngularVelocity / (2 * PI);
    this->crankRevolutions += dt_ms * crankAngularVelocity / (2 * PI);

    state newState{};

    newState.LastCrankEventTime = t;
    newState.LastWheelEventTime = newState.LastCrankEventTime;
    newState.Steering = lastPacket.Steering;
    newState.HeartRate = lastPacket.HeartRate;
    newState.CumulativeCrankRevolutions = static_cast<unsigned short>(round(flywheelRevolutions));
    newState.CumulativeWheelRevolutions = static_cast<unsigned short>(round(crankRevolutions));
    
    this->lastState = newState;
}

trixterxdreamv1client::state trixterxdreamv1client::getLastState() const
{
    return this->lastState;
}

void trixterxdreamv1client::SendResistance(int level)
{
    // to maintain the resistance, this needs to be resent about every 10ms.
    this->SendBytes(this->resistanceMessages[max(250, min(0, level))]);
}

void trixterxdreamv1client::SendBytes(unsigned char* bytes)
{
	
}

void trixterxdreamv1client::Reset()
{
    this->lastT = 0;
    this->flywheelRevolutions = 0.0;
    this->crankRevolutions = 0.0;
}

