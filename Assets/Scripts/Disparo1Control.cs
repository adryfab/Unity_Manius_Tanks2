﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo1Control : MonoBehaviour {

    public float velocity = 3f;

    private SpriteRenderer rend;

    private Color _colorDisparo;
    public Color colorDisparo
    {
        get { return _colorDisparo; }
        set { _colorDisparo = value; }
    }

    void Start ()
    {
        rend = this.GetComponent<SpriteRenderer>();
        CambiarColorDisparo();
    }
	
	void Update ()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" && collision.tag != "Disparo")
        {
            Destroy(gameObject);
        }
    }

    private void CambiarColorDisparo()
    {
        //Debug.Log("Disparo1Control - " + colorDisparo);
        //rend.color = colorDisparo;
        //rend.color = new Color(1, 1, 0, 1); //yellow
        //rend.color = new Color(0, 0, 1, 1); //blue
        //rend.color = new Color(1, 0, 0, 1); //red
        //rend.color = new Color(0, 0, 0, 1); //black
        //rend.color = new Color(0, 0, 0, 0); //clear
        //rend.color = new Color(0, 1, 1, 1); //cyan
        //rend.color = new Color(0.5f, 0.5f, 0.5f, 1); //gray
        //rend.color = new Color(0, 1, 0, 1); //green
        //rend.color = new Color(1, 0, 1, 1); //magenta
        rend.color = new Color(1, 1, 1, 1); //white
    }
}
