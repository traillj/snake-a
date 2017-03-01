// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class CubeScript
{

    public GameObject CreateCube(Shader shader, Color color)
    {
        GameObject gameObject = new GameObject();
        MeshFilter cubeMesh = gameObject.AddComponent<MeshFilter>();
        cubeMesh.mesh = CreateCubeMesh(color);

        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material.shader = shader;

        MeshCollider collider = gameObject.AddComponent<MeshCollider>();
        collider.convex = true;
        collider.isTrigger = true;

        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.isKinematic = true;

        return gameObject;
    }

    private Mesh CreateCubeMesh(Color color)
    {
        Mesh m = new Mesh();
        m.name = "Cube";

        m.vertices = new[] {
            new Vector3(-1.0f, 1.0f, -1.0f), // Top
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, -1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f), // Bottom
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f), // Left
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),

            new Vector3(1.0f, -1.0f, -1.0f), // Right
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),

            new Vector3(-1.0f, 1.0f, 1.0f), // Front
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            new Vector3(-1.0f, 1.0f, -1.0f), // Back
            new Vector3(1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f)
        };



        Color[] colors = new Color[m.vertices.Length];
        int i;
        for (i = 0; i < m.vertices.Length; i++)
        {
            colors[i] = color;
        }
        m.colors = colors;

        // Define the UV coordinates
        m.uv = new[] {
            new Vector2(0.0f, 0.0f), // Top
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),

            new Vector2(0.0f, 1.0f), // Bottom
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),

            new Vector2(1.0f, 0.0f), // Left
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),

            new Vector2(0.0f, 0.0f), // Right
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),

            new Vector2(1.0f, 1.0f), // Front
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),

            new Vector2(0.0f, 1.0f), // Back
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 0.0f)
        };

        // Define the normals
        Vector3 topNormal = new Vector3(0.0f, 1.0f, 0.0f);
        Vector3 bottomNormal = new Vector3(0.0f, -1.0f, 0.0f);
        Vector3 leftNormal = new Vector3(-1.0f, 0.0f, 0.0f);
        Vector3 rightNormal = new Vector3(1.0f, 0.0f, 0.0f);
        Vector3 frontNormal = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 backNormal = new Vector3(0.0f, 0.0f, -1.0f);

        m.normals = new[] {
            topNormal, // Top
            topNormal,
            topNormal,
            topNormal,
            topNormal,
            topNormal,

            bottomNormal, // Bottom
            bottomNormal,
            bottomNormal,
            bottomNormal,
            bottomNormal,
            bottomNormal,

            leftNormal, // Left
            leftNormal,
            leftNormal,
            leftNormal,
            leftNormal,
            leftNormal,

            rightNormal, // Right
            rightNormal,
            rightNormal,
            rightNormal,
            rightNormal,
            rightNormal,

            frontNormal, // Front
            frontNormal,
            frontNormal,
            frontNormal,
            frontNormal,
            frontNormal,

            backNormal, // Back
            backNormal,
            backNormal,
            backNormal,
            backNormal,
            backNormal
        };

        // Define mesh tangents
        Vector4 topTangent = new Vector3(1.0f, 0.0f, 0.0f);
        Vector4 bottomTangent = new Vector3(1.0f, 0.0f, 0.0f);
        Vector4 leftTangent = new Vector3(0.0f, 0.0f, -1.0f);
        Vector4 rightTangent = new Vector3(0.0f, 0.0f, 1.0f);
        Vector4 frontTangent = new Vector3(-1.0f, 0.0f, 0.0f);
        Vector4 backTangent = new Vector3(1.0f, 0.0f, 0.0f);

        m.tangents = new[] {
            topTangent, // Top
            topTangent,
            topTangent,
            topTangent,
            topTangent,
            topTangent,

            bottomTangent, // Bottom
            bottomTangent,
            bottomTangent,
            bottomTangent,
            bottomTangent,
            bottomTangent,

            leftTangent, // Left
            leftTangent,
            leftTangent,
            leftTangent,
            leftTangent,
            leftTangent,

            rightTangent, // Right
            rightTangent,
            rightTangent,
            rightTangent,
            rightTangent,
            rightTangent,

            frontTangent, // Front
            frontTangent,
            frontTangent,
            frontTangent,
            frontTangent,
            frontTangent,

            backTangent, // Back
            backTangent,
            backTangent,
            backTangent,
            backTangent,
            backTangent
        };

        int[] triangles = new int[m.vertices.Length];
        for (i = 0; i < m.vertices.Length; i++)
        {
            triangles[i] = i;
        }
        m.triangles = triangles;

        return m;
    }
}
