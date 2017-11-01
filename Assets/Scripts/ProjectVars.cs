﻿using System.Collections.Generic;
using UnityEngine;

public class ProjectVars : Singleton<ProjectVars> {

	//Variables para instanciar
	public string StringActiveBetweenScenes;
    public bool ganoEscena;
    public int newScene;
    public int maxScene = 3;
    public Color PlayerColor;

	public static ProjectVars Instance {
		get {
			return ((ProjectVars)mInstance);
		} set {
			mInstance = value;
		}
	}

	protected ProjectVars () {}
}