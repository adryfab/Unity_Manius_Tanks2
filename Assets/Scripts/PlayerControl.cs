using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    public float VelocidadJugador;

    //private Vector3 PosicionJugador;
    private Rigidbody2D rgb;

    // Use this for initialization
    void Start ()
    {
        //PosicionJugador = gameObject.transform.position;
        rgb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //MovimientoTransform();
    }

    private void FixedUpdate()
    {
        MovimientoRGB();
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

    public void MovimientoRGB()
    {
        // movimiento horizontal
        float h = Input.GetAxis("Horizontal");
        float hm = CrossPlatformInputManager.GetAxis("Horizontal");

        // movimiento vertical
        float v = Input.GetAxis("Vertical");
        float vm = CrossPlatformInputManager.GetAxis("Vertical");

        Vector2 vel = new Vector2(rgb.velocity.x, rgb.velocity.y);

        //añadir velocidad
        h *= VelocidadJugador;
        hm *= VelocidadJugador;
        v *= VelocidadJugador;
        vm *= VelocidadJugador;

        //if (h > 0 || v > 0)
        //{
            vel.x = h;
            vel.y = v;
        //}
        //else if (hm > 0 || vm > 0)
        //{
        //    vel.x = hm;
        //    vel.y = vm;
        //}

        //Añadiendo la velocidad al rigidbody
        rgb.velocity = vel;
    }
}
