using System;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
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


    //buradaki şey için aslında if else kullanabilirdik ama hoca switch öğretmek için kullanacağını söyledi.


    void Start()    
    {
        audioSource = GetComponent<AudioSource>();  
            
    }


     private void OnCollisionEnter(Collision other) 
    {
        if(!isControllable) //kontrol edilemiyorsa fonksiyondan çık dedik
        {
            return;
        }
        
        switch (other.gameObject.tag)  
        {
            case "Friendly":
                Debug.Log("Everything is looking good");
                break;  

            case "Finish":
               // LoadNextLevel();
               StartNextSequence();
                break;

            default:
                StartCrashSequence();                

                break;
            
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

