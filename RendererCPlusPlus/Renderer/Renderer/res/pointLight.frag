#version 430 core

// matrices
layout (location = 2) uniform mat4 model;

//directional light
layout (location = 3) uniform sampler2D albedo;
layout (location = 4) uniform vec3 ambientLightColor;
layout (location = 5) uniform vec3 lightDir;
layout (location = 6) uniform vec3 lightColor;

//point light
layout (location = 7) uniform vec4 lightPosition;
layout (location = 8) uniform float lightRadius;


in vec2 vUV;
in vec3 vNormal;
in vec4 vPos;

out vec4 fragColor;

void main()
{
    //convert vector position to world space
    //vector position * model(position * rotation * scale)
    vec4 worldPos = vPos * model;

    //get distance between light and object
    vec4 distance = worldPos - lightPosition;

    //get the length from distance
    float d = length(distance);

    float attenuation = clamp(10.0f / d, 0.0, 1.0);
 
    //diffuse = dot product * light color
    vec3 dirToLight = normalize(lightPosition.xyz - worldPos.xyz);
    vec3 diffuse = max(0, dot(vNormal, dirToLight)) * lightColor;

    //gets the objects texture
    vec4 base = texture(albedo, vUV);

    //combines and outputs added light
    fragColor.rgb = attenuation * (base.rgb * (ambientLightColor + diffuse));
    //fragColor.rgb = attenuation * diffuse;
    fragColor.a = base.a;
};