using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EscolherAneisTeclado : MonoBehaviour
{
	
		List<int> ListaAneis = new List<int> ();
		int ValorRandom = 0;
		int contador = 0;
		string AneisApanhados;
		public GUIStyle TipoLetra;
		public GUIStyle LetraHoras;
		public GUIStyle TipoLetraFinal;
		public Texture2D PontuacaoTexture;
		public static string niceTime;
		float timer;
		bool JogoAcabou = false;
		public Texture pauseGUI;
		bool clickMenuReiniciar = false;
		public GameObject[] Aneis;
		public GameObject SetasAuxiliares;
		public static float PosicaoYAneis = 0;
		public GameObject Helicoptero;
		int distancia;
		public GUIText PontuacaoGUI;
		public GUIText DistanciaGUI;
		public GUIText TempoGUI;
		// Use this for initialization
		void Start ()
		{
		clickMenuReiniciar = false;
		JogoAcabou = false;
		ValorRandom = 0;
		contador = 0;

			// Escolha aleatoria de oito numeros em dezasseis
				while (contador<8) {
						ValorRandom = Random.Range (1, 16);
						// verificar se o numero nao existe na lista
						if (!ListaAneis.Contains (ValorRandom)) {
								// Adicionar os numeros a lista
								ListaAneis.Add (ValorRandom);
								contador++;
						}
				}
				

				int minutes = Mathf.FloorToInt (timer / 60F);
				int seconds = Mathf.FloorToInt (timer - minutes * 60);
				niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
				Time.timeScale = 1.0f;
		}
	
		// Update is called once per frame
		void Update ()
		{	
				distancia = (int)Vector3.Distance (Helicoptero.transform.position, Aneis [int.Parse (ListaAneis [PassarAneis.Pontos].ToString ())].transform.position);
				DistanciaGUI.guiText.text = distancia + "m";
				PontuacaoGUI.guiText.text = PassarAneis.Pontos + "/10";
				TempoGUI.guiText.text = niceTime;
		// Associacao da lista ao Anel, sendo o variavel PassarAneis os pontos do utilizador
		// como cada anel vale um ponto, este percorre a lista toda
				Aneis [int.Parse (ListaAneis [PassarAneis.Pontos].ToString ())].SetActive (true);
				PosicaoYAneis = Aneis [int.Parse (ListaAneis [PassarAneis.Pontos].ToString ())].transform.position.y;
				SetasAuxiliares.transform.LookAt (Aneis [int.Parse (ListaAneis [PassarAneis.Pontos].ToString ())].transform);
				
				if (PassarAneis.Pontos == 8) {
						Time.timeScale = 0.0f;
						JogoAcabou = true;
				} else { //if ( Tcpheli.conectado == true)
						timer += Time.deltaTime;
						int minutes = Mathf.FloorToInt (timer / 60F);
						int seconds = Mathf.FloorToInt (timer - minutes * 60);
						niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

				}
			if (clickMenuReiniciar == true) {
				Application.LoadLevel ("HelicopteroLivreTeclado");
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
				} 	
		}
}
