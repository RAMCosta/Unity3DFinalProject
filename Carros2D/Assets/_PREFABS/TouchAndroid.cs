using UnityEngine;
using System.Collections;

public class TouchAndroid : MonoBehaviour {


	// Use this for initialization
	public string toque= "nada";
	public string posicao= "parado";
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touches.Length <= 0) {
				
		} else {
			for(int i=0; i<Input.touchCount; i++){
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					if (Input.GetTouch (i).phase == TouchPhase.Began) {
						toque = "arrastou";
					}
					if (Input.GetTouch (i).phase == TouchPhase.Ended) {
						toque = "parou";	
					}
				}
			}

		}




	}

	void OnGUI() {
		GUI.Label(new Rect (100,100,300,100), "Tipo de Toque: " + toque);
		GUI.Label(new Rect (150,150,300,150), "Posicao: " + posicao);
	}

}
