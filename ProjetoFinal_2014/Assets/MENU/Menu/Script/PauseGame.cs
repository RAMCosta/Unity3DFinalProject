using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

		bool pause = false;
		bool clickMenuReiniciar = false;
		public Texture pauseGUI;
		public bool HelicopteroTecladoScene;
		public bool HelicopteroGusbampScene;
		public bool HelicopteroLivre;
		public bool Carros3DTecladoScene;
		public bool Carros3DGusbampScene;
		public bool Carros2DTecladoScene;
		public bool Carros2DMindwaveScene;
		public bool Carros2DAndroid;
		public bool Taxi3DTecladoScene;
		public bool Taxi3DGusBampScene;

		void Start ()
		{
				//pauseGUI.enabled = false;
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						if (pause == true) {

								if (HelicopteroTecladoScene || HelicopteroGusbampScene || HelicopteroLivre) {
										GameObject.Find ("Helicoptero").audio.Play ();
								}
								if (Carros2DTecladoScene || Carros2DMindwaveScene || Carros2DAndroid) {
										GameObject.Find ("Camera").audio.Play ();
								}
								if (Carros3DTecladoScene || Carros3DGusbampScene || Taxi3DTecladoScene || Taxi3DGusBampScene) {
										GameObject.Find ("TAXI").audio.Play ();
								}
								Time.timeScale = 1.0f;
								
								pause = false;
								
						} else if (pause == false) {
								if (HelicopteroTecladoScene || HelicopteroGusbampScene || HelicopteroLivre) {
										GameObject.Find ("Helicoptero").audio.Pause ();
								}
								if (Carros2DTecladoScene || Carros2DMindwaveScene || Carros2DAndroid) {
										GameObject.Find ("Camera").audio.Pause ();
								}
								if (Carros3DTecladoScene || Carros3DGusbampScene || Taxi3DTecladoScene || Taxi3DGusBampScene) {
										GameObject.Find ("TAXI").audio.Pause ();
								}
								Time.timeScale = 0.0f;
								pause = true;
						} 
				}

				if (clickMenuReiniciar == true) {
				
						if (HelicopteroTecladoScene) {
								Application.LoadLevel ("Helicoptero");
						} else if (HelicopteroGusbampScene) {
								Application.LoadLevel ("HelicopteroEstimulos");
						} else if (HelicopteroLivre) {
								Application.LoadLevel ("HelicopteroLivre");
						} else if (Carros3DTecladoScene) {
								Application.LoadLevel ("Carro3DTeclado");
						} else if (Carros3DGusbampScene) {
								Application.LoadLevel ("Carro3DGusBamp");
						} else if (Carros2DTecladoScene) {
								Application.LoadLevel ("Carros2D");
						} else if (Carros2DMindwaveScene) {
								Application.LoadLevel ("Carros2D_Mindwave");
						} else if (Carros2DAndroid) {
								Application.LoadLevel ("Carros2D_Android");
						} else if (Taxi3DTecladoScene) {
								Application.LoadLevel ("Taxi3DTeclado");
						} else if (Taxi3DGusBampScene) {
								Application.LoadLevel ("Taxi3DGusBamp");
						}
						clickMenuReiniciar = false;
				}
		}

		void OnGUI ()
		{
				if (pause == true) {

						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), pauseGUI);

						GUI.color = Color.yellow;

						if (GUI.Button (new Rect ((Screen.width / 4), (3 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Reiniciar")) {
								clickMenuReiniciar = true;
						}
						if (GUI.Button (new Rect ((Screen.width / 4), (5 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Sair")) {
								Application.LoadLevel ("MainMenu");
						}
						
				}
		}
}
