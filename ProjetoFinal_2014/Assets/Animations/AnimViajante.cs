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
				if (DestinosAnim.AndarViajante == true || DestinosTCPAnim.AndarViajante == true) {
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
						DestinosTCPAnim.AndarViajante = false;

				}		

				if (numeroDestino >= 0 && numeroDestino != 10) {
						agente = gameObject.GetComponent<NavMeshAgent> ();
						agente.SetDestination (NavDestino [numeroDestino].position);
				}
				// calculo da distancia entre o taxi e o destino
				distancia = (int)Vector3.Distance (Taxi.transform.position, destino.transform.position);
				
				if (distancia > 30){
				// Rodar passageiro, para ficar de frente para o taxi
					this.transform.LookAt (referencia.transform); 
				}
				// Caso a distancia seja <100m, o passageiro levanta a mao para chamar o taxi
				if (distancia > 2 && distancia < 100) {
						anim.SetBool ("ChamarTaxi", true);	
				} else {
						anim.SetBool ("ChamarTaxi", false);	
				}
				// AbrirPorta = true e definido quando o passageiro percorre todos os destinos
				// a volta do carro e chega ao destino 0
				if (AbrirPorta == true) {
						time += Time.deltaTime; //contador de tempo
						if (time > 2.1 && time < 2.9) {
								RotacaoPorta = -40 * Time.deltaTime; // Abrir a Porta
								porta.transform.Rotate (new Vector3 (0, RotacaoPorta, 0));
						} else if (time > 3.1 && time < 3.29) {
								RotacaoPorta = 170 * Time.deltaTime; // Fechar a Porta
								porta.transform.Rotate (new Vector3 (0, RotacaoPorta, 0));
								entrouNoCarro = true;
						} else if (AbrirPorta == true && entrouNoCarro == true) {
								// Colocar a porta na posiçao correta, e mandar seguir o carro.
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
				// Activar a animaçao abrir o carro caso o passageiro chegue ao taxi
				if (colisao.gameObject.name == "TAXI") {
						anim.SetBool ("Andar", false);
						anim.SetBool ("AbrirCarro", true);
						AbrirPorta = true;
				}
				// Percorrer os destinos a volta do taxi ate ao Destino0 (Porta)
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
