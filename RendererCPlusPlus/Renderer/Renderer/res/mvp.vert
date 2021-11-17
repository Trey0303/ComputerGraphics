// mvp.vert
#version 430 core

layout (location = 0) in vec4 position;
layout (location = 2) in vec2 uv;
layout (location = 3) in vec3 normal;

layout (location = 0) uniform mat4 proj;
layout (location = 1) uniform mat4 view;
layout (location = 2) uniform mat4 model;



out vec2 vUV;
out vec3 vNormal;
out vec4 vPos;


void main()
{
    gl_Position = proj * view * model * position;
    vPos = gl_Position;
    vUV = uv;



    //transform normals into world-space (sans translation)
    vNormal = mat3(transpose(inverse(model))) * normal;
};