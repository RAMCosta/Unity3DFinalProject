using UnityEngine;
using System.Collections;

public class FrenteAndroid : MonoBehaviour {

	public static bool FrnAndroid = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touches.Length <= 0) {
			FrnAndroid = false;
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if (this.guiTexture.HitTest (Input.GetTouch (i).position)) {
					if (Input.GetTouch (i).phase == TouchPhase.Stationary) {
						FrnAndroid = true;
					}
				}
			}
		}
	}
}
