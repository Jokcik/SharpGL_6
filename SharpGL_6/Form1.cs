using System.Drawing;
using System.Windows.Forms;
using SharpGL;
using SharpGL_6.figures;

namespace SharpGL_6
{   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private readonly FigureHummer _figureHummer = new FigureHummer();
        private readonly FigureToilet _figureToilet = new FigureToilet();
        private readonly FigureParallelepiped _figureToileKub = new FigureParallelepiped();
        private readonly FigureParallelepiped _figureToileParallelepiped = new FigureParallelepiped(2, 0.5f, 1);
        private readonly FigureTriangle _figureTriangle = new FigureTriangle();
        
        private float _angleX;
        private float _angleY;
        private int z;
        private Point _currentLocation = new Point(0, 0);
    
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {     
            var gl = openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(1f, 1f, 1f, 1f);
    
            _figureToilet.Draw(gl, 15f, 0f, -25f, _angleX, _angleY, z);
            _figureHummer.Draw(gl, -5f, 0.5f, -10f, _angleX, _angleY, z);
            _figureToileKub.Draw(gl, -1.3f, -1.3f, -6f, _angleX, _angleY, z);
            _figureToileParallelepiped.Draw(gl, 1.2f, -1.3f, -6f, _angleX, _angleY, z);
            _figureTriangle.Draw(gl, 0f, 1.3f, -6f, _angleX, _angleY, z);
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
    }
}
