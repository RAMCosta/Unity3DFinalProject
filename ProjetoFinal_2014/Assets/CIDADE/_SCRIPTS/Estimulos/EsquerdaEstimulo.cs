using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;

public class EsquerdaEstimulo : MonoBehaviour {
	
	public static Thread ThreadBlink;
	int delay;
	bool state;
	float frequencia;
	public GUITexture Seta1;
	public GUITexture Seta2;
	public Texture[] TexturaEstimulos;
	// Use this for initialization
	void Start ()
	{
		if(FreqEscolhe.DefFreqManual==true)
		{
			frequencia = FreqEscolhe.FreqEsqVal;
		} else if(Calibracao.DefFreqCalibrar==true){
			frequencia= Calibracao.FreqRecMenorEsquerda;
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