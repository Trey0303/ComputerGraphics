// vertex shader
#version 430 core

// vertex inputs
layout (location = 0) in vec4 position;
layout (location = 1) in vec4 colors;
layout (location = 2) in vec2 uv;

// uniforms (shader program globals)
layout (location = 0) uniform mat4 proj;
layout (location = 1) uniform mat4 view;
layout (location = 2) uniform mat4 model;

//time uniform
//layout (location = 2) uniform vec4 time;

out vec4 vertColor;

out vec2 vUV;

void main()
{
  vUV = uv;
  vertColor = colors;

  // transform object from
  // object space to world (model)
  // world to camera       (view)
  // camera to clip        (proj)
  gl_Position = proj * view * model * position;


}
// fragment shader