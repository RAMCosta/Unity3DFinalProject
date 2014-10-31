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
		public bool MenosFreqEsq = false;
		public bool MenosFreqDir = false;
		public bool MenosFreqFrente = false;
		public bool MaisFreqEsq = false;
		public bool MaisFreqDir = false;
		public bool MaisFreqFrente = false;
		public bool OpcoesFreq = false;
		public bool OpcoesEscEsti = false;
		public bool OpcoesCalibrar = false;
		public static int FreqEsqVal = 4;
		public static int FreqFrenteVal = 14;	
		public static int FreqDirVal = 16;
		
		public static bool DefFreqManual = true;
 
		// Use this for initialization
		void Start ()
		{

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
				if (this.name == "MenosFreqEsq") {
						if (FreqEsqVal == 4) {
								FreqEsqVal += 1;
						} else {
								FreqEsqVal--;
								GameObject.Find ("FreqEsq").GetComponent<TextMesh> ().text = "" + FreqEsqVal;
						}
				} else if (this.name == "MaisFreqEsq") {
						if (FreqEsqVal == 20) {
								FreqEsqVal -= 1;
						} else {
								FreqEsqVal++;
								GameObject.Find ("FreqEsq").GetComponent<TextMesh> ().text = "" + FreqEsqVal;
						}
				} else if (this.name == "MenosFreqDir") {
						if (FreqDirVal == 4) {
								FreqDirVal += 1;
						} else {
								FreqDirVal--;
								GameObject.Find ("FreqDir").GetComponent<TextMesh> ().text = "" + FreqDirVal;
						} 
				} else if (this.name == "MaisFreqDir") {
						if (FreqDirVal == 20) {
								FreqDirVal -= 1;
						} else {
								FreqDirVal++;
								GameObject.Find ("FreqDir").GetComponent<TextMesh> ().text = "" + FreqDirVal;
						} 
				} else if (this.name == "MenosFreqFrente") {
						if (FreqFrenteVal == 4) {
								FreqFrenteVal += 1;
						} else {
								FreqFrenteVal--;
								GameObject.Find ("FreqFrente").GetComponent<TextMesh> ().text = "" + FreqFrenteVal;
						} 
				} else if (this.name == "MaisFreqFrente") {
						if (FreqFrenteVal == 20) {
								FreqFrenteVal -= 1;
						} else {	
								FreqFrenteVal++;
								GameObject.Find ("FreqFrente").GetComponent<TextMesh> ().text = "" + FreqFrenteVal;
						}
				}

				if (this.name == "DefFreqManual") {
						DefFreqManual = true;
						Calibracao.DefFreqCalibrar = false;
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
						if (Application.loadedLevelName == "DefinirFrequencias_Menuopcoes" || Application.loadedLevelName == "Calibracao_Menuopcoes" || Application.loadedLevelName == "EscolherEstimulos_Menuopcoes") {
								Application.LoadLevel ("MenuOpcoes");
						} else {
								Application.LoadLevel ("MainMenu");
						}
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
						//************************************************** Menus jogo *********************************
				} else if (Application.loadedLevelName == "MenuCarros2d") {
						if (mindwave == true) {
								Application.LoadLevel ("Carros2D_Mindwave");
						}
						if (gusbamp == true) {
								//Application.LoadLevel("gusbamp");
						}
						if (teclado == true) {
								Application.LoadLevel ("Carros2D");
						}	
				} else if (Application.loadedLevelName == "MenuCarros3d") {
						if (mindwave == true) {
								//Application.LoadLevel("MindWave");
						}
						if (gusbamp == true) {
								Application.LoadLevel ("Carro3DEstimulos");
						}
						if (teclado == true) {
								Application.LoadLevel ("AutoNavegacaoCarro");
						}	
				} else if (Application.loadedLevelName == "MenuHelicoptero") {
						if (mindwave == true) {
								//Application.LoadLevel("MindWave");
						}
						if (gusbamp == true) {
								Application.LoadLevel ("HelicopteroEstimulos");
						}
						if (teclado == true) {
								Application.LoadLevel ("Helicoptero");
						}	
				} else if (Application.loadedLevelName == "MenuOpcoes") {
						if (OpcoesFreq == true) {
								Application.LoadLevel ("DefinirFrequencias_Menuopcoes");
						}
						if (OpcoesEscEsti == true) {
								Application.LoadLevel ("EscolherEstimulos_Menuopcoes");
						}
						if (OpcoesCalibrar == true) {
								Application.LoadLevel ("Calibracao_Menuopcoes");
						}	
				}
		}
}