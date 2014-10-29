using UnityEngine;
using System.Collections;

public class NavMeshDestinos : MonoBehaviour {

	public Transform destino;
	private NavMeshAgent agente;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		agente = gameObject.GetComponent<NavMeshAgent>();
		agente.SetDestination (destino.position);
	}
}
