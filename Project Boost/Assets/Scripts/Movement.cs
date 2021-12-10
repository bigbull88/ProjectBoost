using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotateThrust = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    
    {
        ProcessThrusting();
        ProcessRotation();
    }
    
    //1 Thrust
    void ProcessThrusting()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressing Space - Thrusting");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        
    }

    //2 Rotation
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Pressing A - Rotate Left");
            ApplyRotation(rotateThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Pressing D - Rotate Right");
            ApplyRotation(-rotateThrust);
        }
    }

    //3
    void ApplyRotation(float rotateThisFrame)
    {
    	rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }


}
