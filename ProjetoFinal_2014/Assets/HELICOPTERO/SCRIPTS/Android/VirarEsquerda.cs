using UnityEngine;
using System.Collections;

public class VirarEsquerda : MonoBehaviour {

	// Use this for initialization
	public static bool EsquerdaTeclado=false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter(){
		EsquerdaTeclado = true;
	}
}
