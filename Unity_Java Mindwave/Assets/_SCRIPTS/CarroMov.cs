using UnityEngine;
using System.Collections;

public class CarroMov : MonoBehaviour {

	public WheelCollider WheelFL;
	public WheelCollider WheelFR;
	public WheelCollider WheelBL;
	public WheelCollider WheelBR;
	public float maxTorque = 50f;
	public Transform WheelFLTrans;
	public Transform WheelFRTrans;
	public Transform WheelBLTrans;
	public Transform WheelBRTrans;
	public Transform VolanteTrans;
	private float lowestSteerAtSpeed = 50f; //
	private float lowSpeedSteerAngle = 10f;//
	private float hightSpeedSteerAngle = 1f;//
	public float VelocidadeActual;
	public float VelocidadeMaxima = 150f;
	private float desacelerar = 40f; 
	public GameObject LuzTraseiraDir;
	public GameObject LuzTraseiraEsq;
	public Material LuzTravar;
	public Material LuzMarchaTras;
	public Material LuzNormal;
	bool TravaoDeMao = false;
	public float MaximaTravagemMao = 100f;
	// Use this for initialization
	void Start () {
		// Para o carro nao caputar
		rigidbody.centerOfMass = new Vector3 (0f, -0.9f, 0f);
	}

	void FixedUpdate () {
		ControloCarro ();
		TravagemTravaoDeMao ();
	}
	void Update(){
		// Rotaçao das Rodas
		WheelFLTrans.Rotate (WheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelFRTrans.Rotate (WheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelBLTrans.Rotate (WheelBL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelBRTrans.Rotate (WheelBR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		LuzesTraseiras ();
		EngineSound ();
		// Virar o Volante
		VolanteTrans.Rotate(WheelFL.steerAngle - WheelFLTrans.localEulerAngles.z, 0, 0);

	}

	// Funçao de controlo do carro
	void ControloCarro(){
		VelocidadeActual = 2 * 22 / 7 * WheelBL.radius*WheelBL.rpm * 60 / 1000; // Formula matematica para calcular a velocidade
		VelocidadeActual = Mathf.Round (VelocidadeActual); // Tirar as casas decimais
		if (VelocidadeActual < VelocidadeMaxima && !TravaoDeMao) {
			WheelBR.motorTorque = maxTorque * Input.GetAxis ("Vertical"); // Acelerar Carro
			WheelBL.motorTorque = maxTorque * Input.GetAxis ("Vertical"); // Acelerar Carro
		} else{
			WheelBR.motorTorque = 0; 
			WheelBL.motorTorque = 0; 
		}
		//Desacelerar carro quando nao se esta a acelerar
		if (Input.GetButton ("Vertical") == false) {
			WheelBR.brakeTorque = desacelerar;  // Travar Carro
			WheelBL.brakeTorque = desacelerar;	// Travar Carro
		} else {
			WheelBR.brakeTorque = 0;
			WheelBL.brakeTorque = 0;	
		}
		var speedFactor = rigidbody.velocity.magnitude / lowestSteerAtSpeed;
		var currentSteerAngle = Mathf.Lerp (lowSpeedSteerAngle, hightSpeedSteerAngle, speedFactor);
		currentSteerAngle *= Input.GetAxis ("Horizontal");
		WheelFL.steerAngle = currentSteerAngle; // 10 * Input.GetAxis ("Horizontal");
		WheelFR.steerAngle = currentSteerAngle; // 10 * Input.GetAxis ("Horizontal");
	}

	void LuzesTraseiras() {
		if (VelocidadeActual > 0 && Input.GetAxis("Vertical")<0 && !TravaoDeMao){
			LuzTraseiraDir.renderer.material = LuzTravar;
			LuzTraseiraEsq.renderer.material = LuzTravar;
		} else if (VelocidadeActual < 0 && Input.GetAxis("Vertical")>0 && !TravaoDeMao){
			LuzTraseiraDir.renderer.material = LuzTravar;
			LuzTraseiraEsq.renderer.material = LuzTravar;
		} else if (VelocidadeActual < 0 && Input.GetAxis("Vertical")<0 && !TravaoDeMao){
			LuzTraseiraDir.renderer.material = LuzMarchaTras;
			LuzTraseiraEsq.renderer.material = LuzMarchaTras;
		}else if (!TravaoDeMao){
			LuzTraseiraDir.renderer.material = LuzNormal;
			LuzTraseiraEsq.renderer.material = LuzNormal;
		}
	}

	void TravagemTravaoDeMao () {
		if (Input.GetKey (KeyCode.Space)) {
			TravaoDeMao = true;				
		} else {
			TravaoDeMao = false;
		}
		if (TravaoDeMao) {
			WheelBR.brakeTorque = MaximaTravagemMao; 
			WheelBL.brakeTorque = MaximaTravagemMao;
			WheelBR.motorTorque = 0; 
			WheelBL.motorTorque = 0;
			if (VelocidadeActual <1 && VelocidadeActual > -1){
				LuzTraseiraDir.renderer.material = LuzNormal;
				LuzTraseiraEsq.renderer.material = LuzNormal;
			} else {
				LuzTraseiraDir.renderer.material = LuzTravar;
				LuzTraseiraEsq.renderer.material = LuzTravar;
			}
		}
	}

	void EngineSound (){
		audio.pitch = VelocidadeActual / VelocidadeMaxima +1;
	}
}
