using UnityEngine;
using System.Collections;

public class MeshGenerationDemo : MonoBehaviour
{
    /// <summary>
    /// Length of the Cube
    /// </summary>
    public float cubeLength;

    /// <summary>
    /// width of the Cube
    /// </summary>
    public float cubeWidth;

    /// <summary>
    /// Height of the Cube
    /// </summary>
    public float cubeHeight;

    /// <summary>
    /// Mesh used to generate cube
    /// </summary>
    private Mesh cubeMesh;
    // Use this for initialization
    void Start()
    {
        MakeCube();
    }

    /// <summary>
    /// Get Vertices of the cube
    /// </summary>
    /// <returns></returns>
    private Vector3[] GetVertices()
    {
        Vector3 vertice_0 = new Vector3(-cubeLength * .5f, -cubeWidth * .5f, cubeHeight * .5f);
        Vector3 vertice_1 = new Vector3(cubeLength * .5f, -cubeWidth * .5f, cubeHeight * .5f);
        Vector3 vertice_2 = new Vector3(cubeLength * .5f, -cubeWidth * .5f, -cubeHeight * .5f);
        Vector3 vertice_3 = new Vector3(-cubeLength * .5f, -cubeWidth * .5f, -cubeHeight * .5f);

        Vector3 vertice_4 = new Vector3(-cubeLength * .5f, cubeWidth * .5f, cubeHeight * .5f);
        Vector3 vertice_5 = new Vector3(cubeLength * .5f, cubeWidth * .5f, cubeHeight * .5f);
        Vector3 vertice_6 = new Vector3(cubeLength * .5f, cubeWidth * .5f, -cubeHeight * .5f);
        Vector3 vertice_7 = new Vector3(-cubeLength * .5f, cubeWidth * .5f, -cubeHeight * .5f);

        Vector3[] vertices = new Vector3[]
				{
				// Bottom Polygon
					vertice_0, vertice_1, vertice_2, vertice_0,
					
				// Left Polygon
					vertice_7, vertice_4, vertice_0, vertice_3,
					
				// Front Polygon
					vertice_4, vertice_5, vertice_1, vertice_0,
					
				// Back Polygon
					vertice_6, vertice_7, vertice_3, vertice_2,
					
				// Right Polygon
					vertice_5, vertice_6, vertice_2, vertice_1,
					
				// Top Polygon
					vertice_7, vertice_6, vertice_5, vertice_4
				};

        return vertices;
    }
    /// <summary>
    /// The Cube Side Which Are Use when rendering Cube
    /// </summary>
    /// <returns>The normals.</returns>
    private Vector3[] GetNormals()
    {
        Vector3 up = Vector3.up;
        Vector3 down = Vector3.down;
        Vector3 front = Vector3.forward;
        Vector3 back = Vector3.back;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;

        Vector3[] normales = new Vector3[]
		{
				// Bottom Side Render
					down, down, down, down,
					
				// LEFT Side Render
					left, left, left, left,
					
				// FRONT Side Render
					front, front, front, front,
					
				// BACK Side Render
					back, back, back, back,
					
				// RIGTH Side Render
					right, right, right, right,
					
				// UP Side Render
					up, up, up, up
				};

        return normales;
    }
    /// <summary>
    /// Get the UVs Map of the cube
    /// </summary>
    /// <returns></returns>
    private Vector2[] GetUVsMap()
    {
        Vector2 _00_CORDINATES = new Vector2(0f, 0f);
        Vector2 _10_CORDINATES = new Vector2(1f, 0f);
        Vector2 _01_CORDINATES = new Vector2(0f, 1f);
        Vector2 _11_CORDINATES = new Vector2(1f, 1f);

        Vector2[] uvs = new Vector2[]
				{
				// Bottom
					_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
					
				// Left
					_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
					
				// Front
					_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
					
				// Back
					_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
					
				// Right
					_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
					
				// Top
					_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
				};
        return uvs;
    }
    /// <summary>
    /// Get the triangle
    /// </summary>
    /// <returns></returns>
    private int[] GetTriangles()
    {
        int[] triangles = new int[]
				{
				// Cube Bottom Side Triangles
					3, 1, 0,
					3, 2, 1,			
					
				// Cube Left Side Triangles
					3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
					3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
					
				// Cube Front Side Triangles
					3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
					3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
					
				// Cube Back Side Triangles
					3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
					3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
					
				// Cube Rigth Side Triangles
					3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
					3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
					
				// Cube Top Side Triangles
					3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
					3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
					
				};
        return triangles;
    }
   /// <summary>
   /// Gets the Mesh
   /// </summary>
   /// <returns></returns>
    private Mesh GetCubeMesh()
    {

        if (GetComponent<MeshFilter>() == null)
        {
            Mesh mesh;
            MeshFilter filter = gameObject.AddComponent<MeshFilter>();
            mesh = filter.mesh;
            mesh.Clear();
            return mesh;
        }
        else
        {
            return gameObject.AddComponent<MeshFilter>().mesh;
        }
    }
    /// <summary>
    /// Makes the Cube
    /// </summary>
    void MakeCube()
    {
        cubeMesh = GetCubeMesh();
        cubeMesh.vertices = GetVertices();
        cubeMesh.normals = GetNormals();
        cubeMesh.uv = GetUVsMap();
        cubeMesh.triangles = GetTriangles();
        cubeMesh.RecalculateBounds();
        cubeMesh.RecalculateNormals();
        cubeMesh.Optimize();
    }


}
