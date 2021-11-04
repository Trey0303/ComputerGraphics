#include "context.h"

#include <iostream>

#include "glew//glew.h" //GLEW must be included first before GLFW
#include "glfw/glfw3.h"

namespace aie {
    // Error callback called by OpenGL whenever a problem occurs (vendor-dependent)
    void APIENTRY errorCallback(GLenum source, GLenum type, GLuint id, GLenum severity,
        GLsizei length, const GLchar* message,
        const void* userParam)
    {
        std::cerr << message << std::endl;
    }

    bool aie::context::init(int width, int height, const char* title)
    {
        // init glfw
        glfwInit();


        // create window
        window = glfwCreateWindow(640, 480, "Hello Window", nullptr, nullptr);

        // designate specified window as rendering context
        glfwMakeContextCurrent(window);

        // init glew
        GLenum err = glewInit();
        if (GLEW_OK != err)
        {
            std::cerr << "Error: " << glewGetErrorString(err) << std::endl;
            return -1;
        }

        // print out some diagnostics
        std::cout << "OpenGL Version: " << (const char*)glGetString(GL_VERSION) << "\n";
        std::cout << "Renderer: " << (const char*)glGetString(GL_RENDERER) << "\n";
        std::cout << "Vendor: " << (const char*)glGetString(GL_VENDOR) << "\n";
        std::cout << "GLSL: " << (const char*)glGetString(GL_SHADING_LANGUAGE_VERSION) << "\n";

#ifdef _DEBUG
        glEnable(GL_DEBUG_OUTPUT);
        glEnable(GL_DEBUG_OUTPUT_SYNCHRONOUS);

        glDebugMessageCallback(errorCallback, 0);
        glDebugMessageControl(GL_DONT_CARE, GL_DONT_CARE, GL_DONT_CARE, 0, 0, true);
#endif

        // set up some defaults
        glEnable(GL_BLEND);       // enable blending
        glEnable(GL_DEPTH_TEST);  // enable depth testing
        glEnable(GL_CULL_FACE);   // enable backface culling

        glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);  // set blending function
        glDepthFunc(GL_LEQUAL);                             // depth test function
        glFrontFace(GL_CCW);                                // set front face winding order
        glCullFace(GL_BACK);                                // cull backfaces

        glClearColor(0.25f, 0.25f, 0.25f, 1);               // color to clear the screen to

        return true;
    }

    void aie::context::tick()
    {
        glfwSwapBuffers(window);  // swap framebuffer
        glfwPollEvents();         // work through event queue
    }

    void aie::context::clear()
    {
        //draw
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    }

    void aie::context::term()
    {
        // destroy the window
        glfwDestroyWindow(window);

        // clean up GLFW
        glfwTerminate();
    }

    bool aie::context::shouldClose() const
    {
        //close window
        return glfwWindowShouldClose(window);
    }

    
}


