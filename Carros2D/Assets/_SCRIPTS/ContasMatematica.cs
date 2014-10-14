using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
public class ContasMatematica : MonoBehaviour {

	// Use this for initialization
	int numero1 = 0;
	int numero2 = 0;
	int operador = 0;
	long WaitingTime = 10000;
	long milliseconds;


	void Start () {
		milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
		WaitingTime = milliseconds + WaitingTime;
		MostrarContas ();
	}
	
	void Update () {
		milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
		if (milliseconds>WaitingTime){
			milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
			WaitingTime = 10000;
			WaitingTime = milliseconds + WaitingTime;
			MostrarContas();
		}
	}
	void MostrarContas(){
		numero1 = Random.Range (0,20); // Escolha numero entre 0 e 20
		numero2 = Random.Range (0,20); // Escolha numero entre 0 e 20
		operador = Random.Range (0,4); // Escolha numero entre 0 e 4 (+, -, *, /)
		if (operador == 1){
			gameObject.guiText.text = numero1 + " + " + numero2;
		}
		if (operador == 2){
			gameObject.guiText.text = numero1 + " - " + numero2;
		}
		if (operador == 3){
			gameObject.guiText.text = numero1 + " * " + numero2;
		}
		if (operador == 4){
			gameObject.guiText.text = numero1 + " / " + numero2;
		}
	}
}