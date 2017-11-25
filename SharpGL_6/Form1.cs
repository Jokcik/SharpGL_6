using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;
using KB_LAB_5.Classes;
using ObjLoader.Loader.Loaders;
using SharpGL;

namespace SharpGL_6
{
    public partial class Form1 : Form
    {
        private List<Polygon> _polygons = new List<Polygon>();

        public Form1()
        {
            InitializeComponent();
            
        }

        private float _angleX;
        private float _angleY;
        private int z = 0;
        private Point _currentLocation = new Point(0, 0);
    
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _angleY += (e.Location.X - _currentLocation.X) / 1.0f;
            _angleX += (e.Location.Y - _currentLocation.Y) / 1.0f;
            _currentLocation = e.Location;
            Invalidate();
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _currentLocation = e.Location;
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {     
            var gl = openGLControl1.OpenGL;
            
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            gl.Translate(0f, 0f, -10f);
            gl.Scale(0.1, 0.1, 0.1);
            gl.LookAt(0, 0, z, 0, 0, z + 10, 0 , 1, 0);
            gl.Rotate(_angleX, 1f, 0f, 0f);
            gl.Rotate(_angleY, 0f, 1f, 0f);
            
            
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
            
            gl.Flush();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            z += e.Delta > 0 ? 1 : -1;
            base.OnMouseWheel(e);
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
    }
}
