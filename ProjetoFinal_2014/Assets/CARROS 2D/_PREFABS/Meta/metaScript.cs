using UnityEngine;
using System.Collections;

public class metaScript : MonoBehaviour {

	public static float velocidadeMeta = -5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (velocidadeMeta*Time.deltaTime, 0, 0);
		if (transform.position.x < -12) {
			this.gameObject.SetActive(false); 		
		}
	}
}
