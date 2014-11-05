using UnityEngine;
using System.Collections;

public class Frente : MonoBehaviour {

	// Use this for initialization
	public static bool FrenteTeclado=false;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		FrenteTeclado = true;
	}
}
