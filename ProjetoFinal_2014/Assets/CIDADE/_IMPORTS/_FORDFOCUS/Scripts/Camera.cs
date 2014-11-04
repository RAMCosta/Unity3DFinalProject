using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform carro;
	 float distancia = 5f;
	 float altura = 2f;
	 float rotacaoAmortecimento = 3.0f;
	 float alturaAmortecimento = 2.0f;
	 float zoomCamera = 0.5f;
	 float DefaultFOV = 60f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		var AnguloDesejado = carro.eulerAngles.y;
		var AlturaDesejada = carro.position.y + altura;
		float MeuAngulo = transform.eulerAngles.y;
		var MinhaAltura = transform.position.y;
		MeuAngulo = Mathf.LerpAngle (MeuAngulo, AnguloDesejado, rotacaoAmortecimento * Time.deltaTime);
		MinhaAltura = Mathf.Lerp (MinhaAltura, AlturaDesejada, alturaAmortecimento * Time.deltaTime);
		var RotacaoMomento = Quaternion.Euler (0, MeuAngulo, 0);
		transform.position = carro.position;
		transform.position -= RotacaoMomento * Vector3.forward * distancia;
		transform.position = new Vector3 (transform.position.x, MinhaAltura, transform.position.z);
		transform.LookAt(carro);
	}

	void FixedUpdate() {
		var acc = carro.rigidbody.velocity.magnitude;
		camera.fieldOfView = DefaultFOV + acc*zoomCamera*Time.deltaTime;
		}
}