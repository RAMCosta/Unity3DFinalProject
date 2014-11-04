using UnityEngine;
using System.Collections;

public class Direita : MonoBehaviour {

	// Use this for initialization
	public static bool DireitaTeclado=false;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		Debug.Log("DireitaTeclado");
		DireitaTeclado = true;
	}
}
