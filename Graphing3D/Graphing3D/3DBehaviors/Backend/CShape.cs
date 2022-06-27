using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Graphing3D._3DBehaviors.Frontend;

namespace Graphing3D._3DBehaviors.Backend
{
    public class CShape
    {
        Vector3D[] vertices;
        Vector3D[] vertexConnections; // shifted to triangles
        Vector2D[] transformedPoints;
        Vector2D[] screenPoints;
        Boolean drawVertices = true;
        Boolean drawMeshOutline = false;
        Boolean drawMesh = false;
        byte[] shapeColor; // stores rgb value for the shape
        double screenWidth = CRender.mainWindowReference.Width; // verify that this is the desired value
        double screenHeight = CRender.mainWindowReference.Height;
        public void transform(Camera camIn)
        {
            transformedPoints = new Vector2D[vertices.Length];
            screenPoints = new Vector2D[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                transformedPoints[i] = visualTransform.transformPoint(vertices[i], camIn); // needs a reperation for the new refactorization
                screenPoints[i] = new Vector2D(transformedPoints[i].x * (screenWidth / 2) + screenWidth / 2, screenHeight / 2 - transformedPoints[i].y * (screenHeight / 2));
            }
        }
        public Vector3D centroid()
        {
            double xTotal = 0;
            double yTotal = 0;
            double zTotal = 0;
            double vertexCount = vertices.Length;
            for (int i = 0; i < vertices.Length; i++)
            {
                xTotal += vertices[i].x;
                yTotal += vertices[i].y;
                zTotal += vertices[i].z;
            }
            return new Vector3D(xTotal / vertexCount, yTotal / vertexCount, zTotal / vertexCount);
        }
        public void render()
        {
            if (drawMesh)
            {
                for (int i = 0; i < vertexConnections.Length; i++)
                {
                    CRender.addTriangle(screenPoints[(int)vertexConnections[i].x].x, screenPoints[(int)vertexConnections[i].x].y,
                      screenPoints[(int)vertexConnections[i].y].x, screenPoints[(int)vertexConnections[i].y].y,
                      screenPoints[(int)vertexConnections[i].z].x, screenPoints[(int)vertexConnections[i].z].y,
                      Color.FromArgb(255, shapeColor[0], shapeColor[1], shapeColor[2]));
                }
            }
            if (drawMeshOutline)
            {
                for (int i = 0; i < vertexConnections.Length; i++)
                {
                    CRender.addLine(screenPoints[(int)vertexConnections[i].x].x, screenPoints[(int)vertexConnections[i].x].y,
                      screenPoints[(int)vertexConnections[i].y].x, screenPoints[(int)vertexConnections[i].y].y,
                      Color.FromArgb(255, shapeColor[0], shapeColor[1], shapeColor[2]));
                    CRender.addLine(screenPoints[(int)vertexConnections[i].y].x, screenPoints[(int)vertexConnections[i].y].y,
                      screenPoints[(int)vertexConnections[i].z].x, screenPoints[(int)vertexConnections[i].z].y,
                      Color.FromArgb(255, shapeColor[0], shapeColor[1], shapeColor[2]));
                    CRender.addLine(screenPoints[(int)vertexConnections[i].z].x, screenPoints[(int)vertexConnections[i].z].y,
                      screenPoints[(int)vertexConnections[i].x].x, screenPoints[(int)vertexConnections[i].x].y,
                      Color.FromArgb(255, shapeColor[0], shapeColor[1], shapeColor[2]));
                }
            }
            if (drawVertices)
            {
                for (int i = 0; i < screenPoints.Length; i++)
                {
                    CRender.addVertex(screenPoints[i].x, screenPoints[i].y, Color.FromArgb(255, 0, 0, 0));
                }
            }
        }
        public CShape(Vector3D[] vertices, Vector3D[] vertexConnections, byte[] shapeColor)
        {
            this.vertices = vertices;
            this.vertexConnections = vertexConnections;
            this.shapeColor = shapeColor;
        }
        public CShape(CShape shapeToCopy)
        {
            vertices = new Vector3D[shapeToCopy.vertices.Length];
            vertexConnections = new Vector3D[shapeToCopy.vertexConnections.Length];
            shapeColor = new byte[shapeToCopy.shapeColor.Length];
            for (int i = 0; i < shapeToCopy.vertices.Length; i++)
            {
                vertices[i] = new Vector3D(shapeToCopy.vertices[i].x, shapeToCopy.vertices[i].y, shapeToCopy.vertices[i].z);
            }
            for (int i = 0; i < shapeToCopy.vertexConnections.Length; i++)
            {
                vertexConnections[i] = new Vector3D(shapeToCopy.vertexConnections[i].x, shapeToCopy.vertexConnections[i].y, shapeToCopy.vertexConnections[i].z);
            }
            for (int i = 0; i < shapeToCopy.shapeColor.Length; i++)
            {
                shapeColor[i] = shapeToCopy.shapeColor[i];
            }
        }
    }
}
