using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

public class EnemyControl : MonoBehaviour
{
    public float MoveSpeed = 4; //Establecer velocidad de persecución

    private AIMContext aimContext;
    private Rigidbody2D myBody;
    private Animator anim;

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        aimContext = this.GetComponent<AIMContext>();
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
}
