using UnityEngine;
using System.Collections;

public class RestaurarHeli : MonoBehaviour {

	// Use this for initialization
	public GameObject Helicopterozico;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					if (Input.GetTouch (i).phase == TouchPhase.Began) {
					//	Helicopterozico.transform.Rotate(FramePositionX,FramePositionY,FramePositionZ);
						Application.LoadLevel("GoodCity Android");

					}
				}
			}
		}
	}
}