using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class OitoHzTeste : MonoBehaviour {

		public GameObject SetaDir1;
		public GameObject SetaDir2;		
		public float Timer5Hz = 0.200f;
		public float TimerTotal = 5;
		public int Seta1 = 0;
		public int Seta2 = 0;

		public float timerDeTeste = 0;

		void Start () {
		}
		
		
		// Update is called once per frame
		void Update () {

			Timer5Hz -= Time.deltaTime;
			
			if (Timer5Hz <= 0) {  Debug.Log(Seta1); Seta1=0; Seta2=0; Timer5Hz = 0.200f;}	

			if (Timer5Hz <= 0.1 && Seta1 == 0) {
				SetaDir2.SetActive (false);
				SetaDir1.SetActive (true);
				Seta1 ++;
			} if (Seta2 == 0) {
				SetaDir2.SetActive (true);
				SetaDir1.SetActive (false);
				Seta2++;
			}			
		}
	}
