#version 430 core

//directional light
layout (location = 3) uniform sampler2D albedo;
layout (location = 4) uniform vec3 ambientLightColor;
layout (location = 5) uniform vec3 lightDir;
layout (location = 6) uniform vec3 lightColor;

//point light
layout (location = 7) uniform vec4 lightPosition;


in vec4 vPos;
in vec2 vUV;
in vec3 vNormal;

out vec4 fragColor;

void main()
{
    //get the amount of light that is hitting the surface
    float d = max(0, dot(vNormal, -lightDir));

    //deffuse = dot product * light color
    vec3 diffuse = d * lightColor;

    //gets the objects texture
    vec4 base = texture(albedo, vUV);

    //combines and outputs added light
    fragColor.rgb = base.rgb * (ambientLightColor + diffuse);
    fragColor.a = base.a;
};