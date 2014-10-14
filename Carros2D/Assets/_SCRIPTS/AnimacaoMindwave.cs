using UnityEngine;
using System.Collections;

public class AnimacaoMindwave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("SetaMindwave").renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		GameObject.Find ("SetaMindwave").renderer.enabled = true;
	}
	
	void OnMouseExit(){
		GameObject.Find ("SetaMindwave").renderer.enabled = false;
	}

	void OnMouseDown(){
		Application.LoadLevel("Carros2D_Mindwave");
	}
}
