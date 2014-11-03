using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

		bool pause = false;
		bool clickMenuVoltar = false;
		bool clickMenuReiniciar = false;
		public Texture pauseGUI;
		public bool HelicopteroTecladoScene;
		public bool HelicopteroGusbampScene;
		public bool Carros3DTecladoScene;
		public bool Carros3DGusbampScene;
		public bool Carros2DTecladoScene;
		public bool Carros2DMindwaveScene;

		void Start ()
		{
				//pauseGUI.enabled = false;
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape) || clickMenuVoltar == true) {
						clickMenuVoltar = false;
						if (pause == true) {
								pause = false;
								if (HelicopteroTecladoScene || HelicopteroGusbampScene) {
										GameObject.Find ("Helicoptero").audio.Play ();
								}
								if (Carros2DTecladoScene || Carros2DMindwaveScene) {
										GameObject.Find ("Camera").audio.Play ();
								}
								if (Carros3DTecladoScene || Carros3DGusbampScene) {
										GameObject.Find ("TAXI").audio.Play ();
								}
						} else {
								pause = true;
						}
						if (pause == true) {
								if (HelicopteroTecladoScene || HelicopteroGusbampScene) {
										GameObject.Find ("Helicoptero").audio.Pause ();
								}
								if (Carros2DTecladoScene || Carros2DMindwaveScene) {
										GameObject.Find ("Camera").audio.Pause ();
								}
								if (Carros3DTecladoScene || Carros3DGusbampScene) {
										GameObject.Find ("TAXI").audio.Pause ();
								}

								Time.timeScale = 0.0f;
						} else {
								Time.timeScale = 1.0f;
						}
				}

				if (clickMenuReiniciar == true) {
				
						if (HelicopteroTecladoScene) {
								Application.LoadLevel ("Helicoptero");
						}else if (HelicopteroGusbampScene) {
								Application.LoadLevel ("HelicopteroEstimulos");
						}else if (Carros3DTecladoScene) {
								Application.LoadLevel ("AutoNavegacaoCarro");
						}else if (Carros3DGusbampScene) {
								Application.LoadLevel ("Carro3DEstimulos");
						}else if (Carros2DTecladoScene) {
								Application.LoadLevel ("Carros2D");
						}else if (Carros2DMindwaveScene) {
								Application.LoadLevel ("Carros2D_Mindwave");
						}
			clickMenuReiniciar = false;
				}
		}

		void OnGUI ()
		{
				if (pause == true) {

						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), pauseGUI);

						GUI.color = Color.yellow;

						if (GUI.Button (new Rect ((Screen.width / 4), (Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Voltar ao Jogo")) {
								clickMenuVoltar = true;
						}
						if (GUI.Button (new Rect ((Screen.width / 4), (3 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Reiniciar")) {
								clickMenuReiniciar = true;
						}
						if (GUI.Button (new Rect ((Screen.width / 4), (5 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Sair")) {
								Application.LoadLevel ("MainMenu");
						}
				}
		}
}
