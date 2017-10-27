using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public Button btnReinicio;
    public Canvas cvnFin;
    public Text txtFin;

	void Start ()
    {
        btnReinicio.onClick.AddListener(clickReinicio);
    }
	
	void Update ()
    {
		
	}

    public void clickReinicio()
    {
        SceneManager.LoadScene("Escena01");
    }

    public void finJuego(string mensaje)
    {
        //btnReinicio.gameObject.SetActive(true);
        cvnFin.gameObject.SetActive(true);
        txtFin.text = mensaje;
    }
}
