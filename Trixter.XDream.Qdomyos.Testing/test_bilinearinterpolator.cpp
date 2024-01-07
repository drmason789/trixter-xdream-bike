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



	void TestInterpolation(const bilinearinterpolator& bi, const TestPoint& testPoint, double expectedValue, const std::string& quadrant)
	{
		double value = bi(testPoint.X, testPoint.Y);
		
		std::string what = "Testing " + testPoint.Description + " point " + pointString(testPoint) + " in " + quadrant;

		std::cout << what << " : expecting " << expectedValue << " got " << value << "\n";

		// do they match?
		ASSERT_EQ(expectedValue, value) << what;

	}

	void TestInterpolation(int minX, int incX, int minY, int incY)
    {
        // To generate an internal point, this will use 1/4 of the increment
        if (incX < 4) throw "Increment should be 4 or greater";
        if (incY < 4) throw "Increment should be 4 or greater";
        TestPoint partial(incX >> 2, incY >> 2, "");             
		
		// domain corners
		std::string dc = "domain corner";
		TestPoint dc00(minX, minY, dc), dc10(minX+2*incX, minY, dc), dc01(minX, minY+2*incY, dc), dc11(minX+2*incX, minY+2*incY, dc);

        // Create a bilinear interpolator that is rooted at (minX,minY) and has 4 quadrants, i.e. dimensions are 2*the increment.
        bilinearinterpolator bi(dc00.X, dc10.X, incX, dc00.Y, dc01.Y, incY, getValue);

		// For each quadrant
		std::string corner = "corner", internl = "internal", edge = "edge";
		for (int qy = 0; qy < 2; qy++)
			for (int qx = 0; qx < 2; qx++)
			{
				// Create the corners. Values for these should not need to be interpolated.
				std:std::vector<TestPoint> testPoints;
				TestPoint c00(minX + qx * incX, minY + qy * incY, corner);
				TestPoint c11(c00.X + incX, c00.Y + incY, corner);
				testPoints.push_back(c00);
				testPoints.push_back(TestPoint(c00.X, c00.Y + incY, corner));
				testPoints.push_back(c11);
				testPoints.push_back(TestPoint(c00.X + incX, c00.Y, corner));

				// Error message text showing the quadrant
				std::string quadrant =  pointString(c00) + "-" + pointString(c11);
				
				// A point inside the quadrant. This should trigger bilinear interpolation.
				testPoints.push_back(TestPoint(c00.X + partial.X, c00.Y + partial.Y, internl));

				// A point on the X edge of the quadrant. This should be linearly interpolated
				testPoints.push_back(TestPoint(c00.X + partial.X, c00.Y, edge));

				// A point on the Y edge of the quadrant. This should be linearly interpolated.
				testPoints.push_back(TestPoint(c00.X, c00.Y + partial.Y, edge));

				for (auto testPoint : testPoints)
				{
					this->TestInterpolation(bi, testPoint, getValue(testPoint.X, testPoint.Y), quadrant);
				}
			}

		// Now test that requests for values outside the domain are mapped to the value for the nearest edge point.
		std::vector<TestPoint> testPoints;
		std::vector<double> expectedValues;
		std::string nonDomain = "non-domain";

		// bottom left corner of domain		
		testPoints.push_back(TestPoint(dc00.X-1, dc00.Y+incY, nonDomain)); // left of domain
		expectedValues.push_back(getValue(dc00.X, dc00.Y+incY));
		testPoints.push_back(TestPoint(dc00.X+incX, dc00.Y-1, nonDomain)); // below domain
		expectedValues.push_back(getValue(dc00.X+incX, dc00.Y));
		testPoints.push_back(TestPoint(dc00.X-1, dc00.Y - 1, nonDomain)); // left of and below domain
		expectedValues.push_back(getValue(dc00.X, dc00.Y));

		// bottom right corner of domain
		testPoints.push_back(TestPoint(dc10.X + 1, dc10.Y + incY, nonDomain)); // right of domain
		expectedValues.push_back(getValue(dc10.X, dc10.Y+incY));
		testPoints.push_back(TestPoint(dc10.X-incX, dc10.Y - 1, nonDomain)); // below domain
		expectedValues.push_back(getValue(dc10.X-incX, dc10.Y));
		testPoints.push_back(TestPoint(dc10.X + 1, dc10.Y - 1, nonDomain)); // right of and below domain
		expectedValues.push_back(getValue(dc10.X, dc10.Y));

		// top left corner of domain
		testPoints.push_back(TestPoint(dc01.X -1, dc01.Y - incY, nonDomain)); // left of domain
		expectedValues.push_back(getValue(dc01.X, dc01.Y-incY));
		testPoints.push_back(TestPoint(dc01.X + incX, dc01.Y + 1, nonDomain)); // above domain
		expectedValues.push_back(getValue(dc01.X+incX, dc01.Y));
		testPoints.push_back(TestPoint(dc01.X - 1, dc01.Y + 1, nonDomain)); // left of and above domain
		expectedValues.push_back(getValue(dc01.X, dc01.Y));


		// top right corner of domain
		testPoints.push_back(TestPoint(dc11.X + 1, dc11.Y - incY, nonDomain)); // right of domain
		expectedValues.push_back(getValue(dc11.X, dc11.Y-incY));
		testPoints.push_back(TestPoint(dc11.X - incX , dc11.Y + 1, nonDomain)); // above domain
		expectedValues.push_back(getValue(dc11.X-incX, dc11.Y));
		testPoints.push_back(TestPoint(dc11.X + 1, dc11.Y + 1, nonDomain)); // right of and above domain
		expectedValues.push_back(getValue(dc11.X, dc11.Y));

		for(int i=0; i<testPoints.size(); i++)
		{
			TestPoint testPoint = testPoints[i];
			double expected = expectedValues[i];
			this->TestInterpolation(bi, testPoint, expected, "domain complement");
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



