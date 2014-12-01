using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;

public class FrenteEstimulo : MonoBehaviour {
	
	public static Thread ThreadBlink;
	int delay;
	bool state;
	float frequencia;
	GUITexture Seta1;
	GUITexture Seta2;
	public GUITexture PeqFrn1;
	public GUITexture PeqFrn2;
	public GUITexture MedioFrn1;
	public GUITexture MedioFrn2;
	public GUITexture GrnFrn1;
	public GUITexture GrnFrn2;
	public Texture[] TexturaEstimulos;

	// Use this for initialization
	void Start ()
	{
		if (TamanhoEstimulos.Size == "Pequeno") {
			Seta1 = PeqFrn1;
			Seta2 = PeqFrn2;
			MedioFrn1.enabled=false;
			MedioFrn2.enabled=false;
			GrnFrn1.enabled=false;
			GrnFrn2.enabled=false;
		} else if (TamanhoEstimulos.Size == "Medio") {
			Seta1 = MedioFrn1;
			Seta2 = MedioFrn2;
			PeqFrn1.enabled=false;
			PeqFrn2.enabled=false;
			GrnFrn1.enabled=false;
			GrnFrn2.enabled=false;
		} else if (TamanhoEstimulos.Size == "Grande") {
			Seta1 = GrnFrn1;
			Seta2 = GrnFrn2;
			PeqFrn1.enabled=false;
			PeqFrn2.enabled=false;
			MedioFrn1.enabled=false;
			MedioFrn2.enabled=false;
		}
	
	  if(FreqEscolhe.DefFreqManual==true)
		{
			frequencia = FreqEscolhe.FreqFrenteVal;
			Debug.Log("Frn" + frequencia);
		} else if(Calibracao.DefFreqCalibrar==true){
			frequencia= Calibracao.FreqRecMeioFrente;
			Debug.Log("Frn" + frequencia);
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