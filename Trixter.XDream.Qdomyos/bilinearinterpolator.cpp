#include "pch.h"
#include "bilinearinterpolator.h"

bilinearinterpolator::bilinearinterpolator(uint32_t xmin, uint32_t xmax, uint32_t xi, uint32_t ymin, uint32_t ymax,
	uint32_t yi, std::function<double(int32_t, int32_t)> getValue): minX(xmin), maxX(xmax), minY(ymin), maxY(ymax), incX(xi), incY(yi)
{
	if (xi < 1) throw "xi should be greater than 0";
	if (yi < 1) throw "yi should be greater than 0";
	if (xmin > xmax) "x values in wrong order";
	if (ymin > ymax) throw "y values in wrong order";
	if (!getValue) throw "No sample function provided";

	uint32_t deltaX = xmax - xmin, deltaY = ymax - ymin;

	if (deltaX % xi != 0) throw "x increment should evenly divide the domain.";
	if (deltaY % yi != 0) throw "y increment should evenly divide the domain.";

	uint32_t countX = 1 + deltaX / xi, countY = 1 + deltaY / yi;
        
	this->values.resize(countY);

	for (uint32_t y = ymin, ly = 0; y <= ymax; y += yi, ly++)
		for (uint32_t x = xmin, lx = 0; x <= xmax; x += xi, lx++)
			this->values[ly].push_back(Sample(x, y, getValue(x, y)));
}

double bilinearinterpolator::GetValue(uint32_t x, uint32_t y) const
{
	x = this->ClipX(x);
	y = this->ClipY(y);

	// point offset by the sample origin
	uint32_t yo = y - this->minY, xo = x - this->minX;

	// distance into the quad
	uint32_t yr = yo % this->incY, xr = xo % this->incX;

	// local position in the sample array
	uint32_t yl = yo / this->incY, xl = xo / this->incX;

	if (yr == 0 && xr == 0)
		// it's exactly on a sample
		return this->values[yl][xl].Value;

	// rXY
	const Sample& r00 = this->values[yl][xl];
	const Sample& r10 = this->values[yl][xl + 1];
	const Sample& r01 = this->values[yl + 1][xl];
	const Sample& r11 = this->values[yl + 1][xl + 1];

	if (yr == 0)
		// On the lower Y edge
		return Interpolate( r00.X,r10.X, r00.Value, r10.Value, x);

	if (xr == 0)
		// On the lower X edge
		return Interpolate( r00.Y, r01.Y, r00.Value, r01.Value , y);

	// Interpolate bilinearly.
	double result = Interpolate(r00,r01,r10,r11, x, y);

	return result;
}

double bilinearinterpolator::Interpolate(uint32_t p0, uint32_t p1, double v0, double v1, uint32_t p)
{
	if (p0 >= p1)
		throw "Sample points are not in increasing order.";
                        
	if (p < p0 || p > p1)
		throw "Point is not between sample points.";

	return ((p1 - p) * v0 + (p - p0) * v1) / (p1 - p0);
}

double bilinearinterpolator::Interpolate(const Sample& x0y0, const Sample& x0y1, const Sample& x1y0, const Sample& x1y1,
	uint32_t x, uint32_t y)
{
	if (x0y0.X != x0y1.X || x1y0.X != x1y1.X
		|| x0y0.Y != x1y0.Y || x0y1.Y != x1y1.Y)
		throw "Sample points do not form a rectangle or are not correctly ordered.";

	if (x0y0.X > x1y0.X || x0y0.Y > x0y1.Y)
		throw "Sample points are in wrong order.";
                
	double y0 = x0y0.Y, y1 = x0y1.Y;
	double x0 = x0y0.X, x1 = x1y0.X;

	double dx = x1 - x0, dy = y1 - y0, dxdy = dx * dy, dy1 = y1 - y, dy0 = y - y0, dx1 = x1 - x, dx0 = x - x0;
	double w00, w10, w01, w11;

	// wXY
	w00 = dx1 * dy1;
	w01 = dx1 * dy0;
	w10= dx0 * dy1;
	w11 = dx0 * dy0;

	double value = (w00 * x0y0.Value + w10 * x1y0.Value + w01 * x0y1.Value + w11 * x1y1.Value) / dxdy;

	return value;
}
