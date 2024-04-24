using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrushDoor : MonoBehaviour
{
    [SerializeField] float loadDily = 0.5f;//בניית משתנה עבור יוניטי 
    [SerializeField]ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrush = false;


void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !hasCrush)
    {
      hasCrush = true;  
      FindObjectOfType<playerControl>().DisableControls();

      CrashEffect.Play();

      GetComponent<AudioSource>().PlayOneShot(crashSFX);
      Invoke("ReloadScane",loadDily );//להאט את העברת שלב 

    }

    }
    

void ReloadScane()
{
       SceneManager.LoadScene(0);

}     

}
