using UnityEngine;
using System.Collections;

public class OpcoesAnim : MonoBehaviour {

	// Use this for initialization
	public GameObject Helicoptero;
	public static bool botaoopcoes = false;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (botaoopcoes == true) {
			if (Helicoptero.transform.position.x > -34.25) { //1.97
				Helicoptero.transform.Translate (-6 * Time.deltaTime, 0, 0);
			}
		}
// ----------------------------------------------- ANDROID ------------------------------------------------------------
		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					botaoopcoes = true;
					VoltarAnim.botaovoltar = false;
				}
			}
		}

	}

	void OnMouseEnter(){
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize + 40;
	}

	void OnMouseExit(){
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize - 40;
	}

	void OnMouseDown(){
		botaoopcoes = true;
		VoltarAnim.botaovoltar = false;
	}

}
