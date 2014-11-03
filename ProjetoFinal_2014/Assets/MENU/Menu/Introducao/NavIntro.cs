using UnityEngine;
using System.Collections;

public class NavIntro : MonoBehaviour
{

		public Transform destino;
		private NavMeshAgent agente;
		// Update is called once per frame
		void Update ()
		{
				agente = gameObject.GetComponent<NavMeshAgent> ();
				agente.SetDestination (destino.position);
				
		}
}
