#include "render.h"

#include <fstream>
#include <iostream>
#include <string> //string

#define STB_IMAGE_IMPLEMENTATION 1
#include "stb/stb_image.h"
#include <glm\ext.hpp> //value_ptr

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

        //skip by 16 bytes

        //color
        glEnableVertexAttribArray(1);
        glVertexAttribPointer(1, 4, GL_FLOAT, GL_FALSE, sizeof(vertex), (void*)16);//need to skip by 16 to come after position

        //skip by 16 bytes

        //uv
        glEnableVertexAttribArray(2);
        glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(vertex), (void*)32);

        //skip by 8 bytes

        //normal
        glEnableVertexAttribArray(3);
        glVertexAttribPointer(3, 3, GL_FLOAT, GL_FALSE, sizeof(vertex), (void*)40);

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
        GLint vertCompiled;
        glGetShaderiv(vert, GL_COMPILE_STATUS, &vertCompiled);
        if (vertCompiled != true) {
            GLsizei log_length = 0;
            GLchar message[1024];
            glGetShaderInfoLog(vert, 1024, &log_length, message);
            std::cout << message << std::endl;
        }

        glCompileShader(frag);
        GLint fragCompiled;
        glGetShaderiv(frag, GL_COMPILE_STATUS, &fragCompiled);
        if (fragCompiled != true) {
            GLsizei log_length = 0;
            GLchar message[1024];
            glGetShaderInfoLog(frag, 1024, &log_length, message);
            std::cout << message << std::endl;
        }


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

	shader loadShader(const char* vertPath, const char* fragPath)
	{
        std::ifstream file; 
        std::string buffer;

        //load shaders into string
        std::string vertContents;
        file.open(vertPath);
        if (file.is_open()) {
            while (std::getline(file, buffer)) {
                vertContents += buffer + "\n";
            }
        }
        file.close();

        std::string fragContents;
        file.open(fragPath);
        if (file.is_open()) {
            while (std::getline(file, buffer)) {
                fragContents += buffer + "\n";
            }
        }
        file.close();
        //call makeshader and pass those stringd(as cstrings)

		return makeShader(vertContents.c_str(), fragContents.c_str());
	}

    void freeShader(shader& shad)
    {
        glDeleteShader(shad.program);
        shad = {};
    }

    texture loadTexture(const char* imagePath)
    {
        int imageWidth, imageHeight, imageFormat;
        unsigned char* rawPixelData = nullptr;


        stbi_set_flip_vertically_on_load(true);
        rawPixelData = stbi_load(imagePath,
            &imageWidth,
            &imageHeight,
            &imageFormat,
            STBI_default);//color data type

        texture tex = makeTexture(imageWidth, imageHeight, imageFormat, rawPixelData);
        stbi_image_free(rawPixelData);

        return tex;
    }

    texture makeTexture(unsigned width, unsigned height, unsigned channels, const unsigned char* pixels)
    {
        texture tex = { 0, width, height, channels };

        GLenum oglFormat = GL_RED;// worst case scenario
        switch (channels) {
        case 1:
            oglFormat = GL_RED;
            break;
        case 2:
            oglFormat = GL_RG;
            break;
        case 3:
            oglFormat = GL_RGB;
            break;
        case 4:
            oglFormat = GL_RGBA;
            break;
        }

        glGenTextures(1, &tex.handle);
        glBindTexture(GL_TEXTURE_2D, tex.handle);

        glTexImage2D(GL_TEXTURE_2D,     // texture type(what texture)
            0,//mipmap level is 0(0 is original quality)
            oglFormat,         // color format
            width,             // width
            height,            // height
            0,//border
            oglFormat,         // color format
            GL_UNSIGNED_BYTE,  // type of data
            pixels);           // pointer to data

        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

        glBindTexture(GL_TEXTURE_2D, 0);

        return tex;
    }

    void freeTexture(texture& tex)
    {
        glDeleteTextures(1, &tex.handle);
        tex = {};
    }

    void setUniform(const shader& shad, GLuint location, const glm::mat4& value)
    {
        glProgramUniformMatrix4fv(shad.program, location, 1, GL_FALSE, &value[0][0]);
    }

    void setUniform(const shader& shad, GLuint location, const texture& value, int textureSlot)
    {
        // specify the texture slot we are working with(setting up slot)
        glActiveTexture(GL_TEXTURE0 + textureSlot);
        // bind the texture to that slot
        glBindTexture(GL_TEXTURE_2D, value.handle);

        // assign that texture (slot) to the shader
        glProgramUniform1i(shad.program, location, textureSlot);
    }

    void setUniform(const shader& shad, GLuint location, const glm::vec3& value)
    {
        glProgramUniform3fv(shad.program, location, 1, glm::value_ptr(value));
    }

    void setUniform(const shader& shad, GLuint location,const float& value)
    {
        glProgramUniform1fv(shad.program, location, 1, &value);
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