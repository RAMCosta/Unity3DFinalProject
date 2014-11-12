using UnityEngine;
using System.Collections;

public class Calibracao : MonoBehaviour
{

		public Texture BarraFundo;
		public Texture BarraFrente;
		public Texture Barra;
		public static float progressoCalib;
		float tamanhoBarra;
		// Use this for initialization
		public GUIStyle FontStyle;
		public GUIStyle BarraStyle;
		public GUIStyle HertzStyle;
		float[] Frequencias = { 6f, 7.5f, 9f, 11f, 14f, 16f, 17f };
		int numeroListaFreq;
		public static float frequencia;
		public static bool DefFreqCalibrar = false;
		public static float FreqRecMenorEsquerda = 7.5f;
		public static float FreqRecMeioFrente = 11f;
		public static float FreqRecMaiorDireita = 17f;
		int[] EnviarMatLab = { 1, 1, 1, 1, 1, 1, 1};
	
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (CalibracaoTCP.conectado == true) {
						if (progressoCalib < 70) {
								tamanhoBarra = (progressoCalib * 100) / 70;
								progressoCalib += Time.deltaTime;
						}
						if (progressoCalib >= 0 && progressoCalib < 10) {
								frequencia = Frequencias [0];
								if (EnviarMatLab [0] == 1) {
										CalibracaoTCP.mensagemMatLab = Frequencias [0].ToString () + "1";
										CalibracaoTCP.EnviarComandoMatLabCalib = true;
										EnviarMatLab [0] = 2;
										
								}
						}
						if (progressoCalib >= 10 && progressoCalib < 20) {
								frequencia = Frequencias [1];
								if (EnviarMatLab [1] == 1) {
										CalibracaoTCP.mensagemMatLab = Frequencias [1].ToString () + "1";
										CalibracaoTCP.EnviarComandoMatLabCalib = true;
										EnviarMatLab [1] = 2;

								}
						}
						if (progressoCalib >= 20 && progressoCalib < 30) {
								frequencia = Frequencias [2];
								if (EnviarMatLab [2] == 1) {
										CalibracaoTCP.mensagemMatLab = Frequencias [2].ToString () + "1";
										CalibracaoTCP.EnviarComandoMatLabCalib = true;
										EnviarMatLab [2] = 2;

								}
						}
						if (progressoCalib >= 30 && progressoCalib < 40) {
								frequencia = Frequencias [3];
								if (EnviarMatLab [3] == 1) {
										CalibracaoTCP.mensagemMatLab = Frequencias [3].ToString () + "1";
										CalibracaoTCP.EnviarComandoMatLabCalib = true;
										EnviarMatLab [3] = 2;

								}
						}
						if (progressoCalib >= 40 && progressoCalib < 50) {
								frequencia = Frequencias [4];
								if (EnviarMatLab [4] == 1) {
										CalibracaoTCP.mensagemMatLab = Frequencias [4].ToString () + "1";
										CalibracaoTCP.EnviarComandoMatLabCalib = true;
										EnviarMatLab [4] = 2;

								}
						}
						if (progressoCalib >= 50 && progressoCalib < 60) {
								frequencia = Frequencias [5];
								if (EnviarMatLab [5] == 1) {
										CalibracaoTCP.mensagemMatLab = Frequencias [5].ToString () + "1";
										CalibracaoTCP.EnviarComandoMatLabCalib = true;
										EnviarMatLab [5] = 2;

								}
						}
						if (progressoCalib >= 60 && progressoCalib < 70) {
								frequencia = Frequencias [6];
								if (EnviarMatLab [6] == 1) {
										CalibracaoTCP.mensagemMatLab = Frequencias [6].ToString () + "1";
										CalibracaoTCP.EnviarComandoMatLabCalib = true;
										EnviarMatLab [6] = 2;

								}
						
						}
						if (progressoCalib >= 70) {
								GameObject.Find ("VerSetas").SetActive (false);
								FreqEscolhe.DefFreqManual = false;
								DefFreqCalibrar = true;
						}
				}
		}

		void OnGUI ()
		{
				GUI.DrawTexture (new Rect (Screen.width / 10, Screen.height / 10, 1.5f * Screen.width / 2, Screen.height / 10), BarraFundo);
				GUI.DrawTexture (new Rect (Screen.width / 10, Screen.height / 10, (tamanhoBarra * (1.5f * Screen.width / 2) / 100), Screen.height / 10), BarraFrente);
		
				GUI.Label (new Rect ((Screen.width / 20 + (tamanhoBarra * (1.5f * Screen.width / 2) / 100)), Screen.height / 7, 1.5f * Screen.width / 2, Screen.height / 10), Mathf.Round (progressoCalib) + " seg.", FontStyle);
		
				for (int i = 70; i>=1; i--) {
						if (i % 10 == 0) {
								int j = (i * 100) / 70;
								GUI.DrawTexture (new Rect (((j * (1.5f * Screen.width / 2)) / 100) - Screen.width / 75, Screen.height / 10, Screen.width / 150, Screen.height / 10), Barra);
								//GUI.Label (new Rect (((j*(1.5f*Screen.width/2))/100)-Screen.width/75, Screen.height/4, Screen.width/150, Screen.height/10), Frequencias [6 - (i / 10)] + " Hz", HertzStyle);
						}
				}
		}
}
