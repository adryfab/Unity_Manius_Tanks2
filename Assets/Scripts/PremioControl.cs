﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremioControl : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ProjectVars.Instance.premioRecogido = true;
            Destroy(gameObject);
        }
    }
}
