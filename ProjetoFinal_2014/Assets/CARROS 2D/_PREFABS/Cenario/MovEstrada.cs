using UnityEngine;
using System.Collections;

public class MovEstrada : MonoBehaviour {

	public float velocidade = -2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (velocidade*Time.deltaTime, 0, 0);
		if (transform.position.x < -11) {
			transform.position = new Vector2(36, transform.position.y); 		
		}
	}
}
