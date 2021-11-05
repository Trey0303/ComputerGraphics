#include "time.h"

//float time::time() const
//{
//	return  ;
//}

float time::timeSinceStart() const
{
	return totalTime;
}

float time::systemTime() const
{
	return 0.0f;
}

float time::deltaTime()
{
	return lastDeltaTime++;
}

void time::resetTime()
{
	lastDeltaTime = 0.0f;
}

void time::setTime(float newTime)
{
	lastDeltaTime = newTime;
}
