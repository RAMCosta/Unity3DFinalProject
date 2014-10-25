using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class Estimulos : MonoBehaviour
{

		// Use this for initialization
		public GameObject SetaEsq1;
		public GameObject SetaEsq2;
		public GameObject SetaDir1;
		public GameObject SetaDir2;
		Time data;

		void Start ()
		{

		}

		void Update ()
		{
				long milisegundos = DateTime.Now.Millisecond;
				// ------------------------------------------- SETA DIREITA -----------------------------------------------

				if (milisegundos % 124 < 62) {
						SetaDir2.SetActive (false);
						SetaDir1.SetActive (true);

				} else {
						SetaDir2.SetActive (true);
						SetaDir1.SetActive (false);	
				}
				// ------------------------------------------- SETA ESQUERDA -----------------------------------------------

				if (milisegundos % 82 < 41) {
						SetaEsq2.SetActive (false);
						SetaEsq1.SetActive (true);
				} else {
						SetaEsq2.SetActive (true);
						SetaEsq1.SetActive (false);	
				}

		
		}
	
}