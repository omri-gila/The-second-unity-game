using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float Boostspeed = 100f;
    [SerializeField] float Basespeed = 15f;

    bool rotationComplete = false;

    bool canmove = true; 
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    private float previousRotation;
    GameManger gameManager;

    
    private const float FullRotationThreshold = 360f;


    // Start is called before the first frame update


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); 
        gameManager = FindObjectOfType<GameManger>(); // Find the GameManager in the scene

    }

    // Update is called once per frame
    void Update()
    {
        if (canmove)
        {
             RotatePlyer();
             RspondToBoost();

        }

         if (IsFullRotation())
        {
            gameManager.AddPoints(1);
        }

       
    }
    public void DisableControls()
    {
        canmove = false;

    }

     void RspondToBoost()
    {
      if (Input.GetKey(KeyCode.UpArrow))
        {
           surfaceEffector2D.speed = Boostspeed;
        }
        else //(Input.GetKey(KeyCode.DownArrow))
        {
           surfaceEffector2D.speed = Basespeed;
        } 
    }

    void RotatePlyer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }


   private bool IsFullRotation()
{
    float currentRotation = transform.eulerAngles.z;

    // Check if the rotation has completed a full circle
    if ((previousRotation <= 190 && currentRotation >= 190) || (previousRotation >= 190 && currentRotation <= 190))
      {
        rotationComplete = true;
        previousRotation = currentRotation;
        return true;
     }

      rotationComplete = false;
       return false;
  }
     
}

    

