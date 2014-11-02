using UnityEngine;
using System.Collections;

public class EscolhaEstimulos : MonoBehaviour
{
	
		GameObject VerSeta1;
		GameObject VerSeta2;
		public Sprite[] sprites;
		public static int numeroSeta = 1;
		public static string Seta1Usada = "SetaVermelha";
		public static string Seta2Usada = "SetaAmarela";
		public static int aux = 0;
		// Use this for initialization
		void Start ()
		{
				VerSeta1 = GameObject.Find ("VerSeta1");
				VerSeta2 = GameObject.Find ("VerSeta2");

				VerSeta1.GetComponent<SpriteRenderer> ().sprite = sprites [6];
				VerSeta2.GetComponent<SpriteRenderer> ().sprite = sprites [6];
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		void OnMouseDown ()
		{
				aux++;
				if (aux == 2) {
						GameObject.Find ("VerSetas").GetComponent<PiscarSetas> ().enabled = true;
				}
				if (this.gameObject.name == "SetaAmarela") {
						if (numeroSeta == 1) {
								VerSeta1.GetComponent<SpriteRenderer> ().sprite = sprites [0];
								numeroSeta = 2;
								Seta1Usada = "SetaAmarela";
						} else {
								VerSeta2.GetComponent<SpriteRenderer> ().sprite = sprites [0];
								numeroSeta = 1;
								Seta2Usada = "SetaAmarela";
						}
						
				}
				if (this.gameObject.name == "SetaAzul") {
						if (numeroSeta == 1) {
								VerSeta1.GetComponent<SpriteRenderer> ().sprite = sprites [1];
								numeroSeta = 2;
								Seta1Usada = "SetaAzul";
						} else {
								VerSeta2.GetComponent<SpriteRenderer> ().sprite = sprites [1];
								numeroSeta = 1;
								Seta2Usada = "SetaAzul";
						}
						
				}
				if (this.gameObject.name == "SetaBranca") {
						if (numeroSeta == 1) {
								VerSeta1.GetComponent<SpriteRenderer> ().sprite = sprites [2];
								numeroSeta = 2;
								Seta1Usada = "SetaBranca";
						} else {
								VerSeta2.GetComponent<SpriteRenderer> ().sprite = sprites [2];
								numeroSeta = 1;
								Seta2Usada = "SetaBranca";
						}
						
				}
				if (this.gameObject.name == "SetaVerde") {
						if (numeroSeta == 1) {
								VerSeta1.GetComponent<SpriteRenderer> ().sprite = sprites [3];
								numeroSeta = 2;
								Seta1Usada = "SetaVerde";
						} else {
								VerSeta2.GetComponent<SpriteRenderer> ().sprite = sprites [3];
								numeroSeta = 1;
								Seta2Usada = "SetaVerde";
						}
						
				}
				if (this.gameObject.name == "SetaVermelha") {
						if (numeroSeta == 1) {
								VerSeta1.GetComponent<SpriteRenderer> ().sprite = sprites [4];
								numeroSeta = 2;
								Seta1Usada = "SetaVermelha";
						} else {
								VerSeta2.GetComponent<SpriteRenderer> ().sprite = sprites [4];
								numeroSeta = 1;
								Seta2Usada = "SetaVermelha";
						}		
				}
				if (this.gameObject.name == "SetaCinzenta") {
						if (numeroSeta == 1) {
								VerSeta1.GetComponent<SpriteRenderer> ().sprite = sprites [5];
								numeroSeta = 2;
								Seta1Usada = "SetaCinzenta";
						} else {
								VerSeta2.GetComponent<SpriteRenderer> ().sprite = sprites [5];
								numeroSeta = 1;
								Seta2Usada = "SetaCinzenta";
						}	
				}
				if (this.gameObject.name == "DefinirSeta") {
						aux = 0;
						PiscarSetas.ThreadBlink.Abort();
				}
				
		}
}
