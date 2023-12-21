using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public float forceFactor = 10.0f;
    public float forwardForce = 1.5f;
    public float bounceForce = 1f;
    public float bounceForceMax = 50f;
    public float flappyForceHeightMax = 10f; //Maximum height 'flappy'force can be added
    public float maxHeight = 20f;
    public float velocityDampingForce = 1.0f; // Adjust this damping force value
    private Rigidbody rb;
    private Vector3 transformDir = Vector3.zero;
    private Vector3 bounceDir = Vector3.zero;
    private float forceX = 0f;
    private float forceY = 0f;
    private float forceZ = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        forceX = Input.acceleration.x * forceFactor;
        forceY = Input.acceleration.y * forceFactor;
        forceZ = Input.acceleration.z * forceFactor;

        transformDir = new Vector3(forceX, 0f, 0f); // y is set to zero because gravity will always make it negative 
        bounceDir = new Vector3(0f, forceY+1, 0f); //this will be used only to "bounce"/"jump" +1 is to negate the effect of gravity
        //Debug.Log(bounceDir);

        // Make it move 10 meters per second instead of 10 meters per frame...
        transformDir *= Time.deltaTime;

        //transform.localPosition += transformDir; //this is translating accelerometer values directly to the transform
         
    }
    
    void FixedUpdate()
    {
        // Move object according to the accelerometer
        transform.localPosition += transformDir; //this is translating accelerometer values directly to the transform

        if (transform.position.y >= maxHeight)
        {
            //If the object is at or above max height, set its upward velocity to zero
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = 0f;
            rb.velocity = newVelocity;
        }

        if (forceY > 0f && transform.position.y < flappyForceHeightMax)
        {
            float clampedBounceForce = Mathf.Clamp(bounceForce, 0f, bounceForceMax);
            rb.AddRelativeForce(bounceDir * clampedBounceForce); // Bouncing Y up with clamped force
            Debug.Log("Bounce Force Applied: " + clampedBounceForce);
        }
        

        // Also keep the object constantly moving forward
        //rb.AddRelativeForce((Vector3.forward)* forwardForce); // using force
        //rb.AddForce(gameObject.transform.TransformDirection(Vector3.forward) * forwardForce);
    }  
    
}
