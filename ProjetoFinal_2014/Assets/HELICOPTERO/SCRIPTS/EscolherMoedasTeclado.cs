using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EscolherMoedasTeclado : MonoBehaviour
{

		List<int> ListaMoedas = new List<int> ();
		int ValorRandom = 0;
		int contador = 0;
		public GUIStyle TipoLetra;
		public GUIStyle LetraHoras;
		public GUIStyle TipoLetraFinal;
		public Texture2D PontuacaoTexture;
		string niceTime; // TESTE
		float timer;
		bool JogoAcabou = false;
		public Texture pauseGUI;
		bool clickMenuReiniciar = false;
		public bool HelicopteroTeclado;
		public bool HelicopteroEstimulos;
		public GUIText PontuacaoGUI;
		public GUIText TempoGUI;
		float distancia;
		public GameObject DirectionRight;
		public GameObject DirectionLeft;
		public GameObject DirectionMiddle;
		public GameObject[] Moedas;
		// Use this for initialization
		void Start ()
		{
		for (int i=0; i<=19; i++) {
			Moedas[i].SetActive(false);
		}
				while (contador<10) {
						ValorRandom = Random.Range (0, 20);
						if (!ListaMoedas.Contains (ValorRandom)) {
								ListaMoedas.Add (ValorRandom);
								Moedas[ListaMoedas [contador]].SetActive (true);	
								contador++;
						}
				}

				int minutes = Mathf.FloorToInt (timer / 60F);
				int seconds = Mathf.FloorToInt (timer - minutes * 60);
				niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

				DirectionRight.SetActive (false);
				DirectionLeft.SetActive (false);
		}
	
		// Update is called once per frame
		void Update ()
		{
				int dir = NextDirection ();
				if (dir == 1) {
						DirectionRight.SetActive (true);
						DirectionMiddle.SetActive (false);
						DirectionLeft.SetActive (false);
				} else if (dir == -1) {
						DirectionLeft.SetActive (true);
						DirectionMiddle.SetActive (false);
						DirectionRight.SetActive (false);
				} else {
						DirectionLeft.SetActive (false);
						DirectionMiddle.SetActive (true);
						DirectionRight.SetActive (false);
				}

				PontuacaoGUI.guiText.text = ApanharMoedas.Pontuacao + "/10";
				TempoGUI.guiText.text = niceTime; 

				if (ApanharMoedas.Pontuacao == 10) {
						Time.timeScale = 0.0f;
						JogoAcabou = true;
				} else if (HelicopteroEstimulos == true && Tcpheli.conectado == true) {
						timer += Time.deltaTime;
						int minutes = Mathf.FloorToInt (timer / 60F);
						int seconds = Mathf.FloorToInt (timer - minutes * 60);
						niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
					
				} else if (HelicopteroTeclado == true) {
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

		public int NextDirection ()
		{
				int direcao = 0;
				Vector3 h = GameObject.Find ("Destino" + DestinosHelicoptero.NumeroDestino).transform.position;
				distancia = 1000000;
				for (int i=0; i<ListaMoedas.Count; i++) {
						string name = "Coin" + ListaMoedas [i];
						if (Moedas[ListaMoedas [i]].activeSelf == true) {
						Vector3 m = Moedas[ListaMoedas [i]].transform.position;

								float h2 = Vector3.Distance (h, m);
								if (h2 < distancia) {
										distancia = h2;
										if (h.x < m.x) {
												direcao = 1;
										} else {
												direcao = -1;
										}
								}
						}
				}
				//Debug.Log ("direcao: " + direcao);
				//Debug.Log ("Helicoptero : " + h);
				//Debug.Log ("LM : " + ListaMoedas.Count);
				return direcao;
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
				}
		}
}
