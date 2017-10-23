using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    public float speed = 10;
    public GameObject disparo;

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
        CambiarColorPlayer();
    }

    void Update()
    {        
        //Debug.Log("Vertical: " + CrossPlatformInputManager.GetAxis("Vertical").ToString() +
        //    " - Horizontal: " + CrossPlatformInputManager.GetAxis("Horizontal").ToString());

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

        Debug.Log("Input.touchCount: " + Input.touchCount.ToString() + " - Input.GetMouseButtonDown(0): "
            + Input.GetMouseButtonDown(0).ToString());
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            CrearDisparo();
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 
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

    private void CrearDisparo()
    {
        Instantiate(disparo, transform.position, Quaternion.identity);
    }
}
