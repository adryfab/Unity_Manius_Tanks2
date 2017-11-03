using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameControl : MonoBehaviour
{
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

    public void StartGame()
    {
        SceneManager.LoadScene("Escena1");
    }

    public void Color()
    {
        SceneManager.LoadScene("Config");
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
