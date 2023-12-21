using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyGyroRotation : MonoBehaviour
{
    [SerializeField] private GameObject gyroObject;
    private Quaternion gyroRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gyroRotation = gyroObject.transform.rotation;
        transform.rotation = Quaternion.Euler(gyroRotation.eulerAngles.x, 0f, gyroRotation.eulerAngles.z);
    }
}
