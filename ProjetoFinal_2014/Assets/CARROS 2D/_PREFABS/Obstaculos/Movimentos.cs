using UnityEngine;
using System.Collections;

public class Movimentos : MonoBehaviour {

	public float velocidade = -2;
	public static bool final = false; // Variavel para verificar e esta passou a meta
	// Variavel utilizada porque nao sabia como parar o script Obstaculos e Movimentos devido a haver clonagem dos Obstaculos
	// E utilizada no script Obstaculos(Para verificacao) e MostrarSons, para meter a true quando passa a meta

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(final == false){
			transform.Translate (velocidade*Time.deltaTime, 0, 0);
			if (transform.position.x < -12) {
				this.gameObject.SetActive(false);
				Destroy(this.gameObject);
			}
		}
	}
}
