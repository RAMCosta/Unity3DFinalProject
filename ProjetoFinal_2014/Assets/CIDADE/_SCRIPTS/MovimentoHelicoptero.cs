using UnityEngine;
using System.Collections;

public class MovimentoHelicoptero : MonoBehaviour {

	// Use this for initialization
	//int handleID;
	//public int connectStatus;
	//public float attencion;
	//public float meditation;
	public int velocidadeAndamento = 40;
	public int velocidadeVirar = 10;
	public int velocidadeSubir = 5;

	void Start () {
		// Conexao Mindwave
		//handleID= ThinkGear.TG_GetNewConnectionId ();
		//connectStatus = ThinkGear.TG_Connect (handleID, "COM5", ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

	}
	
	// Update is called once per frame
	void Update () {
		//Leitura Mindwave
		//attencion = ThinkGear.TG_GetValue (handleID, ThinkGear.DATA_ATTENTION);

		if (Input.GetKey (KeyCode.Space)) {
			rigidbody.useGravity = false;
			//transform.Translate (Input.GetAxis ("Horizontal") * 10 * Time.deltaTime, Input.GetAxis ("Vertical") * 10 * Time.deltaTime, velocidadeHeli * Time.deltaTime);
			transform.Translate (0,Input.GetAxis ("Vertical") * velocidadeSubir * Time.deltaTime, velocidadeAndamento * Time.deltaTime);
			// virar para a esquerda
			if(Input.GetKey(KeyCode.LeftArrow)){
				transform.Rotate(Vector3.down * Time.deltaTime*velocidadeVirar);
			}
			// virar para a direita
			if(Input.GetKey(KeyCode.RightArrow)){
				transform.Rotate(Vector3.up * Time.deltaTime*velocidadeVirar);
			}
		} else {
			rigidbody.useGravity =true;	
		}
	}
}
