using UnityEngine;
using System.Collections;

public class JogarAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// ----------------------------------------------- ANDROID ------------------------------------------------------------
		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					OpcoesAnim.botaoopcoes = false;
					Application.LoadLevel("GoodCity Android");
				}
			}
		}


	}

	void OnMouseEnter(){
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize + 40;
	}
	void OnMouseExit(){
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize - 40;
		//animation.Play ("ResizeDown");
	}
	void OnMouseDown(){
		OpcoesAnim.botaoopcoes = false;
		Application.LoadLevel("GoodCity Android");
	}
}
