using UnityEngine;
using System.Collections;

public class CimaMov : MonoBehaviour
{

		// Use this for initialization
		private float velocidade = 0.1f;

		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
				if (Input.touches.Length <= 0) {
			
				} else {
						for (int i=0; i<Input.touchCount; i++) {
								if (this.guiTexture.HitTest (Input.GetTouch (i).position)) {
										if (Input.GetTouch (i).phase == TouchPhase.Stationary) {
												GameObject.Find ("Carro").transform.position = new Vector2 (-7, GameObject.Find ("Carro").transform.position.y + velocidade);

										}
								}
						}
				}
		}
}
