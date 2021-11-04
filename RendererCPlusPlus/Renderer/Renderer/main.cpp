#include "context.h"

#include "render.h"

using namespace aie;


int main() {
    context window;
    window.init(640, 480, "Hello Window");

    //create a triangle
    vertex triVerts[] = {
        {//vertex 0 - bottom left
            {-.5f,-.5f,0,1},//vertex 0 position
            {1, 0, 0, 1}//color
        },
        {//vertex 1 - bottom right
            {.5f,-.5f,0,1},//vertex 1 position
            {0, 0, 1, 1}//color
        },
        {//vertex 2 - top middle
            {0.0f,.5f,0,1},//vertex 2 position
            {0, 1, 0, 1}//color
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




    // update-render loop
    while (!window.shouldClose())
    {
        window.tick();
        //update

        //draw
        window.clear();

        //draw triangle
        //draw(multiColorShad, basicTriangleGeo);

        //draw Rectangle
        draw(multiColorShad, basicRectangleGeo);

    }
    window.term();

	return 0;
}