using UnityEngine;
using System.Collections;

public class TecladoAnim : MonoBehaviour {

	// Use this for initialization
	public static bool tecladomodo = false;
	void Start () {
		if (tecladomodo == true) {
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
					tecladomodo = true;
					ModoVisualAnim.visualmodo = false;
					GameObject.Find("ModoVisualTexto").GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize - 20;
					GameObject.Find("ModoVisualTexto").GetComponent<TextMesh>().color = Color.black;
				}
			}
		}

	}

	void OnMouseEnter(){
		if (tecladomodo == false) {
			GetComponent<TextMesh> ().fontSize = GetComponent<TextMesh> ().fontSize + 10;
		}
	}
	
	void OnMouseExit(){
		if (tecladomodo == false) {
			GetComponent<TextMesh> ().fontSize = GetComponent<TextMesh> ().fontSize - 10;
		}
	}

	void OnMouseDown(){
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize + 10;
		GetComponent<TextMesh>().color = Color.grey;
		tecladomodo = true;
		ModoVisualAnim.visualmodo = false;
		GameObject.Find("ModoVisualTexto").GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize - 20;
		GameObject.Find("ModoVisualTexto").GetComponent<TextMesh>().color = Color.black;
	}
}
