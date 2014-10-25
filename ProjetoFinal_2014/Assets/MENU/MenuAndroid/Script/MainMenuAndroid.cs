using UnityEngine;
using System.Collections;

public class MainMenuAndroid : MonoBehaviour
{

		public bool jogar = false;
		public bool opcoes = false;
		public bool sair = false;
		public bool voltar = false;
		public bool carros2d = false;
		public bool carros3d = false;
		public bool helicoptero = false;
		public bool mindwave = false;
		public bool gusbamp = false;
		public bool teclado = false;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.touches.Equals (jogar)) {
						Application.LoadLevel ("MenuJogar");
				} else if (Input.touches.Equals (opcoes)) {
						Application.LoadLevel ("MenuOpcoes");	
				} else if (Input.touches.Equals (sair)) {
						Application.Quit ();	
				} else if (Input.touches.Equals (voltar)) {
						Application.LoadLevel ("MainMenu");	
				} else if (Input.touches.Equals (carros2d)) {
						Application.LoadLevel ("MenuCarros2d");	
				} else if (Input.touches.Equals (carros3d)) {
						Application.LoadLevel ("MenuCarros3d");	
				} else if (Input.touches.Equals (helicoptero)) {
						Application.LoadLevel ("MenuHelicoptero");	
				} else if (Input.touches.Equals (mindwave)) {
						//Application.LoadLevel ("MindWave");	
				} else if (Input.touches.Equals (gusbamp)) {
						//Application.LoadLevel ("gusbamp");	
				} else if (Input.touches.Equals (teclado)) {
						//Application.LoadLevel ("teclado");	
				}


		}

		void OnMouseEnter ()
		{
				if (voltar == true) {
						GetComponent<TextMesh> ().fontSize = GetComponent<TextMesh> ().fontSize + 2;
						renderer.material.color = Color.red;
				} else {
						GetComponent<TextMesh> ().fontSize = GetComponent<TextMesh> ().fontSize + 2;
						renderer.material.color = Color.black;
				}
		}
	
		void OnMouseExit ()
		{
				GetComponent<TextMesh> ().fontSize = GetComponent<TextMesh> ().fontSize - 2;
				renderer.material.color = Color.white;
		}
}
