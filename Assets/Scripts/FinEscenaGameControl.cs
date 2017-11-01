using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinEscenaGameControl : MonoBehaviour
{
    public Text txtMensaje;
    public Button btnContinuar;

    private int escena;

    void Start ()
    {
        GanoEscena();
    }
	
	void Update ()
    {
        SalirJuego();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SalirJuego()
    {
        //***Saliendo del juego***
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

    private void GanoEscena()
    {
        bool gana = ProjectVars.Instance.ganoEscena;
        escena = ProjectVars.Instance.newScene;
        if (gana == true)
        {
            txtMensaje.text = "¡Ganaste!";
            if (escena <= ProjectVars.Instance.maxScene)
            {
                btnContinuar.gameObject.SetActive(true);
            }
            else
            {
                btnContinuar.gameObject.SetActive(false);
            }
        }
        else
        {
            txtMensaje.text = "¡Perdiste!";
            btnContinuar.gameObject.SetActive(false);
        }
    }

    public void SiguienteEscena()
    {
        escena = ProjectVars.Instance.newScene;
        if (escena <= ProjectVars.Instance.maxScene)
        {
            SceneManager.LoadScene("Escena" + escena);
        }
    }
}
