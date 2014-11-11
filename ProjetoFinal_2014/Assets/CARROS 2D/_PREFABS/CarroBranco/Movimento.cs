using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	// Use this for initialization
	public float velocidade;
	public GameObject Setas;
	void Start () {
		if (Application.platform == RuntimePlatform.Android) {
			Setas.SetActive(true);
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Setas.SetActive(true);
		} else {
			Setas.SetActive(false);
		}
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,Input.GetAxis ("Vertical")*Time.deltaTime*velocidade, -5); // mexer conforme a tecla
		transform.position = new Vector3(-8, transform.position.y, -2); //Nao deixar mover o eixo Y
	}
}
