using UnityEngine;
using System.Collections;

public class AnimacaoWindows : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("SetaWindows").renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		GameObject.Find ("SetaWindows").renderer.enabled = true;
	}
	
	void OnMouseExit(){
		GameObject.Find ("SetaWindows").renderer.enabled = false;
	}

	void OnMouseDown(){
		Application.LoadLevel("Carros2D");
	}

}
