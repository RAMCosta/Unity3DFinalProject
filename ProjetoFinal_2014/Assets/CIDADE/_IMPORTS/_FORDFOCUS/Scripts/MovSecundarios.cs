using UnityEngine;
using System.Collections;

public class MovSecundarios : MonoBehaviour {

	// Use this for initialization
	public GameObject CarroPlayer;
	public bool LadoEstrada = false; // False- Via direita ----- True- Via esquerda
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(LadoEstrada == false){
			if (CarroPlayer.transform.position.z > 700) {
				transform.Translate(new Vector3(-10*Time.deltaTime,0,0));	
			}
			if (transform.position.x > 1535 && transform.position.x < 1536) { // Posicao meio da estrada
				transform.position = new Vector3(transform.position.x,transform.position.y,1362);
			}
			if (transform.position.x > 1482 && transform.position.x < 1483) { // Posicao meio da estrada
				transform.position = new Vector3(transform.position.x,transform.position.y,1368);
			}
			if (transform.position.x > 1415 && transform.position.x < 1416) { // Posicao meio da estrada
				transform.position = new Vector3(transform.position.x,transform.position.y,1375);
			}
			if (transform.position.x > 1289 && transform.position.x < 1290) { // Posicao meio da estrada
				transform.position = new Vector3(transform.position.x,transform.position.y,1382);
			}
			if (transform.position.x > 1055 && transform.position.x < 1056) { // Posicao meio da estrada
				transform.position = new Vector3(transform.position.x,transform.position.y,1388);
			}
			if (transform.position.x < 500) {
				transform.position = new Vector3(transform.position.x,transform.position.y,1375);
				transform.Rotate(0,180,0);
				LadoEstrada = true;
			}
		}
		if(LadoEstrada == true){
			if (CarroPlayer.transform.position.z > 700) {
				transform.Translate(new Vector3(-10*Time.deltaTime,0,0));	
			}
			if (transform.position.x > 1292 && transform.position.x < 1293) { // Posicao meio da estrada
				transform.position = new Vector3(transform.position.x,transform.position.y,1363);
			}
			if (transform.position.x > 1406 && transform.position.x < 1407) { // Posicao meio da estrada
				transform.position = new Vector3(transform.position.x,transform.position.y,1357);
			}
			if (transform.position.x > 1549) { // Posicao meio da estrada
				transform.Rotate(0,-180,0);
				LadoEstrada = false;
			}
		}
	}
}
