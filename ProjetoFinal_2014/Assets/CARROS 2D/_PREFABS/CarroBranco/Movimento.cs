using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	// Use this for initialization
	public float velocidade;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (ServidorTCP.comand.Equals("A")){

			ServidorTCP.comand = "";
			Debug.Log("Fui para cima");

		transform.Translate (0,2, -5); // mexer conforme a tecla
		transform.position = new Vector3(-7, transform.position.y, -2); //Nao deixar mover o eixo Y
		}
	}
}
