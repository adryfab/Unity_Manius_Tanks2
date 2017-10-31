using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

public class EnemyControl : MonoBehaviour
{
    public float MoveSpeed = 4; //Establecer velocidad de persecución
    public GameObject disparo; //Prefab Disparo
    public GameObject player; //Objetivo a disparar
    public float fireRate = 0.5F;
    public GameObject game;

    private AIMContext aimContext;
    private Rigidbody2D myBody;
    private Animator anim;
    private float nextFire = 0.0F;
    private SpriteRenderer rend;

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        aimContext = this.GetComponent<AIMContext>();
        rend = this.GetComponent<SpriteRenderer>();
        CambiarColorEnemy();
    }

    void Update ()
    {
        //***Mover automaticamente al enemigo - animacion ***
        anim.SetFloat("MoveX", aimContext.DecidedDirection.x);
        anim.SetFloat("MoveY", aimContext.DecidedDirection.y);

        //*** Disparar ***
        if(Time.time > nextFire)
        {
            Disparar();
        }
    }

    private void FixedUpdate()
    {
        //***Mover automaticamente al enemigo ***
        Vector2 moveVec;
        moveVec = new Vector2(aimContext.DecidedDirection.x, aimContext.DecidedDirection.y) * MoveSpeed;
        myBody.AddForce(moveVec);
    }

    private void CrearDisparo(Vector3 target)
    {
        GameObject DisparoCopia = Instantiate(disparo, transform.position, transform.rotation);
        Rigidbody2D rb = DisparoCopia.GetComponent<Rigidbody2D>();
        rb.AddForce(target * MoveSpeed, ForceMode2D.Impulse);
        nextFire = Time.time + fireRate;
    }

    private void Disparar()
    {
        Vector3 target;
        Vector3 mouseDir;

        target = player.transform.position;
        target.z = transform.position.z;
        mouseDir = target - this.transform.position;
        mouseDir = mouseDir.normalized;
        CrearDisparo(mouseDir);

    }

    private void CambiarColorEnemy()
    {
        //rend.color = new Color(1, 1, 0, 1); //yellow
        //rend.color = new Color(0, 0, 1, 1); //blue
        //rend.color = new Color(1, 0, 0, 1); //red
        //rend.color = new Color(0, 0, 0, 1); //black
        //rend.color = new Color(0, 0, 0, 0); //clear
        //rend.color = new Color(0, 1, 1, 1); //cyan
        rend.color = new Color(0.5f, 0.5f, 0.5f, 1); //gray
        //rend.color = new Color(0, 1, 0, 1); //green
        //rend.color = new Color(1, 0, 1, 1); //magenta
        //rend.color = new Color(1, 1, 1, 1); //white
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DisparoPlayer")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
