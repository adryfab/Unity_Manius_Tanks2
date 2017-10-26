using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

public class EnemyControl : MonoBehaviour
{
    public float MoveSpeed = 4; //Establecer velocidad de persecución
    public Transform trans; //De donde sale el disparo
    public GameObject disparo; //Prefab Disparo
    public GameObject player; //Objetivo a disparar
    public float fireRate = 0.5F;

    private AIMContext aimContext;
    private Rigidbody2D myBody;
    private Animator anim;
    private float nextFire = 0.0F;

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        aimContext = this.GetComponent<AIMContext>();
        trans = GameObject.Find("Disparo").transform;
    }

    void Update ()
    {
        anim.SetFloat("MoveX", aimContext.DecidedDirection.x);
        anim.SetFloat("MoveY", aimContext.DecidedDirection.y);

        if(Time.time > nextFire)
        {
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
        mouseDir = target - gameObject.transform.position;
        mouseDir = mouseDir.normalized;
        CrearDisparo(mouseDir);

    }

}
