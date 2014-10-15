using UnityEngine;
using System.Collections;

public class DadosFrequencias : MonoBehaviour {

	// Use this for initialization
	public GameObject SetaCimaFreq;
	public GameObject SetaBaixoFreq;
	public GameObject SetaEsqFreq;
	public GameObject SetaDirFreq;

	public static int freqCima = 15;
	public static int freqBaixo = 10;
	public static int freqEsq = 12;
	public static int freqDir = 8;

	void Start () {
		SetaCimaFreq.GetComponent<TextMesh>().text =  "" + freqCima;
		SetaBaixoFreq.GetComponent<TextMesh>().text = "" + freqBaixo;
		SetaEsqFreq.GetComponent<TextMesh>().text = "" + freqEsq;
		SetaDirFreq.GetComponent<TextMesh>().text = "" + freqDir;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (this.name == "maisCima") {
			freqCima++;
			SetaCimaFreq.GetComponent<TextMesh>().text =  "" + freqCima;
		} 
		if (this.name == "menosCima") {
			freqCima--;
			SetaCimaFreq.GetComponent<TextMesh>().text =  "" + freqCima;
		}
// ---------------------------------------------------------------------------
		if (this.name == "maisBaixo") {
			freqBaixo ++;
			SetaBaixoFreq.GetComponent<TextMesh>().text = "" + freqBaixo;
		} 
		if (this.name == "menosBaixo") {
			freqBaixo --;
			SetaBaixoFreq.GetComponent<TextMesh>().text = "" + freqBaixo;
		}
// ---------------------------------------------------------------------------
		if (this.name == "maisEsq") {
			freqEsq ++;
			SetaEsqFreq.GetComponent<TextMesh>().text = "" + freqEsq;
		} 
		if (this.name == "menosEsq") {
			freqEsq --;
			SetaEsqFreq.GetComponent<TextMesh>().text = "" + freqEsq;
		}
// ---------------------------------------------------------------------------
		if (this.name == "maisDir") {
			freqDir ++;
			SetaDirFreq.GetComponent<TextMesh>().text = "" + freqDir;
		} 
		if (this.name == "menosDir") {
			freqDir --;
			SetaDirFreq.GetComponent<TextMesh>().text = "" + freqDir;
		}
	}
}
