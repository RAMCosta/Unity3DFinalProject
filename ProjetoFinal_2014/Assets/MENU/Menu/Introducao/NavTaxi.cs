using UnityEngine;
using System.Collections;

public class NavTaxi : MonoBehaviour {

	public Transform destino;
	private NavMeshAgent agente;
	public static bool chegouTaxi2 = false;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		agente = gameObject.GetComponent<NavMeshAgent> ();
		agente.SetDestination (destino.position);

		if (Vector3.Distance( agente.destination, agente.transform.position) <= agente.stoppingDistance) {
			chegouTaxi2 = true;		
		}
	}
}