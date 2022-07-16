#include "pch.h"
#include "../Trixter.XDream.Qdomyos/trixterxdreamv1client.h"
#include <chrono>


// The fixture for testing class Foo.
class PacketInterpreter : public ::testing::Test {
protected:
	// You can remove any or all of the following functions if their bodies would
	// be empty.

	PacketInterpreter() {
		// You can do set-up work for each test here.
	}

	~PacketInterpreter() override {
		// You can do clean-up work that doesn't throw exceptions here.
	}

	static uint32_t getTime()
	{
		std::chrono::milliseconds ms = std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch());
		
		return static_cast<uint32_t>(ms.count());
	}

	// If the constructor and destructor are not enough for setting up
	// and cleaning up each test, you can define the following methods:

	void SetUp() override {
		// Code here will be called immediately after the constructor (right
		// before each test).
	}

	void TearDown() override {
		// Code here will be called immediately after each test (right
		// before the destructor).
	}

	// Class members declared here can be used by all tests in the test suite
	// for Foo.

	void TestInput(std::string input, uint8_t expectedHR, uint8_t expectedSteering)
	{
		trixterxdreamv1client tx1;
		
		tx1.set_GetTime(getTime);

		

		for (char value : input)
			tx1.ReceiveChar(value);

		trixterxdreamv1client::state state = tx1.getLastState();



		EXPECT_EQ(state.HeartRate, expectedHR);
		EXPECT_EQ(state.Steering, expectedSteering);


	}

	uint8_t* packet;
	int packetLength;

	void TestResistance(trixterxdreamv1client * tx1, uint8_t resistanceLevel)
	{

		this->packet = nullptr;
		this->packetLength = -1;
		tx1->SendResistance(resistanceLevel);
		
		auto p = this->packet;

		if(resistanceLevel==0)
		{
			// no packet sent = request for no resistance
			EXPECT_EQ(-1, this->packetLength);
			EXPECT_TRUE(p == nullptr);

			return;
		}

		// make sure the resistance is clipped
		if (resistanceLevel > trixterxdreamv1client::MaxResistance)
			resistanceLevel = trixterxdreamv1client::MaxResistance;

		EXPECT_EQ(6, this->packetLength);
		EXPECT_TRUE(p != nullptr);
		EXPECT_EQ(p[0], 0x6a);
		EXPECT_EQ(p[1], resistanceLevel);
		EXPECT_EQ(p[2], (resistanceLevel+60)%255);
		EXPECT_EQ(p[3], (resistanceLevel+90)%255);
		EXPECT_EQ(p[4], (resistanceLevel+120)%255);
		EXPECT_EQ(p[5], p[0]^p[1]^p[2]^p[3]^p[4]);

	}

};

//int main(int argc, char** argv) {
//	::testing::InitGoogleTest(&argc, argv);
//	return RUN_ALL_TESTS();
//}

TEST_F(PacketInterpreter, ValidPacket) {

	TestInput("56b6a00000000000000000000000000016b6a7f45000000000000000000000050006a", 0x50, 0x7f);
}

TEST_F(PacketInterpreter, SendResistance) {

	trixterxdreamv1client tx1;

	tx1.set_GetTime(getTime);
	auto device = this;
	tx1.set_WriteBytes([device](uint8_t* bytes, int length)->void { device->packet = bytes; device->packetLength = length; });

	for (int i = 0; i <= 255; i++)
		TestResistance(&tx1, static_cast<uint8_t>(i));	
}

