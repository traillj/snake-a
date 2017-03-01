// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public Shader shader;
    public PointLight pointLight;
    public Color foodColor;

    private GameObject food;
    
    void Start()
    {
        CubeScript cubeScript = new CubeScript();
        food = cubeScript.CreateCube(shader, foodColor);
        food.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        food.transform.parent = gameObject.transform;

        food.AddComponent<FoodTriggerScript>();
    }
    
    void Update()
    {
        // Update the shading on the food
        MeshRenderer renderer;
        renderer = food.GetComponent<MeshRenderer>();
        renderer.material.SetColor("_PointLightColor", this.pointLight.color);
        renderer.material.SetVector("_PointLightPosition",
            this.pointLight.GetWorldPosition());
    }
}
