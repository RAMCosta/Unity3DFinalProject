using UnityEngine;
using System.Collections;

public class RodarHelic : MonoBehaviour {

	public Transform helicesCima;
	public Transform helicesTras;
	float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (Input.anyKey) {
			time = 0;		
		}
		if (time >= 15) {
			Application.LoadLevel("Introducao");		
		}
		helicesCima.Rotate (new Vector3 (0, 300*Time.deltaTime, 0));
		helicesTras.Rotate (new Vector3 (300*Time.deltaTime,0,0));
	}
}
