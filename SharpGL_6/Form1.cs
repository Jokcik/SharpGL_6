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
        
        private float _angleX;
        private float _angleY;
        private int z;
        private Point _currentLocation = new Point(0, 0);
    
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {     
            var gl = openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
    
            _figureToilet.Draw(gl, 5f, 0, -25f, _angleX, _angleY, z);
            _figureHummer.Draw(gl, -5f, 0, -10f, _angleX, _angleY, z);

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
