#pragma once
// A time-keeping class
class time
{
private:
    float totalTime;          // time since start of the program
    float lastDeltaTime;      // time at the end of the last frame

public:
    float timeSinceStart() const;// time since start of the program
    float systemTime() const; // get current real-world time
    float deltaTime() ;  // time between frames

    void resetTime();         // reset time to zero again
    void setTime(float newTime);      // set time to a new value
};