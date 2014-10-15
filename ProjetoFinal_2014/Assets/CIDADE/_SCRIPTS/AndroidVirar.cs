using UnityEngine;
using System.Collections;

public class AndroidVirar : MonoBehaviour {

	public GUITexture SetaEsq;
	public GUITexture SetaDir;
	int velocidadeVirar = 10;
	public GameObject Helicopterozico;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				//VIRAR ESQUERDA
				if(SetaEsq.guiTexture.HitTest(Input.GetTouch(i).position)){
					if (Input.GetTouch (i).phase == TouchPhase.Stationary) {
						transform.Rotate (Vector3.down * Time.deltaTime * velocidadeVirar);
					}	
				}
				//VIRAR DIREITA
				if(SetaDir.guiTexture.HitTest(Input.GetTouch(i).position)){
					if (Input.GetTouch (i).phase == TouchPhase.Stationary) {
						transform.Rotate (Vector3.up * Time.deltaTime * velocidadeVirar);
					}
				}
			}
		}
	}
}
