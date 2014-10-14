using UnityEngine;
using System.Collections;

public class SonsScript : MonoBehaviour {

	float FriccaoRodas ;
	public WheelCollider Roda;
	public GameObject Sonzicos;
	public GameObject Fumozico;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		WheelHit hit;
		Roda.GetGroundHit (out hit);
		FriccaoRodas = hit.sidewaysSlip;
		if (FriccaoRodas < -0.7f || FriccaoRodas > 0.7f) {
			Instantiate (Sonzicos, hit.point, Quaternion.identity);
			Fumozico.particleEmitter.emit = true;
		}else 
		{
			Fumozico.particleEmitter.emit = false;
		}
	}
}
