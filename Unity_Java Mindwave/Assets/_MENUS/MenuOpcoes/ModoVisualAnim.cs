using UnityEngine;
using System.Collections;

public class ModoVisualAnim : MonoBehaviour {

	// Use this for initialization
	public static bool visualmodo = false;
	void Start () {
		if (visualmodo == true) {
			GetComponent<TextMesh> ().color = Color.grey;
		}
	}
	
	// Update is called once per frame
	void Update () {
// ----------------------------------------------- ANDROID ------------------------------------------------------------
		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize + 10;
					GetComponent<TextMesh>().color = Color.grey;
					visualmodo = true;
					TecladoAnim.tecladomodo = false;
					GameObject.Find("TecladoTexto").GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize - 20;
					GameObject.Find("TecladoTexto").GetComponent<TextMesh>().color = Color.black;
				}
			}
		}


	}

	void OnMouseEnter(){
		if (visualmodo == false) {
			GetComponent<TextMesh> ().fontSize = GetComponent<TextMesh> ().fontSize + 10;
		}
	}
	
	void OnMouseExit(){
		if (visualmodo == false) {
			GetComponent<TextMesh> ().fontSize = GetComponent<TextMesh> ().fontSize - 10;
		}
	}

	void OnMouseDown(){
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize + 10;
		GetComponent<TextMesh>().color = Color.grey;
		visualmodo = true;
		TecladoAnim.tecladomodo = false;
		GameObject.Find("TecladoTexto").GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize - 20;
		GameObject.Find("TecladoTexto").GetComponent<TextMesh>().color = Color.black;
	}
}
