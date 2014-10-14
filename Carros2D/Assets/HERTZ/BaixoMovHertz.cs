using UnityEngine;
using System.Collections;

public class BaixoMovHertz : MonoBehaviour {

	// Use this for initialization
	public string toque= "nada";
	public string posicao= "parado";
	private float velocidade= 0.1f;
	public bool qualquervalor = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (qualquervalor) {
			GameObject.Find("Carro").transform.position= new Vector2(-7, GameObject.Find("Carro").transform.position.y-velocidade);
		}
	}
}
