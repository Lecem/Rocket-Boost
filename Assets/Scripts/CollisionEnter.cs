using System;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEnter : MonoBehaviour
{
    //buradaki şey için aslında if else kullanabilirdik ama hoca swith öğretmek için kullanacağını söyledi.

     private void OnCollisionEnter(Collision other) 
    {
        
        switch (other.gameObject.tag)  
        {
            case "Friendly":
                Debug.Log("Everything is looking good");
                break;  

            case "Finish":
                LoadNextLevel();
                break;

            default:
                StartCrashSequence();                
                Invoke("Reloadlevel", 2f); // (nameof(ReloadLevel), 2f); olarak kullansaydık parantez dışına almamız gerekmeyecekti.
                break;                     // "Reloadlevel" i string olarak verdiğimiz için Invoke bunu algılayamadı.
                                           //fonksiyonun içine fonksiyon yazdığımız için bu şekilde sıkıntı oldu.
            
        }
    }

    void StartCrashSequence()
    {
        throw new NotImplementedException();
    }

    void LoadNextLevel()
        {
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
            int currentScene =SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
            
        }


    }

