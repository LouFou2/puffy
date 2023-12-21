using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObjectMover : MonoBehaviour
{
    // This Script uses a child object rotated by Gyro, and moves the parent
    // using relevant calculations as needed
    private GameObject childGyroObject;
    private Rigidbody rb;
    [SerializeField] private float xForceFactor = 10f;
    [SerializeField] private float zForceFactor = 10f;
    private Quaternion gyroRotation = Quaternion.identity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Find the child GameObject named "gyroObject"
        childGyroObject = transform.Find("GyroObject").gameObject;
    }

    private void FixedUpdate()
    {
        // Read child gyroObject Quaternions
        gyroRotation = childGyroObject.transform.rotation;

        // Y Rotation
        // Rotate the parent object's Y axis according to gyroObject Y orientation
        //the initial Y rotation is subtracted to "reset" the object/(face z forward in world space)
        //transform.rotation = Quaternion.Euler(0f, gyroRotation.eulerAngles.y, 0f);

        //Recalculate x and z angles to be -180 to 180
        float xAngle = gyroRotation.eulerAngles.x;
        if (xAngle > 180f)
        {
            xAngle -= 360f;
        }
        float zAngle = gyroRotation.eulerAngles.z;
        if (zAngle > 180f)
        {
            zAngle -= 360f;
        }

        // X Force (sideways movement)
        float xNormForce = Mathf.InverseLerp(-90f, 90f, -zAngle) * 2f - 1f; //use z rotation to drive x direction
        Vector3 xForce = new Vector3(xNormForce * xForceFactor, 0f, 0f);
        rb.AddRelativeForce(xForce);

        //Vector3 xForce = transform.right * (xNormForce * xForceFactor);
        //rb.AddForce(xForce);

        // Z Force (forward - backward movement)
        float zNormForce = Mathf.InverseLerp(-90f, 90f, xAngle) * 2f - 1f; //use x rotation to drive z movement

        Vector3 zForce = new Vector3(0f, 0f, zNormForce * zForceFactor);
        rb.AddRelativeForce(zForce);

        //Vector3 zForce = transform.forward * (zNormForce * zForceFactor);
        //rb.AddForce(zForce);

        //Debug.Log("Gyro Y Rotation: " + gyroRotation.eulerAngles.y);
        //Debug.Log("offset Y rotation: " + transform.eulerAngles.y);
        //Debug.Log("X Rotation: " + xAngle + ", Z Rotation: " + zAngle);
        //Debug.Log("X Norm Force: " + xNormForce + ", Z Norm Force: " + zNormForce);
        //Debug.Log("X Force: " + xForce + ", Z Force: " + zForce); 
    }
}
