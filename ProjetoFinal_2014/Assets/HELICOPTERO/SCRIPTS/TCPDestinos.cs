using UnityEngine;
using System.Collections;
using System;

public class TCPDestinos : MonoBehaviour
{
	
		string DestinoAnterior;
		string ColisaoActual;
		public GameObject SetaDireita;
		public GameObject SetaEsquerda;
		public static int NumeroDestino = 1;
		int Aceleracao = 10;
		int Velocidade = 10;
		string DestinoActual;
		public GameObject EscolhaDestino;
		public Transform[] destino;
		private NavMeshAgent agente;
		public int Pontuacao = 0;
		public string comando;				 // contem a tecla que o utilizador escolheu
		public bool chegouDestino = false; 	 // verifica se passou num trigger Destino
		public bool ParouCruzamento = false; // Serve para verificar se chegou a um cruzamento
		public static float distancia;
		public GUIText DistanciaGUI;
		bool EnviarMatLab = true; // ficheiro que controla o pedido de envio de freq, para nao enviar mais que uma vez
		bool EnviarMatLabModoJogo = true; // variavel que controla o pedido de envio de ModoJogo
		float tempo = 0; // enviar comando ao MatLab 2s depois da conexao
		// Use this for initialization
		public static bool novoCmdRecebido = false;
		bool controlocolisao = false;
		string DirValor;
		string EsqValor;

		void Start ()
		{	
				Time.timeScale = 1.0f;
				EscolhaDestino.SetActive (false);
				SetaDireita.SetActive (false);
				SetaEsquerda.SetActive (false);
				DestinoActual = "Destino20";
				DestinoAnterior = "Destino20";
				comando = "";

				int d = Convert.ToInt32(MatLab_Det_Setas.DirValor.ToString(), 10);
				char dir = (char) d;
				DirValor = dir.ToString ();
				
				int e = Convert.ToInt32(MatLab_Det_Setas.EsqValor.ToString(), 10);
				char esq = (char) e;
				EsqValor = esq.ToString ();
		}
	
