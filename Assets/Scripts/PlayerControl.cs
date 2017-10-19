using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float VelocidadJugador;

    private Vector3 PosicionJugador;
    private Rigidbody2D rgb;

    // Use this for initialization
    void Start ()
    {
        PosicionJugador = gameObject.transform.position;
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

    void MovimientoTransform()
    {
        // movimiento horizontal
        PosicionJugador.x += Input.GetAxis("Horizontal") * VelocidadJugador;
        // movimiento vertical
        PosicionJugador.y += Input.GetAxis("Vertical") * VelocidadJugador;
        // actualiza el valor de la posicion del Transform del objeto Jugador
        transform.position = PosicionJugador;
    }

    void MovimientoRGB()
    {
        // movimiento horizontal
        float h = Input.GetAxis("Horizontal");
        // movimiento vertical
        float v = Input.GetAxis("Vertical");

        Vector2 vel = new Vector2(rgb.velocity.x, rgb.velocity.y);
        h *= VelocidadJugador;
        v *= VelocidadJugador;
        vel.x = h;
        vel.y = v;
        rgb.velocity = vel;
    }
}
