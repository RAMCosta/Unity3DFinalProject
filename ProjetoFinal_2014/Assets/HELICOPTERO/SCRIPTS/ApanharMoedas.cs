using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApanharMoedas : MonoBehaviour
{
	// variavel static para poder ser acessada nos script HeliLivre e TCPHeliLivre
	public static int Pontuacao= 0;

	void Start(){
		Pontuacao= 0;
	}
	// OnTriggerEnter() e onde e detetada a colisao
	void OnTriggerEnter (Collider collision)
	{
		// Reproduzir o som - esta na camera, devido a camera conter o AudioListener
		GameObject.Find ("Main Camera").audio.Play ();
		// Desativa a moeda
		this.gameObject.SetActive (false);
		// Aumenta a pontuacao
		Pontuacao += 1;
	}		
}
