using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewGyroRotator : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
    }

    protected void Update()
    {
        GyroRotateObject();
    }

    /*
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + transform.rotation);
    }
    */

    /********************************************/

    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroRotateObject()
    {
        // This is rotated around x axis, for holding phone upright instead of facing down
        transform.rotation = Quaternion.Euler(90, 0, 0) * GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}

