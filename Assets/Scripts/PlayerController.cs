using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float fltTorqueAmount = 1f;
    [SerializeField] float fltBoostSpeed = 30f;
    [SerializeField] float fltBaseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool blnCanMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(blnCanMove)
        {
        RotatePlayer();
        RespondToBoost();
        }
    }
    public void DisableControls()
    {
        blnCanMove = false;
    }
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = fltBoostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = fltBaseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(fltTorqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-fltTorqueAmount);
        }
    }
}
