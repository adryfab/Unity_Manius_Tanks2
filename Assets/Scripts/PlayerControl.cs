using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using CnControls;

public class PlayerControl : MonoBehaviour {

    public float speed = 10;
    public GameObject disparo;
    public Transform trans;
    public int vida = 3;
    public Text txt;
    public Slider slider;
    public GameObject game;
    public Color PlayerColor;
    public Image life;

    private Rigidbody2D myBody;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private SpriteRenderer rend;
    private float LifePart;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        rend = this.GetComponent<SpriteRenderer>();
        trans = GameObject.Find("Disparo").transform;
        CambiarColorPlayer(ProjectVars.Instance.PlayerColor);
        LifePart = 1f;
    }

    void Update()
    {
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        //***Disparar***
        Disparar();

        //***Vida***
        txt.text = vida.ToString();
        slider.value = vida;
        Vida();
    }

    //private void Mover_MobileSingleStickControl()
    //{
    //    Vector2 moveVec;
    //    moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
    //        CrossPlatformInputManager.GetAxis("Vertical")) * speed;
    //    myBody.AddForce(moveVec);

    //    playerMoving = false;
    //    if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.5f || CrossPlatformInputManager.GetAxis("Horizontal") < -0.5f)
    //    {
    //        playerMoving = true;
    //        lastMove = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0f);
    //    }
    //    if (CrossPlatformInputManager.GetAxis("Vertical") > 0.5f || CrossPlatformInputManager.GetAxis("Vertical") < -0.5f)
    //    {
    //        playerMoving = true;
    //        lastMove = new Vector2(0f, CrossPlatformInputManager.GetAxis("Vertical"));
    //    }
    //    anim.SetFloat("MoveX", CrossPlatformInputManager.GetAxis("Horizontal"));
    //    anim.SetFloat("MoveY", CrossPlatformInputManager.GetAxis("Vertical"));
    //}
    
    private void Mover_SensitiveJoystick()
    {
        Vector2 moveVec;
        moveVec = new Vector2(CnInputManager.GetAxis("Horizontal"),
            CnInputManager.GetAxis("Vertical")) * speed;
        myBody.AddForce(moveVec);

        playerMoving = false;
        if (CnInputManager.GetAxis("Horizontal") > 0.5f || CnInputManager.GetAxis("Horizontal") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(CnInputManager.GetAxis("Horizontal"), 0f);
        }
        if (CnInputManager.GetAxis("Vertical") > 0.5f || CnInputManager.GetAxis("Vertical") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, CnInputManager.GetAxis("Vertical"));
        }
        anim.SetFloat("MoveX", CnInputManager.GetAxis("Horizontal"));
        anim.SetFloat("MoveY", CnInputManager.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        //Mover_MobileSingleStickControl();
        Mover_SensitiveJoystick();
    }

    private void CambiarColorPlayer(Color plColor)
    {
        if (plColor.a == 0 && plColor.b == 0 && plColor.g == 0 && plColor.r == 0)
        {
            rend.color = new Color(1, 1, 0, 1); //yellow
        }
        else
        {
            rend.color = plColor;
        }
        //rend.color = new Color(1, 1, 0, 1); //yellow
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

    private void CrearDisparo(Vector3 target)
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
            CrearDisparo(mouseDir);
        }
        else if (Input.touchCount > 0)
        {
            target = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position); //***
            target.z = transform.position.z;
            mouseDir = target - gameObject.transform.position;
            mouseDir = mouseDir.normalized;
            CrearDisparo(mouseDir);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Disparo")
        {
            vida = vida - 1;
            if (vida < 0)
            {
                vida = 0;
            }
        }

        //***Recogiendo premio***
        if (collision.tag == "Premio")
        {
            vida = vida + 1;
            if (vida > 3)
            {
                vida = 3;
            }

        }
    }

    private void Vida()
    {
        if (vida <= 0)
        {
            gameObject.SetActive(false);
            game.SendMessage("finJuego", false);
        }

        switch (vida)
        {
            case 0:
                LifePart = 0.0f;
                break;
            case 1:
                LifePart = 0.30f;
                break;
            case 2:
                LifePart = 0.70f;
                break;
            case 3:
                LifePart = 1.0f;
                break;
        }
        life.fillAmount = LifePart;
    }
}
