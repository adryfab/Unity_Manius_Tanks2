using System.Collections.Generic;
using UnityEngine;

public class ProjectVars : Singleton<ProjectVars> {

	//Variables para instanciar
	public string StringActiveBetweenScenes;
    public bool ganoEscena;
    public int newScene;
    public int maxScene = 4;
    public Color PlayerColor;
    public int tiempoGanador;
    public bool premioRecogido;
    public bool AudioEncendido = true;
    public string ProximaEscena;

	public static ProjectVars Instance {
		get {
			return ((ProjectVars)mInstance);
		} set {
			mInstance = value;
		}
	}

	protected ProjectVars () {}
}
