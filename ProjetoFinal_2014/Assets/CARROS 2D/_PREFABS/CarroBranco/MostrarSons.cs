using UnityEngine;
using System.Collections;

public class MostrarSons : MonoBehaviour {
	
	public AudioClip[] audioclip;
	private int pontuacao = 10000;
	private float Tempo = 120;
	// Use this for initialization
	
	void Start () {
		metaScript.velocidadeMeta = 0f;
		//PlaySound (0);
	}
	// Update is called once per frame
	void Update () {
		GameObject.Find("Pontuacaozica").guiText.text = "Pontuacao: " + pontuacao;
		if (Tempo > 1) { 
			Tempo -= Time.deltaTime;
		} else {
			Tempo = 0;
		}
		if (Tempo < 5) {
			metaScript.velocidadeMeta = -5f;
		}
		GameObject.Find("TempoJogo").guiText.text = "Tempo de Jogo: " + Mathf.Floor(Tempo) + " seg.";
	}
	
	void PlaySound(int numberClip){
		audio.clip = audioclip [numberClip];
		audio.Play ();
	}

	void OnCollisionEnter2D(Collision2D ObjectoColisao) {
		if (ObjectoColisao.gameObject.name == "Barreira(Clone)") {
			audio.Stop();
			PlaySound(0);
			pontuacao = pontuacao - 5;
		}
		if (ObjectoColisao.gameObject.name == "Bidon(Clone)") {
			audio.Stop();
			PlaySound(1);
			pontuacao = pontuacao - 3;
		}
		if (ObjectoColisao.gameObject.name == "Buraco(Clone)") {
			audio.Stop();
			PlaySound(2);
			pontuacao = pontuacao - 2;
		}
		if (ObjectoColisao.gameObject.name == "Pino(Clone)") {
			audio.Stop();
			PlaySound(3);
			pontuacao = pontuacao - 1;
		}
		if (ObjectoColisao.gameObject.name == "Coelho(Clone)") {
			audio.Stop();
			PlaySound(4);
			pontuacao = pontuacao - 2;
		}
		if (ObjectoColisao.gameObject.name == "Meta") {
			audio.Stop();
			PlaySound(5);
		//	GameObject.Find("Cenario").SetActive(false);
		//	GameObject.Find("Cenario2").SetActive(false);
			GameObject.Find("Camera").audio.Stop();
			(GameObject.Find("Cenario").GetComponent(typeof(MovEstrada)) as MovEstrada).enabled = false; //Desativar Script de movimento da estrada
			(GameObject.Find("Cenario2").GetComponent(typeof(MovEstrada)) as MovEstrada).enabled = false;
			(GameObject.Find("Meta").GetComponent(typeof(metaScript)) as metaScript).enabled = false;
			Movimentos.final = true;
			/*(GameObject.Find("Barreira(Clone)").GetComponent(typeof(Obstaculos)) as Obstaculos).enabled = false;
			(GameObject.Find("Pino(Clone)").GetComponent(typeof(Obstaculos)) as Obstaculos).enabled = false;
			(GameObject.Find("Coelho(Clone)").GetComponent(typeof(Obstaculos)) as Obstaculos).enabled = false;*/
		}
		
	}
	
	/*void OnGUI() {
		GUI.Label(new Rect (500,4,100,100), pontuacao + " pontos");
		GUI.Label(new Rect (850,4,100,100), "Tempo: " + Tempo);
	}*/
}

