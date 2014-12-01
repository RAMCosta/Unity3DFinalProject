using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;

public class DireitaEstimulo : MonoBehaviour {

	public static Thread ThreadBlink;
	int delay;
	bool state;
	float frequencia;
	public GUITexture PeqDir1;
	public GUITexture PeqDir2;
	public GUITexture MedioDir1;
	public GUITexture MedioDir2;
	public GUITexture GrnDir1;
	public GUITexture GrnDir2;
	GUITexture Seta1;
	GUITexture Seta2;
	public Texture[] TexturaEstimulos;
	// Use this for initialization
	void Start ()
	{
		if (TamanhoEstimulos.Size == "Pequeno") {
			Seta1 = PeqDir1;
			Seta2 = PeqDir2;
			MedioDir1.enabled=false;
			MedioDir2.enabled=false;
			GrnDir1.enabled=false;
			GrnDir2.enabled=false;
		} else if (TamanhoEstimulos.Size == "Medio") {
			Seta1 = MedioDir1;
			Seta2 = MedioDir2;
			PeqDir1.enabled=false;
			PeqDir2.enabled=false;
			GrnDir1.enabled=false;
			GrnDir2.enabled=false;
		} else if (TamanhoEstimulos.Size == "Grande") {
			Seta1 = GrnDir1;
			Seta2 = GrnDir2;
			PeqDir1.enabled=false;
			PeqDir2.enabled=false;
			MedioDir1.enabled=false;
			MedioDir2.enabled=false;
		}
		//frequencia=9;
		if(FreqEscolhe.DefFreqManual==true)
		{
			frequencia = FreqEscolhe.FreqDirVal;

			Debug.Log("Dir" + frequencia);
		} else if(Calibracao.DefFreqCalibrar==true){
			frequencia= Calibracao.FreqRecMaiorDireita;
		}
		delay = (int) (1000 / frequencia)/2;
		
		ThreadBlink = new Thread (Blink);
		ThreadBlink.Start ();
		
		if (EstimulosEscolha.Seta1Usada == "SetaAmarela") {
			Seta1.guiTexture.texture = TexturaEstimulos[0];	
		}
		if (EstimulosEscolha.Seta2Usada == "SetaAmarela") {
			Seta2.guiTexture.texture = TexturaEstimulos[0];		
		}
		if (EstimulosEscolha.Seta1Usada == "SetaAzul") {
			Seta1.guiTexture.texture = TexturaEstimulos[1];		
		}
		if (EstimulosEscolha.Seta2Usada == "SetaAzul") {
			Seta2.guiTexture.texture = TexturaEstimulos[1];			
		}
		if (EstimulosEscolha.Seta1Usada == "SetaBranca") {
			Seta1.guiTexture.texture = TexturaEstimulos[2];			
		}
		if (EstimulosEscolha.Seta2Usada == "SetaBranca") {
			Seta2.guiTexture.texture = TexturaEstimulos[2];			
		}
		if (EstimulosEscolha.Seta1Usada == "SetaVerde") {
			Seta1.guiTexture.texture = TexturaEstimulos[3];			
		}
		if (EstimulosEscolha.Seta2Usada == "SetaVerde") {
			Seta2.guiTexture.texture = TexturaEstimulos[3];			
		}
		if (EstimulosEscolha.Seta1Usada == "SetaVermelha") {
			Seta1.guiTexture.texture = TexturaEstimulos[4];			
		}
		if (EstimulosEscolha.Seta2Usada == "SetaVermelha") {
			Seta2.guiTexture.texture = TexturaEstimulos[4];			
		}
		if (EstimulosEscolha.Seta1Usada == "SetaCinzenta") {
			Seta1.guiTexture.texture = TexturaEstimulos[5];			
		}
		if (EstimulosEscolha.Seta2Usada == "SetaCinzenta") {
			Seta2.guiTexture.texture = TexturaEstimulos[5];			
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state) {
			Seta1.enabled=true;
			Seta2.enabled=false;
		} else {
			Seta1.enabled=false;
			Seta2.enabled=true;
		}
	}
	
	void Blink ()
	{
		while (true) {
			int resto = DateTime.Now.Millisecond % delay;
			state = !state;
			Thread.Sleep (delay-resto);
		}
	}
	
	void OnApplicationQuit()
	{
		ThreadBlink.Abort ();
	}
}
