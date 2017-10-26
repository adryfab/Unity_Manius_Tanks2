using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

public class EnemyControl : MonoBehaviour
{
    public float MoveSpeed = 4; //Establecer velocidad de persecución
    public Transform trans; //De donde sale el disparo
    public GameObject disparo; //Prefab Disparo

    private AIMContext aimContext;
    private Rigidbody2D myBody;
    private Animator anim;

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
    }

    private void FixedUpdate()
    {
        Vector2 moveVec;
        moveVec = new Vector2(aimContext.DecidedDirection.x, aimContext.DecidedDirection.y) * MoveSpeed;
        myBody.AddForce(moveVec);
    }

    private void CrearDisparo(float posX, float posY, float posZ, Vector3 target)
    {
        GameObject DisparoCopia = Instantiate(disparo, trans.position, trans.rotation);
        Rigidbody2D rb = DisparoCopia.GetComponent<Rigidbody2D>();
        rb.AddForce(target * MoveSpeed, ForceMode2D.Impulse);
    }

    private void Disparar()
    {

    }
}
