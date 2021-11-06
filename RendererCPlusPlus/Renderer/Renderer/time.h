#pragma once

#include <chrono>
// A time-keeping class
class timer
{
protected:
    //float totalTimeFromStart;          // time since start of the program
    float lastDeltaTime;      // time at the end of the last frame

    float curDeltaTime;// time currently this frame
    float _deltaTime; // total time of cur minus last delta time

    
    //float totalTime;
    
    


public:
    float time() const; // time since start of the program
    float systemTime() const; // get current real-world time
    float deltaTime() ;  // time between frames

    void resetTime();         // reset time to zero again
    void setTime(float newTime);      // set time to a new value
};