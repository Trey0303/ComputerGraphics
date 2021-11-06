
#include "time.h"
#include "glfw/glfw3.h"

#include <iostream>
#include <chrono>//system clock
#include <ctime>
#include <iomanip>


// time since start of the program
float timer::time() const
{
	return glfwGetTime();
}

// get current real-world time
float timer::systemTime() const
{
	using std::chrono::system_clock;

	
	std::chrono::system_clock::time_point now = std::chrono::system_clock::now();
	//now = std::chrono::system_clock::now();

	time_t timeNow;

	timeNow = std::chrono::system_clock::to_time_t(now);//converts system clock to time


#pragma warning(suppress : 4996)//use this to prevent unnecessary error for the line below
	std::cout << "real time: " << ctime(&timeNow) << std::endl;//prints out time in debug console

	
	return 0;
}

// time between frames
float timer::deltaTime()
{
	curDeltaTime = glfwGetTime();
	_deltaTime = curDeltaTime - lastDeltaTime;
	//std::cout << "delta time: " << _deltaTime << std::endl;
	lastDeltaTime = _deltaTime;
	return _deltaTime;
}

// reset time to zero again
void timer::resetTime()
{

	_deltaTime = 0.0f;
	curDeltaTime = 0.0f;
	lastDeltaTime = 0.0f;


}

// set time to a new value
void timer::setTime(float newTime)
{
	glfwSetTime(newTime);
	//totalTime = newTime;
}


