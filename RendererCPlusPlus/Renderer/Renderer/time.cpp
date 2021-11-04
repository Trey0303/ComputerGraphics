#include "time.h"

float time::time() const
{
	return totalTime++ ;
}

float time::systemTime() const
{
	return 0.0f;
}

float time::deltaTime() const
{
	return 0.0f;
}

void time::resetTime()
{
}

void time::setTime(float)
{
}
