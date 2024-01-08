#include "pch.h"
#include "../Trixter.XDream.Qdomyos/bilinearinterpolator.h"
#include <stdexcept>

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
		std::string what = "Testing " + testPoint.Description + " point " + pointString(testPoint) + " in " + quadrant;

		double value = bi(testPoint.X, testPoint.Y);

		std::cout << what << " : expecting " << expectedValue << " got " << value << "\n";

		// do they match?
		ASSERT_EQ(expectedValue, value) << what;

	}

	void TestInterpolation(int minX, int incX, int minY, int incY)
    {
        // To generate an internal point, this will use 1/4 of the increment
        if (incX < 4) throw std::invalid_argument("Increment should be 4 or greater");
        if (incY < 4) throw std::invalid_argument("Increment should be 4 or greater");
        TestPoint partial(incX >> 2, incY >> 2, ""); 

		// domain corners
		std::string dc = "domain corner";
		TestPoint dc00(minX, minY, dc), dc10(minX+2*incX, minY, dc), dc01(minX, minY+2*incY, dc), dc11(minX+2*incX, minY+2*incY, dc);
		std::string domainBounds = pointString(dc00) + "-" + pointString(dc11);

		std::cout << "Testing domain: " << domainBounds + "\n";

        // Create a bilinear interpolator that is rooted at (minX,minY) and has 4 quadrants, i.e. dimensions are 2*the increment.
        bilinearinterpolator bi(dc00.X, dc10.X, incX, dc00.Y, dc01.Y, incY, getValue);

		// For each quadrant
		std::string corner = "corner", internl = "internal", edge = "edge";
		for (int qy = 0; qy < 2; qy++)
			for (int qx = 0; qx < 2; qx++)
			{
				// Create the corners. Values for these should not need to be interpolated.
				std::vector<TestPoint> testPoints;
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
		std::string complementOfDomain = "complement of domain " + domainBounds;

		// bottom left corner of domain		
		testPoints.push_back(TestPoint(dc00.X-1, dc00.Y+incY, nonDomain)); // left of domain		
		testPoints.push_back(TestPoint(dc00.X+incX, dc00.Y-1, nonDomain)); // below domain		
		testPoints.push_back(TestPoint(dc00.X-1, dc00.Y - 1, nonDomain)); // left of and below domain
		
		// bottom right corner of domain
		testPoints.push_back(TestPoint(dc10.X + 1, dc10.Y + incY, nonDomain)); // right of domain		
		testPoints.push_back(TestPoint(dc10.X-incX, dc10.Y - 1, nonDomain)); // below domain		
		testPoints.push_back(TestPoint(dc10.X + 1, dc10.Y - 1, nonDomain)); // right of and below domain
		
		// top left corner of domain
		testPoints.push_back(TestPoint(dc01.X -1, dc01.Y - incY, nonDomain)); // left of domain		
		testPoints.push_back(TestPoint(dc01.X + incX, dc01.Y + 1, nonDomain)); // above domain		
		testPoints.push_back(TestPoint(dc01.X - 1, dc01.Y + 1, nonDomain)); // left of and above domain
		

		// top right corner of domain
		testPoints.push_back(TestPoint(dc11.X + 1, dc11.Y - incY, nonDomain)); // right of domain		
		testPoints.push_back(TestPoint(dc11.X - incX , dc11.Y + 1, nonDomain)); // above domain		
		testPoints.push_back(TestPoint(dc11.X + 1, dc11.Y + 1, nonDomain)); // right of and above domain
		

		for(int i=0; i<testPoints.size(); i++)
		{
			TestPoint testPoint = testPoints[i];

			std::string what = "Testing " + testPoint.Description + " point " + pointString(testPoint) + " in " + complementOfDomain;

			std::cout << what << " : expecting std::out_of_range thrown\n";
			try
			{
				double value = bi(testPoint.X, testPoint.Y);
				FAIL() << "std::out_of_range was not thrown for non-domain point";
			}
			catch(std::out_of_range)
			{
				SUCCEED();
			}

			// test clipping
			int32_t x = testPoint.X, y=testPoint.Y;
			ASSERT_TRUE(x < dc00.X || x > dc10.X || y < dc00.Y || y > dc01.Y) << "Test point is not outside domain";
			ASSERT_TRUE(bi.clip(x, y)) << "clip function did not report that it clipped";
			ASSERT_TRUE(x >= dc00.X && x <= dc10.X && y >= dc00.Y && y <= dc01.Y) << "values were not clipped";
			uint32_t oldX = x, oldY = y;
			ASSERT_FALSE(bi.clip(x, y)) << "clip function reported that it clipped in-domain coordinates";
			ASSERT_TRUE(oldX == x && oldY == y) << "clip function changed in-domain coordinates";
		}
			

        std::cout << "Finished testing domain: " << domainBounds << "\n";
	}

	

};

TEST_F(BilinearInterpolatorTest, TestInterpolation) {

	this->TestInterpolation(30, 10, 100, 50);
	this->TestInterpolation(100, 50, 30, 10);
	this->TestInterpolation(-200, 50, -50, 10);
	this->TestInterpolation(-200, 50, -50, 10);
}



