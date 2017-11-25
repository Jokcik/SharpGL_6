using SharpGL;

namespace SharpGL_6.figures
{
    public class FigureTriangle
    {
        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float z)
        {
            gl.LoadIdentity();

            gl.Translate(ta, ty, tz);
            gl.Rotate(angleX, 1f, 0f, 0f);
            gl.Rotate(angleY, 0f, 1f, 0f);

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1f,0,0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0,1f,0);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0,0,1f);
            gl.Vertex(1.0f, -1.0f, 1.0f);

            gl.Color(1f,0,0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0,0,1f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0,1f,0);
            gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.Color(1f,0,0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0,1f,0);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0,0,1f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);

            gl.Color(1f,0,0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0,1f,0);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0,1f,1f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            
            gl.End();
            
            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(1f,0,0);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0,1f,0);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0,1f,1f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0,1f,1f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.End();
        }
    }
}