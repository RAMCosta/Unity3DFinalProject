using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NavigationTest : MonoBehaviour {

	
	
	public Transform[] destino;
	private NavMeshAgent agente;
	public GameObject EscolhaDestino;
	int numerodestino=0;
	bool teclapressionada = false;
	float posicaoAtualX;
	float posicaoAtualY;
	float posicaoAtualZ;
	string DestinoAnterior;
	// Use this for initialization
	void Start () {
		EscolhaDestino.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (EscolhaDestino.activeSelf == true) {
			this.gameObject.transform.position = new Vector3(posicaoAtualX,posicaoAtualY,posicaoAtualZ);
			
			if (Input.GetKey(KeyCode.M)){
				EscolhaDestino.SetActive(false);
				numerodestino = 2;
				this.gameObject.GetComponent<NavMeshAgent>().acceleration =8;
			}
			if (Input.GetKey(KeyCode.Z)){
				EscolhaDestino.SetActive(false);
				numerodestino = 1;
				this.gameObject.GetComponent<NavMeshAgent>().acceleration =8;
			}
		}
		
		agente = gameObject.GetComponent<NavMeshAgent>();
		agente.SetDestination (destino[numerodestino].position);
	}
	
	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.name == "Destino") 
		{
			EscolhaDestino.SetActive (true);
			agente.acceleration=0;
			this.gameObject.GetComponent<NavMeshAgent>().acceleration =0;
			posicaoAtualX = this.gameObject.transform.position.x;
			posicaoAtualY = this.gameObject.transform.position.y;
			posicaoAtualZ = this.gameObject.transform.position.z;
			DestinoAnterior = collision.gameObject.name;
			GameObject.Find(DestinoAnterior).SetActive(false);
		}

		if (collision.gameObject.name == "Destino1") 
		{
			EscolhaDestino.SetActive (true);
			agente.acceleration=0;
			this.gameObject.GetComponent<NavMeshAgent>().acceleration =0;
			posicaoAtualX = this.gameObject.transform.position.x;
			posicaoAtualY = this.gameObject.transform.position.y;
			posicaoAtualZ = this.gameObject.transform.position.z;
			DestinoAnterior = collision.gameObject.name;
			GameObject.Find(DestinoAnterior).SetActive(false);
		}

		if (collision.gameObject.name == "Destino2") 
		{
			EscolhaDestino.SetActive (true);
			agente.acceleration=0;
			this.gameObject.GetComponent<NavMeshAgent>().acceleration =0;
			posicaoAtualX = this.gameObject.transform.position.x;
			posicaoAtualY = this.gameObject.transform.position.y;
			posicaoAtualZ = this.gameObject.transform.position.z;
			DestinoAnterior = collision.gameObject.name;
			GameObject.Find(DestinoAnterior).SetActive(false);
		}
	}
}
