using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionEnter : MonoBehaviour
{
    // bir işlemi ikiden fazla kez kullanırsak bunun için metod oluştursak daha tatlı olur.

    [SerializeField] float levelLoadDelaytime = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;


    AudioSource audioSource;
   // public ParticleSystem particleSystem;

    bool isControllable = true; //karakterimizi bir yerde kontrol etmekte sıkıntı yaşarsak bu ifadenin true olduğunu 
                                //  veya başka yerde yanlış kullanmış olma durumuna karşı bunu kontrol etmeliyiz.
    bool isCollidable = true;

    private void Start()    
    {
        audioSource = GetComponent<AudioSource>();      
    }

    private void Update()
    {
        RespondDebugKeys();
    }

    private  void RespondDebugKeys()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if(Keyboard.current.cKey.wasPressedThisFrame)
        {
           isCollidable = !isCollidable;
          
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(!isControllable ||  !isCollidable) //kontrol edilemiyorsa fonksiyondan çık dedik
        {
            return;
        }
        
            // if(other.gameObject.CompareTag("Obstacle"))
            // {
                
            // }
        switch (other.gameObject.tag) //burada aslınd if-else kullanabilirdik ama hoca switch öğretmek için kullanacağını söyledi.

        {
            case "Friendly":
                Debug.Log("Everything is looking good");
                break;  

            case "Finish":
                StartNextSequence();
                break;

            case "Obstacle":
                StartCrashSequence();                
                break;
            //     case

            // default:
            //     StartCrashSequence();                
            //     break;
        }
    }

    private void StartNextSequence()
    {
        
        
        isControllable = false;
        audioSource.Stop();
       // particleSystem.Stop();
        audioSource.PlayOneShot(successSFX);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", + levelLoadDelaytime);
        

    }

    void StartCrashSequence()
    {
        //todo add sfx and particles
        isControllable = false; //çift çarpma sesi yapmaması için-> bu fonksiyon kullanılırsa kullandığı anda artık kullanılamaz
                                //olması için kontrol edilebilir mi ifadesini false yaptık
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 2f);
        

    }

    void LoadNextLevel()
    {
        isControllable = false;
        int currentScene =SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
    
    void ReloadLevel()
    {
        isControllable = false;
        int currentScene =SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        
    }


    }

