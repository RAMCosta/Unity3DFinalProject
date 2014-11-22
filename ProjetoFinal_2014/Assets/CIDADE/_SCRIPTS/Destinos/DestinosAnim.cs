using UnityEngine;
using System.Collections;

public class DestinosAnim : MonoBehaviour {

	string DestinoAnterior;
	string ColisaoActual;
	int NumeroDestino = 5;
	int Aceleracao = 10;
	int Velocidade = 10;
	string DestinoActual;
	public GameObject EscolhaDestino;
	public Transform[] destino;
	private NavMeshAgent agente;
	public GameObject[] Viajantes;
	public GameObject[] ParticulasDestino;
	public int NumeroViajante = 0;
	public int Pontuacao = 0;
	public bool viajanteABordo = false;
	public GameObject Setas;
	public GUIText TextoPontos;
	public Material TaxiOcupado;
	public Material TaxiLivre;
	public string comando;				 // contem a tecla que o utilizador escolheu
	public bool chegouDestino = false; 	 // verifica se passou num trigger Destino
	public bool ParouCruzamento = false; // Serve para verificar se chegou a um cruzamento
	int distanciaDest;
	int distanciaViaj;
	public GUIText DistanciaGUI;
	public GUIText TempoGUI; // Tempo de jogo
	string niceTime;
	float timer; 
	bool clickMenuReiniciar = false;
	bool JogoAcabou = false;
	public GUIStyle TipoLetraFinal;
	public Texture pauseGUI;

	
	// variaveis para animacao
	public static bool AndarViajante = false;
	
	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1.0f;
		NumeroViajante = 0;
		Pontuacao = 0;
		viajanteABordo = false;
		chegouDestino = false;
		ParouCruzamento = false;
		clickMenuReiniciar = false;
		JogoAcabou = false;

		EscolhaDestino.SetActive (false);
		DestinoActual = "Destino4";
		DestinoAnterior = "Destino4";
		comando = "";
		
		int minutes = Mathf.FloorToInt (timer / 60F);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (AnimViajante.SeguirCarro == true) {
			
			if (AnimViajante.ActualizarDestino == true){
				AnimViajante.ActualizarDestino = false;
				ApanharViajante(NumeroViajante);
			}
			
			distanciaDest = (int)Vector3.Distance (this.transform.position, destino [NumeroDestino].transform.position);
			
			// Actualizacao dos pontos do Jogador
			TextoPontos.guiText.text = Pontuacao.ToString ();
			TempoGUI.guiText.text = niceTime;
			
			
			if (NumeroViajante >= 8) {
				Time.timeScale = 0.0f;	
			} else {
				timer += Time.deltaTime;
				int minutes = Mathf.FloorToInt (timer / 60F);
				int seconds = Mathf.FloorToInt (timer - minutes * 60);
				niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
			}

			if (viajanteABordo == false) {
				// indica a distancia entre o taxi e o passageiro
				distanciaViaj = (int)Vector3.Distance (this.transform.position, Viajantes [NumeroViajante].transform.position);
				// actualizacao da seta orientadora, neste caso, para o passageiro a ir apanhar
				Setas.transform.LookAt (Viajantes [NumeroViajante].transform);
				// Mudar a cor da placa em cima do taxi, para avisar se ocupado ou livre
				GameObject.Find ("EstadoDir").renderer.material = TaxiLivre;
				GameObject.Find ("EstadoEsq").renderer.material = TaxiLivre;
			} else {
				// indica a distancia entre o taxi e o destino do passageiro
				distanciaViaj = (int)Vector3.Distance (this.transform.position, ParticulasDestino [NumeroViajante].transform.position);
				// actualizacao da seta orientadora, neste caso, para o destino do passageiro
				Setas.transform.LookAt (ParticulasDestino [NumeroViajante].transform);
				// Mudar a cor da placa em cima do taxi, para avisar se ocupado ou livre
				GameObject.Find ("EstadoDir").renderer.material = TaxiOcupado;
				GameObject.Find ("EstadoEsq").renderer.material = TaxiOcupado;
			}

			DistanciaGUI.guiText.text = distanciaViaj + "m";

			// Escolha da tecla correspondente ao destino do Taxi
			if (EscolhaDestino.activeSelf == true || ParouCruzamento == true) {
				if (Input.GetKey (KeyCode.M) || Direita.DireitaTeclado == true) {
					comando = "M";
					EscolhaDestino.SetActive (false);
					Direita.DireitaTeclado = false;
					this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
					if (this.gameObject.GetComponent<NavMeshAgent> ().enabled == false) {
						ParouCruzamento = false;
						ActivarNavMesh (Velocidade, Aceleracao);
					}
					
				} else if (Input.GetKey (KeyCode.Z) || Esquerda.EsquerdaTeclado == true) {
					comando = "Z";
					EscolhaDestino.SetActive (false);
					Esquerda.EsquerdaTeclado = false;
					this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
					if (this.gameObject.GetComponent<NavMeshAgent> ().enabled == false) {
						ParouCruzamento = false;
						ActivarNavMesh (Velocidade, Aceleracao);
					}
				} else if (Input.GetKey (KeyCode.Y) || Frente.FrenteTeclado == true) {
					comando = "Y";
					EscolhaDestino.SetActive (false);
					Frente.FrenteTeclado = false;
					this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
					if (this.gameObject.GetComponent<NavMeshAgent> ().enabled == false) {
						ParouCruzamento = false;
						ActivarNavMesh (Velocidade, Aceleracao);
					}
				}
			}
			if (distanciaDest <= 100 && comando == "") {
				EscolhaDestino.SetActive (true);
				this.gameObject.GetComponent<NavMeshAgent> ().speed = Mathf.Floor (Velocidade / 2);
			} else if (distanciaDest > 100) {
				comando = "";
				EscolhaDestino.SetActive (false);
				this.gameObject.GetComponent<NavMeshAgent> ().speed = Mathf.Floor (Velocidade);
			}

			
			// Dar destino ao Taxi segundo a tecla pressionada
			if (comando != "" && chegouDestino == true) {
				
				if (comando == "M") {
					VirarDireita ();	
				}
				if (comando == "Z") {
					VirarEsquerda ();
				}
				if (comando == "Y") {
					SeguirEmFrente ();
				}
				comando = "";
				DestinoAnterior = DestinoActual;
				chegouDestino = false;
				
			}


			// Colocar o Taxi na rota de destino definida pela tecla pressionada, se o NavMesh estiver ativo
			if (this.gameObject.GetComponent<NavMeshAgent> ().enabled == true) {
				agente = gameObject.GetComponent<NavMeshAgent> ();
				agente.SetDestination (destino [NumeroDestino].position);
			}
			
			
		}

