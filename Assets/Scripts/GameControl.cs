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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call<bool>("moveTaskToBack", true);
            }
            else
            {
                Application.Quit();
            }
        }

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
