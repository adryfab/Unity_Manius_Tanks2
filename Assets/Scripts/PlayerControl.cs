﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    public float speed = 10;
    public GameObject disparo;
    public Transform trans;

    private Rigidbody2D myBody;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private SpriteRenderer rend;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        rend = this.GetComponent<SpriteRenderer>();
        trans = GameObject.Find("Disparo").transform;
        CambiarColorPlayer();
    }

    void Update()
    {        
        playerMoving = false;

        //***GamePad***
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.5f || CrossPlatformInputManager.GetAxis("Horizontal") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0f); 
        }
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0.5f || CrossPlatformInputManager.GetAxis("Vertical") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, CrossPlatformInputManager.GetAxis("Vertical"));
        }
        anim.SetFloat("MoveX", CrossPlatformInputManager.GetAxis("Horizontal"));
        anim.SetFloat("MoveY", CrossPlatformInputManager.GetAxis("Vertical"));

        //***Ambos***
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        Disparar();
    }

    private void FixedUpdate()
    {
        Vector2 moveVec;

        //***GamePad***
        moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 
            CrossPlatformInputManager.GetAxis("Vertical")) * speed;
        myBody.AddForce(moveVec);
        
    }

    private void CambiarColorPlayer()
    {
        rend.color = new Color(1, 1, 0, 1); //yellow
        //rend.color = new Color(0, 0, 1, 1); //blue
        //rend.color = new Color(1, 0, 0, 1); //red
        //rend.color = new Color(0, 0, 0, 1); //black
        //rend.color = new Color(0, 0, 0, 0); //clear
        //rend.color = new Color(0, 1, 1, 1); //cyan
        //rend.color = new Color(0.5f, 0.5f, 0.5f, 1); //gray
        //rend.color = new Color(0, 1, 0, 1); //green
        //rend.color = new Color(1, 0, 1, 1); //magenta
        //rend.color = new Color(1, 1, 1, 1); //white
    }

    private void CrearDisparo(float posX, float posY, float posZ, Vector3 target)
    {
        GameObject DisparoCopia = Instantiate(disparo, trans.position, trans.rotation);
        Rigidbody2D rb = DisparoCopia.GetComponent<Rigidbody2D>();
        rb.AddForce(target * speed, ForceMode2D.Impulse);
    }

    private void Disparar()
    {
        //***Disparo***
        Vector3 target;
        Vector3 mouseDir;
        if (Input.GetButtonDown("Fire1"))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            mouseDir = target - gameObject.transform.position;
            mouseDir = mouseDir.normalized;
            CrearDisparo(target.x, target.y, target.z, mouseDir);
        }
        else if (Input.touchCount > 0)
        {
            target = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position); //***
            target.z = transform.position.z;
            mouseDir = target - gameObject.transform.position;
            mouseDir = mouseDir.normalized;
            CrearDisparo(target.x, target.y, target.z, mouseDir);
        }
    }
}
