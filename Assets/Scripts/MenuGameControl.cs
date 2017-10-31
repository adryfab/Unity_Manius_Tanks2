using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameControl : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Escena1");
    }

    public void Color()
    {
        SceneManager.LoadScene("Config");
    }
}
