using UnityEngine;
using System.Collections;

public class Calibracao : MonoBehaviour
{

		public Texture BarraFundo;
		public Texture BarraFrente;
		public float progresso;
		public float tamanhoBarra;
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
		
	
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (progresso < 70) {
						tamanhoBarra = ((progresso / 70) * 140) * 4;
						progresso += Time.deltaTime;
				}
				if (progresso >= 0 && progresso < 10) {
						frequencia = Frequencias [0];
				}
				if (progresso >= 10 && progresso < 20) {
						frequencia = Frequencias [1];
				}
				if (progresso >= 20 && progresso < 30) {
						frequencia = Frequencias [2];
				}
				if (progresso >= 30 && progresso < 40) {
						frequencia = Frequencias [3];
				}
				if (progresso >= 40&& progresso < 50) {
						frequencia = Frequencias [4];
				}
				if (progresso >= 50 && progresso < 60) {
						frequencia = Frequencias [5];
				}
				if (progresso >= 60 && progresso < 70) {
						frequencia = Frequencias [6];
				}
		if (progresso >= 70) {
			CalibracaoPiscarSetas.ThreadBlink.Abort();
//			GameObject.Find ("VerSetas").GetComponent<CalibracaoPiscarSetas> ().enabled = false;
			GameObject.Find ("VerSetas").SetActive(false);
			MainMenu.DefFreqManual = false;
			DefFreqCalibrar = true;
				}
		}

		void OnGUI ()
		{
				GUI.DrawTexture (new Rect (10, 30, 560, 20), BarraFundo);
				GUI.DrawTexture (new Rect (10, 30, tamanhoBarra, 20), BarraFrente);
				if (tamanhoBarra < 63) {
						GUI.Label (new Rect (13, 35, 200, 300), Mathf.Round (progresso) + " seg.", FontStyle);
				} else {
						GUI.Label (new Rect ((tamanhoBarra - 53), 35, 200, 300), Mathf.Round (progresso) + " seg.", FontStyle);
				}
				for (int i = 69; i>=0; i--) {
						if (i % 10 == 0) {
								GUI.Label (new Rect (570 - (i * 8) - 8, 20, 200, 300), "|", BarraStyle);
								GUI.Label (new Rect (570 - (i * 8) - 64, 50, 200, 300), Frequencias [6 - (i / 10)] + " Hz", HertzStyle);
						}
				}
		}
}
