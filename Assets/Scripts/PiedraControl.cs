using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiedraControl : MonoBehaviour
{
    public Image premio;

    private bool premioRecogido;

    void Start ()
    {
        premioRecogido = false;
        ProjectVars.Instance.premioRecogido = premioRecogido;
    }

    void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DisparoPlayer" && ProjectVars.Instance.premioRecogido == false)
        {
            premio.gameObject.SetActive(true);
        }
    }
}
