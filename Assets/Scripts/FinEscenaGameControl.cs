using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinEscenaGameControl : MonoBehaviour
{
    public Text txtMensaje;
    public Button btnContinuar;
    //public Image medalla;
    public GameObject MedallaBronce;
    public GameObject MedallaPlata;
    public GameObject MedallaOro;

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
            txtMensaje.text = "VICTORIA";
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
                MedallaBronce.GetComponent<Animation>().Stop();
                MedallaPlata.GetComponent<Animation>().Stop();
                MedallaOro.GetComponent<Animation>().Play();
            }
            else if (tiempo < 20 && tiempo >= 10)
            {
                //***Medalla de plata
                MedallaBronce.GetComponent<Animation>().Stop();
                MedallaPlata.GetComponent<Animation>().Play();
                MedallaOro.GetComponent<Animation>().Stop();
            }
            else if (tiempo < 10)
            {
                //***Medalla de bronce
                MedallaBronce.GetComponent<Animation>().Play();
                MedallaPlata.GetComponent<Animation>().Stop();
                MedallaOro.GetComponent<Animation>().Stop();
            }
        }
        else
        {
            txtMensaje.text = "FIN DEL JUEGO";
            btnContinuar.gameObject.SetActive(false);

            //***Muestra una medalla de perdedor o ninguna medalla
            MedallaBronce.SetActive(false);
            MedallaPlata.SetActive(false);
            MedallaOro.SetActive(false);
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
