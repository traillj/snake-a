// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class AccelerometerScript : MonoBehaviour
{
    private bool tiltedDown;
    private bool tiltedUp;

    private float prevTiltPos;
    private float counter;

    void Start()
    {
        tiltedDown = false;
        tiltedUp = false;
        prevTiltPos = Input.acceleration.z;
        counter = 0;
    }

    void Update()
    {
        counter += Time.deltaTime;
        // Check every fifth of a second
        if (counter > 0.2)
        {
            counter = 0;
            float currentTiltPos = Input.acceleration.z;

            if (tiltedDown || tiltedUp)
            {
                // Wait for the previous tilt to take effect
                prevTiltPos = currentTiltPos;
                return;
            }

            if (prevTiltPos - currentTiltPos > 0.4)
            {
                // Tilted top of screen downwards
                tiltedDown = true;
            }
            else if (prevTiltPos - currentTiltPos < -0.4)
            {
                // Tilted top of screen upwards
                tiltedUp = true;
            }
            prevTiltPos = currentTiltPos;               
        }
    }

    public bool IsTiltedDown()
    {
        return tiltedDown;
    }

    public bool IsTiltedUp()
    {
        return tiltedUp;
    }

    public void SetTiltedDown(bool tiltedDown)
    {
        this.tiltedDown = tiltedDown;
    }

    public void SetTiltedUp(bool tiltedUp)
    {
        this.tiltedUp = tiltedUp;
    }
}
