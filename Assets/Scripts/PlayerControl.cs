using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    //public float VelocidadJugador;
    public float speed = 10;

    //private Vector3 PosicionJugador;
    //private Rigidbody2D rgb;
    private Rigidbody2D myBody;
    private float hInput = 0;

    // Use this for initialization
    void Start()
    {
        //PosicionJugador = gameObject.transform.position;
        //rgb = GetComponent<Rigidbody2D>();
        //myBody = this.rigidbody2D;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //MovimientoTransform();
    }

    private void FixedUpdate()
    {
        #if !UNITY_ANDROID
            Move(Input.GetAxisRaw("Horizontal"));
        #else
            Move(hInput);
        #endif
    }

    void Move(float horizontalInput)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontalInput * speed;
        //moveVel.y = verticalInput * speed;
        myBody.velocity = moveVel;
    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }

    //void MovimientoTransform()
    //{
    //    // movimiento horizontal
    //    PosicionJugador.x += Input.GetAxis("Horizontal") * VelocidadJugador;
    //    // movimiento vertical
    //    PosicionJugador.y += Input.GetAxis("Vertical") * VelocidadJugador;
    //    // actualiza el valor de la posicion del Transform del objeto Jugador
    //    transform.position = PosicionJugador;
    //}

    //public void MovimientoRGB()
    //{
    //    // movimiento horizontal
    //    float h = Input.GetAxisRaw("Horizontal");
    //    //float hm = CrossPlatformInputManager.GetAxis("Horizontal");

    //    // movimiento vertical
    //    float v = Input.GetAxisRaw("Vertical");
    //    //float vm = CrossPlatformInputManager.GetAxis("Vertical");

    //    Vector2 vel = new Vector2(rgb.velocity.x, rgb.velocity.y);

    //    //añadir velocidad
    //    h *= VelocidadJugador;
    //    //hm *= VelocidadJugador;
    //    v *= VelocidadJugador;
    //    //vm *= VelocidadJugador;

    //    //if (h > 0 || v > 0)
    //    //{
    //    vel.x = h;
    //    vel.y = v;
    //    //}
    //    //else if (hm > 0 || vm > 0)
    //    //{
    //    //    vel.x = hm;
    //    //    vel.y = vm;
    //    //}

    //    //Añadiendo la velocidad al rigidbody
    //    rgb.velocity = vel;
    //}
}
