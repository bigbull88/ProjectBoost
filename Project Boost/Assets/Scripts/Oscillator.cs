using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        //Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {

        if (period <= Mathf.Epsilon) {return; } 
            
        float cycles = Time.time/period;  // growing over time
        const float tau = Mathf.PI * 2;   //constant value of 6.283 (full circle)
        float rawSinWave = Mathf.Sin(tau * cycles); //going from -1 to 1 - Truc tung (-1 , 1) cua sin(x)

        movementFactor = (rawSinWave + 1f) / 2;       // recaculate to make (-1,1) -> (0,1)
        //Debug.Log(movementFactor);
        


        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
