using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float VelocidadJugador;

    private Vector3 PosicionJugador;

    // Use this for initialization
    void Start ()
    {
        PosicionJugador = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // movimiento horizontal
        PosicionJugador.x += Input.GetAxis("Horizontal") * VelocidadJugador;
        // movimiento vertical
        PosicionJugador.y += Input.GetAxis("Vertical") * VelocidadJugador;
        // actualiza el valor de la posicion del Transform del objeto Jugador
        transform.position = PosicionJugador;
    }
}
