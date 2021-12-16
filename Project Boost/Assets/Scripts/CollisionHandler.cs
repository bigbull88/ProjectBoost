using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    //PARAMETERS - for tuning, typically set by editor
    //CACHE - e.g. references for readability or speed
    //STATE - private instantce (member) variables

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip audioDeath;
    [SerializeField] AudioClip audioSucess;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField ]ParticleSystem deathParticle;

    
    AudioSource audioSource;
    //ParticleSystem particleSource;

    bool isTransitioning = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other) 
    {

        if (isTransitioning) {return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Launching pad");
                break;
            case "Finish":
                //Debug.Log("Finish");
                StartSuccessSequence();
                break;        
            default:
                //Debug.Log("Explosion");
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(audioSucess);
        //audioSource.Stop();
        successParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",levelLoadDelay);
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(audioDeath);
        //audioSource.Stop();
        deathParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
    }

    

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }



    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


   

}
