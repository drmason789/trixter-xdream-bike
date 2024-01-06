#include "pch.h"
#include "../Trixter.XDream.Qdomyos/bilinearinterpolator.h"


// The fixture for testing class Foo.
class BilinearInterpolatorTest : public ::testing::Test {

private:
    struct TestPoint
    {
        const int32_t X, Y;
        const std::string Description;

        TestPoint(int32_t x, int32_t y, const std::string& description): X(x), Y(y), Description(description) {}
    };

    static std::string pointString(const TestPoint& p)
    {
        return "("+ std::to_string(p.X)+","+std::to_string(p.Y)+")";
    }

protected:
	// You can remove any or all of the following functions if their bodies would
	// be empty.

	BilinearInterpolatorTest() {
		// You can do set-up work for each test here.
	}
	

	static double getValue(int x, int y) { return x * y; };

	void TestInterpolation(int minX, int incX, int minY, int incY)
    {
        // To generate an internal point, this will use 1/4 of the increment
        if (incX < 4) throw "Increment should be 4 or greater";
        if (incY < 4) throw "Increment should be 4 or greater";
        TestPoint partial(incX >> 2, incY >> 2, "");             

        // Create a bilinear interpolator that is rooted at (minX,minY) and has 4 quadrants, i.e. dimensions are 2*the increment.
        bilinearinterpolator bi(minX, minX + 2 * incX, incX, minY, minY + 2 * incY, incY, getValue);

		// For each quadrant
		for (int qy = 0; qy < 2; qy++)
			for (int qx = 0; qx < 2; qx++)
			{
				// Create the corners. Values for these should not need to be interpolated.
				std:std::vector<TestPoint> testPoints;
				TestPoint c00(minX + qx * incX, minY + qy * incY, "Corner");
				TestPoint c11(c00.X + incX, c00.Y + incY, "Corner");
				testPoints.push_back(c00);
				testPoints.push_back(TestPoint(c00.X, c00.Y + incY, "Corner"));
				testPoints.push_back(c11);
				testPoints.push_back(TestPoint(c00.X + incX, c00.Y, "Corner"));

				// Error message text showing the quadrant
				std::string quadrant =  pointString(c00) + "-" + pointString(c11);
				
				// A point inside the quadrant. This should trigger bilinear interpolation.
				testPoints.push_back(TestPoint(c00.X + partial.X, c00.Y + partial.Y, "Internal"));

				// A point on the X edge of the quadrant. This should be linearly interpolated
				testPoints.push_back(TestPoint(c00.X + partial.X, c00.Y, "Edge"));

				// A point on the Y edge of the quadrant. This should be linearly interpolated.
				testPoints.push_back(TestPoint(c00.X, c00.Y + partial.Y, "Edge"));

				for (auto testPoint : testPoints)
				{
					double value = bi(testPoint.X, testPoint.Y);
					double expectedValue = getValue(testPoint.X, testPoint.Y);

					std::string what = "Testing " + testPoint.Description + " point " + pointString(testPoint) + " in " + quadrant;

					std::cout << what << " : expecting " << expectedValue << " got " << value << "\n";

					// do they match?
					ASSERT_EQ(expectedValue, value) << what;
				}
			}
	}

	

};

//int main(int argc, char** argv) {
//	::testing::InitGoogleTest(&argc, argv);
//	return RUN_ALL_TESTS();
//}

TEST_F(BilinearInterpolatorTest, TestInterpolation) {

	this->TestInterpolation(30, 10, 100, 50);
	this->TestInterpolation(100, 50, 30, 10);
}



