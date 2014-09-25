using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class ciclosHertz : MonoBehaviour {

	// Use this for initialization
	public GameObject SetaEsq1;
	public GameObject SetaEsq2;
	public GameObject SetaDir1;
	public GameObject SetaDir2;
	public GameObject SetaDireccaoCima;
	public GameObject SetaDireccaoBaixo;
	public GameObject SetaDireccaoEsquerda;
	public GameObject SetaDireccaoDireita;
	bool PiscarEsquerda = false;
	bool PiscarDireita = false;
	Time data;
	double frequenciaSetaCima;
	double frequenciaSetaBaixo;
	double frequenciaSetaEsquerda;
	double frequenciaSetaDireita;

	void Start () {
		if (ModoVisualAnim.visualmodo == true) {
			SetaEsq1.SetActive (true);
			SetaEsq2.SetActive (true);
			SetaDir1.SetActive (true);
			SetaDir2.SetActive (true);
			SetaDireccaoCima.SetActive(false);
			SetaDireccaoBaixo.SetActive(false);
			SetaDireccaoEsquerda.SetActive(false);
			SetaDireccaoDireita.SetActive(false);

		}

		if (TecladoAnim.tecladomodo == true) {
			SetaEsq1.SetActive (false);
			SetaEsq2.SetActive (false);
			SetaDir1.SetActive (false);
			SetaDir2.SetActive (false);
			SetaDireccaoCima.SetActive(true);
			SetaDireccaoBaixo.SetActive(true);
			SetaDireccaoEsquerda.SetActive(true);
			SetaDireccaoDireita.SetActive(true);
		}

		// Valor definido nas opçoes de jogo
		frequenciaSetaCima = 1000 / DadosFrequencias.freqCima;
		frequenciaSetaBaixo = 1000 / DadosFrequencias.freqBaixo;
		frequenciaSetaEsquerda = 1000 / DadosFrequencias.freqEsq;
		frequenciaSetaDireita = 1000 / DadosFrequencias.freqDir;

		Debug.Log ("SetaCima : " + DadosFrequencias.freqCima );
		Debug.Log ("SetaBaixo : " + DadosFrequencias.freqBaixo );
		Debug.Log ("SetaEsq : " + DadosFrequencias.freqEsq );
		Debug.Log ("SetaDir : " + DadosFrequencias.freqDir );
		Debug.Log ("frequenciaSetaCima : " + frequenciaSetaCima );
		Debug.Log ("frequenciaSetaBaixo : " + frequenciaSetaBaixo );
		Debug.Log ("frequenciaSetaEsq : " + frequenciaSetaEsquerda );
		Debug.Log ("frequenciaSetaDir : " + frequenciaSetaDireita );
	}

	static int imagens = 0;
	// Update is called once per frame
	void Update () {
		long milisegundos = DateTime.Now.Millisecond;

	//	if(ModoVisualAnim.visualmodo==true){
// ------------------------------------------- SETA DIREITA -----------------------------------------------
		//if (PiscarDireita==true) {
			if (milisegundos % 124 < 62) {
				SetaDir2.SetActive (false);
				SetaDir1.SetActive (true);
				imagens++;
				//Debug.Log(imagens);
				} else {
					imagens = 0;
					SetaDir2.SetActive (true);
					SetaDir1.SetActive (false);	
			  	}
			//}
// ------------------------------------------- SETA ESQUERDA -----------------------------------------------
		//if (PiscarEsquerda == true) {
			if (milisegundos % 82 < 41) {
				SetaEsq2.SetActive (false);
				SetaEsq1.SetActive (true);
				} else {
					SetaEsq2.SetActive (true);
					SetaEsq1.SetActive (false);	
			}
		//}
	//}
// ------------------------------------------- TECLADO -----------------------------------------------
	/*	if (Input.GetKey(KeyCode.Z)) {
			PiscarEsquerda = true;
		}
		if (Input.GetKey(KeyCode.X)) {
			PiscarEsquerda = false;
			SetaEsq2.SetActive (false);
			SetaEsq1.SetActive (false);

		}
		if (Input.GetKey(KeyCode.M)) {
			PiscarDireita = true;
		}
		if (Input.GetKey(KeyCode.N)) {
			PiscarDireita = false;
			SetaDir1.SetActive (false);	
			SetaDir2.SetActive (false);	
		}
*/

	}

}
