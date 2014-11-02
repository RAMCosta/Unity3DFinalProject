using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApanharMoedas : MonoBehaviour
{
		public static int Pontuacao= 0;


		void OnTriggerEnter (Collider collision)
		{

				GameObject.Find ("Main Camera").audio.Play ();
				this.gameObject.SetActive (false);
				Pontuacao += 100;
		}

		
}
