using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	// Use this for initialization
	public float velocidade;
	void Start () {
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,Input.GetAxis ("Vertical")*Time.deltaTime*velocidade, -5); // mexer conforme a tecla
		transform.position = new Vector3(-10, transform.position.y, -2); //Nao deixar mover o eixo Y
	}
}
