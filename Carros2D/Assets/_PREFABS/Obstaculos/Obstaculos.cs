using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstaculos : MonoBehaviour {

	private int alturamaxima = 4;
	private int alturaminima = -3;
	public float speed;

	private int DistanciaEntreObstaculos = 4;
	private float contadorEntreObstaculos;

	public GameObject BarreiraPrefab;
	public GameObject BidonPrefab;
	public GameObject BuracoPrefab;
	public GameObject CoelhoPrefab;
	public GameObject PinoPrefab;
	public GameObject StopPrefab;

	public List<GameObject> ListaObstaculos;

	// Use this for initialization
	void Start () {
		GameObject temporario = Instantiate (BarreiraPrefab) as GameObject;
		ListaObstaculos.Add (temporario);
		temporario.SetActive (false);
		temporario = Instantiate (BidonPrefab) as GameObject;
		ListaObstaculos.Add (temporario);
		temporario.SetActive (false);
		temporario = Instantiate (BuracoPrefab) as GameObject;
		ListaObstaculos.Add (temporario);
		temporario.SetActive (false);
		temporario = Instantiate (CoelhoPrefab) as GameObject;
		ListaObstaculos.Add (temporario);
		temporario.SetActive (false);
		temporario = Instantiate (PinoPrefab) as GameObject;
		ListaObstaculos.Add (temporario);
		temporario.SetActive (false);
		temporario = Instantiate (StopPrefab) as GameObject;
		ListaObstaculos.Add (temporario);
		temporario.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Movimentos.final == false) {
			contadorEntreObstaculos += Time.deltaTime * speed; // Contador da distancia entre obstaculos
			if (contadorEntreObstaculos > DistanciaEntreObstaculos) {
				contadorEntreObstaculos = 0;
				DistanciaEntreObstaculos = Random.Range (1, 10); // Distancia aleatoria entre Obstaculos
				PosicaoObstaculo (); // coloca o Obstaculo no cenario
				ListaObstaculos.Clear (); // Limpa a lista e obstaculos
				Start (); // Cria nova lista
			}
		}
	}

	public void PosicaoObstaculo(){
		int posicaoaleatoria = Random.Range (alturaminima,alturamaxima); // posicao aleatoria do obstaculos
		int obstaculoMostrar = Random.Range (0,6); // escolha aleatoria do obstaculo a mostrar

		GameObject tempObj = ListaObstaculos [obstaculoMostrar]; // criaçao de um Objecto e colocar o Obstaculo

		tempObj.transform.position = new Vector3 (transform.position.x, posicaoaleatoria,-1 ); //Criaçao do Obstaculo no cenario		
		tempObj.SetActive (true); // Activar o Obstaculo
		
	}

}
