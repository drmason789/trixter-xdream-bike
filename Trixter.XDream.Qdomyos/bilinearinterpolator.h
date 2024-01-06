#pragma once
#include <functional>
#include <vector>

class bilinearinterpolator
{
private:
    class Sample
    {
    public:
        const uint32_t X, Y;
        const double Value;

        Sample(uint32_t x, uint32_t y, double value) : X(x), Y(y), Value(value) {}

    };

    std::vector<std::vector<Sample>> values;
    const uint32_t minX, maxX, minY, maxY, incX, incY;

    uint32_t Clip(uint32_t v, uint32_t lower, uint32_t upper) const { return v < lower ? lower : (v > upper ? upper : v); }
    uint32_t ClipX(uint32_t x) const { return this->Clip(x, minX, maxX); }
    uint32_t ClipY(uint32_t y) const { return  this->Clip(y, minY, maxY); }

    double GetValue(uint32_t x, uint32_t y) const;
public:

    bilinearinterpolator(uint32_t xmin, uint32_t xmax, uint32_t xi, uint32_t ymin, uint32_t ymax, uint32_t yi, std::function<double(int32_t, int32_t)> getValue);

    
    double operator()(uint32_t x, uint32_t y) const { return this->GetValue(x,y); }
        
    static double Interpolate(uint32_t p0, uint32_t p1, double v0, double v1, uint32_t p);

    static double Interpolate(const Sample& x0y0, const Sample& x0y1, const Sample& x1y0, const Sample& x1y1, uint32_t x, uint32_t y);
};

