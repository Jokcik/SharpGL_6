using System.Drawing;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL_6.figures;

namespace SharpGL_6
{   
    public partial class Form1 : Form
    {
        private bool lines = false;
        private bool fill = false;
        
        
        public Form1()
        {
            InitializeComponent();
            checkBoxLines.CheckedChanged += (sender, args) => lines = !lines;
            checkBoxFill.CheckedChanged += (sender, args) => fill = !fill;
        }
        
        private readonly FigureHummer _figureHummer = new FigureHummer();
        private readonly FigureToilet _figureToilet = new FigureToilet();
        private readonly FigureParallelepiped _figureKub = new FigureParallelepiped();
        private readonly FigureParallelepiped _figureParallelepiped = new FigureParallelepiped(2, 0.5f, 1);
        private readonly FigureTriangle _figureTriangle = new FigureTriangle();

        private float _mainAngle;
        
        private float _angleX;
        private float _angleY;

        private float _angle1;
        private float _angle2;
        private float _angle3;
        private float _angle4;
        private float _angle5;
        
        private float _scale1 = 1;
        private float _scale2 = 1;
        private float _scale3 = 1;
        private float _scale4 = 1;
        private float _scale5 = 1;
        
        private int z;
        private Point _currentLocation = new Point(0, 0);
        
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {     
            var gl = openGLControl1.OpenGL;
            
            gl.Enable(OpenGL.GL_BLEND);           // Разрешить прозрачность.
            gl.Enable(OpenGL.GL_POINT_SMOOTH);   // Разрешить сглаживание точек.
            gl.Enable(OpenGL.GL_COLOR_MATERIAL); // Отключить перелевание цвета.
            gl.PointSize(16);             // Размер точки.
            gl.LineWidth(2);              // Толщина линий.
            
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(1f, 1f, 1f, 1f);
            
            FormatOpenGL(gl);
            _figureToilet.Draw(gl, 8f, 0f, -25f, _angle1, _angle1, _scale1, z, lines, fill, true);
            FormatOpenGL(gl);
            _figureHummer.Draw(gl, -3f, 0.5f, -10f, _angle2, _angle2, _scale2, z, lines, fill, true);
            FormatOpenGL(gl);
            _figureKub.Draw(gl, -1.3f, -1.8f, -6f, _angle3, _angle3, _scale3, z, lines, fill, true);
            FormatOpenGL(gl);
            _figureParallelepiped.Draw(gl, 1.2f, -1.8f, -6f, _angle4, _angle4, _scale4, z, lines, fill, true);
            FormatOpenGL(gl);
            _figureTriangle.Draw(gl, 0f, 1.8f, -6f, _angle5, _angle5, _scale5, z, lines, fill, true);
        }

        private void FormatOpenGL(OpenGL gl)
        {
            gl.LoadIdentity();
            gl.Rotate(_mainAngle, 0, 0, 1);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            z += e.Delta > 0 ? 1 : -1;
            base.OnMouseWheel(e);
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _angleY += (e.Location.X - _currentLocation.X) / 1.0f;
            _angleX += (e.Location.Y - _currentLocation.Y) / 1.0f;
            _currentLocation = e.Location;
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _currentLocation = e.Location;
        }


        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    _mainAngle += 1;
                    break;
                case Keys.A:
                    _mainAngle -= 1;
                    break;
                    
                case Keys.Q:
                    _angle1 += e.Shift ? -1 : 1;
                    if (e.Alt)
                        _scale1 += e.Shift ? -0.1f : 0.1f;
                    break;
                case Keys.W:
                    _angle2 += e.Shift ? -1 : 1;
                    if (e.Alt)
                        _scale2 += e.Shift ? -0.1f : 0.1f;
                    break;
                case Keys.E:
                    _angle3 += e.Shift ? -1 : 1;
                    if (e.Alt)
                        _scale3 += e.Shift ? -0.1f : 0.1f;
                    break;
                case Keys.R:
                    _angle4 += e.Shift ? -1 : 1;
                    if (e.Alt)
                        _scale4 += e.Shift ? -0.1f : 0.1f;
                    break;
                case Keys.T:
                    _angle5 += e.Shift ? -1 : 1;
                    if (e.Alt)
                        _scale5 += e.Shift ? -0.1f : 0.1f;
                    break;
            }
        }

    }
}
