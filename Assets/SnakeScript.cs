// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public Shader shader;
    public PointLight pointLight;

    // Each cube alternates between the two colours
    public Color color1;
    public Color color2;
    private Color currentColor;

    public double stepTime;
    public int initialSnakeLength;
    public int growAmount;

    private double stepTimeCounter;
    private CubeScript cubeScript;
    private List<GameObject> body;
    private Vector3 direction;
    private Vector3 nextStepDirection;

    private int cubesToAdd;
    private bool collided;

    void Start ()
    {
        body = new List<GameObject>();
        cubeScript = new CubeScript();

        Vector3 endPos = new Vector3(3.5f, 0.5f, 19f);
        GameObject cube;
        currentColor = color1;

        int i, j, k;
        for (i = 0; i < initialSnakeLength; i++)
        {
            cube = CreateCubeAt(endPos, currentColor);
            AlternateCurrentColor();

            cube.transform.Translate(Vector3.right * i);
            body.Add(cube);
            if (i >= 20)
            {
                break;
            }
        }

        k = 0;
        for (j = i + 1; j < initialSnakeLength; j++)
        {
            cube = CreateCubeAt(endPos, currentColor);
            AlternateCurrentColor();

            cube.transform.Translate(new Vector3(i, 0, -k));
            body.Add(cube);
            k++;
        }

        body[0].AddComponent<CollisionScript>();
        body[0].tag = "SnakeHead";
        body[1].tag = "NextToSnakeHead";

        direction = Vector3.forward;
        nextStepDirection = direction;
        cubesToAdd = 0;
        collided = false;
        UpdateShading();
    }

    private void AlternateCurrentColor()
    {
        if (currentColor.Equals(color1))
        {
            currentColor = color2;
        }
        else
        {
            currentColor = color1;
        }
    }

    
    void Update()
    {
        if (collided == true)
        {
            return;
        }

        int i;
        stepTimeCounter += Time.deltaTime;
        if (stepTimeCounter >= stepTime)
        {
            stepTimeCounter = 0;

            Vector3 prevLastCubePos =
                body[body.Count - 1].transform.position;
            Vector3 prevSecondLastCubePos =
                body[body.Count - 2].transform.position;

            // Move cubes by 2 units
            for (i = body.Count - 1; i > 1; i--)
            {
                body[i].transform.position = body[i - 2].transform.position;
            }

            body[i].transform.position = body[i - 1].transform.position
                + nextStepDirection;
            body[i - 1].transform.Translate(nextStepDirection * 2);
            direction = nextStepDirection;

            if (cubesToAdd > 0)
            {
                // Grow snake if there are cubes to add
                body.Add(CreateCubeAt(prevSecondLastCubePos, currentColor));
                AlternateCurrentColor();
                body.Add(CreateCubeAt(prevLastCubePos, currentColor));
                AlternateCurrentColor();
                cubesToAdd -= 2;
            }

            UpdateShading();
        }
    }

    private void UpdateShading()
    {
        // Update the shading on the snake
        MeshRenderer renderer;
        int i;
        for (i = 0; i < body.Count; i++)
        {
            renderer = body[i].GetComponent<MeshRenderer>();
            renderer.material.SetColor("_PointLightColor", this.pointLight.color);
            renderer.material.SetVector("_PointLightPosition",
                this.pointLight.GetWorldPosition());
        }
    }

    private GameObject CreateCubeAt(Vector3 pos, Color color)
    {
        GameObject cube = cubeScript.CreateCube(shader, color);
        cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        cube.transform.position = pos;
        cube.transform.parent = gameObject.transform;
        cube.tag = "SnakeBody";

        return cube;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public void SetNextStepDirection(Vector3 nextStepDirection)
    {
        this.nextStepDirection = nextStepDirection;
    }

    public Vector3 GetHeadPosition()
    {
        return body[body.Count - 1].transform.position;
    }

    public void Grow()
    {
        cubesToAdd += growAmount;
    }

    public bool HasCollided()
    {
        return collided;
    }

    public void SetCollided(bool collided)
    {
        this.collided = collided;
    }
}
