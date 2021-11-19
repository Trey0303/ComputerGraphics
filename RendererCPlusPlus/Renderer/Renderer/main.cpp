#include "context.h"
#include "render.h"
#include "time.h"
#include "transform.h"

#include "glm/ext.hpp"
#include <iostream>
#include <glfw\glfw3.h>

using namespace aie;


int main() {
    context window;
    window.init(640, 480, "Hello Window");

    timer time;

    //create a triangle
    vertex triVerts[] = {
        {//vertex 0 - bottom left
            {-1.5,-.5,0,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {0.0f,0.0f},//uv
            {0.0f ,0.0f , 1.0f} //normal
        },
        {//vertex 1 - bottom right
            {-.5,-.5,0,1},//vertex 1 position
            {0, 0, 1, 1},//color
            {1.0f,0.0f},//uv
            {0 ,0 , 1} //normal
        },
        {//vertex 2 - top middle
            {-1,0,0,1},//vertex 2 position
            {0, 1, 0, 1},//color
            {0.5f,1.0f},//uv
            {0 ,0 , 1} //normal
        }
    };
    unsigned int triIndices[] = { 0,1,2 };

    geometry basicTriangleGeo = makeGeometry(triVerts, 3, triIndices, 3);

    //create a shader
    const char* basicVert =
        "#version 430 core\n"
        "layout (location = 0) in vec4 position;\n"
        "void main() { gl_Position = position; }";

    const char* basicFrag =
        "#version 430 core\n"
        "out vec4 vertColor;\n"
        "void main() { vertColor = vec4(1.0, 0.0, 0.0, 1.0); }";

    shader basicShad = makeShader(basicVert, basicFrag);


    //create a rectangle
    vertex recVerts[] = {
        {//vertex 0 - bottom left
            {-.5f,-.5f,0,1},//vertex 0 position
            {1, 0, 0, 1}//color
            
        },
        {//vertex 1 - bottom right
            {.5f,-.5f,0,1},//vertex 1 position
            {0, 1, 0, 1}//color
            
        },
        {//vertex 2 - top right
            {.5f,.5f,0,1},//vertex 2 position
            {0, 0, 1, 1}//color
        },
        {//vertex 3 - top left
            {-.5f,.5f,0,1},//vertex 3 position
            {1, 0, 1, 1}//color
        }
    };

    unsigned int recIndices[] = { 
        0,1,2,//triangle one
        0,2,3 //triangle two
    };

    geometry basicRectangleGeo = makeGeometry(recVerts, 4, recIndices, 6);

    //create a cube
    vertex cubeVerts[] = {
        //front
        {//vertex 0 - bottom left
            
            {-.5f,-.5f,0,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {0.0f,0.0f},//uv
            {0.0f ,0.0f , 1.0f} //normal
        },
        {//vertex 1 - bottom right
            {.5f,-.5f,0,1},//vertex 1 position
            {0, 1, 0, 1},//color
            {1.0f,0.0f},//uv
            {0 ,0 , 1} //normal
        },
        {//vertex 2 - top right
            

            {.5f,.5f,0,1},//vertex 2 position
            {0, 0, 1, 1},//color
            {1.0f,1.0f},//uv
            {0 ,0 , 1} //normal
        },
        {//vertex 3 - top left
            

            {-.5f,.5f,0,1},//vertex 3 position
            {1, 0, 1, 1},//color
            {0.0f,1.0f},//uv
            {0 ,0 , 1} //normal
        },
        //back
        {//vertex 4 - bottom left

            {-.5f,-.5f,-1,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {0.0f,0.0f},//uv
            {0.0f ,0.0f , -1.0f} //normal
        },
        {//vertex 5 - bottom right
            {.5f,-.5f,-1,1},//vertex 1 position
            {0, 1, 0, 1},//color
            {1.0f,0.0f},//uv
            {0 ,0 , -1} //normal
        },
        {//vertex 6 - top right


            {.5f,.5f,-1,1},//vertex 2 position
            {0, 0, 1, 1},//color
            {1.0f,1.0f},//uv
            {0 ,0 , -1} //normal
        },
        {//vertex 7 - top left


            {-.5f,.5f,-1,1},//vertex 3 position
            {1, 0, 1, 1},//color
            {0.0f,1.0f},//uv
            {0 ,0 , -1} //normal
        },
        //top
        {//vertex 8 - top right f


            {.5f,.5f,0,1},//vertex 2 position
            {0, 0, 1, 1},//color
            {1.0f,0},//uv
            {0 ,1 , 1} //normal
        },
        {//vertex 9 - top left f


            {-.5f,.5f,0,1},//vertex 3 position
            {1, 0, 1, 1},//color
            {0.0f,0.0f},//uv
            {0 ,1 , 1} //normal
        },
        {//vertex 10 - top right b


            {.5f,.5f,-1,1},//vertex 2 position
            {0, 0, 1, 1},//color
            {1.0f,1.0f},//uv
            {0 ,1 , 1} //normal
        },
        {//vertex 11 - top left b


            {-.5f,.5f,-1,1},//vertex 3 position
            {1, 0, 1, 1},//color
            {0.0f,1.0f},//uv
            {0 ,1 , 1} //normal
        },
        //left
        {//vertex 12 - bottom right f
            {.5f,-.5f,0,1},//vertex 1 position
            {0, 1, 0, 1},//color
            {0.0f,0.0f},//uv
            {1 ,0 , 1} //normal
        },
        {//vertex 13 - bottom right b
            {.5f,-.5f,-1,1},//vertex 1 position
            {0, 1, 0, 1},//color
            {1.0f,0.0f},//uv
            {1 ,0 , 1} //normal
        },
        {//vertex 14 - top right f


            {.5f,.5f,0,1},//vertex 2 position
            {0, 0, 1, 1},//color
            {0.0f,1.0f},//uv
            {1 ,0 , 1} //normal
        },
        {//vertex 15 - top right b


            {.5f,.5f,-1,1},//vertex 2 position
            {0, 0, 1, 1},//color
            {1.0f,1.0f},//uv
            {1 ,0 , 1} //normal
        },
        //right
        {//vertex 16 - bottom left b

            {-.5f,-.5f,-1,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {0.0f,0.0f},//uv
            {-1.0f ,0.0f , 1.0f} //normal
        },
        {//vertex 17 - bottom left f

            {-.5f,-.5f,0,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {1.0f,0.0f},//uv
            {-1.0f ,0.0f , 1.0f} //normal
        }, 
        {//vertex 18 - top left b


            {-.5f,.5f,-1,1},//vertex 3 position
            {1, 0, 1, 1},//color
            {0.0f,1.0f},//uv
            {-1 ,0 , 1} //normal
        },
        {//vertex 19 - top left f


            {-.5f,.5f,0,1},//vertex 3 position
            {1, 0, 1, 1},//color
            {1.0f,1.0f},//uv
            {-1 ,0 , 1} //normal
        },
        //bot
        {//vertex 20 - bottom left b

            {-.5f,-.5f,-1,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {0.0f,0.0f},//uv
            {0.0f ,-1.0f , 1.0f} //normal
        },
        {//vertex 21 - bottom right b
            {.5f,-.5f,-1,1},//vertex 1 position
            {0, 1, 0, 1},//color
            {1.0f,0.0f},//uv
            {0 ,-1 , 1} //normal
        },
        {//vertex 22 - bottom left f

            {-.5f,-.5f,0,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {0.0f,1.0f},//uv
            {0.0f ,-1.0f , 1.0f} //normal
        },
        {//vertex 23 - bottom right f
            {.5f,-.5f,0,1},//vertex 1 position
            {0, 1, 0, 1},//color
            {1.0f,1.0f},//uv
            {0 ,-1 , 1} //normal
        },
        
    };

    unsigned int cubeIndices[] = {
        //6
        //front
        0,1,2,//triangle one
        0,2,3, //triangle two
        
        //+6
        //back
        5,4,7,
        5,7,6,
        
        //+6
        //top
        9,8,10,
        9,10,11,

        //+6
        //left
        12,13,15,
        12,15,14,
        
        //+6
        //right
        16,17,19,
        16,19,18,
        
        
        //+6
        //bot
        20,21,23,
        20,23,22
        //=38
    };

    geometry basicCubeGeo = makeGeometry(cubeVerts, 24, cubeIndices, 38);
   
    //create vertex colors
    const char* colorVert =
        "#version 430 core\n"
        "layout (location = 0) in vec4 position;\n"
        "layout (location = 1) in vec4 colors;\n"
        "out vec4 vertColor;\n"
        "void main() { vertColor = colors; gl_Position = position; }";

    const char* colorFrag =
        "#version 430 core\n"
        "in vec4 vertColor;\n"
        "out vec4 outColor;"
        "void main() { outColor = vertColor;}";

    shader multiColorShad = makeShader(colorVert, colorFrag);

    //loading shader
    shader stdShad = loadShader("res\\pointLight.vert", "res\\pointLight.frag");

    //loading textures
    texture checker = loadTexture("res\\uvchecker.jpg");
    
    //transform
    transform tri_default;
    transform tri_trans;
    tri_trans.localPos = glm::vec3(.5, 1, 0);
    tri_trans.localRot = glm::angleAxis(45.0f, glm::vec3(0, 0, 1));
    tri_trans.localScl = glm::vec3(2, 2, 2);

    glm::mat4 triModel = glm::identity<glm::mat4>(); // #include "glm/ext.hpp"
    glm::mat4 camView = glm::lookAt(glm::vec3(0, 1, 5), //eye
                                    glm::vec3(0, 0, 0), //look at
                                    glm::vec3(0, 1, 0));//up
    glm::mat4 camProj = glm::perspective(glm::radians(45.0f), // vertical fov
                                        640.0f / 480.0f,    // aspect ratio
                                        0.1f,               // near-plane
                                        1000.0f);           // far-plane

    //define ambient color
    glm::vec3 ambient(0.3f, 0.3f, 0.3f);
    glm::vec3 sunlight = glm::vec3(0, 0,-1);//directional light direction?
    glm::vec3 lightColor = glm::vec3(1, 1, 0);//directional light color
    
    //point light
    glm::vec4 lightPos = glm::vec4(0, 0, .5 , 0);
    float lightRadius = 7;


    // update-render loop
    while (!window.shouldClose())
    {
        time.time();
        window.tick();
        window.clear();
        time.systemTime();
        

        //update
        time.deltaTime();

        if (time.deltaTime() >= 10) {
            time.resetTime();
        }

        triModel = glm::rotate(triModel, 0.01f, glm::vec3(0, 1, 0));
        tri_trans.localRot = glm::angleAxis((float)glfwGetTime(), glm::vec3(1, 0, 0));


        //draw
        //shader
        setUniform(stdShad, 0, camProj);//proj at index 0(projection mat)
        setUniform(stdShad, 1, camView);//view at index 1(view mat)
        //setUniform(stdShad, 2, triModel);//modl at index 2(model mat)
        setUniform(stdShad, 2, tri_trans.localMat());// model mat

        //uv
        setUniform(stdShad, 3, checker, 0); //albedo(main color)
        setUniform(stdShad, 4, ambient); //ambient light
        setUniform(stdShad, 5, sunlight);//directional light
        setUniform(stdShad, 6, lightColor);//light color
        
        //point light
        setUniform(stdShad, 7, lightPos);//point light position
        setUniform(stdShad, 8, lightRadius);//point light radius

        //draw Rectangle
        //draw(multiColorShad, basicRectangleGeo);
        
        //draw triangle
        draw(stdShad, basicTriangleGeo);

        draw(stdShad, basicCubeGeo);
        


    }
    window.term();

	return 0;
}