		// Update is called once per frame
		void Update ()
		{	// Se houver ligacao TCP com o jogo ele anda, senao fica parado
				if (Tcpheli.conectado == true) {
						tempo += Time.deltaTime;
						/*if (EnviarMatLabModoJogo == true && tempo > 11) { // Cada vez que se perde ligaçao e retoma, envia um pedido de jogo modo2 (1 em 1s)
							int n = Convert.ToInt32(MatLab_Env_Comando.modo1Valor.ToString (), 10);
							char res = (char) n;
							string msg = res.ToString ();				

							Tcpheli.mensagemMatLab = msg + "1";
							Tcpheli.EnviarComandoMatLabHeli = true;
							EnviarMatLabModoJogo = false;
						}*/

						distancia = (int)Vector3.Distance (this.transform.position, destino [NumeroDestino].transform.position);
						DistanciaGUI.guiText.text = distancia + "m";
					
						// Escolha da tecla correspondente ao destino do Helicoptero
						if (EscolhaDestino.activeSelf == true || ParouCruzamento == true) { 
						if (Tcpheli.comand.Equals (DirValor) && Tcpheli.RecebeuComando==true ||Input.GetKey (KeyCode.M)) {
								//if (Tcpheli.comand.Equals ("B") && Tcpheli.RecebeuComando == true/*|| Tcpheli.comand.Equals ("D")*/) {
										novoCmdRecebido = true;
										Tcpheli.comand.Equals ("");
										comando = "M";
										SetaDireita.SetActive (true);
										//EnviarMatLab = true;
										EscolhaDestino.SetActive (false);
										this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
										if (this.gameObject.GetComponent<NavMeshAgent> ().enabled == false) {
												ParouCruzamento = false;
												ActivarNavMesh (Velocidade, Aceleracao);
										}

								}
						if (Tcpheli.comand.Equals (EsqValor) && Tcpheli.RecebeuComando==true || Input.GetKey (KeyCode.Z)) {
							//	if (Tcpheli.comand.Equals ("A") && Tcpheli.RecebeuComando == true/* || Tcpheli.comand.Equals ("C")*/) {	
										novoCmdRecebido = true;
										Tcpheli.comand.Equals ("");
										comando = "Z";
										SetaEsquerda.SetActive (true);
										//EnviarMatLab = true;
										EscolhaDestino.SetActive (false);
										this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
										if (this.gameObject.GetComponent<NavMeshAgent> ().enabled == false) {
												ParouCruzamento = false;
												ActivarNavMesh (Velocidade, Aceleracao);
										}
								}
						}
		
						// Dar destino ao Taxi segundo a tecla em cima pressionada
						if (comando != "" && chegouDestino == true) {
								if (comando == "M") {
										VirarDireita ();
										comando = "";
										DestinoAnterior = DestinoActual;
										chegouDestino = false;
				
								}
								if (comando == "Z") {
										VirarEsquerda ();
										comando = "";
										DestinoAnterior = DestinoActual;
										chegouDestino = false;
								}
								comando = "";
						}
		
						// Enviar comando ao MatLab 2s antes
						/*if (distancia < 120) {
								if (EnviarMatLab == true) { // Para apenas mandar o comando 1 vez
										//Tcpheli.mensagemMatLab = MatLab_Env_Comando.ini_estimuloValor.ToString () + "1"; // Mensagem de para pedir Frequencia
										Tcpheli.mensagemMatLab = "R1";
										Tcpheli.EnviarComandoMatLabHeli = true;  // Dizer ao MatLab para enviar comando -- Class TCPheli
										EnviarMatLab = false;
								}
						}*/


						// Verificacao de colidiu com os Triggers colocados ao meio das ruas, para visualizar as direcoes
						if (distancia <= 100 && comando == "" && controlocolisao == false) {
								if (EnviarMatLab == true) { // Para apenas mandar o comando 1 vez
									int n = Convert.ToInt32(MatLab_Env_Comando.ini_estimuloValor.ToString (), 10);
									char res = (char) n;
									string msg = res.ToString ();			
									Tcpheli.mensagemMatLab = msg + "1";
									Tcpheli.EnviarComandoMatLabHeli = true; // Dizer ao MatLab para enviar comando -- Class Tcpheli
									EnviarMatLab = false;
								}
								EscolhaDestino.SetActive (true);
								this.gameObject.GetComponent<NavMeshAgent> ().speed = Mathf.Floor (Velocidade / 2);
						} else if (distancia > 100) {
								SetaDireita.SetActive (false);
								SetaEsquerda.SetActive (false);
								controlocolisao = false;
								Tcpheli.comand.Equals ("");
								comando = "";
								EnviarMatLab = true;
								EscolhaDestino.SetActive (false);
								this.gameObject.GetComponent<NavMeshAgent> ().speed = Mathf.Floor (Velocidade);
						}
		
						// Colocar o Taxi na rota de destino definida pela tecla pressionada, se o NavMesh estiver ativo
						if (this.gameObject.GetComponent<NavMeshAgent> ().enabled == true) {
								agente = gameObject.GetComponent<NavMeshAgent> ();
								agente.SetDestination (destino [NumeroDestino].position);
						}
		
				} else {
						EnviarMatLabModoJogo = true;
						tempo = 0;
				}

		}

		void OnGUI(){
			Velocidade = (int)GUI.HorizontalSlider (new Rect (Screen.width/3, Screen.height/14, Screen.width/4, Screen.width/5), Velocidade, 5, 20);
		}
	
		void OnTriggerEnter (Collider collision)
		{
		
				// Verificacao de colidiu com algum Trigger Destino. Esta condicao serve para verificar onde estao os viajantes,
				// bem como verificar se o jogador definiu algum caminho antes de chegar ao cruzamento
				if (collision.gameObject.name.Contains ("Destino") && DestinoActual != collision.gameObject.name) {
						controlocolisao = true;
			
						// Verificacao se chegou ao cruzamento ja com rota definida ou nao. Se nao para o carro e espera direcao
						if (comando == "") {
								this.gameObject.GetComponent<NavMeshAgent> ().speed = 0;
								this.gameObject.GetComponent<NavMeshAgent> ().acceleration = 0;
								this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
								ParouCruzamento = true;
						}
						// Actualiza o Destino Actual, para saber em que sentido o Taxi segue
						//comando = "";

						DestinoActual = collision.gameObject.name;
						chegouDestino = true;

				}
		}
	
