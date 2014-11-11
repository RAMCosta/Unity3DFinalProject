using UnityEngine;
using System.Collections;

public class MostrarSons : MonoBehaviour {
	
	public AudioClip[] audioclip;
	private int pontuacao = 10000;
	private float Tempo = 120;
	public GUIStyle TipoLetraFinal;
	public Texture pauseGUI;
	bool clickMenuReiniciar = false;
	bool JogoAcabou = false;
	public bool Carros2D;
	public bool Carros2DMindwave;
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

		if (clickMenuReiniciar == true) {
			if(Carros2D){Application.LoadLevel ("Carros2D");}
			if(Carros2DMindwave){Application.LoadLevel ("Carros2D_Mindwave");}
		}
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
			JogoAcabou = true;
			Time.timeScale = 0.0f;
		}
		
	}
	
	void OnGUI ()
	{
		
		if (JogoAcabou == true) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), pauseGUI);
			GUI.Label (new Rect ((Screen.width / 4), (Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "FIM DO JOGO", TipoLetraFinal);
			GUI.Label (new Rect ((Screen.width / 4), (3 * Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "Pontos : " + pontuacao, TipoLetraFinal);
			if (GUI.Button (new Rect ((Screen.width / 4), (4 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Reiniciar")) {
				clickMenuReiniciar = true;
			}
			if (GUI.Button (new Rect ((Screen.width / 4), (6 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Sair")) {
				Application.LoadLevel ("MainMenu");
			}
		}
	}
}

