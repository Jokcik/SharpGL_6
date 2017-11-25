using System.Collections.Generic;
using System.Drawing;
using KB_LAB_5.Classes;
using SharpGL;

namespace SharpGL_6.figures
{
    public class FigureParallelepiped
    {
        private float a = 1, b = 1, c = 1;

        public FigureParallelepiped(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public FigureParallelepiped()
        {
        }

        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float z, 
            bool isLine, bool isFill)
        {
            gl.LoadIdentity();

            gl.Translate(ta, ty, tz);
            gl.Rotate(angleX, 1f, 0f, 0f);
            gl.Rotate(angleY, 0f, 1f, 0f);

            if (isFill || !isLine)
            {
                gl.Begin(OpenGL.GL_QUAD_STRIP);
                gl.Color(1f, 1f, 0f);
                gl.Vertex(-a / 2, -b / 2, -c / 2);
                gl.Vertex(-a / 2, -b / 2, c / 2);
                gl.Vertex(-a / 2, b / 2, -c / 2);
                gl.Vertex(-a / 2, b / 2, c / 2);

                gl.Color(1f, 0.5f, 0f);
                gl.Vertex(a / 2, b / 2, -c / 2);
                gl.Vertex(a / 2, b / 2, c / 2);

                gl.Color(0f, 0.5f, 0f);
                gl.Vertex(a / 2, -b / 2, -c / 2);
                gl.Vertex(a / 2, -b / 2, c / 2);

                gl.Color(0f, 0.5f, 1f);
                gl.Vertex(-a / 2, -b / 2, -c / 2);
                gl.Vertex(-a / 2, -b / 2, c / 2);
                gl.End();

                gl.Begin(OpenGL.GL_QUADS);

                gl.Color(1f, 0f, 1f);
                gl.Vertex(-a / 2, -b / 2, c / 2);
                gl.Vertex(-a / 2, b / 2, c / 2);
                gl.Vertex(a / 2, b / 2, c / 2);
                gl.Vertex(a / 2, -b / 2, c / 2);

                gl.Color(0.8f, 0.2f, 0.4f);
                gl.Vertex(-a / 2, -b / 2, -c / 2);
                gl.Vertex(-a / 2, b / 2, -c / 2);
                gl.Vertex(a / 2, b / 2, -c / 2);
                gl.Vertex(a / 2, -b / 2, -c / 2);
                gl.End();
            }

            if (!isLine) return;
            
            gl.Begin(OpenGL.GL_LINE_STRIP);
            
            gl.Vertex(-a/2, -b/2, -c/2);
            
            gl.Vertex(a/2, -b/2, -c/2);
            gl.Vertex(a/2, b/2, -c/2);
            gl.Vertex(-a/2, b/2, -c/2);
            gl.Vertex(-a/2, -b/2, -c/2);
            
            gl.Vertex(-a/2,-b/2, c/2);
            gl.Vertex(a/2,-b/2, c/2);
            gl.Vertex(a/2,-b/2, -c/2);
            gl.Vertex(-a/2,-b/2, -c/2);
            
            gl.Vertex(-a/2,b/2,-c/2);
            gl.Vertex(-a/2,b/2,c/2);
            gl.Vertex(-a/2,-b/2,c/2);
            gl.Vertex(-a/2,-b/2,-c/2);
            
            gl.Vertex(-a/2,-b/2, c/2);
            gl.Vertex(-a/2,b/2, c/2);
            gl.Vertex(a/2,b/2, c/2);
            gl.Vertex(a/2, -b/2, c/2);
            gl.Vertex(-a/2, -b/2, c/2);
            gl.Vertex(a/2, -b/2, c/2);
            gl.Vertex(a/2, b/2, c/2);
            gl.Vertex(a/2, b/2, -c/2);
            
            gl.End();
            
        }
    }
}