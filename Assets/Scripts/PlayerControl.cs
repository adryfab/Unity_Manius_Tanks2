using System.Collections;
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

        ////***Teclado***
        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    playerMoving = true;
        //    lastMove = new Vector2(Input.GetAxis("Horizontal"), 0f);
        //}
        //if (Input.GetAxis("Vertical") != 0)
        //{
        //    playerMoving = true;
        //    lastMove = new Vector2(0f, Input.GetAxis("Vertical"));
        //}
        //anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        //anim.SetFloat("MoveY", Input.GetAxis("Vertical"));

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

        if (Input.GetButtonDown("Fire1") || Input.touchCount > 0)
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.x = target.x * -1;
            target.y = target.y * -1;
            CrearDisparo(target.x, target.y, target.z, target);
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVec;

        ////***Teclado***
        //moveVec = new Vector2(Input.GetAxis("Horizontal"),
        //    Input.GetAxis("Vertical")) * speed;
        //myBody.AddForce(moveVec);

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
        Debug.Log("posX: " + target.x.ToString() + " - posY: " + target.x.ToString() + " - posZ: " + target.z.ToString());

        //Instantiate(disparo, trans.position, trans.rotation);
        //Instantiate(disparo, transform.position, transform.rotation);
        GameObject DisparoCopia = Instantiate(disparo);
        //rotation.z
        //DisparoCopia.transform.Rotate(0, 45, 0, Space.World);
        //DisparoCopia.transform.Rotate(0, 0, -90);
        //DisparoCopia.transform.rotation = Quaternion.Euler(posX,0,0);
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //DisparoCopia.transform.position = Vector3.MoveTowards(DisparoCopia.transform.position, target, speed * Time.deltaTime);
        Rigidbody2D rb = DisparoCopia.GetComponent<Rigidbody2D>();
        //rb.velocity = target;
        rb.AddForce(target * speed, ForceMode2D.Impulse);
    }
}
