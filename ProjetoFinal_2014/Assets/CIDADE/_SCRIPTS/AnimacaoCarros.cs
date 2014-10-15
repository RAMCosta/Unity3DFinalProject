using UnityEngine;
using System.Collections;

public class AnimacaoCarros : MonoBehaviour {
	int contador = 0;
	int auxiliar = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > -174 && auxiliar==0) {
			transform.Translate (0, 0, 10 * Time.deltaTime);
		}else{contador = contador +1;}

		if (contador>0 && auxiliar==0) {
			contador=0;
			auxiliar = auxiliar+1;
			transform.Rotate(0,-90,0);
		}

		if (auxiliar>0) {
			transform.Translate (0, 0, 10 * Time.deltaTime);
		}
	}
}
