using UnityEngine;
using System.Collections;

public class TCPHeliLivre : MonoBehaviour
{		
	
		public Transform[] destino;
		public int Pontuacao = 0;
		public string comando;				 // contem a tecla que o utilizador escolheu
		public static float distancia;
		public GameObject Estimulos;
		bool EnviarMatLab = true;
		
		// Use this for initialization
		void Start ()
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (Tcpheli.conectado == true) {

						if (EnviarMatLab == true) { // Cada vez que se perde ligaçao e retoma, envia um pedido de Frequencias
								EnviarMatLab = false;
				Tcpheli.EnviarComandoMatLabHeli=true;
						}
						Estimulos.SetActive (true);

						if (!Input.GetKey (KeyCode.UpArrow)) {
								if (this.gameObject.transform.position.y > EscolherAneis.PosicaoYAneis) {
										this.transform.Translate (new Vector3 (0, -2 * Time.deltaTime, 0));
								}
						}
						this.transform.Translate (new Vector3 (0, 0, 10 * Time.deltaTime));
				
						// Se houver ligacao TCP com o jogo ele anda, senao fica parado
						if (Tcpheli.conectado == true) {

								if (Tcpheli.comand.Equals ("A")) {
										this.transform.Rotate (new Vector3 (0, 10 * Time.deltaTime, 0));	
								}
								if (Tcpheli.comand.Equals ("B")) {
										this.transform.Rotate (new Vector3 (0, -10 * Time.deltaTime, 0));
								}
						
								if (Tcpheli.comand.Equals ("C")) {
										this.transform.Translate (new Vector3 (0, 2 * Time.deltaTime, 0));
								}
						}
				


						if (Input.GetKey (KeyCode.RightArrow)) {
								this.transform.Rotate (new Vector3 (0, 10 * Time.deltaTime, 0));	
						}
						if (Input.GetKey (KeyCode.LeftArrow)) {
								this.transform.Rotate (new Vector3 (0, -10 * Time.deltaTime, 0));
						}
		
						if (Input.GetKey (KeyCode.UpArrow)) {
								this.transform.Translate (new Vector3 (0, 2 * Time.deltaTime, 0));
						}

				} else {
					EnviarMatLab=true; 
				}
		}
		
		void OnTriggerEnter (Collider collision)
		{
			


		}
}
