using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfigControl : MonoBehaviour
{
    public Image imgTank;
    public AudioSource audioGame;

    void Start ()
    {

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
    }

    public void Amarillo()
    {
        imgTank.color = new Color(1, 1, 0, 1); //yellow
        ProjectVars.Instance.PlayerColor = new Color(1, 1, 0, 1); //yellow
    }

    public void Azul()
    {
        imgTank.color = new Color(0, 0, 1, 1); //blue
        ProjectVars.Instance.PlayerColor = new Color(0, 0, 1, 1); //blue
    }

    public void Rojo()
    {
        imgTank.color = new Color(1, 0, 0, 1); //red
        ProjectVars.Instance.PlayerColor = new Color(1, 0, 0, 1); //red
    }

    public void Blanco()
    {
        imgTank.color = new Color(1, 1, 1, 1); //white
        ProjectVars.Instance.PlayerColor = new Color(1, 1, 1, 1); //white
    }

    public void Magenta()
    {
        imgTank.color = new Color(1, 0, 1, 1); //magenta
        ProjectVars.Instance.PlayerColor = new Color(1, 0, 1, 1); //magenta
    }

    public void Verde()
    {
        imgTank.color = new Color(0, 1, 0, 1); //green
        ProjectVars.Instance.PlayerColor = new Color(0, 1, 0, 1); //green
    }

    public void Regresar()
    {
        SceneManager.LoadScene("Menu");
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
