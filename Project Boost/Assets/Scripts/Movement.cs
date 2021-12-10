using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrusting();
        ProcessRotation();
    }
    
    void ProcessThrusting()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressing Space - Thrusting");
        }
        
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressing A - Rotate Left");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressing D - Rotate Right");
        }
    }



}
