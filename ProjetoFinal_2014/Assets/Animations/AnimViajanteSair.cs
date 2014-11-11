using UnityEngine;
using System.Collections;

public class AnimViajanteSair : MonoBehaviour {
	
	
	private Animator anim;	
	public int distancia;
	public GameObject destino;
	public GameObject Taxi;
	public GameObject porta;
	public bool AbrirPorta = false;
	public float time;
	public float RotacaoPorta = 0;
	bool entrouNoCarro = false;
	public static bool SeguirCarro = true;
	public static bool ActualizarDestino = false; // Dizer a Class Destinos para efectuar a funçao Apanhar Viajante
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool ("Andar", false);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Destinos.AndarViajante == true) {
			SeguirCarro = false;
			anim.SetBool ("Andar", true);
			Destinos.AndarViajante=false;
			
		}
		distancia = (int)Vector3.Distance (Taxi.transform.position, destino.transform.position);
		if (distancia > 2 && distancia<100) {
			anim.SetBool ("ChamarTaxi", true);
		} else {
			anim.SetBool ("ChamarTaxi", false);	
		}
		if (AbrirPorta == true){
			time += Time.deltaTime;
			if (time > 2.1 && time < 2.9 ){
				RotacaoPorta = -40*Time.deltaTime;
				porta.transform.Rotate(new Vector3 (0,RotacaoPorta,0));
			}else if(time >3.1 && time< 3.3){
				RotacaoPorta = 170*Time.deltaTime;
				porta.transform.Rotate(new Vector3 (0,RotacaoPorta,0));
				entrouNoCarro = true;
			} else if (AbrirPorta== true && entrouNoCarro == true){
				SeguirCarro = true;
				AbrirPorta = false;
				/*GameObject.Find("TAXI").gameObject.GetComponent<NavMeshAgent> ().enabled = true;
				GameObject.Find("TAXI").gameObject.GetComponent<NavMeshAgent> ().speed = 10;
				GameObject.Find("TAXI").gameObject.GetComponent<NavMeshAgent> ().acceleration = 10;*/
				ActualizarDestino = true;
				//this.gameObject.SetActive(false);
			}
		}
	}
	
	void OnTriggerEnter(Collider colisao){
		if (colisao.gameObject.name == "TAXI") {
			anim.SetBool ("Andar", false);
			anim.SetBool("AbrirCarro",true);
			AbrirPorta = true;
		}
	}
	
}
