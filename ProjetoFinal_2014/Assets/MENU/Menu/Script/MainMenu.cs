using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
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
		public GUIText FreqEsq;
		public GUIText FreqDir;
		public GUIText FreqFrente;
		public static int FreqEsqVal = 4;
		public static int FreqDirVal = 4;
		public static int FreqFrenteVal = 4;
 
		// Use this for initialization
		void Start ()
		{
				FreqEsq.text = "" + FreqEsqVal;
				FreqDir.text = "" + FreqDirVal;
				FreqFrente.text = "" + FreqFrenteVal;

		}
	
		// Update is called once per frame
		void Update ()
		{
	
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

		void OnMouseDown ()
		{
				//********************************** Frequencias ******************************

				if (this.gameObject.name == "MenosFreqEsq") {
						FreqEsqVal--;
						FreqEsq.GetComponent<TextMesh> ().text = "" + FreqEsqVal;
				} else if (this.gameObject.name == "MaisFreqEsq") {
						FreqEsqVal++;
						FreqEsq.GetComponent<TextMesh> ().text = "" + FreqEsqVal;
				} else if (this.gameObject.name == "MenosFreqDir") {
						FreqDirVal--;
						FreqDir.GetComponent<TextMesh> ().text = "" + FreqDirVal;
				} else if (this.gameObject.name == "MaisFreqDir") {
						FreqDirVal++;
						FreqDir.GetComponent<TextMesh> ().text = "" + FreqDirVal;
				} else if (this.gameObject.name == "MenosFreqFrente") {
						FreqFrenteVal--;
						FreqFrente.GetComponent<TextMesh> ().text = "" + FreqFrenteVal;
				} else if (this.gameObject.name == "MaisFreqFrente") {
						FreqFrenteVal++;
						FreqFrente.GetComponent<TextMesh> ().text = "" + FreqFrenteVal;
				}

				//********************************** Menus ************************************
				if (jogar == true) {
						opcoes = false;
						sair = false;
						voltar = false;
						Application.LoadLevel ("MenuJogar");
				} else if (opcoes == true) {
						jogar = false;
						sair = false;
						voltar = false;
						Application.LoadLevel ("MenuOpcoes");
				} else if (sair == true) {
						jogar = false;
						opcoes = false;
						voltar = false;
						Application.Quit ();
				} else if (voltar == true) {
						helicoptero = false;
						carros2d = false;
						carros3d = false;
						Application.LoadLevel ("MainMenu");
				} else if (carros2d == true) {
						helicoptero = false;
						carros3d = false;
						voltar = false;
						Application.LoadLevel ("MenuCarros2d");
				} else if (carros3d == true) {
						helicoptero = false;
						carros2d = false;
						voltar = false;
						Application.LoadLevel ("MenuCarros3d");
				} else if (helicoptero == true) {
						carros2d = false;
						carros3d = false;
						voltar = false;
						Application.LoadLevel ("MenuHelicoptero");
				} else if (mindwave == true) {
						teclado = false;
						gusbamp = false;
						voltar = false;
						//Application.LoadLevel("MindWave");
				} else if (gusbamp == true) {
						mindwave = false;
						teclado = false;
						voltar = false;
						//Application.LoadLevel("gusbamp");
				} else if (teclado == true) {
						mindwave = false;
						gusbamp = false;
						voltar = false;
						//Application.LoadLevel("teclado");
				}
		}
}