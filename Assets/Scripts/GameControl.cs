using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameControl : MonoBehaviour
{
    public Text timer;
    public AudioSource audioGame;
    public string proximaEscena;

    private EnemyControl enemyCtr;
    private int TiempoEscena;
    private float timeLeft;

    void Start ()
    {
        enemyCtr = FindObjectOfType<EnemyControl>();
        TiempoEscena = Int32.Parse(timer.text);
        timeLeft = TiempoEscena;
    }

    void Update ()
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

        //***Finalizando juego - Ya no hay enemigos***        
        enemyCtr = FindObjectOfType<EnemyControl>();
		if (enemyCtr == null) 
		{
            //***Ganó el juego***
            ProjectVars.Instance.tiempoGanador = TiempoEscena; //***Tiempo que tomó en ganar***
            finJuego(true);
		}

        //***Actualizando el tiempo restante***
        ActualizarTiempo();
    }

    public void clickReinicio()
    {
        SceneManager.LoadScene("Escena01");
    }

    public void finJuego(bool gana)
    {
        ProjectVars.Instance.ganoEscena = gana;
        int escenaActual = ProjectVars.Instance.newScene;
        if (escenaActual == 0)
        {
            escenaActual = 1;
        }
        ProjectVars.Instance.newScene = escenaActual + 1;
        ProjectVars.Instance.ProximaEscena = proximaEscena;
        SceneManager.LoadScene("FinEscena");
    }

    private void ActualizarTiempo()
    {
        timeLeft -= Time.deltaTime;
        TiempoEscena = (int)timeLeft;
        timer.text = TiempoEscena.ToString();
        if (TiempoEscena <= 0)
        {
            //***Perdió el juego por falta de tiempo***
            finJuego(false);
        }
    }

    public void AudioEncendido()
    {
        if (ProjectVars.Instance.AudioEncendido == true)
        {
            audioGame.Stop();
            ProjectVars.Instance.AudioEncendido = false;
        }
        else
        {
            audioGame.Play();
            ProjectVars.Instance.AudioEncendido = true;
        }
    }
}
