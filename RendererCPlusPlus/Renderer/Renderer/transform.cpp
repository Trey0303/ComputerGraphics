#include "transform.h"

transform::transform()
{
	localPos = glm::vec3(0, 0, 0);
	//localRot = glm::identity<glm::quat>();
	localScl = glm::vec3(1,1,1);
}

glm::mat4 transform::localMat() const
{
	return glm::mat4();
}
