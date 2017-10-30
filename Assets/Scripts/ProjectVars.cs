using System.Collections.Generic;
using UnityEngine;

public class ProjectVars : Singleton<ProjectVars> {

	//Variables para instanciar
	public string StringActiveBetweenScenes;
    public bool ganoEscena;
    public int newScene;

	public static ProjectVars Instance {
		get {
			return ((ProjectVars)mInstance);
		} set {
			mInstance = value;
		}
	}

	protected ProjectVars () {}
}
