// fragment shader
// this is run for each fragment to the screen (basically each pixel for now)

#version 430 core

layout(location = 3) uniform sampler2D albedo;

in vec2 vUV;

in vec4 vertColor;

out vec4 outColor;

void main() { 

        outColor = texture(albedo, vUV) * vertColor;
};