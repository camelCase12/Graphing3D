using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using Graphing3D._3DBehaviors.Backend;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Graphing3D._3DBehaviors.Frontend
{
    public static class CRender
    {
        public static MainWindow mainWindowReference;
        public static Canvas myCanvas = new Canvas();
        public static DrawingVisual drawingVisual = new DrawingVisual();//new
        public static DrawingContext drawingContext;
        public static void init()
        {
            mainWindowReference.Content = myCanvas;
        }
        public static void clear()
        {
            myCanvas.Children.Clear();
            drawingVisual = new DrawingVisual();
            drawingContext = drawingVisual.RenderOpen();
        }
        public static void addLine(double x1, double y1, double x2, double y2, Color color)
        {
            drawingContext.DrawLine(new Pen(new SolidColorBrush(color), 1), new Point(x1, y1), new Point(x2, y2));

            //Line newLine = new Line();
            //newLine.X1 = x1; newLine.Y1 = y1; newLine.X2 = x2; newLine.Y2 = y2;
            //newLine.StrokeThickness = 1;
            //newLine.Stroke = new SolidColorBrush(color);
            //myCanvas.Children.Add(newLine); //old
        }
        public static void addTriangle(double x1, double y1, double x2, double y2, double x3, double y3, Color color)
        {
            //Polygon newTriangle = new Polygon();
            //newTriangle.Points = new PointCollection() { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            //newTriangle.Stroke = new SolidColorBrush(color);
            //newTriangle.StrokeThickness = 1;
            //myCanvas.Children.Add(newTriangle);

        }
        public static void addVertex(double x1, double y1, Color color)
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Stroke = new SolidColorBrush(color);
            newEllipse.Width = 3;
            newEllipse.Height = 3;
            double left = x1 - (3.0 / 2.0);
            double top = y1 - (3.0 / 2.0);
            newEllipse.Margin = new Thickness(left, top, 0, 0);
            myCanvas.Children.Add(newEllipse);
        }
        public static void drawFrame(object sender, EventArgs e)
        {
            
            //do any necessary visual object additions, noting that all visual objects are culled before each frame
            Movement.applyMovement();
            Screen.recalculatePoints();
            Screen.graph.transform(Screen.cam); // calculate the screen transform of the 3d object
            
            clear(); // removes previous content and reopens drawingvisual's drawing context
            
            Screen.graph.render(); // draw to drawing context
            drawingContext.Close(); // close drawing context after drawing is finished
            
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)mainWindowReference.Width, (int)mainWindowReference.Height, 0, 0, PixelFormats.Pbgra32); // Create requisite bitmap
            rtb.Render(drawingVisual); // render the drawingvisual's content to the bitmap
            Stopwatch sw = Stopwatch.StartNew();
            Image image = new Image(); // Create requisite image
            image.Source = rtb; // source bitmap for the image
            myCanvas.Children.Add(image); // add the finished product to the canvas, which is attatched to the mainwindow's reference
            long timeElapsed = sw.ElapsedMilliseconds;
            Console.WriteLine(timeElapsed);
        }
        /*public static MainWindow mainWindowReference;
        public static Canvas myCanvas = new Canvas();
        public static List<Vector2D> linePoints = new List<Vector2D>(); // used in conjunction: part 1
        public static Color polyColor;
        public static void init()
        {
            mainWindowReference.Content = myCanvas;
        }
        public static void clear()
        {
            myCanvas.Children.Clear();
        }
        public static void addLine(double x1, double y1, double x2, double y2, Color color)
        {
            polyColor = color;
            linePoints.Add(new Vector2D(x1, y1));
            linePoints.Add(new Vector2D(x2, y2));
            //
            //Line newLine = new Line();
            //newLine.X1 = x1; newLine.Y1 = y1; newLine.X2 = x2; newLine.Y2 = y2;
            //newLine.StrokeThickness = 1;
            //newLine.Stroke = new SolidColorBrush(color);
            //myCanvas.Children.Add(newLine);
        }
        public static void addTriangle(double x1, double y1, double x2, double y2, double x3, double y3, Color color)
        {
            Polygon newTriangle = new Polygon();
            newTriangle.Points = new PointCollection() { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            newTriangle.Stroke = new SolidColorBrush(color);
            newTriangle.StrokeThickness = 1;
            myCanvas.Children.Add(newTriangle);
        }
        public static void addVertex(double x1, double y1, Color color)
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Stroke = new SolidColorBrush(color);
            newEllipse.Width = 3;
            newEllipse.Height = 3;
            int left = (int)(x1 - (3.0 / 2.0));
            int top = (int)(y1 - (3.0 / 2.0));
            newEllipse.Margin = new Thickness(left, top, 0, 0);
            myCanvas.Children.Add(newEllipse);
        }
        public static void compileLines() // as of update to this method, coloring can now be done only in one color per polyline
        {
            Polyline lines = new Polyline();
            lines.Stroke = new SolidColorBrush(polyColor);
            lines.StrokeThickness = 1;
            PointCollection pc = new PointCollection();
            foreach (Vector2D p in linePoints)
            {
                pc.Add(new Point(p.x, p.y));
            }
            lines.Points = pc;
            myCanvas.Children.Add(lines);
        }
        public static void drawFrame(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            clear();
            //do any necessary visual object additions, noting that all visual objects are culled before each frame
            Movement.applyMovement();
            Screen.recalculatePoints();
            
            Screen.graph.transform(Screen.cam);
            
            Screen.graph.render();
            long timeElapsed = sw.ElapsedMilliseconds;
            Console.WriteLine(timeElapsed);
            
        }*/
    }
}
