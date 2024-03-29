#pragma once
#include <functional>
#include <stdexcept>
#include <vector>

/**
 * \brief Stores a uniform 2D grid of sample values and performs bilinear interpolation on points between samples.
 */
class bilinearinterpolator
{
private:
    class Sample
    {
    public:
        const int32_t X, Y;
        const double Value;

        Sample(int32_t x, int32_t y, double value) : X(x), Y(y), Value(value) {}
    };

    std::vector<std::vector<Sample>> values;
    const int32_t minX, maxX, minY, maxY, incX, incY;
    
    int32_t clip(int32_t v, int32_t lower, int32_t upper) const { return v < lower ? lower : (v > upper ? upper : v); }
    int32_t clipX(int32_t x) const { return this->clip(x, minX, maxX); }
    int32_t clipY(int32_t y) const { return  this->clip(y, minY, maxY); }

    double GetValue(int32_t x, int32_t y) const;    

    static double Interpolate(int32_t p0, int32_t p1, double v0, double v1, int32_t p);
    static double Interpolate(const Sample& x0y0, const Sample& x0y1, const Sample& x1y0, const Sample& x1y1, int32_t x, int32_t y);
public:
    /**
     * \brief Constructor
     * \param xmin Minimum X value (left edge of domain)
     * \param xmax Maximum X value (right edge of domain). xmax-xmin should be evenly divisible by xi.
     * \param xi Sample increment in X direction. 
     * \param ymin Minimum Y value (bottom edge of domain)
     * \param ymax Maximum Y value (top edge of domain). ymax-ymin should be evenly divisible by yi.
     * \param yi Sample increment in Y direction. 
     * \param getSample Gets a sample at a specified location. Used to build the sample grid.
     */
    bilinearinterpolator(int32_t xmin, int32_t xmax, int32_t xi, int32_t ymin, int32_t ymax, int32_t yi, 
        const std::function<double(int32_t, int32_t)>& getSample);

    /**
     * \brief Gets the value for the specified inputs.
     * If (x,y) is outside the sample domain, the value for the nearest domain edge point is returned.
     * \param x 
     * \param y 
     * \return 
     */
    double operator()(int32_t x, int32_t y) const { return this->GetValue(x,y); }

    /**
     * \brief Clips the coordinates to the boundaries of the domain.
     * \param x 
     * \param y 
     * \return Indicates if clipping occurred.
     */
    bool clip(int32_t& x, int32_t& y) const
    {
        int32_t oldX = x, oldY = y;
        x = this->clipX(x);
        y = this->clipY(y);
        return x != oldX || y != oldY;
    }
    
    
};

