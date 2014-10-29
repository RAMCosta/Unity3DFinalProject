using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;

public class EsquerdaEstimulo : MonoBehaviour {
	
	Thread Autorun;
	int delay;
	bool state;
	public float frequencia;
	public GameObject Seta1;
	public GameObject Seta2;
	// Use this for initialization
	void Start ()
	{
		//frequencia = MainMenu.FreqEsqVal;
		delay = (int) (1000 / frequencia)/2;
		Autorun = new Thread (Blink);
		Autorun.Start ();
		
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
}