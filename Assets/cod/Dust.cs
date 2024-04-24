using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] ParticleSystem dustparticles;
     void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            dustparticles.Play();
        }


    }

     void OnCollisionExit2D(Collision2D other) 
    {

        if(other.gameObject.tag == "Ground" )
         {

          dustparticles.Stop();

         }

    }

}
