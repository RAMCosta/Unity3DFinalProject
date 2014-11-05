using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;

public class PiscarGUI : MonoBehaviour {

	public static Thread ThreadPiscar;
	int delay;
	bool state;
	public float frequencia;
	public GameObject Seta1;
	public GameObject Seta2;
	public Texture2D[] GUIArrows;
	float[] Frequencias = { 6f, 7.5f, 9f, 11f, 14f, 16f, 17f };
	public static float progressoGUI;
	// Use this for initialization
	void Start ()
	{
		frequencia = Frequencias [0];
		delay = (int) (1000 / frequencia)/2;

		ThreadPiscar = new Thread (Piscar);
		ThreadPiscar.Start ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (progressoGUI < 70) {
			progressoGUI += Time.deltaTime;
		}
		if (progressoGUI >= 0 && progressoGUI < 10) {
			frequencia = Frequencias [0];
		}
		if (progressoGUI >= 10 && progressoGUI < 20) {
			frequencia = Frequencias [1];
		}
		if (progressoGUI >= 20 && progressoGUI < 30) {
			frequencia = Frequencias [2];
		}
		if (progressoGUI >= 30 && progressoGUI < 40) {
			frequencia = Frequencias [3];
		}
		if (progressoGUI >= 40&& progressoGUI < 50) {
			frequencia = Frequencias [4];
		}
		if (progressoGUI >= 50 && progressoGUI < 60) {
			frequencia = Frequencias [5];
		}
		if (progressoGUI >= 60 && progressoGUI < 70) {
			frequencia = Frequencias [6];
		}

		if (progressoGUI >= 70) {
			ThreadPiscar.Abort();
			GameObject.Find ("Estimulo1").SetActive(false);
			GameObject.Find ("Estimulo2").SetActive(false);
		}

		delay = (int) (1000 / frequencia)/2;

		if (state) {
			Seta1.SetActive (true);
			Seta2.SetActive (false);
		} else {
			Seta1.SetActive (false);
			Seta2.SetActive (true);
		}
	}
	
	void Piscar ()
	{
		while (true) {
			int resto = DateTime.Now.Millisecond % delay;
			state = !state;
			Thread.Sleep (delay-resto);
		}
	}
	
	void OnApplicationQuit()
	{
		ThreadPiscar.Abort ();
	}
}