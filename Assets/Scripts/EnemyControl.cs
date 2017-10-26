using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

public class EnemyControl : MonoBehaviour
{
    public float MoveSpeed = 4; //Establecer velocidad de persecución
    public Transform trans; //De donde sale el disparo (hijo)
    public GameObject disparo; //Prefab Disparo
    public GameObject player; //Objetivo a disparar
    public float fireRate = 0.5F;

    private AIMContext aimContext;
    private Rigidbody2D myBody;
    private Animator anim;
    private float nextFire = 0.0F;
    private SpriteRenderer rend;
    private Color colorEnemigo;
    private Disparo1Control scriptDisparo;

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        aimContext = this.GetComponent<AIMContext>();
        rend = this.GetComponent<SpriteRenderer>();
        CambiarColorEnemy();
        trans = GameObject.Find("DisparoEnemy").transform;
        scriptDisparo = disparo.GetComponent<Disparo1Control>();
        colorEnemigo = rend.color;
    }

    void Update ()
    {
        anim.SetFloat("MoveX", aimContext.DecidedDirection.x);
        anim.SetFloat("MoveY", aimContext.DecidedDirection.y);

        if(Time.time > nextFire)
        {
            //Debug.Log("EnemyControl - " + colorEnemigo);
            scriptDisparo.colorDisparo = colorEnemigo;
            Disparar();
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVec;
        moveVec = new Vector2(aimContext.DecidedDirection.x, aimContext.DecidedDirection.y) * MoveSpeed;
        myBody.AddForce(moveVec);
    }

    private void CrearDisparo(Vector3 target)
    {
        GameObject DisparoCopia = Instantiate(disparo, trans.position, trans.rotation);
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
        rend.color = new Color(0, 0, 1, 1); //blue
        //rend.color = new Color(1, 0, 0, 1); //red
        //rend.color = new Color(0, 0, 0, 1); //black
        //rend.color = new Color(0, 0, 0, 0); //clear
        //rend.color = new Color(0, 1, 1, 1); //cyan
        //rend.color = new Color(0.5f, 0.5f, 0.5f, 1); //gray
        //rend.color = new Color(0, 1, 0, 1); //green
        //rend.color = new Color(1, 0, 1, 1); //magenta
        //rend.color = new Color(1, 1, 1, 1); //white
    }

}
