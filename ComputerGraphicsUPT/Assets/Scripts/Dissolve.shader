Shader "Custom/CustomShader"
{
    // The properties block of the Unity shader. In this example this block is empty
       // because the output color is predefined in the fragment shader code.
        Properties
        {
        
            [MainTexture] _BaseMap("Albedo", 2D) = "white"{}
            _Cutoff("Alpha Cutoff", Range(0, 1)) = 0.5

        }
    
        // The SubShader block containing the Shader code. 
        SubShader
        {
            // SubShader Tags define when and under which conditions a SubShader block or
            // a pass is executed.
            Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" }

            Pass
            {
                 
                // The HLSL code block. Unity SRP uses the HLSL language.
                HLSLPROGRAM

                #pragma prefer_hlslcc gles
                #pragma exclude_renderers d3d11_9x
                #pragma target 2.0

                // -------------------------------------
                // Material Keywords
                // unused shader_feature variants are stripped from build automatically
                #pragma shader_feature _NORMALMAP
                #pragma shader_feature _ALPHATEST_ON
                #pragma shader_feature _ALPHAPREMULTIPLY_ON
                #pragma shader_feature _EMISSION
                #pragma shader_feature _METALLICSPECGLOSSMAP
                #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
                #pragma shader_feature _OCCLUSIONMAP

                #pragma shader_feature _SPECULARHIGHLIGHTS_OFF
                #pragma shader_feature _GLOSSYREFLECTIONS_OFF
                #pragma shader_feature _SPECULAR_SETUP
                #pragma shader_feature _RECEIVE_SHADOWS_OFF

                // -------------------------------------
                // Universal Render Pipeline keywords
                // When doing custom shaders you most often want to copy and past these #pragmas
                // These multi_compile variants are stripped from the build depending on:
                // 1) Settings in the LWRP Asset assigned in the GraphicsSettings at build time
                // e.g If you disable AdditionalLights in the asset then all _ADDITIONA_LIGHTS variants
                // will be stripped from build
                // 2) Invalid combinations are stripped. e.g variants with _MAIN_LIGHT_SHADOWS_CASCADE
                // but not _MAIN_LIGHT_SHADOWS are invalid and therefore stripped.
                #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
                #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
                #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
                #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
                #pragma multi_compile _ _SHADOWS_SOFT
                #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE

                // -------------------------------------
                // Unity defined keywords
                /*#pragma multi_compile _ DIRLIGHTMAP_COMBINED
                #pragma multi_compile _ LIGHTMAP_ON
                #pragma multi_compile_fog*/

                #pragma multi_compile_instancing

                // This line defines the name of the vertex shader. 
                #pragma vertex vert
                // This line defines the name of the fragment shader. 
                #pragma fragment frag

                // The Core.hlsl file contains definitions of frequently used HLSL
                // macros and functions, and also contains #include references to other
                // HLSL files (for example, Common.hlsl, SpaceTransforms.hlsl, etc.).
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"      

                // Material shader variables are not defined in SRP or LWRP shader library.
                // This means _BaseColor, _BaseMap, _BaseMap_ST, and all variables in the Properties section of a shader
                // must be defined by the shader itself. If you define all those properties in CBUFFER named
                // UnityPerMaterial, SRP can cache the material properties between frames and reduce significantly the cost
                // of each drawcall.
                // In this case, for sinmplicity LitInput.hlsl is included. This contains the CBUFFER for the material
                // properties defined above. As one can see this is not part of the ShaderLibrary, it specific to the
                // LWRP Lit shader.
                #include "Packages/com.unity.render-pipelines.universal/Shaders/LitInput.hlsl"

                // The structure definition defines which variables it contains.
                // This example uses the Attributes structure as an input structure in
                // the vertex shader.
                struct Attributes
                {
                    // The positionOS variable contains the vertex positions in object
                    // space.
                    float4 positionOS   : POSITION;
                    float4 normalOS : NORMAL;
                    float2 uvOS : TEXCOORD0;
                };

                struct Varyings
                {
                    float2 uvHCS : TEXCOORD0;
                    //float2 uv
                    // The positions in this struct must have the SV_POSITION semantic.
                    float4 positionHCS  : SV_POSITION;
                    float4 normalHCS : NORMAL;
                };
                
                /*CBUFFER_START(UnityPerMaterial)
                    float4 _BaseMap_ST;
                CBUFFER_END*/

                // The vertex shader definition with properties defined in the Varyings 
                // structure. The type of the vert function must match the type (struct)
                // that it returns.
                Varyings vert(Attributes IN)
                {
                    // Declaring the output object (OUT) with the Varyings struct.
                    Varyings OUT;


                    // The TransformObjectToHClip function transforms vertex positions
                    // from object space to homogenous space
                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                    OUT.normalHCS = float4(TransformObjectToWorldNormal(IN.normalOS), 0);



                    OUT.uvHCS = TRANSFORM_TEX(IN.uvOS, _BaseMap);



                    //OUT.uvHCS = IN.uvOS;


                    /*OUT.tangentHCS : */

                    // Returning the output.
                    return OUT;
                }


                // The fragment shader definition.            
                half4 frag() : SV_Target
                {


                    // Defining the color variable and returning it.
                    half4 customColor;
                    customColor = half4(0.5, 0, 0, 1);
                    return customColor;
                }
                ENDHLSL
            }
        }

}
