﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour
{
    public Text NombreDerecha;
    public Text NombreIzquierda;
    public Text DialogoTexto;
    public Image ImagenDerecha;
    public Image ImagenIzquierda;
    public string SiguienteEscena;

    [Tooltip("Nombre:Dialogo:NumImagen{inicia en 0}:Posicion{I=izquierda,D=derecha}")]
    [TextArea(2, 10)]
    public string Dialogo;

    struct DialogueLine // The data of each line of dialogue
    {
        public string name; //Nombre del personaje
        public string content; //Lo que el personaje dice
        public int pose; //Imagen del personaje
        public string position; //Posicion del personaje

        public DialogueLine(string Name, string Content, int Pose, string Position)
        {
            name = Name;
            content = Content;
            pose = Pose;
            position = Position;
        }
    }

    List<DialogueLine> lines; // Storing the lines in a specific order

    private int lineNum; //Numero de linea que se lee
    private int sceneNum; //Numero de escena que se lee del archivo

    void Start ()
    {
        //string file = "Assets/Data/Dialogos.txt";
        string sceneName = SceneManager.GetActiveScene().name; // Gets the current Scene saved name
        // Regex is a way to manipulate strings
        sceneName = Regex.Replace(sceneName, "[^0-9]", ""); //Replace everything except numbers in the string with ""
        sceneNum = int.Parse(sceneName);

        lines = new List<DialogueLine>();

        //LoadDialogue(file);
        DialogoLoad();
        PanelBotonClick();
    }

    void Update ()
    {

    }

    private void LoadDialogue(string filename)
    {
        string line;
        StreamReader r = new StreamReader(filename);

        using (r)
        {
            do
            {
                line = r.ReadLine();
                if (line != null)
                {
                    string[] lineData = line.Split(':');
                    if (lineData[0] == "Escena"+sceneNum)
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[1], lineData[2], int.Parse(lineData[3]), lineData[4]);
                        lines.Add(lineEntry);
                    }
                }
            }
            while (line != null);
            r.Close();
        }
    }

    private void DialogoLoad()
    {
        if (Dialogo != null)
        {
            using (StringReader reader = new StringReader(Dialogo))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineData = line.Split(':');
                    DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], int.Parse(lineData[2]), lineData[3]);
                    lines.Add(lineEntry);
                }
            }
        }
    }

    public void PanelBotonClick()
    {
        //El usuario le dio clic en el boton oculto del panel
        int linesCount = lines.Count - 1; //Total de lineas a leer
        if (linesCount >= lineNum) //Se verifica que las lineas no sobrepasen
        {
            ShowDialogue(); //Muestra los dialogos
            lineNum++; //Lee la siguiente linea
        }
        else
        {
            //Salir del dialogo
            StartGame();
        }
    }

    private void ShowDialogue()
    {
        ParseLine();
    }

    private void ParseLine()
    {
        DialogoTexto.text = lines[lineNum].content;
        if (lines[lineNum].position == "D") //Derecha
        {
            NombreDerecha.text = lines[lineNum].name;
            NombreDerecha.gameObject.SetActive(true);
            NombreIzquierda.text = "";
            NombreIzquierda.gameObject.SetActive(false);
            ImagenDerecha.gameObject.SetActive(true);
            ImagenIzquierda.gameObject.SetActive(false);
            ImagenDerecha.sprite = ImagenDerecha.GetComponent<Caracter>().ImagenesPersonaje[lines[lineNum].pose];
        }
        else if(lines[lineNum].position == "I") //Izquierda
        {
            NombreDerecha.text = "";
            NombreDerecha.gameObject.SetActive(false);
            NombreIzquierda.text = lines[lineNum].name;
            NombreIzquierda.gameObject.SetActive(true);
            ImagenDerecha.gameObject.SetActive(false);            
            ImagenIzquierda.gameObject.SetActive(true);
            ImagenIzquierda.sprite = ImagenIzquierda.GetComponent<Caracter>().ImagenesPersonaje[lines[lineNum].pose];
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(SiguienteEscena);        
    }
}
