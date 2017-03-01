// COMP30019 Graphics and Interaction
// Project 1
// Author: traillj

using UnityEngine;
using System.Collections;

// From Lab 5
public class PointLight : MonoBehaviour {

    public Color color;

    public Vector3 GetWorldPosition()
    {
        return this.transform.position;
    }
}
