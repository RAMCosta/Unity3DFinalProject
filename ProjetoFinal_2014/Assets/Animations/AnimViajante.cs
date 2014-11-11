using UnityEngine;
using System.Collections;

public class AnimViajante : MonoBehaviour
{

	
		private Animator anim;
		public Transform[] NavDestino;
		private NavMeshAgent agente;
		public int distancia;
		public GameObject destino;
		public GameObject Taxi;
		public GameObject porta;
		public bool AbrirPorta = false;
		public GameObject referencia;
		public float time;
		public float RotacaoPorta = 0;
		bool entrouNoCarro = false;
		public static bool SeguirCarro = true;
		public static bool ActualizarDestino = false; // Dizer a Class Destinos para efectuar a funçao Apanhar Viajante
		int distanciaPeq = 100;
		int numeroDestino = 10;
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				anim.SetBool ("Andar", false);
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (DestinosAnim.AndarViajante == true) {
						SeguirCarro = false;
						anim.SetBool ("Andar", true);
						for (int i=0; i<6; i++) {
								distancia = (int)Vector3.Distance (this.transform.position, NavDestino [i].transform.position);
								if (distancia < distanciaPeq) {
										distanciaPeq = distancia;
										numeroDestino = i;
								}
						}
						DestinosAnim.AndarViajante = false;

				}		

				if (numeroDestino >= 0 && numeroDestino != 10) {
						agente = gameObject.GetComponent<NavMeshAgent> ();
						agente.SetDestination (NavDestino [numeroDestino].position);
				}
			
				distancia = (int)Vector3.Distance (Taxi.transform.position, destino.transform.position);
				if (distancia > 30){
					this.transform.LookAt (referencia.transform);
				}

				if (distancia > 2 && distancia < 100) {
						anim.SetBool ("ChamarTaxi", true);
						
				} else {
						anim.SetBool ("ChamarTaxi", false);	
				}
				if (AbrirPorta == true) {
						time += Time.deltaTime;
						if (time > 2.1 && time < 2.9) {
								RotacaoPorta = -40 * Time.deltaTime;
								porta.transform.Rotate (new Vector3 (0, RotacaoPorta, 0));
						} else if (time > 3.1 && time < 3.29) {
								RotacaoPorta = 170 * Time.deltaTime;
								porta.transform.Rotate (new Vector3 (0, RotacaoPorta, 0));
								entrouNoCarro = true;
						} else if (AbrirPorta == true && entrouNoCarro == true) {
								porta.transform.localEulerAngles = new Vector3 (0, 0, 0);
								SeguirCarro = true;
								AbrirPorta = false;
								ActualizarDestino = true;

								//this.gameObject.SetActive(false);
						}
				}
		}
	
		void OnTriggerEnter (Collider colisao)
		{
				if (colisao.gameObject.name == "TAXI") {
						anim.SetBool ("Andar", false);
						anim.SetBool ("AbrirCarro", true);
						AbrirPorta = true;
				}

				if (colisao.gameObject.name == "DestinoNav1") {
						numeroDestino = 0;
						this.transform.LookAt (referencia.transform);
				} else if (colisao.gameObject.name == "DestinoNav2") {
						numeroDestino = 1;
						this.transform.LookAt (NavDestino [1].position);
				} else if (colisao.gameObject.name == "DestinoNav3") {
						numeroDestino = 2;
						this.transform.LookAt (NavDestino [2].position);
				} else if (colisao.gameObject.name == "DestinoNav4") {
						numeroDestino = 3;
						this.transform.LookAt (NavDestino [3].position);
				} else if (colisao.gameObject.name == "DestinoNav5") {
						numeroDestino = 4;
						this.transform.LookAt (NavDestino [4].position);
				}
		}
	
}
