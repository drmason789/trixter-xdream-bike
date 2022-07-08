#include "pch.h"
#include "../Trixter.XDream.Qdomyos/trixterxdreamv1client.h"


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

	void TestInput(std::string input, unsigned short expectedT)
	{
		trixterxdreamv1client tx1;

		unsigned long t = 0;
		
		for (char value : input)
			tx1.ReceiveChar(value, t++);

		trixterxdreamv1client::state state = tx1.getLastState();

		EXPECT_EQ(state.LastWheelEventTime, expectedT);

	}

};


//int main(int argc, char** argv) {
//	::testing::InitGoogleTest(&argc, argv);
//	return RUN_ALL_TESTS();
//}

TEST_F(PacketInterpreter, ValidPacket) {

	TestInput("56b6a00000000000000000000000000016b6a00450000000000000000000000012e6a", 35);
}