		if (clickMenuReiniciar == true) {
			Application.LoadLevel ("Taxi3DTeclado");
		}

	}
	
	void OnTriggerEnter (Collider collision)
	{
		// Verificacao de colidiu com algum Trigger Destino. Esta condicao serve para verificar onde estao os viajantes,
		// bem como verificar se o jogador definiu algum caminho antes de chegar ao cruzamento
		if (collision.gameObject.name.Contains ("Destino") && DestinoActual != collision.gameObject.name) {
			chegouDestino = true;
			this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
			
			// -------------------- VIAJANTE 0 ---------------------------------------------
			if (collision.gameObject.name == "Destino5" && Viajantes [0].activeSelf == true) {
				AndarViajante = true;		
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
				//ApanharViajante (NumeroViajante);
				
			}
			if (collision.gameObject.name == "Destino17" && NumeroViajante == 0) {
				LargarViajante (NumeroViajante);
			}
			
			// ------------------------- VIAJANTE 1 -------------------------------------

			// Caso o destino em que o taxi bateu o local do passageiro em questao e este esteja ativo
			if (collision.gameObject.name == "Destino40" && Viajantes [1].activeSelf == true) {
				// preparar animaçao de andamento do passageiro
				AndarViajante = true;
				// Desabilita a componente NavMesh, para o carro ficar imovel ate o passageiro entrar
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			}

			// Caso o taxi colida com o local de destino, e o numero de passageiro for o destinado a este local
			if (collision.gameObject.name == "Destino46" && NumeroViajante == 1) {
				LargarViajante (NumeroViajante);
			}
			
			// ------------------------- VIAJANTE 2 -------------------------------------
			
			if (collision.gameObject.name == "Destino52" && Viajantes [2].activeSelf == true) {
				AndarViajante = true;		
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			}
			if (collision.gameObject.name == "Destino20" && NumeroViajante == 2) {
				LargarViajante (NumeroViajante);
			}
			
			// --------------------- VIAJANTE 3 ----------------------------------------
			if (collision.gameObject.name == "Destino11" && Viajantes [3].activeSelf == true) {
				AndarViajante = true;		
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			}
			if (collision.gameObject.name == "Destino35" && NumeroViajante == 3) {
				LargarViajante (NumeroViajante);
			}
			
			// --------------------- VIAJANTE 4 ----------------------------------------
			if (collision.gameObject.name == "Destino34" && Viajantes [4].activeSelf == true) {
				AndarViajante = true;		
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			}
			if (collision.gameObject.name == "Destino24" && NumeroViajante == 4) {
				LargarViajante (NumeroViajante);
			}
			
			
			// --------------------- VIAJANTE 5 ----------------------------------------
			if (collision.gameObject.name == "Destino37" && Viajantes [5].activeSelf == true) {
				AndarViajante = true;		
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			}
			if (collision.gameObject.name == "Destino2" && NumeroViajante == 5) {
				LargarViajante (NumeroViajante);
			}
			
			// --------------------- VIAJANTE 6 ----------------------------------------
			if (collision.gameObject.name == "Destino58" && Viajantes [6].activeSelf == true) {
				AndarViajante = true;		
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			}
			if (collision.gameObject.name == "Destino16" && NumeroViajante == 6) {
				LargarViajante (NumeroViajante);
			}
			
			// --------------------- VIAJANTE 7 ----------------------------------------
			if (collision.gameObject.name == "Destino13" && Viajantes [7].activeSelf == true) {
				AndarViajante = true;		
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			}
			if (collision.gameObject.name == "Destino64" && NumeroViajante == 7) {
				LargarViajante (NumeroViajante);
				this.audio.Stop();
				Time.timeScale = 0.0f;
				JogoAcabou = true;

			}



			// Verificacao se chegou ao cruzamento ja com rota definida ou nao. Se nao para o carro e espera direcao
			if (comando == "") {
				this.gameObject.GetComponent<NavMeshAgent> ().speed = 0;
				this.gameObject.GetComponent<NavMeshAgent> ().acceleration = 0;
				this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
				ParouCruzamento = true;
			}
			// Actualiza o Destino Actual, para saber em que sentido o Taxi segue
			DestinoActual = collision.gameObject.name;
		}
	}
	
	// Verificacao se o Taxi parou num cruzamento, se parou ativa de novo o NavMesh e respectivas Velocidades
	void ActivarNavMesh (int Velocidade, int Aceleracao)
	{
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		this.gameObject.GetComponent<NavMeshAgent> ().speed = Velocidade;
		this.gameObject.GetComponent<NavMeshAgent> ().acceleration = Aceleracao;
	}
	
	// Funcao que serve para desativar o viajante que esta no carro, bem como ativar a particula para o local de destino
	void ApanharViajante (int viajante)
	{
		Viajantes [viajante].SetActive (false);
		ParticulasDestino [viajante].SetActive (true);
		ActivarNavMesh (Velocidade,Aceleracao);
		viajanteABordo = true;
	}
	
	// Funcao que serve para desativar a particula de destino e ativar o viajante seguinte
	void LargarViajante (int destino)
	{
		ParticulasDestino [NumeroViajante].SetActive (false);
		NumeroViajante++;
		Pontuacao += 490 + (NumeroViajante * 10);
		Viajantes [NumeroViajante].SetActive (true);
		viajanteABordo = false;
	}

	void OnGUI ()
	{
		
		if (JogoAcabou == true) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), pauseGUI);
			GUI.Label (new Rect ((Screen.width / 4), (Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "FIM DO JOGO", TipoLetraFinal);
			GUI.Label (new Rect ((Screen.width / 10), (3 * Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "Tempo : " + niceTime, TipoLetraFinal);
			GUI.Label (new Rect ((6*Screen.width / 10), (3 * Screen.height / 10), 2 * Screen.width / 4, Screen.height / 8), "Pontos : " + Pontuacao, TipoLetraFinal);
			if (GUI.Button (new Rect ((Screen.width / 4), (4 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Reiniciar")) {
				clickMenuReiniciar = true;
			}
			if (GUI.Button (new Rect ((Screen.width / 4), (6 * Screen.height / 8), 2 * Screen.width / 4, Screen.height / 8), "Sair")) {
				Application.LoadLevel ("MainMenu");
			}
		}
	}

	//  ----------------------  FUNCOES RELATIVAS A DIRECAO ESCOLHIDA ------------------------------------------------------
	void VirarDireita ()
	{
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino63") {
						NumeroDestino = 2;
				} else if (DestinoActual == "Destino2" && DestinoAnterior == "Destino1") {
						NumeroDestino = 3;
				} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino2") {
						NumeroDestino = 10;
				} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino4") {
						NumeroDestino = 2;
				} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino10") {
						NumeroDestino = 12;
				} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino12") {
						NumeroDestino = 4;
				} else if (DestinoActual == "Destino4" && DestinoAnterior == "Destino3") {
						NumeroDestino = 13;
				} else if (DestinoActual == "Destino4" && DestinoAnterior == "Destino13") {
						NumeroDestino = 5;
				} else if (DestinoActual == "Destino5" && DestinoAnterior == "Destino4") {
						NumeroDestino = 14;
				} else if (DestinoActual == "Destino5" && DestinoAnterior == "Destino14") {
						NumeroDestino = 6;
				} else if (DestinoActual == "Destino6" && DestinoAnterior == "Destino5") {
						NumeroDestino = 15;
				} else if (DestinoActual == "Destino6" && DestinoAnterior == "Destino15") {
						NumeroDestino = 7;
				} else if (DestinoActual == "Destino7" && DestinoAnterior == "Destino6") {
						NumeroDestino = 16;
				} else if (DestinoActual == "Destino7" && DestinoAnterior == "Destino16") {
						NumeroDestino = 8;
				} else if (DestinoActual == "Destino8" && DestinoAnterior == "Destino7") {
						NumeroDestino = 17;
				} else if (DestinoActual == "Destino8" && DestinoAnterior == "Destino17") {
						NumeroDestino = 9;
				} else if (DestinoActual == "Destino9" && DestinoAnterior == "Destino8") {
						NumeroDestino = 18;
				} else if (DestinoActual == "Destino10" && DestinoAnterior == "Destino11") {
						NumeroDestino = 3;
				} else if (DestinoActual == "Destino10" && DestinoAnterior == "Destino22") {
						NumeroDestino = 11;
				} else if (DestinoActual == "Destino11" && DestinoAnterior == "Destino10") {
						NumeroDestino = 19;
				} else if (DestinoActual == "Destino11" && DestinoAnterior == "Destino19") {
						NumeroDestino = 12;
				} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino3") {
						NumeroDestino = 11;
				} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino11") {
						NumeroDestino = 19;
				} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino13") {
						NumeroDestino = 3;
				} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino19") {
						NumeroDestino = 13;
				} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino4") {
						NumeroDestino = 12;
				} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino12") {
						NumeroDestino = 21;
				} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino14") {
						NumeroDestino = 4;
				} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino21") {
						NumeroDestino = 14;
				} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino5") {
						NumeroDestino = 13;
				} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino13") {
						NumeroDestino = 27;
				} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino15") {
						NumeroDestino = 5;
				} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino27") {
						NumeroDestino = 15;
				} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino6") {
						NumeroDestino = 14;
				} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino14") {
						NumeroDestino = 28;
				} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino16") {
						NumeroDestino = 6;
				} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino28") {
						NumeroDestino = 16;
				} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino7") {
						NumeroDestino = 15;
				} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino15") {
						NumeroDestino = 29;
				} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino17") {
						NumeroDestino = 7;
				} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino29") {
						NumeroDestino = 17;
				} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino8") {
						NumeroDestino = 16;
				} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino16") {
						NumeroDestino = 30;
				} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino18") {
						NumeroDestino = 8;
				} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino30") {
						NumeroDestino = 18;
				} else if (DestinoActual == "Destino18" && DestinoAnterior == "Destino9") {
						NumeroDestino = 17;
				} else if (DestinoActual == "Destino18" && DestinoAnterior == "Destino17") {
						NumeroDestino = 31;
				} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino11") {
						NumeroDestino = 24;
				} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino12") {
						NumeroDestino = 11;
				} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino20") {
						NumeroDestino = 12;
				} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino24") {
						NumeroDestino = 20;
				} else if (DestinoActual == "Destino20" && DestinoAnterior == "Destino19") {
						NumeroDestino = 25;
				} else if (DestinoActual == "Destino20" && DestinoAnterior == "Destino25") {
						NumeroDestino = 21;
				} else if (DestinoActual == "Destino21" && DestinoAnterior == "Destino13") {
						NumeroDestino = 20;
				} else if (DestinoActual == "Destino21" && DestinoAnterior == "Destino20") {
						NumeroDestino = 26;
				} else if (DestinoActual == "Destino22" && DestinoAnterior == "Destino23") {
						NumeroDestino = 10;
				} else if (DestinoActual == "Destino22" && DestinoAnterior == "Destino32") {
						NumeroDestino = 23;
				} else if (DestinoActual == "Destino23" && DestinoAnterior == "Destino22") {
						NumeroDestino = 32;
				} else if (DestinoActual == "Destino23" && DestinoAnterior == "Destino32") {
						NumeroDestino = 24;
				} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino19") {
						NumeroDestino = 23;
				} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino23") {
						NumeroDestino = 33;
				} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino25") {
						NumeroDestino = 19;
				} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino33") {
						NumeroDestino = 25;
				} else if (DestinoActual == "Destino25" && DestinoAnterior == "Destino20") {
						NumeroDestino = 24;
				} else if (DestinoActual == "Destino25" && DestinoAnterior == "Destino26") {
						NumeroDestino = 20;
				} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino21") {
						NumeroDestino = 25;
				} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino25") {
						NumeroDestino = 36;
				} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino27") {
						NumeroDestino = 21;
				} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino36") {
						NumeroDestino = 27;
				} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino14") {
						NumeroDestino = 26;
				} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino26") {
						NumeroDestino = 37;
				} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino28") {
						NumeroDestino = 14;
				} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino37") {
						NumeroDestino = 28;
				} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino15") {
						NumeroDestino = 27;
				} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino27") {
						NumeroDestino = 38;
				} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino38") {
						NumeroDestino = 29;
				} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino29") {
						NumeroDestino = 15;
				} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino16") {
						NumeroDestino = 28;
				} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino28") {
						NumeroDestino = 39;
				} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino39") {
						NumeroDestino = 30;
				} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino30") {
						NumeroDestino = 16;
				} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino17") {
						NumeroDestino = 29;
				} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino29") {
						NumeroDestino = 40;
				} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino40") {
						NumeroDestino = 31;
				} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino31") {
						NumeroDestino = 17;
				} else if (DestinoActual == "Destino31" && DestinoAnterior == "Destino18") {
						NumeroDestino = 30;
				} else if (DestinoActual == "Destino31" && DestinoAnterior == "Destino30") {
						NumeroDestino = 41;
				} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino22") {
						NumeroDestino = 34;
				} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino23") {
						NumeroDestino = 22;
				} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino33") {
						NumeroDestino = 23;
				} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino35") {
						NumeroDestino = 33;
				} else if (DestinoActual == "Destino33" && DestinoAnterior == "Destino24") {
						NumeroDestino = 32;
				} else if (DestinoActual == "Destino33" && DestinoAnterior == "Destino32") {
						NumeroDestino = 35;
				} else if (DestinoActual == "Destino33" && DestinoAnterior == "Destino35") {
						NumeroDestino = 24;
				} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino33") {
						NumeroDestino = 32;
				} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino34") {
						NumeroDestino = 45;
				} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino36") {
						NumeroDestino = 33;
				} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino45") {
						NumeroDestino = 36;
				} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino42") {
						NumeroDestino = 36;
				} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino26") {
						NumeroDestino = 35;
				} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino35") {
						NumeroDestino = 46;
				} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino37") {
						NumeroDestino = 26;
				} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino46") {
						NumeroDestino = 37;
				} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino27") {
						NumeroDestino = 36;
				} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino36") {
						NumeroDestino = 47;
				} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino38") {
						NumeroDestino = 27;
				} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino47") {
						NumeroDestino = 38;
				} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino28") {
						NumeroDestino = 37;
				} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino37") {
						NumeroDestino = 48;
				} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino39") {
						NumeroDestino = 28;
				} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino48") {
						NumeroDestino = 39;
				} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino29") {
						NumeroDestino = 38;
				} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino38") {
						NumeroDestino = 49;
				} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino40") {
						NumeroDestino = 29;
				} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino49") {
						NumeroDestino = 40;
				} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino30") {
						NumeroDestino = 39;
				} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino39") {
						NumeroDestino = 50;
				} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino41") {
						NumeroDestino = 30;
				} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino50") {
						NumeroDestino = 41;
				} else if (DestinoActual == "Destino41" && DestinoAnterior == "Destino31") {
						NumeroDestino = 40;
				} else if (DestinoActual == "Destino41" && DestinoAnterior == "Destino40") {
						NumeroDestino = 51;
				} else if (DestinoActual == "Destino42" && DestinoAnterior == "Destino43") {
						NumeroDestino = 44;
				} else if (DestinoActual == "Destino42" && DestinoAnterior == "Destino44") {
						NumeroDestino = 35;
				} else if (DestinoActual == "Destino43" && DestinoAnterior == "Destino42") {
						NumeroDestino = 35;
				} else if (DestinoActual == "Destino43" && DestinoAnterior == "Destino45") {
						NumeroDestino = 42;
				} else if (DestinoActual == "Destino44" && DestinoAnterior == "Destino36") {
						NumeroDestino = 42;
				} else if (DestinoActual == "Destino44" && DestinoAnterior == "Destino42") {
						NumeroDestino = 46;
				} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino35") {
						NumeroDestino = 64;
				} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino46") {
						NumeroDestino = 35;
				} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino52") {
						NumeroDestino = 46;
				} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino64") {
						NumeroDestino = 52;
				} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino36") {
						NumeroDestino = 45;
				} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino45") {
						NumeroDestino = 53;
				} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino47") {
						NumeroDestino = 36;
				} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino53") {
						NumeroDestino = 47;
				} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino37") {
						NumeroDestino = 46;
				} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino46") {
						NumeroDestino = 54;
				} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino48") {
						NumeroDestino = 37;
				} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino54") {
						NumeroDestino = 48;
				} else if (DestinoActual == "Destino48" && DestinoAnterior == "Destino38") {
						NumeroDestino = 47;
				} else if (DestinoActual == "Destino48" && DestinoAnterior == "Destino49") {
						NumeroDestino = 38;
				} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino39") {
						NumeroDestino = 48;
				} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino48") {
						NumeroDestino = 55;
				} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino50") {
						NumeroDestino = 39;
				} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino55") {
						NumeroDestino = 50;
				} else if (DestinoActual == "Destino50" && DestinoAnterior == "Destino40") {
						NumeroDestino = 49;
				} else if (DestinoActual == "Destino50" && DestinoAnterior == "Destino51") {
						NumeroDestino = 40;
				} else if (DestinoActual == "Destino51" && DestinoAnterior == "Destino41") {
						NumeroDestino = 50;
				} else if (DestinoActual == "Destino51" && DestinoAnterior == "Destino50") {
						NumeroDestino = 56;
				} else if (DestinoActual == "Destino52" && DestinoAnterior == "Destino53") {
						NumeroDestino = 45;
				} else if (DestinoActual == "Destino52" && DestinoAnterior == "Destino57") {
						NumeroDestino = 53;
				} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino46") {
						NumeroDestino = 52;
				} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino52") {
						NumeroDestino = 58;
				} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino54") {
						NumeroDestino = 46;
				} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino58") {
						NumeroDestino = 54;
				} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino47") {
						NumeroDestino = 53;
				} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino53") {
						NumeroDestino = 59;
				} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino55") {
						NumeroDestino = 47;
				} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino59") {
						NumeroDestino = 55;
				} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino49") {
						NumeroDestino = 54;
				} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino54") {
						NumeroDestino = 60;
				} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino57") {
						NumeroDestino = 49;
				} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino60") {
						NumeroDestino = 56;
				} else if (DestinoActual == "Destino56" && DestinoAnterior == "Destino51") {
						NumeroDestino = 55;
				} else if (DestinoActual == "Destino56" && DestinoAnterior == "Destino55") {
						NumeroDestino = 62;
				} else if (DestinoActual == "Destino57" && DestinoAnterior == "Destino58") {
						NumeroDestino = 52;
				} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino53") {
						NumeroDestino = 57;
				} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino65") {
						NumeroDestino = 59;
				} else if (DestinoActual == "Destino59" && DestinoAnterior == "Destino54") {
						NumeroDestino = 58;
				} else if (DestinoActual == "Destino60" && DestinoAnterior == "Destino55") {
						NumeroDestino = 59;
				} else if (DestinoActual == "Destino61" && DestinoAnterior == "Destino56") {
						NumeroDestino = 60;
				} else if (DestinoActual == "Destino63" && DestinoAnterior == "Destino62") {
						NumeroDestino = 1;
				} else {
		}	
	}
	
	void VirarEsquerda ()
	{
		if (DestinoActual == "Destino1" && DestinoAnterior == "Destino2") {
			NumeroDestino = 63;
		} else if (DestinoActual == "Destino2" && DestinoAnterior == "Destino3") {
			NumeroDestino = 1;
		} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino2") {
			NumeroDestino = 4;
		} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino4") {
			NumeroDestino = 12;
		} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino10") {
			NumeroDestino = 2;
		} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino12") {
			NumeroDestino = 10;
		} else if (DestinoActual == "Destino4" && DestinoAnterior == "Destino5") {
			NumeroDestino = 13;
		} else if (DestinoActual == "Destino4" && DestinoAnterior == "Destino13") {
			NumeroDestino = 3;
		} else if (DestinoActual == "Destino5" && DestinoAnterior == "Destino6") {
			NumeroDestino = 14;
		} else if (DestinoActual == "Destino5" && DestinoAnterior == "Destino14") {
			NumeroDestino = 4;
		} else if (DestinoActual == "Destino6" && DestinoAnterior == "Destino7") {
			NumeroDestino = 15;
		} else if (DestinoActual == "Destino6" && DestinoAnterior == "Destino15") {
			NumeroDestino = 5;
		} else if (DestinoActual == "Destino7" && DestinoAnterior == "Destino8") {
			NumeroDestino = 16;
		} else if (DestinoActual == "Destino7" && DestinoAnterior == "Destino16") {
			NumeroDestino = 6;
		} else if (DestinoActual == "Destino8" && DestinoAnterior == "Destino9") {
			NumeroDestino = 17;
		} else if (DestinoActual == "Destino8" && DestinoAnterior == "Destino17") {
			NumeroDestino = 7;
		} else if (DestinoActual == "Destino9" && DestinoAnterior == "Destino18") {
			NumeroDestino = 8;
		} else if (DestinoActual == "Destino10" && DestinoAnterior == "Destino3") {
			NumeroDestino = 11;
		} else if (DestinoActual == "Destino10" && DestinoAnterior == "Destino11") {
			NumeroDestino = 22;
		} else if (DestinoActual == "Destino11" && DestinoAnterior == "Destino12") {
			NumeroDestino = 19;
		} else if (DestinoActual == "Destino11" && DestinoAnterior == "Destino19") {
			NumeroDestino = 10;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino3") {
			NumeroDestino = 13;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino11") {
			NumeroDestino = 3;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino13") {
			NumeroDestino = 19;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino19") {
			NumeroDestino = 11;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino4") {
			NumeroDestino = 14;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino12") {
			NumeroDestino = 4;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino14") {
			NumeroDestino = 21;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino21") {
			NumeroDestino = 12;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino5") {
			NumeroDestino = 15;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino13") {
			NumeroDestino = 5;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino15") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino27") {
			NumeroDestino = 13;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino6") {
			NumeroDestino = 16;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino14") {
			NumeroDestino = 6;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino16") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino28") {
			NumeroDestino = 14;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino7") {
			NumeroDestino = 17;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino15") {
			NumeroDestino = 7;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino17") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino29") {
			NumeroDestino = 15;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino8") {
			NumeroDestino = 18;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino16") {
			NumeroDestino = 8;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino18") {
			NumeroDestino = 30;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino30") {
			NumeroDestino = 16;
		} else if (DestinoActual == "Destino18" && DestinoAnterior == "Destino17") {
			NumeroDestino = 9;
		} else if (DestinoActual == "Destino18" && DestinoAnterior == "Destino31") {
			NumeroDestino = 17;
		} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino12") {
			NumeroDestino = 20;
		} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino20") {
			NumeroDestino = 24;
		} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino24") {
			NumeroDestino = 11;
		} else if (DestinoActual == "Destino20" && DestinoAnterior == "Destino21") {
			NumeroDestino = 25;
		} else if (DestinoActual == "Destino20" && DestinoAnterior == "Destino25") {
			NumeroDestino = 19;
		} else if (DestinoActual == "Destino21" && DestinoAnterior == "Destino20") {
			NumeroDestino = 13;
		} else if (DestinoActual == "Destino21" && DestinoAnterior == "Destino26") {
			NumeroDestino = 20;
		} else if (DestinoActual == "Destino22" && DestinoAnterior == "Destino10") {
			NumeroDestino = 23;
		} else if (DestinoActual == "Destino22" && DestinoAnterior == "Destino23") {
			NumeroDestino = 32;
		} else if (DestinoActual == "Destino23" && DestinoAnterior == "Destino24") {
			NumeroDestino = 32;
		} else if (DestinoActual == "Destino23" && DestinoAnterior == "Destino32") {
			NumeroDestino = 22;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino19") {
			NumeroDestino = 25;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino23") {
			NumeroDestino = 19;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino25") {
			NumeroDestino = 33;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino33") {
			NumeroDestino = 23;
		} else if (DestinoActual == "Destino25" && DestinoAnterior == "Destino20") {
			NumeroDestino = 26;
		} else if (DestinoActual == "Destino25" && DestinoAnterior == "Destino24") {
			NumeroDestino = 20;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino21") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino25") {
			NumeroDestino = 21;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino27") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino36") {
			NumeroDestino = 25;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino14") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino26") {
			NumeroDestino = 14;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino28") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino37") {
			NumeroDestino = 26;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino15") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino27") {
			NumeroDestino = 15;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino29") {
			NumeroDestino = 38;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino38") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino16") {
			NumeroDestino = 30;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino28") {
			NumeroDestino = 16;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino30") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino39") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino17") {
			NumeroDestino = 31;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino29") {
			NumeroDestino = 17;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino31") {
			NumeroDestino = 40;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino40") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino31" && DestinoAnterior == "Destino30") {
			NumeroDestino = 18;
		} else if (DestinoActual == "Destino31" && DestinoAnterior == "Destino41") {
			NumeroDestino = 41;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino22") {
			NumeroDestino = 23;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino23") {
			NumeroDestino = 33;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino33") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino34") {
			NumeroDestino = 22;
		} else if (DestinoActual == "Destino33" && DestinoAnterior == "Destino24") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino33" && DestinoAnterior == "Destino35") {
			NumeroDestino = 32;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino33") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino32") {
			NumeroDestino = 33;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino36") {
			NumeroDestino = 45;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino42"){
			NumeroDestino = 34;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino45") {
			NumeroDestino = 32;
		} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino26") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino35") {
			NumeroDestino = 26;
		} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino37") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino46") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino27") {
			NumeroDestino = 38;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino36") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino38") {
			NumeroDestino = 47;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino47") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino28") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino37") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino39") {
			NumeroDestino = 48;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino48") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino29") {
			NumeroDestino = 40;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino38") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino40") {
			NumeroDestino = 49;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino49") {
			NumeroDestino = 38;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino30") {
			NumeroDestino = 41;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino39") {
			NumeroDestino = 30;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino41") {
			NumeroDestino = 50;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino50") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino41" && DestinoAnterior == "Destino40") {
			NumeroDestino = 31;
		} else if (DestinoActual == "Destino41" && DestinoAnterior == "Destino51") {
			NumeroDestino = 40;
		} else if (DestinoActual == "Destino42" && DestinoAnterior == "Destino43") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino42" && DestinoAnterior == "Destino44") {
			NumeroDestino = 43;
		} else if (DestinoActual == "Destino43" && DestinoAnterior == "Destino35") {
			NumeroDestino = 42;
		} else if (DestinoActual == "Destino43" && DestinoAnterior == "Destino42") {
			NumeroDestino = 45;
		} else if (DestinoActual == "Destino44" && DestinoAnterior == "Destino42") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino44" && DestinoAnterior == "Destino46") {
			NumeroDestino = 42;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino35") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino46") {
			NumeroDestino = 52;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino52") {
			NumeroDestino = 64;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino64") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino36") {
			NumeroDestino = 47;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino45") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino47") {
			NumeroDestino = 53;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino53") {
			NumeroDestino = 45;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino37") {
			NumeroDestino = 48;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino46") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino48") {
			NumeroDestino = 54;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino54") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino48" && DestinoAnterior == "Destino38") {
			NumeroDestino = 49;
		} else if (DestinoActual == "Destino48" && DestinoAnterior == "Destino47") {
			NumeroDestino = 38;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino39") {
			NumeroDestino = 50;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino48") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino50") {
			NumeroDestino = 55;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino55") {
			NumeroDestino = 48;
		} else if (DestinoActual == "Destino50" && DestinoAnterior == "Destino40") {
			NumeroDestino = 51;
		} else if (DestinoActual == "Destino50" && DestinoAnterior == "Destino49") {
			NumeroDestino = 40;
		} else if (DestinoActual == "Destino51" && DestinoAnterior == "Destino50") {
			NumeroDestino = 41;
		} else if (DestinoActual == "Destino51" && DestinoAnterior == "Destino56") {
			NumeroDestino = 50;
		} else if (DestinoActual == "Destino52" && DestinoAnterior == "Destino45") {
			NumeroDestino = 53;
		} else if (DestinoActual == "Destino52" && DestinoAnterior == "Destino53") {
			NumeroDestino = 57;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino46") {
			NumeroDestino = 54;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino52") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino54") {
			NumeroDestino = 58;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino58") {
			NumeroDestino = 52;
		} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino47") {
			NumeroDestino = 55;
		} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino53") {
			NumeroDestino = 47;
		} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino55") {
			NumeroDestino = 59;
		} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino59") {
			NumeroDestino = 53;
		} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino49") {
			NumeroDestino = 56;
		} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino54") {
			NumeroDestino = 49;
		} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino56") {
			NumeroDestino = 60;
		} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino60") {
			NumeroDestino = 54;
		} else if (DestinoActual == "Destino56" && DestinoAnterior == "Destino55") {
			NumeroDestino = 51;
		} else if (DestinoActual == "Destino56" && DestinoAnterior == "Destino61") {
			NumeroDestino = 55;
		} else if (DestinoActual == "Destino57" && DestinoAnterior == "Destino52") {
			NumeroDestino = 58;
		} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino53") {
			NumeroDestino = 59;
		} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino57") {
			NumeroDestino = 53;
		} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino59") {
			NumeroDestino = 62;
		} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino62") {
			NumeroDestino = 67;
		} else if (DestinoActual == "Destino59" && DestinoAnterior == "Destino54") {
			NumeroDestino = 60;
		} else if (DestinoActual == "Destino59" && DestinoAnterior == "Destino58") {
			NumeroDestino = 54;
		} else if (DestinoActual == "Destino60" && DestinoAnterior == "Destino55") {
			NumeroDestino = 61;
		} else if (DestinoActual == "Destino60" && DestinoAnterior == "Destino59") {
			NumeroDestino = 55;
		} else if (DestinoActual == "Destino61" && DestinoAnterior == "Destino60") {
			NumeroDestino = 56;
		}else {
		}
	}
	
	void SeguirEmFrente ()
	{
		if (DestinoActual == "Destino3" && DestinoAnterior == "Destino2") {
			NumeroDestino = 12;
		} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino4") {
			NumeroDestino = 10;
		} else if (DestinoActual == "Destino3" && DestinoAnterior == "Destino10") {
			NumeroDestino = 4;
		} else if (DestinoActual == "Destino4" && DestinoAnterior == "Destino3") {
			NumeroDestino = 5;
		} else if (DestinoActual == "Destino4" && DestinoAnterior == "Destino5") {
			NumeroDestino = 3;
		} else if (DestinoActual == "Destino5" && DestinoAnterior == "Destino4") {
			NumeroDestino = 6;
		} else if (DestinoActual == "Destino5" && DestinoAnterior == "Destino6") {
			NumeroDestino = 4;
		} else if (DestinoActual == "Destino6" && DestinoAnterior == "Destino5") {
			NumeroDestino = 7;
		} else if (DestinoActual == "Destino6" && DestinoAnterior == "Destino7") {
			NumeroDestino = 5;
		} else if (DestinoActual == "Destino7" && DestinoAnterior == "Destino6") {
			NumeroDestino = 8;
		} else if (DestinoActual == "Destino7" && DestinoAnterior == "Destino8") {
			NumeroDestino = 6;
		} else if (DestinoActual == "Destino8" && DestinoAnterior == "Destino7") {
			NumeroDestino = 9;
		} else if (DestinoActual == "Destino8" && DestinoAnterior == "Destino9") {
			NumeroDestino = 7;
		} else if (DestinoActual == "Destino10" && DestinoAnterior == "Destino3") {
			NumeroDestino = 22;
		} else if (DestinoActual == "Destino10" && DestinoAnterior == "Destino22") {
			NumeroDestino = 3;
		} else if (DestinoActual == "Destino11" && DestinoAnterior == "Destino10") {
			NumeroDestino = 12;
		} else if (DestinoActual == "Destino11" && DestinoAnterior == "Destino12") {
			NumeroDestino = 10;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino3") {
			NumeroDestino = 19;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino11") {
			NumeroDestino = 13;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino13") {
			NumeroDestino = 11;
		} else if (DestinoActual == "Destino12" && DestinoAnterior == "Destino19") {
			NumeroDestino = 3;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino4") {
			NumeroDestino = 21;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino12") {
			NumeroDestino = 14;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino14") {
			NumeroDestino = 12;
		} else if (DestinoActual == "Destino13" && DestinoAnterior == "Destino21") {
			NumeroDestino = 4;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino5") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino13") {
			NumeroDestino = 15;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino15") {
			NumeroDestino = 13;
		} else if (DestinoActual == "Destino14" && DestinoAnterior == "Destino27") {
			NumeroDestino = 5;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino6") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino14") {
			NumeroDestino = 16;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino16") {
			NumeroDestino = 14;
		} else if (DestinoActual == "Destino15" && DestinoAnterior == "Destino28") {
			NumeroDestino = 6;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino7") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino15") {
			NumeroDestino = 17;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino17") {
			NumeroDestino = 15;
		} else if (DestinoActual == "Destino16" && DestinoAnterior == "Destino29") {
			NumeroDestino = 7;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino8") {
			NumeroDestino = 30;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino16") {
			NumeroDestino = 18;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino18") {
			NumeroDestino = 16;
		} else if (DestinoActual == "Destino17" && DestinoAnterior == "Destino30") {
			NumeroDestino = 8;
		} else if (DestinoActual == "Destino18" && DestinoAnterior == "Destino9") {
			NumeroDestino = 31;
		} else if (DestinoActual == "Destino18" && DestinoAnterior == "Destino31") {
			NumeroDestino = 9;
		} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino11") {
			NumeroDestino = 20;
		} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino12") {
			NumeroDestino = 24;
		} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino20") {
			NumeroDestino = 11;
		} else if (DestinoActual == "Destino19" && DestinoAnterior == "Destino24") {
			NumeroDestino = 12;
		} else if (DestinoActual == "Destino20" && DestinoAnterior == "Destino19") {
			NumeroDestino = 21;
		} else if (DestinoActual == "Destino20" && DestinoAnterior == "Destino21") {
			NumeroDestino = 19;
		} else if (DestinoActual == "Destino21" && DestinoAnterior == "Destino13") {
			NumeroDestino = 26;
		} else if (DestinoActual == "Destino21" && DestinoAnterior == "Destino26") {
			NumeroDestino = 13;
		} else if (DestinoActual == "Destino22" && DestinoAnterior == "Destino10") {
			NumeroDestino = 32;
		} else if (DestinoActual == "Destino22" && DestinoAnterior == "Destino32") {
			NumeroDestino = 10;
		} else if (DestinoActual == "Destino23" && DestinoAnterior == "Destino22") {
			NumeroDestino = 24;
		} else if (DestinoActual == "Destino23" && DestinoAnterior == "Destino24") {
			NumeroDestino = 22;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino19") {
			NumeroDestino = 33;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino23") {
			NumeroDestino = 25;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino25") {
			NumeroDestino = 23;
		} else if (DestinoActual == "Destino24" && DestinoAnterior == "Destino33") {
			NumeroDestino = 19;
		} else if (DestinoActual == "Destino25" && DestinoAnterior == "Destino24") {
			NumeroDestino = 26;
		} else if (DestinoActual == "Destino25" && DestinoAnterior == "Destino26") {
			NumeroDestino = 24;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino21") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino25") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino27") {
			NumeroDestino = 25;
		} else if (DestinoActual == "Destino26" && DestinoAnterior == "Destino36") {
			NumeroDestino = 21;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino14") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino26") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino28") {
			NumeroDestino = 26;
		} else if (DestinoActual == "Destino27" && DestinoAnterior == "Destino37") {
			NumeroDestino = 14;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino15") {
			NumeroDestino = 38;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino27") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino29") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino28" && DestinoAnterior == "Destino38") {
			NumeroDestino = 15;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino16") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino28") {
			NumeroDestino = 30;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino30") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino29" && DestinoAnterior == "Destino39") {
			NumeroDestino = 16;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino17") {
			NumeroDestino = 40;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino29") {
			NumeroDestino = 31;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino31") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino30" && DestinoAnterior == "Destino40") {
			NumeroDestino = 17;
		} else if (DestinoActual == "Destino31" && DestinoAnterior == "Destino18") {
			NumeroDestino = 41;
		} else if (DestinoActual == "Destino31" && DestinoAnterior == "Destino41") {
			NumeroDestino = 18;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino22") {
			NumeroDestino = 33;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino23") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino33") {
			NumeroDestino = 22;
		} else if (DestinoActual == "Destino32" && DestinoAnterior == "Destino34") {
			NumeroDestino = 23;
		} else if (DestinoActual == "Destino33" && DestinoAnterior == "Destino24") {
			NumeroDestino = 32;
		} else if (DestinoActual == "Destino33" && DestinoAnterior == "Destino32") {
			NumeroDestino = 24;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino34") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino36") {
			NumeroDestino = 34;
		} else if (DestinoActual == "Destino35" && DestinoAnterior == "Destino45") {
			NumeroDestino = 33;
		}else if(DestinoActual == "Destino35" && DestinoAnterior == "Destino42"){
			NumeroDestino = 33;
		}else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino26") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino35") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino37") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino36" && DestinoAnterior == "Destino46") {
			NumeroDestino = 26;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino27") {
			NumeroDestino = 47;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino36") {
			NumeroDestino = 38;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino38") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino37" && DestinoAnterior == "Destino47") {
			NumeroDestino = 27;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino28") {
			NumeroDestino = 12;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino37") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino39") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino38" && DestinoAnterior == "Destino48") {
			NumeroDestino = 28;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino29") {
			NumeroDestino = 49;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino38") {
			NumeroDestino = 40;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino40") {
			NumeroDestino = 38;
		} else if (DestinoActual == "Destino39" && DestinoAnterior == "Destino29") {
			NumeroDestino = 29;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino30") {
			NumeroDestino = 50;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino39") {
			NumeroDestino = 41;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino41") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino40" && DestinoAnterior == "Destino50") {
			NumeroDestino = 30;
		} else if (DestinoActual == "Destino41" && DestinoAnterior == "Destino31") {
			NumeroDestino = 51;
		} else if (DestinoActual == "Destino41" && DestinoAnterior == "Destino51") {
			NumeroDestino = 31;
		} else if (DestinoActual == "Destino43" && DestinoAnterior == "Destino35") {
			NumeroDestino = 45;
		} else if (DestinoActual == "Destino43" && DestinoAnterior == "Destino45") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino44" && DestinoAnterior == "Destino36") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino44" && DestinoAnterior == "Destino46") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino35") {
			NumeroDestino = 52;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino46") {
			NumeroDestino = 64;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino52") {
			NumeroDestino = 35;
		} else if (DestinoActual == "Destino45" && DestinoAnterior == "Destino64") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino36") {
			NumeroDestino = 53;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino45") {
			NumeroDestino = 47;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino47") {
			NumeroDestino = 45;
		} else if (DestinoActual == "Destino46" && DestinoAnterior == "Destino53") {
			NumeroDestino = 36;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino37") {
			NumeroDestino = 54;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino46") {
			NumeroDestino = 48;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino48") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino47" && DestinoAnterior == "Destino54") {
			NumeroDestino = 37;
		} else if (DestinoActual == "Destino48" && DestinoAnterior == "Destino47") {
			NumeroDestino = 49;
		} else if (DestinoActual == "Destino48" && DestinoAnterior == "Destino49") {
			NumeroDestino = 47;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino39") {
			NumeroDestino = 55;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino48") {
			NumeroDestino = 50;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino50") {
			NumeroDestino = 48;
		} else if (DestinoActual == "Destino49" && DestinoAnterior == "Destino55") {
			NumeroDestino = 39;
		} else if (DestinoActual == "Destino50" && DestinoAnterior == "Destino49") {
			NumeroDestino = 51;
		} else if (DestinoActual == "Destino50" && DestinoAnterior == "Destino51") {
			NumeroDestino = 49;
		} else if (DestinoActual == "Destino51" && DestinoAnterior == "Destino41") {
			NumeroDestino = 56;
		} else if (DestinoActual == "Destino51" && DestinoAnterior == "Destino56") {
			NumeroDestino = 41;
		} else if (DestinoActual == "Destino52" && DestinoAnterior == "Destino45") {
			NumeroDestino = 57;
		} else if (DestinoActual == "Destino52" && DestinoAnterior == "Destino57") {
			NumeroDestino = 45;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino46") {
			NumeroDestino = 58;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino52") {
			NumeroDestino = 54;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino54") {
			NumeroDestino = 52;
		} else if (DestinoActual == "Destino53" && DestinoAnterior == "Destino58") {
			NumeroDestino = 46;
		} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino47") {
			NumeroDestino = 59;
		} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino53") {
			NumeroDestino = 55;
		} else if (DestinoActual == "Destino54" && DestinoAnterior == "Destino55") {
			NumeroDestino = 53;
		} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino49") {
			NumeroDestino = 60;
		} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino54") {
			NumeroDestino = 56;
		} else if (DestinoActual == "Destino55" && DestinoAnterior == "Destino56") {
			NumeroDestino = 54;
		} else if (DestinoActual == "Destino56" && DestinoAnterior == "Destino51") {
			NumeroDestino = 61;
		} else if (DestinoActual == "Destino56" && DestinoAnterior == "Destino61") {
			NumeroDestino = 51;
		} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino53") {
			NumeroDestino = 62;
		} else if (DestinoActual == "Destino58" && DestinoAnterior == "Destino62") {
			NumeroDestino = 53;
		} else if (DestinoActual == "Destino62" && DestinoAnterior == "Destino58") {
			NumeroDestino = 63;
		} else if (DestinoActual == "Destino62" && DestinoAnterior == "Destino63") {
			NumeroDestino = 58;
		}else {

		}
		
	}
}
