using UnityEngine;
using System.Collections;

public class FreqEscolhe : MonoBehaviour
{

		public GUIText FreqEsq;
		public GUIText FreqDir;
		public GUIText FreqFrente;
		public static int FreqEsqVal = 6;
		public static int FreqDirVal = 11;
		public static int FreqFrenteVal = 15;
		public static bool DefFreqManual = true;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnMouseDown ()
		{
				if (this.name == "MenosFreqEsq") {
						if (FreqEsqVal == 4) {
								FreqEsqVal += 1;
						} else {
								FreqEsqVal--;
								FreqEsq.gameObject.guiText.text = "" + FreqEsqVal;
						}
				} else if (this.name == "MaisFreqEsq") {
						if (FreqEsqVal == 20) {
								FreqEsqVal -= 1;
						} else {
								FreqEsqVal++;
								FreqEsq.gameObject.guiText.text = "" + FreqEsqVal;
						}
				} else if (this.name == "MenosFreqDir") {
						if (FreqDirVal == 4) {
								FreqDirVal += 1;
						} else {
								FreqDirVal--;
								FreqDir.gameObject.guiText.text = "" + FreqDirVal;
						}
				} else if (this.name == "MaisFreqDir") {
						if (FreqDirVal == 20) {
								FreqDirVal -= 1;
						} else {
								FreqDirVal++;
								FreqDir.gameObject.guiText.text = "" + FreqDirVal;
						}
				} else if (this.name == "MenosFreqFrente") {
						if (FreqFrenteVal == 4) {
								FreqFrenteVal += 1;
						} else {
								FreqFrenteVal--;
								FreqFrente.gameObject.guiText.text = "" + FreqFrenteVal;
						}
				} else if (this.name == "MaisFreqFrente") {
						if (FreqFrenteVal == 20) {
								FreqFrenteVal -= 1;
						} else {
								FreqFrenteVal++;
								FreqFrente.gameObject.guiText.text = "" + FreqFrenteVal;
						}
				} else if (this.name == "Bt_Definir") {
						DefFreqManual = true;
						Calibracao.DefFreqCalibrar = false;
				}
		}
}
