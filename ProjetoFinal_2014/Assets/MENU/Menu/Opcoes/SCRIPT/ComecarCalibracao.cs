using UnityEngine;
using System.Collections;

public class ComecarCalibracao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		GameObject.Find ("Main Camera").GetComponent<Calibracao> ().enabled = true;
		GameObject.Find ("VerSetas").GetComponent<CalibracaoPiscarSetas> ().enabled = true;
	}
}
