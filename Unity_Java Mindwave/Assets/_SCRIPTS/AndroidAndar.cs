using UnityEngine;
using System.Collections;

public class AndroidAndar : MonoBehaviour {

	// Use this for initialization
	public int velocidadeAndamento = 40;
	public int velocidadeVirar = 10;
	public int velocidadeSubir = 5;
	public GameObject Helicopterozico;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					rigidbody.useGravity = false;
					Helicopterozico.transform.Translate (0, Helicopterozico.transform.position.y - 0.1f * Time.deltaTime, velocidadeAndamento * Time.deltaTime);
					// virar para a esquerda
					/*	if (SetaEsqu.guiTexture.HitTest(Input.GetTouch(i).position)) {
							transform.Rotate (Vector3.down * Time.deltaTime * velocidadeVirar);
						}
						// virar para a direita
						if (SetaDir.guiTexture.HitTest(Input.GetTouch(i).position)) {
							transform.Rotate (Vector3.up * Time.deltaTime * velocidadeVirar);
					}*/
				}else {
					rigidbody.useGravity = true;	
				}
			}
		}
	}
}
