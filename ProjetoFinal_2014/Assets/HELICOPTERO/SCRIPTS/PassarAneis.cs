using UnityEngine;
using System.Collections;

public class PassarAneis : MonoBehaviour {

	public static int Pontos= 0;
	
	
	void OnTriggerEnter (Collider collision)
	{
		
		GameObject.Find ("Main Camera").audio.Play ();
		this.gameObject.SetActive (false);
		Pontos += 1;
	}
	
	
}
