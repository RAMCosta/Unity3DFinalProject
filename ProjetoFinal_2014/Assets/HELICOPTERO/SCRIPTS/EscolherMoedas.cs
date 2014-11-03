using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EscolherMoedas : MonoBehaviour
{

		List<int> ListaMoedas = new List<int> ();
		int ValorRandom = 0;
		int contador = 0;
		public GUIStyle TipoLetra;
		public GUIStyle LetraHoras;
		public GUIStyle TipoLetraFinal;
		public Texture2D PontuacaoTexture;
		string niceTime;
		float timer;
		bool JogoAcabou = false;
		public Texture pauseGUI;
		bool clickMenuReiniciar = false;
		public bool HelicopteroTeclado;
		public bool HelicopteroEstimulos;
		// Use this for initialization
		void Start ()
		{
				while (contador<10) {
						ValorRandom = Random.Range (1, 20);
						if (!ListaMoedas.Contains (ValorRandom)) {
								ListaMoedas.Add (ValorRandom);
								GameObject.Find ("Coin" + ListaMoedas [contador]).SetActive (false);	
								contador++;
						}
				}

		int minutes = Mathf.FloorToInt (timer / 60F);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (ApanharMoedas.Pontuacao == 10) {
						Time.timeScale = 0.0f;
						JogoAcabou = true;
				} else if (HelicopteroEstimulos == true && Tcpheli.conectado == true) {
						timer += Time.deltaTime;
						int minutes = Mathf.FloorToInt (timer / 60F);
						int seconds = Mathf.FloorToInt (timer - minutes * 60);
						niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
					
				} else if (HelicopteroTeclado== true) {
						timer += Time.deltaTime;
						int minutes = Mathf.FloorToInt (timer / 60F);
						int seconds = Mathf.FloorToInt (timer - minutes * 60);
						niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
					
				}

				if (clickMenuReiniciar == true) {
						if (HelicopteroTeclado == true) {
								Application.LoadLevel ("Helicoptero");
						} else if (HelicopteroEstimulos == true) {
								Application.LoadLevel ("EstimulosHelicoptero");
						}
				}
				
		}

		void OnGUI ()
		{

				if (JogoAcabou == true) {
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), pauseGUI);
						GUI.Label (new Rect ((Screen.width / 4), (Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "FIM DO JOGO", TipoLetraFinal);
						GUI.Label (new Rect ((Screen.width / 4), (3 * Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "Tempo : " + niceTime, TipoLetraFinal);
						
						if (GUI.Button (new Rect ((Screen.width / 4), (4 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Reiniciar")) {
								clickMenuReiniciar = true;
						}
						if (GUI.Button (new Rect ((Screen.width / 4), (6 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Sair")) {
								Application.LoadLevel ("MainMenu");
						}
			
				} else {
				
						GUI.contentColor = Color.white;
			
						// Distancia
						if (HelicopteroTeclado == true) {
								GUI.Label (new Rect (23 * Screen.width / 30, 10 * Screen.height / 12, Screen.width / 5, Screen.height / 4), DestinosHelicoptero.distancia + " m", TipoLetra);
						} else if (HelicopteroEstimulos == true) {
								GUI.Label (new Rect (23 * Screen.width / 30, 10 * Screen.height / 12, Screen.width / 5, Screen.height / 4), TCPDestinos.distancia + " m", TipoLetra);
						}

						// Pontuacao
						GUI.DrawTexture (new Rect (Screen.width / 30, 10.5f * Screen.height / 12, Screen.width / 20, Screen.height / 16), PontuacaoTexture);
						GUI.Label (new Rect (3 * Screen.width / 30, 10 * Screen.height / 12, Screen.width / 5, Screen.height / 4), ApanharMoedas.Pontuacao + "/10", TipoLetra);
			
						// Tempo 
						GUI.Label (new Rect (3 * Screen.width / 30, Screen.height / 12, Screen.width / 5, Screen.height / 4), "" + niceTime, LetraHoras);
				}
		}
}
