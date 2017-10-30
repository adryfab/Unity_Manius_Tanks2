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

    private EnemyControl enemyCtr;

    void Start ()
    {
        btnReinicio.onClick.AddListener(clickReinicio);
        enemyCtr = FindObjectOfType<EnemyControl>();
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

        //***Finalizando juego***        
        enemyCtr = FindObjectOfType<EnemyControl>();
		if (enemyCtr == null) 
		{
			finJuego (true);
		}
    }

    public void clickReinicio()
    {
        SceneManager.LoadScene("Escena01");
    }

    public void finJuego(bool gana)
    {
        ProjectVars.Instance.ganoEscena = gana;
        ProjectVars.Instance.newScene = 2;
        SceneManager.LoadScene("FinEscena");
    }
}
