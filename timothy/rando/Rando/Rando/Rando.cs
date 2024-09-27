using Aspose.Gis;
using Aspose.Gis.Formats.Gpx;
using Aspose.Gis.Geometries;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Rando
{
    public partial class Rando : Form
    {
        private List<Pt> points;

        public Rando()
        {
            InitializeComponent();
            points = new List<Pt>();
            csrLaiktur();
            labelo.Text = CalculeDistance().ToString();
        }

        private void csrLaiktur()
        {
            using (var layer = Drivers.Gpx.OpenLayer("../../../../../gpx/Chemin_des_planètes_3_4.gpx"))
            {
               
                foreach (var feature in layer)
                {
                    if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
                    {
                        var lines = (MultiLineString)feature.Geometry;
                        for (int i = 0; i < lines.Count; i++)
                        {
                            var segment = (LineString)lines[i];

                            for (int j = 0; j < segment.Count; j++)
                            {
                                float point = segment[j]
                                points.Add(new Pt(point.X, point.Y, point.Z));
                            }

                            double y = pt.Aggregate(new pt(), (p, next) =>
                            {
                                return new Points()
                                {
                                    _x = next._x,
                                    _y = next._y,
                                    _z = next._z,
                                    _distance = Math.Sqrt(Math.Pow((next._x - p._x), 2) + Math.Pow((next._y - p._y), 2) + Math.Pow((next._z - p._z), 2)) + p._distance
                                };
                            }, p => p._distance);
                            MessageBox.Show((y * 3.78103356).ToString());
                        }
                    }
                }

            }
        }

        private float CalculeDistance()
        {
            float distance = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                distance += (float)Math.Sqrt(Math.Pow(points[i].X - points[i + 1].X, 2) + Math.Pow(points[i].Y - points[i + 1].Y, 2) + Math.Pow(points[i].Z - points[i + 1].Z, 2));
            }
            return distance;
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            using (var layer = Drivers.Gpx.OpenLayer("../../../../../gpx/Chemin_des_planètes_3_4.gpx"))
            {
                foreach (var feature in layer)
                {
                    if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
                    {
                        var lines = (MultiLineString)feature.Geometry;
                        using (var pen = new Pen(Color.Red))
                        {
                            pen.Width = 2;
                            foreach (var segment in lines)
                            {
                                e.Graphics.DrawLines(pen, points.Select(p => new PointF((float)p.X, (float)p.Y)).ToArray());
                            }
                        }
                    }
                }
            }
        }
    }

    public class Pt
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public Pt(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}