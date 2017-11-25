using System.Collections.Generic;
using KB_LAB_5.Classes;
using SharpGL;

namespace SharpGL_6.figures
{
    public class FigureHummer
    {
        private readonly List<Polygon> _polygons;

        public FigureHummer()
        {
            _polygons = LoadPrimitive.Load(
                "G:\\универ\\4 курс\\компьютерная графика\\Kompyuteraya_grafika\\Компьютерая графика\\obj файлы\\Hammer.obj");
        }
        
        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float z)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            gl.Translate(0f, 0f, -10f);
            gl.Scale(0.1, 0.1, 0.1);
            gl.LookAt(0, 0, z, 0, 0, z + 10, 0 , 1, 0);
            gl.Rotate(angleX, 1f, 0f, 0f);
            gl.Rotate(angleY, 0f, 1f, 0f);
            
            
            gl.Begin(OpenGL.GL_QUADS);
            foreach (var polygon in _polygons)
            {
                gl.Color(polygon.color.R, polygon.color.G, polygon.color.B);
                foreach (var points in polygon.list)
                {
                    gl.Vertex(points.Item1, points.Item2, points.Item3);
                }
            }
            gl.End();
        }
    }
}