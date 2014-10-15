using UnityEngine;
using System.Collections;

public class RodarHelices : MonoBehaviour {

	public WheelCollider HeliceFrenteCol;
	public WheelCollider HeliceTrasCol;
	public Transform HeliceTras;
	public Transform HeliceFrente;
	float VelocidadeMaxima=350f;
	public float VelocidadeActual;
	float desacelerar = 20f;
	public float teste;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ControloHelicoptero ();
}

	void ControloHelicoptero () {
		VelocidadeActual = 2 * 22 / 7 * HeliceFrenteCol.radius*HeliceFrenteCol.rpm * 60 / 1000;
		EngineSound ();
		if (VelocidadeActual <= VelocidadeMaxima && Input.GetKey(KeyCode.Space)) {
			HeliceFrenteCol.motorTorque = 50 ;
				HeliceTrasCol.motorTorque = 50 ;

			HeliceFrente.Rotate(0, HeliceFrenteCol.rpm / 60 * 360 * Time.deltaTime, 0);
			HeliceTras.Rotate(HeliceTrasCol.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		} else {
			HeliceFrenteCol.motorTorque = 0; 
			HeliceTrasCol.motorTorque = 0; 

			HeliceFrente.Rotate(0, HeliceFrenteCol.rpm / 60 * 360 * Time.deltaTime, 0);
			HeliceTras.Rotate(HeliceTrasCol.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		//	HeliceTras.transform.Rotate (Vector3.right * Time.deltaTime * 2000);
		//	HeliceFrente.transform.Rotate (Vector3.up * Time.deltaTime * 2000);
		}
		if (Input.GetButton ("Vertical")==false){
			HeliceFrenteCol.brakeTorque = desacelerar;
			HeliceTrasCol.brakeTorque = desacelerar;

			HeliceFrente.Rotate(0, HeliceFrenteCol.rpm / 60 * 360 * Time.deltaTime, 0);
			HeliceTras.Rotate(HeliceTrasCol.rpm / 60 * 360 * Time.deltaTime, 0, 0);

		} else {
			HeliceFrenteCol.brakeTorque = 0; 
			HeliceTrasCol.brakeTorque = 0; 		
		}
		if (VelocidadeActual <10) {
			HeliceFrente.Rotate(0, 700 * Time.deltaTime, 0);
			HeliceTras.Rotate(700* Time.deltaTime, 0, 0);
		}
	}
	
	void EngineSound (){
		audio.pitch = VelocidadeActual / VelocidadeMaxima +1;
	}
}
