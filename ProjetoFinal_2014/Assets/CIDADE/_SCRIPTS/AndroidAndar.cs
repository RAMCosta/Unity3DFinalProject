using UnityEngine;
using System.Collections;

public class AndroidAndar : MonoBehaviour {

	// Use this for initialization
	int velocidadeAndamento = 13;
	int velocidadeSubir = 3;
	public GameObject Helicopterozico;
	bool carregou = false;
	bool colisao = false;
	public GUITexture Acelerar;
	public GUITexture SetaCima;
	public GUITexture SetaBaixo;
	public GUIText texto;



	void Start () {
		/*int widht = Screen.width;
		Acelerar.transform.position = new Vector3(0.25f ,0.3f, 1.0f);
		SetaCima.transform.position = new Vector3(0.65f ,0.4f, 1.0f);
		SetaBaixo.transform.position = new Vector3(0.69f ,0.25f, 1.0f);
*/
	}
	
	


	// Update is called once per frame
	void Update () {

		if (Input.touches.Length <= 0) {
		} else {
			for (int i=0; i<Input.touchCount; i++) {
				if(Acelerar.guiTexture.HitTest(Input.GetTouch(i).position)){
					if (Input.GetTouch (i).phase == TouchPhase.Began) {
						carregou = true;
						Helicopterozico.rigidbody.useGravity = false; 
					}if (Input.GetTouch (i).phase == TouchPhase.Ended) {
						carregou = false;
						Helicopterozico.rigidbody.useGravity=true;
					}
				}
				if(SetaCima.guiTexture.HitTest(Input.GetTouch(i).position)){
						Helicopterozico.rigidbody.useGravity = false;
						texto.text = "Start";
						Helicopterozico.transform.Translate (0, velocidadeSubir*Time.deltaTime, 0);
				}
				if(SetaBaixo.guiTexture.HitTest(Input.GetTouch(i).position)){
					Helicopterozico.transform.Translate (0, -(velocidadeSubir*Time.deltaTime),0);
			}
		}
		if (carregou == true) {
			colisao = false;
			Helicopterozico.transform.Translate (0, 0, velocidadeAndamento * Time.deltaTime);
				
		}if (carregou == false && colisao != true) {
			//Helicopterozico.transform.Translate (0, -(velocidadeSubir*Time.deltaTime), (velocidadeAndamento-4) * Time.deltaTime);	
		}
	}
	}
}
