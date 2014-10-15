using UnityEngine;
using System.Collections;

public class HelicopterMenu : MonoBehaviour {
	
	public Transform HeliceFrente;

	// Use this for initialization
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HeliceFrente.Rotate(0, 200 * Time.deltaTime, 0);
		// 1.973081
		if (this.transform.position.x > -17.244) { //16.1
			this.transform.Translate (-6*Time.deltaTime,0,0);
		}
	} //-34.24971

}
