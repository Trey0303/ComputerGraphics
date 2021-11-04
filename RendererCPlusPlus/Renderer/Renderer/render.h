#pragma once
// render.h
#pragma once

#include "glew/glew.h"
#include "glm/glm.hpp" // include this for glm::vec4


/*Let's create a vertex structure that will be used to store information about each vertex in our meshes. Our program will only have one vertex format to keep things simplified for our pipeline.

When we load or create meshes, we'll create arrays of vertices to store all of that information. If we need to add more information like vertex normals or vertex colors, we'll add to that structure.*/
namespace aie
{
    /*In this header, you'll want to create a new structure called vertex which will have one field: a 4D vector for its position.*/
    struct vertex
    {
        glm::vec4 pos;
        glm::vec4 color;
    };

    /*We'll create a different object called geometry to represent our meshes.*/
    struct geometry
    {
        /*The VAO, VBO, and IBO, are GLuint objects whose values are numbers referring to objects created by OpenGL on the GPU.*/
        GLuint vao,//VAO, Vertex Array Object - a collection of related buffer objects
               vbo,//VBO, Vertex Buffer Object - a buffer containing vertex information
               ibo;//IBO, Index Buffer Object - a buffer containing indices that form mesh primitive
               // ogl buffer names
        GLuint size;            // ogl index count
    };

    struct shader
    {
        GLuint program;         // ogl program names
    };

    geometry makeGeometry(const vertex* const verts, GLsizei vertCount,
                          const GLuint* const indicies, GLsizei indxCount);
    void freeGeometry(geometry& geo);

    shader makeShader(const char* vertSource, const char* fragSource);

    void freeShader(shader& shad);

    void draw(const shader& shad, const geometry& geo);
}