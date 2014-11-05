using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;

public class CalibracaoPiscarSetas : MonoBehaviour {

	public static Thread ThreadBlink;
	int delay;
	bool state;
	float frequencia;
	public GameObject Seta1;
	public GameObject Seta2;
	public Sprite[] sprites;
	// Use this for initialization
	void Start ()
	{
		frequencia = Calibracao.frequencia;
		delay = (int) (1000 / frequencia)/2;

		ThreadBlink = new Thread (Blink);
		ThreadBlink.Start ();

		if (EstimulosEscolha.Seta1Usada == "SetaAmarela") {
			Seta1.GetComponent<SpriteRenderer> ().sprite = sprites [0];		
		}
		if (EstimulosEscolha.Seta2Usada == "SetaAmarela") {
			Seta2.GetComponent<SpriteRenderer> ().sprite = sprites [0];		
		}
		if (EstimulosEscolha.Seta1Usada == "SetaAzul") {
			Seta1.GetComponent<SpriteRenderer> ().sprite = sprites [1];		
		}
		if (EstimulosEscolha.Seta2Usada == "SetaAzul") {
			Seta2.GetComponent<SpriteRenderer> ().sprite = sprites [1];		
		}
		if (EstimulosEscolha.Seta1Usada == "SetaBranca") {
			Seta1.GetComponent<SpriteRenderer> ().sprite = sprites [2];		
		}
		if (EstimulosEscolha.Seta2Usada == "SetaBranca") {
			Seta2.GetComponent<SpriteRenderer> ().sprite = sprites [2];		
		}
		if (EstimulosEscolha.Seta1Usada == "SetaVerde") {
			Seta1.GetComponent<SpriteRenderer> ().sprite = sprites [3];		
		}
		if (EstimulosEscolha.Seta2Usada == "SetaVerde") {
			Seta2.GetComponent<SpriteRenderer> ().sprite = sprites [3];		
		}
		if (EstimulosEscolha.Seta1Usada == "SetaVermelha") {
			Seta1.GetComponent<SpriteRenderer> ().sprite = sprites [4];		
		}
		if (EstimulosEscolha.Seta2Usada == "SetaVermelha") {
			Seta2.GetComponent<SpriteRenderer> ().sprite = sprites [4];		
		}
		if (EstimulosEscolha.Seta1Usada == "SetaCinzenta") {
			Seta1.GetComponent<SpriteRenderer> ().sprite = sprites [5];		
		}
		if (EstimulosEscolha.Seta2Usada == "SetaCinzenta") {
			Seta2.GetComponent<SpriteRenderer> ().sprite = sprites [5];		
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		frequencia = Calibracao.frequencia;
		delay = (int) (1000 / frequencia)/2;

		if (state) {
			Seta1.SetActive (true);
			Seta2.SetActive (false);
		} else {
			Seta1.SetActive (false);
			Seta2.SetActive (true);
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
