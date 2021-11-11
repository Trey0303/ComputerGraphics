#include "transform.h"



transform::transform()
{
	localPos = glm::vec3(0, 0, 0);
	localRot = glm::identity<glm::quat>();
	localScl = glm::vec3(1,1,1);

	parent = nullptr;
}

void transform::setParent(transform* newParent)
{
	// WARN: this will break if you become your own parent

	//if there are existing children attached to this object
	if (parent != nullptr) {
		//remove child
		parent->removeChild(this);
		parent = nullptr;
	}
	//add a new parent for this object
	newParent->addChild(this);
	parent = newParent;
}

transform* transform::getParent() const
{

	return parent;
}

transform* transform::getChildAtIndex(size_t index) const
{

	return children[index];
}

size_t transform::getChildCount() const
{

	return children.size();
}

glm::vec3 transform::getPosition() const
{

	return localToWorldMatrix() * glm::vec4(localPos, 0);
}

void transform::setPosition(glm::vec3 position)
{

}

glm::mat4 transform::localMat() const
{

	return glm::mat4();
}

glm::mat4 transform::worldMat() const
{

	return glm::mat4();
}

glm::mat4 transform::localToWorldMatrix() const
{

	return glm::mat4();
}

glm::mat4 transform::worldToLocalMatrix() const
{

	return glm::mat4();
}

void transform::addChild(transform* const child)
{

}

void transform::removeChild(const transform* const child)
{

}
