using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    public float speed = 10;

    private Rigidbody2D myBody;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {        
        Debug.Log("Vertical: " + CrossPlatformInputManager.GetAxis("Vertical").ToString() +
            " - Horizontal: " + CrossPlatformInputManager.GetAxis("Horizontal").ToString());

        playerMoving = false;

        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.5f || 
            CrossPlatformInputManager.GetAxis("Horizontal") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0f); 
        }
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0.5f || 
            CrossPlatformInputManager.GetAxis("Vertical") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, CrossPlatformInputManager.GetAxis("Vertical"));
        }

        anim.SetFloat("MoveX", CrossPlatformInputManager.GetAxis("Horizontal"));
        anim.SetFloat("MoveY", CrossPlatformInputManager.GetAxis("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 
            CrossPlatformInputManager.GetAxis("Vertical")) * speed;
        myBody.AddForce(moveVec);
    }

}
