using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //PARAMETERS - for tuning, typically set by editor
    //CACHE - e.g. references for readability or speed
    //STATE - private instantce (member) variables

    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 1f;
    [SerializeField] AudioClip MainEngineAudio;

    [SerializeField] ParticleSystem MainEngineParticle;
    [SerializeField] ParticleSystem RightThrusterParticle;
    [SerializeField] ParticleSystem LeftThrusterParticle;


    Rigidbody rb;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }

    }

    //2 Rotation
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }


    //Thrusting
    void StartThrusting()
    {
        //Debug.Log("Pressing Space - Thrusting");
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(MainEngineAudio);
        }

        if (!MainEngineParticle.isPlaying)
        {
            MainEngineParticle.Play();
        }
    }

    void StopThrusting()
    {
        MainEngineParticle.Stop();
        audioSource.Stop();
    }



    
    //Rotating
    void RotateLeft()
    {
        //Debug.Log("Pressing A - Rotate Left");
        ApplyRotation(rotateThrust);
        if (!RightThrusterParticle.isPlaying)
        {
            RightThrusterParticle.Play();
        }
    }

    void RotateRight()
    {
        //Debug.Log("Pressing D - Rotate Right");
        ApplyRotation(-rotateThrust);
        if (!LeftThrusterParticle.isPlaying)
        {
            LeftThrusterParticle.Play();
        }
    }

    void StopRotating()
    {
        RightThrusterParticle.Stop();
        LeftThrusterParticle.Stop();
    }

    
    void ApplyRotation(float rotateThisFrame)
    {
    	rb.freezeRotation = true;  // freeze Rotation to manual rotate
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreeze Rotation to manual rotate
    }


}
