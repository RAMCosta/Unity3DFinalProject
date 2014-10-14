using UnityEngine;
using System.Collections;

public class JogarAnimacao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter(){
		renderer.material.color = Color.grey;
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize + 40;
		
		//GameObject.Find ("Seta1").renderer.enabled = false;
		//animation.Play ("ResizeUp");
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
		GetComponent<TextMesh>().fontSize = GetComponent<TextMesh> ().fontSize - 40;
		//animation.Play ("ResizeDown");
	}

	void OnMouseDown(){
	/*	float posicaoCamera = GameObject.Find ("Main Camera").transform.position.x;
		while (posicaoCamera < 16.75) {
			GameObject.Find ("Main Camera").transform.Translate (new Vector3 (0.000001f, 0f, 0f));
			posicaoCamera = posicaoCamera+0.000001f;
			Example();
		}*/
		Application.LoadLevel("MenuJogar");
	}
	IEnumerator Example() {
		Debug.Log (Time.time);
		yield return new WaitForSeconds(3);
		Debug.Log (Time.time);
	}
}
