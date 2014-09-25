using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform Helicoptero;
	 float distancia = 7f;
	 float altura = 4f;
	 float rotacaoAmortecimento = 3.0f;
	 float alturaAmortecimento = 2.0f;
	 float zoomCamera = 0.5f;
	 float DefaultFOV = 60f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		var AnguloDesejado = Helicoptero.eulerAngles.y;
		var AlturaDesejada = Helicoptero.position.y + altura;
		float MeuAngulo = transform.eulerAngles.y;
		var MinhaAltura = transform.position.y;
		MeuAngulo = Mathf.LerpAngle (MeuAngulo, AnguloDesejado, rotacaoAmortecimento * Time.deltaTime);
		MinhaAltura = Mathf.Lerp (MinhaAltura, AlturaDesejada, alturaAmortecimento * Time.deltaTime);
		var RotacaoMomento = Quaternion.Euler (0, MeuAngulo, 0);
		transform.position = Helicoptero.position;
		transform.position -= RotacaoMomento * Vector3.forward * distancia;
		transform.position = new Vector3 (transform.position.x, MinhaAltura, transform.position.z);
		transform.LookAt(Helicoptero);
	}

	void FixedUpdate() {
		var acc = Helicoptero.rigidbody.velocity.magnitude;
		camera.fieldOfView = DefaultFOV + acc*zoomCamera*Time.deltaTime;
		}
}