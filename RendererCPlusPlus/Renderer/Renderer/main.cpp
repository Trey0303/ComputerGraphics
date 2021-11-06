#include "context.h"

#include "render.h"

#include "time.h"

#include "glm/ext.hpp"
#include <iostream>

using namespace aie;


int main() {
    context window;
    window.init(640, 480, "Hello Window");

    timer time;

    //create a triangle
    vertex triVerts[] = {
        {//vertex 0 - bottom left
            {-.5f,-.5f,0,1},//vertex 0 position
            {1, 0, 0, 1},//color
            {0.0f,0.0f}//uv
        },
        {//vertex 1 - bottom right
            {.5f,-.5f,0,1},//vertex 1 position
            {0, 0, 1, 1},//color
            {1.0f,0.0f}//uv
        },
        {//vertex 2 - top middle
            {0.0f,.5f,0,1},//vertex 2 position
            {0, 1, 0, 1},//color
            {0.5f,1.0f}//uv
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
    vertex RecVerts[] = {
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

    geometry basicRectangleGeo = makeGeometry(RecVerts, 4, recIndices, 6);
   
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
    shader stbShad = loadShader("res\\basic.vert", "res\\basic.frag");

    //loading textures
    texture checker = loadTexture("res\\uvchecker.jpg");
    

    glm::mat4 triModel = glm::identity<glm::mat4>(); // #include "glm/ext.hpp"
    glm::mat4 camView = glm::lookAt(glm::vec3(0, 1, 5), //eye
                                    glm::vec3(0, 0, 0), //look at
                                    glm::vec3(0, 1, 0));//up
    glm::mat4 camProj = glm::perspective(glm::radians(45.0f), // vertical fov
                                        640.0f / 480.0f,    // aspect ratio
                                        0.1f,               // near-plane
                                        1000.0f);           // far-plane

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

        triModel = glm::rotate(triModel, 0.5f, glm::vec3(0, 1, 0));


        //draw
        //shader
        setUniform(stbShad, 0, camProj);// proj at index 0
        setUniform(stbShad, 1, camView);// view at index 1
        setUniform(stbShad, 2, triModel);// modl at index 2

        //uv
        setUniform(stbShad, 3, checker, 0);
        
        //draw triangle
        draw(stbShad, basicTriangleGeo);
        
        //draw Rectangle
        //draw(multiColorShad, basicRectangleGeo);


    }
    window.term();

	return 0;
}