		// Verificacao se o Taxi parou num cruzamento, se parou ativa de novo o NavMesh e respectivas Velocidades
		void ActivarNavMesh (int Velocidade, int Aceleracao)
		{
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
				this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
				this.gameObject.GetComponent<NavMeshAgent> ().acceleration = Aceleracao; 
		}

	
		//  ----------------------  FUNCOES RELATIVAS A DIRECAO ESCOLHIDA ------------------------------------------------------
		void VirarDireita ()
		{
		
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino20") {
						NumeroDestino = 3;
				}
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino2") {
						NumeroDestino = 20;
				}
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino3") {
						NumeroDestino = 2;
				}
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino7") {
						NumeroDestino = 2;
				}
		
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino1") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino3") {
						NumeroDestino = 4;
				}
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino4") {
						NumeroDestino = 1;
				}
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino5") {
						NumeroDestino = 4;
				}
		
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino1") {
						NumeroDestino = 7;
				}
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino5") {
						NumeroDestino = 1;
				}
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino6") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino7") {
						NumeroDestino = 6;
				}
		
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino2") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino5") {
						NumeroDestino = 9;
				}
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino9") {
						NumeroDestino = 2;
				}
		
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino2") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino3") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino4") {
						NumeroDestino = 3;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino6") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino10") {
						NumeroDestino = 4;
				}
		
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino3") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino11") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino12") {
						NumeroDestino = 11;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino7") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino5") {
					NumeroDestino = 3;
				}
		
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino3") {
						NumeroDestino = 8;
				}
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino8") {
						NumeroDestino = 6;
				}
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino6") {
						NumeroDestino = 3;
				}
		
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino7") {
						NumeroDestino = 20;
				}
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino12") {
						NumeroDestino = 7;
				}
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino13") {
						NumeroDestino = 7;
				}
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino20") {
						NumeroDestino = 13;
				}
		
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino4") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino10") {
						NumeroDestino = 14;
				}
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino14") {
						NumeroDestino = 4;
				}
		
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino5") {
						NumeroDestino = 11;
				}
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino11") {
						NumeroDestino = 15;
				}
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino14") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino15") {
						NumeroDestino = 9;
				}
		
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino6") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino10") {
						NumeroDestino = 6;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino12") {
						NumeroDestino = 15;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino15") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino16") {
						NumeroDestino = 15;
				}
		
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino6") {
						NumeroDestino = 13;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino8") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino11") {
						NumeroDestino = 8;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino13") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino16") {
						NumeroDestino = 11;
				}
		
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino8") {
						NumeroDestino = 17;
				}
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino12") {
						NumeroDestino = 8;
				}
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino17") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino20") {
					NumeroDestino = 17;
				}
		
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino9") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino19") {
						NumeroDestino = 9;
				}
		
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino10") {
						NumeroDestino = 18;
				}
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino11") {
						NumeroDestino = 18;
				}
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino18") {
						NumeroDestino = 19;
				}
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino19") {
						NumeroDestino = 10;
				}
		
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino11") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino12") {
						NumeroDestino = 17;
				}
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino17") {
						NumeroDestino = 18;
				}
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino18") {
						NumeroDestino = 11;
				}
		
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino13") {
						NumeroDestino = 18;
				}
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino16") {
						NumeroDestino = 13;
				}
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino18") {
						NumeroDestino = 16;
				}
		
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino15") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino16") {
						NumeroDestino = 17;
				}
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino17") {
						NumeroDestino = 19;
				}
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino19") {
						NumeroDestino = 16;
				}
		
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino14") {
						NumeroDestino = 15;
				}
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino15") {
						NumeroDestino = 18;
				}
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino18") {
						NumeroDestino = 14;
				}
		
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino1") {
						NumeroDestino = 1;
				}
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino8") {
						NumeroDestino = 1;
				}
		
		}
	
		void VirarEsquerda ()
		{
		
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino20") {
						NumeroDestino = 2;
				}
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino2") {
						NumeroDestino = 3;
				}
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino3") {
						NumeroDestino = 20;
				}
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino7") {
					NumeroDestino = 20;
				}
		
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino1") {
						NumeroDestino = 4;
				}
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino3") {
						NumeroDestino = 1;
				}
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino4") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino5") {
						NumeroDestino = 1;
				}
		
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino1") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino5") {
						NumeroDestino = 6;
				}
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino6") {
						NumeroDestino = 2;
				}
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino7") {
						NumeroDestino = 1;
				}
		
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino2") {
						NumeroDestino = 9;
				}
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino5") {
						NumeroDestino = 2;
				}
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino9") {
						NumeroDestino = 5;
				}
		
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino2") {
						NumeroDestino = 4;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino3") {
						NumeroDestino = 4;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino4") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino6") {
						NumeroDestino = 2;
				}
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino10") {
						NumeroDestino = 2;
				}
		
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino3") {
						NumeroDestino = 11;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino11") {
						NumeroDestino = 7;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino12") {
						NumeroDestino = 3;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino7") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino5") {
						NumeroDestino = 11;
				}
		
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino3") {
						NumeroDestino = 6;
				}
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino8") {
						NumeroDestino = 1;
				}
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino6") {
						NumeroDestino = 8;
				}
		
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino7") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino12") {
						NumeroDestino = 13;
				}
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino13") {
						NumeroDestino = 20;
				}
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino20") {
						NumeroDestino = 7;
				}
		
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino4") {
						NumeroDestino = 14;
				}
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino10") {
						NumeroDestino = 4;
				}
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino14") {
						NumeroDestino = 10;
				}
		
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino5") {
						NumeroDestino = 9;
				}
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino11") {
						NumeroDestino = 5;
				}
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino14") {
						NumeroDestino = 15;
				}
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino15") {
						NumeroDestino = 11;
				}
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino9") {
						NumeroDestino = 15;
				}
		
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino6") {
						NumeroDestino = 10;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino10") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino12") {
						NumeroDestino = 6;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino15") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino16") {
						NumeroDestino = 6;
				}
		
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino6") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino8") {
						NumeroDestino = 6;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino11") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino13") {
						NumeroDestino = 11;
				}
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino16") {
						NumeroDestino = 13;
				}
		
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino8") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino12") {
						NumeroDestino = 17;
				}
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino17") {
						NumeroDestino = 8;
				}
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino20") {
						NumeroDestino = 12;
				}
		
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino9") {
						NumeroDestino = 9;
				}
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino19") {
						NumeroDestino = 19;
				}
		
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino10") {
						NumeroDestino = 19;
				}
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino11") {
						NumeroDestino = 19;
				}
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino18") {
						NumeroDestino = 11;
				}
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino19") {
						NumeroDestino = 18;
				}
		
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino11") {
						NumeroDestino = 17;
				}
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino12") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino17") {
						NumeroDestino = 12;
				}
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino18") {
						NumeroDestino = 17;
				}
		
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino13") {
						NumeroDestino = 16;
				}
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino16") {
						NumeroDestino = 18;
				}
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino18") {
						NumeroDestino = 18;
				}
		
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino15") {
						NumeroDestino = 19;
				}
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino16") {
						NumeroDestino = 15;
				}
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino17") {
						NumeroDestino = 15;
				}
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino19") {
						NumeroDestino = 17;
				}
		
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino14") {
						NumeroDestino = 18;
				}
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino15") {
						NumeroDestino = 14;
				}
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino18") {
						NumeroDestino = 15;
				}
		
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino1") {
						NumeroDestino = 8;
				}
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino8") {
						NumeroDestino = 13;
				}
		
		}
	
}