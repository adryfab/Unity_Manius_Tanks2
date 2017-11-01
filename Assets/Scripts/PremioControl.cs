using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PremioControl : MonoBehaviour
{
    public Image premio;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DisparoPlayer")
        {
            premio.gameObject.SetActive(true);
        }
    }
}
