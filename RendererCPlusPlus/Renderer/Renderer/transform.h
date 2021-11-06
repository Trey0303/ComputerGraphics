#pragma once
#include <glm/glm.hpp>



class transform
{
public:
    glm::vec3 localPos;
    //glm::quat localRot;
    glm::vec3 localScl;

public:
    transform();

    glm::mat4 localMat() const;
};