using System.Collections.Generic;
using System.Drawing;
using System.IO;
using KB_LAB_5.Classes;
using ObjLoader.Loader.Loaders;

namespace SharpGL_6.figures
{
    public static class LoadPrimitive
    {        
        public static List<Polygon> Load(string path)
        {
            var polygons = new List<Polygon>();
            
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(path, FileMode.Open);
            var loadedObj = objLoader.Load(fileStream);

            var colors = new[]
            {
                Color.FromArgb(255, 255, 128, 64),
                Color.FromArgb(255, 5, 128, 0),
                Color.FromArgb(255, 255, 0, 64),
                Color.FromArgb(255, 200, 0, 160),
                Color.FromArgb(255, 60, 0, 64),
                Color.FromArgb(255, 0, 128, 255),
                Color.FromArgb(255, 100, 100, 100),
                Color.FromArgb(255, 100, 100, 100)
            };
            var k = 0;
            foreach (var g in loadedObj.Groups)
            {
                var color = colors[k++];
                foreach (var f in g.Faces)
                {
                    var p = new Polygon(color);
                    for (var i = 0; i < f.Count; i++)
                    {
                        p.AddPoint(
                            loadedObj.Vertices[f[i].VertexIndex - 1].X,
                            loadedObj.Vertices[f[i].VertexIndex - 1].Y,
                            loadedObj.Vertices[f[i].VertexIndex - 1].Z
                        );
                    }

                    polygons.Add(p);
                }
            }

            fileStream.Close();
            return polygons;
        }
    }
}