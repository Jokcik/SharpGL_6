using SharpGL;

namespace SharpGL_6.figures
{
    public class FigureTriangle
    {
        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float scale, float z, 
            bool isLine, bool isFill, bool isRotate)
        {
            scale = 0.5f * scale;
            
            gl.Translate(ta, ty, tz);
            gl.LookAt(0, 0, z, 0, 0, z + 10, 0 , 1, 0);
            gl.Scale(scale, scale, scale);
            if (isRotate)
            {
                gl.Rotate(angleX, 1f, 0f, 0f);
                gl.Rotate(angleY, 0f, 1f, 0f);
            }
            if (isFill || !isLine)
            {
                gl.Begin(OpenGL.GL_TRIANGLES);

                gl.Color(1f, 0, 0);
                gl.Vertex(0.0f, 1.0f, 0f);
                gl.Color(0, 1f, 0);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Color(0, 0, 1f);
                gl.Vertex(1.0f, -1.0f, 1.0f);

                gl.Color(1f, 0, 0);
                gl.Vertex(0.0f, 1.0f, 0f);
                gl.Color(0, 0, 1f);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Color(0, 1f, 0);
                gl.Vertex(1.0f, -1.0f, -1.0f);

                gl.Color(1f, 0, 0);
                gl.Vertex(0.0f, 1.0f, 0f);
                gl.Color(0, 1f, 0);
                gl.Vertex(1.0f, -1.0f, -1.0f);
                gl.Color(0, 0, 1f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);

                gl.Color(1f, 0, 0);
                gl.Vertex(0.0f, 1.0f, 0f);
                gl.Color(0, 1f, 0);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Color(0, 1f, 1f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);

                gl.End();

                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(1f, 0, 0);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Color(0, 1f, 0);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Color(0, 1f, 1f);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Color(0, 1f, 1f);
                gl.Vertex(1.0f, -1.0f, -1.0f);
                gl.End();
            }
            
            if (!isLine) return;
            
            gl.Begin(OpenGL.GL_LINE_STRIP);

            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Vertex(0.0f, 1.0f, 0f);
            
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(0.0f, 1.0f, 0f);
            
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            

            gl.End();
            
        }
    }
}