using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinEscenaGameControl : MonoBehaviour
{
    public Text txtMensaje;
    public Button btnContinuar;
    public Image medalla;
    public Sprite MedallaBronce;
    public Sprite MedallaPlata;
    public Sprite MedallaOro;

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
        ProjectVars.Instance.newScene = 1;
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
                //***Si es la ultima escena ni muestra botón de Continuar***
                btnContinuar.gameObject.SetActive(false);
            }

            //***Muestra la medalla dependiendo del tiempo
            int tiempo = ProjectVars.Instance.tiempoGanador;
            if (tiempo >= 20)
            {
                //***Medalla de oro
                medalla.sprite = MedallaOro;
            }
            else if (tiempo < 20 && tiempo >= 10)
            {
                //***Medalla de plata
                medalla.sprite = MedallaPlata;
            }
            else if (tiempo < 10)
            {
                //***Medalla de bronce
                medalla.sprite = MedallaBronce;
            }
        }
        else
        {
            txtMensaje.text = "¡Perdiste!";
            btnContinuar.gameObject.SetActive(false);

            //***Muestra una medalla de perdedor
            medalla.sprite = null;
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
