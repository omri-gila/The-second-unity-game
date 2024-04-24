using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  [SerializeField] float loadDily = 1f;//בניית משתנה עבור יוניטי 
  [SerializeField]ParticleSystem finishEffect;
  void OnTriggerEnter2D(Collider2D other)
   {
    if(other.tag == "Player" )
    {
      finishEffect.Play();

      GetComponent<AudioSource>().Play(); 

      Invoke("ReloadScane",loadDily );//להאט את העברת שלב 
    }
   } 

void ReloadScane()
{
       SceneManager.LoadScene(0);

}     

}
