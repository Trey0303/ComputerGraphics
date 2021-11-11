#pragma once
#include <glm/glm.hpp>

//glm::quat
#define GLM_ENABLE_EXPERIMENTAL 1
#include "glm/gtx/quaternion.hpp"
#undef GLM_ENABLE_EXPERIMENTAL

#include <vector>

//Create a type to manage the transform of an object. 
//This should encode information such as the position, rotation, and scale of the object.
class transform
{
public:
	glm::vec3 localPos;
	glm::quat localRot;
	glm::vec3 localScl;

	transform();

	// get/set parent
	void setParent(transform* newParent);
	transform* getParent() const;

	// get children
	transform* getChildAtIndex(size_t index) const;
	size_t getChildCount() const;

	// get/set the world space position - analagous to transform.position
	glm::vec3 getPosition() const;
	void setPosition(glm::vec3 position);

	// local model matrix
	glm::mat4 localMat() const;
	// world model matrix
	glm::mat4 worldMat() const;

	// conversions matrices
	glm::mat4 localToWorldMatrix() const;
	glm::mat4 worldToLocalMatrix() const;

private:
	transform* parent;
	std::vector<transform*> children;

	void addChild(transform* const child);

	void removeChild(const transform* const child);
};
