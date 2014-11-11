using UnityEngine;
using System.Collections;

public class HeliLivre : MonoBehaviour
{		
		public GameObject explosao;
		public int Pontuacao = 0;
		public string comando;				 // contem a tecla que o utilizador escolheu
		public static float distancia;
		public GameObject Teclado;
		bool Colisao = false;
		bool JogoAcabou = false;
		public Texture pauseGUI;
		bool clickMenuReiniciar = false;
		public GUIStyle TipoLetraFinal;
		int numeroColisao = 0; // Apenas faz a explosao quando bate a primeira vez em algo
		
		// Use this for initialization
		void Start ()
		{
				if (Application.platform == RuntimePlatform.Android) {
						Teclado.SetActive (true);
				} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
						Teclado.SetActive (true);
				} else {
						Teclado.SetActive (false);
				}
				
		}
		
		// Update is called once per frame
		void Update ()
		{
				if (Colisao == false) {
						if (!Input.GetKey (KeyCode.UpArrow) && !FrenteAndroid.FrnAndroid == true) {
								if (this.gameObject.transform.position.y > EscolherAneisTeclado.PosicaoYAneis) {
										this.transform.Translate (new Vector3 (0, -2 * Time.deltaTime, 0));
								}
						}
						this.transform.Translate (new Vector3 (0, 0, 10 * Time.deltaTime));			


						if (Input.GetKey (KeyCode.RightArrow) || DireitaAndroid.DirAndroid == true) {
								this.transform.Rotate (new Vector3 (0, 10 * Time.deltaTime, 0));	
						}
						if (Input.GetKey (KeyCode.LeftArrow) || EsquerdaAndroid.EsqAndroid == true) {
								this.transform.Rotate (new Vector3 (0, -10 * Time.deltaTime, 0));
						}
		
						if (Input.GetKey (KeyCode.UpArrow) || FrenteAndroid.FrnAndroid == true) {
								this.transform.Translate (new Vector3 (0, 2 * Time.deltaTime, 0));
						}
				} else if (Colisao == true && JogoAcabou != true) {
						this.transform.Translate (new Vector3 (0, -10 * Time.deltaTime, 0));	
				} 
			
				if (clickMenuReiniciar == true) {
						Application.LoadLevel ("HelicopteroLivreTeclado");
				}
		}
		
		void  OnCollisionEnter (Collision collision)
		{
				Colisao = true;
				explosao.SetActive (true);
				if (numeroColisao == 0) {
						explosao.audio.Play ();
				}
				this.rigidbody.useGravity = true;
				this.audio.Stop ();
				if (collision.gameObject.name.Contains ("floor") || collision.gameObject.name.Contains ("Terrain") || collision.gameObject.name.Contains ("Street") || numeroColisao == 4) {
						JogoAcabou = true;
						this.GetComponent<RodarHelices> ().enabled = false;
				
						Time.timeScale = 0.0f;
				}
				numeroColisao++;
		}

		void OnGUI ()
		{
		
				if (JogoAcabou == true) {
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), pauseGUI);
						GUI.Label (new Rect ((Screen.width / 4), (Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "FIM DO JOGO", TipoLetraFinal);
						GUI.Label (new Rect ((Screen.width / 8), (3 * Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "Tempo : " + EscolherAneisTeclado.niceTime, TipoLetraFinal);
						GUI.Label (new Rect ((5 * Screen.width / 8), (3 * Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "Pontos : " + PassarAneis.Pontos, TipoLetraFinal);
						if (GUI.Button (new Rect ((Screen.width / 4), (4 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Reiniciar")) {
								clickMenuReiniciar = true;
						}
						if (GUI.Button (new Rect ((Screen.width / 4), (6 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Sair")) {
								Application.LoadLevel ("MainMenu");
						}
				} 	
		}
}
