using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;

public class PiscarSetas : MonoBehaviour {

	public static Thread ThreadBlink;
	int delay;
	bool state;
	float frequencia;
	public GameObject Seta1;
	public GameObject Seta2;
	float progresso;
	// Use this for initialization
	void Start ()
	{
		frequencia = 5;
		delay = (int) (1000 / frequencia)/2;
		
		ThreadBlink = new Thread (Blink);
		ThreadBlink.Start ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
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
