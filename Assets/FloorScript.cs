// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public Shader shader;
    public PointLight pointLight;
    public Texture tex;

    public float maxBlur;
    public float blurSpeed;

    private float currentBlur = 0;
    private int blurDirection = 1;

    // Create the floor, add the renderer component and assign the shader.
    void Start()
    {
        MeshFilter quadMesh = gameObject.AddComponent<MeshFilter>();
        quadMesh.mesh = CreateQuadMesh();

        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material.shader = shader;
        renderer.material.SetTexture("_MainTex", tex);

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.RecalculateNormals();

        ScaleFloor();
    }

    // Change the blurriness.
    void Update()
    {
        if (currentBlur > maxBlur || currentBlur < 0)
        {
            // Stay between minimum and maximum blur
            blurDirection *= -1;
        }
        currentBlur += blurSpeed * blurDirection;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.SetFloat("_BlurAmount", currentBlur);
    }

    // Set floor to fit a 3:2 aspect ratio.
    private void ScaleFloor()
    {
        Transform transform = gameObject.GetComponent<Transform>();

        float width = 75;
        float height = 50;
        transform.localScale = new Vector3(width, 1.0f, height);
    }

    private Mesh CreateQuadMesh()
    {
        Mesh m = new Mesh();
        m.name = "Quad";

        // Vertices are ordered in increasing x, then
        // increasing y with no duplicates
        int numVertices = 4;
        Vector3[] vertices = new Vector3[numVertices];

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 0, 1);
        vertices[3] = new Vector3(1, 0, 1);

        m.vertices = vertices;

        m.uv = new[] {
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
        };

        m.triangles = GenerateTriangles(1);
        return m;
    }

    // Assumes vertices are ordered in increasing x,
    // then increasing y with no duplicates.
    // Derived from http://catlikecoding.com/unity/tutorials/procedural-grid/
    private int[] GenerateTriangles(int dim)
    {
        int[] triangles = new int[dim * dim * 6];
        for (int ti = 0, vi = 0, y = 0; y < dim; y++, vi++)
        {
            for (int x = 0; x < dim; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + dim + 1;
                triangles[ti + 5] = vi + dim + 2;
            }
        }
        return triangles;
    }
}
