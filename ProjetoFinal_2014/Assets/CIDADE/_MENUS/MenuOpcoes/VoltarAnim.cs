using UnityEngine;
using System.Collections;

public class VoltarAnim : MonoBehaviour {

	// Use this for initialization
	public GameObject Helicoptero;
	public static bool botaovoltar = false;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (botaovoltar == true) {
			if (Helicoptero.transform.position.x < (-17.244)) { //16.1
				Helicoptero.transform.Translate ((6 * Time.deltaTime), 0, 0);
			}
		}
// ----------------------------------------------- ANDROID ------------------------------------------------------------
		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					OpcoesAnim.botaoopcoes = false;
					botaovoltar = true;
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
		OpcoesAnim.botaoopcoes = false;
		botaovoltar = true;
	}
}
