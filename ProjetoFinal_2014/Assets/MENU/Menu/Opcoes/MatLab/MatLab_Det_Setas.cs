using UnityEngine;
using System.Collections;

public class MatLab_Det_Setas : MonoBehaviour
{

		public GUIText Esquerda;
		public GUIText Direita;
		public GUIText Frente;
		public GUIText Tras;
		public static int EsqValor = 65;
		public static int DirValor = 66;
		public static int FrenteValor = 67;
		public static int TrasValor = 68;
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
				if (this.name == "EsqMenosSeta_Bt") {
						if (EsqValor == 0) {
								EsqValor += 1;
						} else {
								EsqValor--;
								Esquerda.gameObject.guiText.text = "" + EsqValor;
						}
				} else if (this.name == "EsqMaisSeta_Bt") {
						if (EsqValor == 100) {
								EsqValor -= 1;
						} else {
								EsqValor++;
								Esquerda.gameObject.guiText.text = "" + EsqValor;
						}
				} else if (this.name == "DirMenosSeta_Bt") {
						if (DirValor == 0) {
								DirValor += 1;
						} else {
								DirValor--;
								Direita.gameObject.guiText.text = "" + DirValor;
						}
				} else if (this.name == "DirMaisSeta_Bt") {
						if (DirValor == 100) {
								DirValor -= 1;
						} else {
								DirValor++;
								Direita.gameObject.guiText.text = "" + DirValor;
						}
				} else if (this.name == "FrenteMenosSeta_Bt") {
						if (FrenteValor == 0) {
								FrenteValor += 1;
						} else {
								FrenteValor--;
								Frente.gameObject.guiText.text = "" + FrenteValor;
						}
				} else if (this.name == "FrenteMaisSeta_Bt") {
						if (FrenteValor == 100) {
								FrenteValor -= 1;
						} else {
								FrenteValor++;
								Frente.gameObject.guiText.text = "" + FrenteValor;
						}
				} else if (this.name == "TrasMenosSeta_Bt") {
						if (TrasValor == 0) {
								TrasValor -= 1;
						} else {
								TrasValor++;
								Tras.gameObject.guiText.text = "" + TrasValor;
						}
				} else if (this.name == "TrasMaisSeta_Bt") {
						if (TrasValor == 100) {
								TrasValor -= 1;
						} else {
								TrasValor++;
								Tras.gameObject.guiText.text = "" + TrasValor;
						}
				}
		}
}
