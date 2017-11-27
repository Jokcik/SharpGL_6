using System;
using System.Collections.Generic;
using SharpGL;

namespace SharpGL_6.figures
{
    public class FigureHummer
    {
        private readonly List<Polygon> _polygons;

        public FigureHummer()
        {
            _polygons = LoadPrimitive.Load("C:\\Users\\User\\RiderProjects\\SharpGL_6\\SharpGL_6\\obj_files\\Hammer.obj");
        }
        
        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float scale, float z, 
            bool isLine, bool isFill, bool isRotate)
        {
            scale = 0.03f * scale;

            gl.Translate(ta, ty, tz);
            gl.Scale(scale, scale, scale);
            gl.LookAt(0, 0, z, 0, 0, z + 10, 0 , 1, 0);
            if (isRotate)
            {
                gl.Rotate(angleX, 1f, 0f, 0f);
                gl.Rotate(angleY, 0f, 1f, 0f);
            }
            if (isFill || !isLine)
            {
                foreach (var polygon in _polygons)
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(polygon.color.R, polygon.color.G, polygon.color.B);
                    foreach (var points in polygon.list)
                    {
                        gl.Vertex(points.Item1, points.Item2, points.Item3);
                    }

                    gl.End();
                }
            }

            if (!isLine) return;
            foreach (var polygon in _polygons)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Color(0, 0, 0);
                foreach (var points in polygon.list)
                {
                    gl.Vertex(points.Item1, points.Item2, points.Item3);
                }

                gl.End();
            }
        }
    }
}