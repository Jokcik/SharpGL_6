using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace KB_LAB_5.Classes
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