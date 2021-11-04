#pragma once
// A time-keeping class
class time
{
private:
    float totalTime;          // time since start of the program
    float lastDeltaTime;      // time at the end of the last frame

public:
    float time() const;       // time since start of the program
    float systemTime() const; // get current real-world time
    float deltaTime() const;  // time between frames

    void resetTime();         // reset time to zero again
    void setTime(float);      // set time to a new value
};