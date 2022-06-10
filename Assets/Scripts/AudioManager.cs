using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{    
     public AudioClip menuAudio;
     public AudioClip gameAudio;
     private AudioSource audioSource;

     void Awake()
     {
         DontDestroyOnLoad(gameObject);
         
         audioSource = GetComponent<AudioSource>();
         
         Scene level = SceneManager.GetActiveScene();
 
         PlaySongBySceneName(level.name);
     }
     
     void OnEnable()
     {
         SceneManager.sceneLoaded += OnSceneLoaded;
     }
     
     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
     {
         PlaySongBySceneName(scene.name);
     }
     
     private void PlaySongBySceneName(string levelname)
     {
         switch(levelname)
         {
             case "Menu":
                 audioSource.clip = menuAudio;
             break;
             case "SampleScene":
                 audioSource.clip = gameAudio;
             break;
             default:
                 // Do whatever
             break;
         }  
         audioSource.Play();
    }
}
