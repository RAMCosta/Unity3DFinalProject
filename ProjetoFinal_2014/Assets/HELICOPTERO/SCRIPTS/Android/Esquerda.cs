using UnityEngine;
using System.Collections;

public class Esquerda : MonoBehaviour {

	// Use this for initialization
	public static bool EsquerdaTeclado=false;
	
	public Texture Esq;
	
	void Start () {
		if (Application.platform == RuntimePlatform.Android) {
			this.guiTexture.texture = Esq;
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			this.guiTexture.texture = Esq;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		Debug.Log("EsquerdaTeclado");
		EsquerdaTeclado = true;
	}
}