#include "render.h"

namespace aie
{
    geometry makeGeometry(const vertex* verts, GLsizei vertCount, const GLuint* indicies, GLsizei indxCount)
    {

        // create an instance of geometry
        geometry newGeo = {};
        newGeo.size = indxCount;

        //creating buffers to store data
        // generate buffers
        glGenVertexArrays(1, &newGeo.vao);//VAO, Vertex Array Object
        glGenBuffers(1, &newGeo.vbo);//VBO, Vertex Buffer Object
        glGenBuffers(1, &newGeo.ibo);//IBO, Index Buffer Object

        //bind those buffers together
        glBindVertexArray(newGeo.vao);
        glBindBuffer(GL_ARRAY_BUFFER, newGeo.vbo);
        glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, newGeo.ibo);

        //buffer the data(aka upload to the GPU)
        glBufferData(GL_ARRAY_BUFFER, vertCount * sizeof(vertex), verts, GL_STATIC_DRAW);
        glBufferData(GL_ELEMENT_ARRAY_BUFFER, indxCount * sizeof(GLsizei), indicies, GL_STATIC_DRAW);

        //describe the data
        //a float = 4 bytes
        //a vec4 = 16 bytes(vec4 has 4 floats which has 4 bytes in each float making it 16)


        //position
        glEnableVertexAttribArray(0);
        glVertexAttribPointer(0, 4, GL_FLOAT, GL_FALSE, sizeof(vertex), (void*)0);//need to skip by 0 because its the first field in struct vertex

        //color
        glEnableVertexAttribArray(1);
        glVertexAttribPointer(1, 4, GL_FLOAT, GL_FALSE, sizeof(vertex), (void*)16);//need to skip by 16 to come after position

        //unbind buffers when done
        glBindVertexArray(0);
        glBindBuffer(GL_ARRAY_BUFFER, 0);
        glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);

        //return the object
        return newGeo;
    }

    void freeGeometry(geometry& geo)
    {
        glDeleteBuffers(1, &geo.vbo);
        glDeleteBuffers(1, &geo.ibo);
        glDeleteVertexArrays(1, &geo.vao);

        geo = {}; // clear out the geo - to prevent use after free

    }
    shader makeShader(const char* vertSource, const char* fragSource)
    {
        // make the shader object
        shader newShad = {};

        // create the shader program
        newShad.program = glCreateProgram();

        // create shaders
        GLuint vert = glCreateShader(GL_VERTEX_SHADER);
        GLuint frag = glCreateShader(GL_FRAGMENT_SHADER);

        //load the source code and compile it
        glShaderSource(vert, 1, &vertSource, 0);
        glShaderSource(frag, 1, &fragSource, 0);
        // compile shaders
        glCompileShader(vert);
        glCompileShader(frag);

        //attach the shaders to the shader program
        glAttachShader(newShad.program, vert);
        glAttachShader(newShad.program, frag);

        //link the program
        glLinkProgram(newShad.program);

        //delete the shaders(NOT the shader program)
        glDeleteShader(vert);
        glDeleteShader(frag);

        //return the shader object
        return newShad;
    }

    void freeShader(shader& shad)
    {
        glDeleteShader(shad.program);
        shad = {};
    }

    void draw(const shader& shad, const geometry& geo)
    {
        // bind the shader program
        glUseProgram(shad.program);
        // bind the VAO
        glBindVertexArray(geo.vao);

        // draw the object
        glDrawElements(GL_TRIANGLES, geo.size, GL_UNSIGNED_INT, nullptr);
    }
}