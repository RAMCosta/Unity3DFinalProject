using UnityEngine;
using System.Collections;

public class MatLab_Calib_Freq : MonoBehaviour {

	public GUIText freq1;
	public GUIText freq2;
	public GUIText freq3;
	public GUIText freq4;
	public GUIText freq5;
	public GUIText freq6;
	public GUIText freq7;
	public static int freq1Valor = 70;
	public static int freq2Valor = 71;
	public static int freq3Valor = 72;
	public static int freq4Valor = 73;
	public static int freq5Valor = 74;
	public static int freq6Valor = 75;
	public static int freq7Valor = 76;
	// Use this for initialization
	void Start ()
	{
		freq1.gameObject.guiText.text = "" + freq1Valor;
		freq2.gameObject.guiText.text = "" + freq2Valor;
		freq3.gameObject.guiText.text = "" + freq3Valor;
		freq4.gameObject.guiText.text = "" + freq4Valor;
		freq5.gameObject.guiText.text = "" + freq5Valor;
		freq6.gameObject.guiText.text = "" + freq6Valor;
		freq7.gameObject.guiText.text = "" + freq7Valor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnMouseDown ()
	{
		if (this.name == "Freq1Menos_Bt") {
			if (freq1Valor == 0) {
				freq1Valor += 1;
			} else {
				freq1Valor--;
				freq1.gameObject.guiText.text = "" + freq1Valor;
			}
		} else if (this.name == "Freq1Mais_Bt") {
			if (freq1Valor == 100) {
				freq1Valor -= 1;
			} else {
				freq1Valor++;
				freq1.gameObject.guiText.text = "" + freq1Valor;
			}
		} else if (this.name == "Freq2Menos_Bt") {
			if (freq2Valor == 0) {
				freq2Valor += 1;
			} else {
				freq2Valor--;
				freq2.gameObject.guiText.text = "" + freq2Valor;
			}
		} else if (this.name == "Freq2Mais_Bt") {
			if (freq2Valor == 100) {
				freq2Valor -= 1;
			} else {
				freq2Valor++;
				freq2.gameObject.guiText.text = "" + freq2Valor;
			}
		} else if (this.name == "Freq3Menos_Bt") {
			if (freq3Valor == 0) {
				freq3Valor += 1;
			} else {
				freq3Valor--;
				freq3.gameObject.guiText.text = "" + freq3Valor;
			}
		} else if (this.name == "Freq3Mais_Bt") {
			if (freq3Valor == 100) {
				freq3Valor -= 1;
			} else {
				freq3Valor++;
				freq3.gameObject.guiText.text = "" + freq3Valor;
			}
		} else if (this.name == "Freq4Menos_Bt") {
			if (freq4Valor == 0) {
				freq4Valor -= 1;
			} else {
				freq4Valor--;
				freq4.gameObject.guiText.text = "" + freq4Valor;
			}
		} else if (this.name == "Freq4Mais_Bt") {
			if (freq4Valor == 100) {
				freq4Valor -= 1;
			} else {
				freq4Valor++;
				freq4.gameObject.guiText.text = "" + freq4Valor;
			}
		}else if (this.name == "Freq5Menos_Bt") {
			if (freq5Valor == 0) {
				freq5Valor -= 1;
			} else {
				freq5Valor--;
				freq5.gameObject.guiText.text = "" + freq5Valor;
			}
		} else if (this.name == "Freq5Mais_Bt") {
			if (freq5Valor == 100) {
				freq5Valor -= 1;
			} else {
				freq5Valor++;
				freq5.gameObject.guiText.text = "" + freq5Valor;
			}
		}else if (this.name == "Freq6Menos_Bt") {
			if (freq6Valor == 0) {
				freq6Valor -= 1;
			} else {
				freq6Valor--;
				freq6.gameObject.guiText.text = "" + freq6Valor;
			}
		} else if (this.name == "Freq6Mais_Bt") {
			if (freq6Valor == 100) {
				freq6Valor -= 1;
			} else {
				freq6Valor++;
				freq6.gameObject.guiText.text = "" + freq6Valor;
			}
		}else if (this.name == "Freq7Menos_Bt") {
			if (freq7Valor == 0) {
				freq7Valor -= 1;
			} else {
				freq7Valor--;
				freq7.gameObject.guiText.text = "" + freq7Valor;
			}
		} else if (this.name == "Freq7Mais_Bt") {
			if (freq7Valor == 100) {
				freq7Valor -= 1;
			} else {
				freq7Valor++;
				freq7.gameObject.guiText.text = "" + freq7Valor;
			}
		}
	}
}