using System;
using System.Collections.Generic;
using System.Drawing;

namespace SharpGL_6
{
    public class Polygon
    {
        public Color color;
        public readonly List<Tuple<float, float, float>> list = new List<Tuple<float, float, float>>();

        public Polygon(Color color)
        {
            this.color = color;
        }

        public void AddPoint(Tuple<float, float, float> point)
        {
            list.Add(point);
        }
        
        public void AddPoint(float x, float y, float z)
        {
            AddPoint(new Tuple<float, float, float>(x, y, z));
        }
        
    }
}