using UnityEngine;
using System.Collections;

public class detectarcolisoes : MonoBehaviour {

	bool bebe1Movimento = false;
	bool bebe2Movimento = false;
	bool bebe3Movimento = false;
	public GameObject Bebe1;
	public GameObject Bebe2;
	public GameObject Bebe3;
	int NumeroBebes = 0;
	// Use this for initialization

	void Start () {
		GameObject.Find("particulasEliporto").particleSystem.Stop();
		Bebe1.SetActive(false);
		Bebe1.SetActive(true);
		Bebe2.SetActive(false);
		Bebe3.SetActive(false);
	}	

	// Update is called once per frame
	void Update () {
		if (bebe1Movimento == true) {
			GameObject.Find("babyzico1").transform.position = this.transform.position;		
		}
		if (bebe2Movimento == true) {
			GameObject.Find("babyzico2").transform.position = this.transform.position;		
		}
		if (bebe3Movimento == true) {
			GameObject.Find("babyzico3").transform.position = this.transform.position;		
		}
		if (NumeroBebes==3){
			Application.Quit();
		}
	}




	void OnTriggerEnter(Collider colisao) {

		// Detecçao de Colisoes do helicoptero com os diversos bebes
		if (colisao.gameObject.name == "ColliderBebe1") {
			bebe1Movimento = true;
			GameObject.Find("particulasEliporto").particleSystem.Play();
		}
		if (colisao.gameObject.name == "ColliderBebe2") {
			bebe2Movimento = true;
			GameObject.Find("particulasEliporto").particleSystem.Play();
		}
		if (colisao.gameObject.name == "ColliderBebe3") {
			bebe3Movimento = true;
			GameObject.Find("particulasEliporto").particleSystem.Play();
		}


		if (colisao.gameObject.name == "ColliderHeliporto") {

			if (bebe1Movimento == true){
				GameObject.Find("particulasBebe1").particleSystem.Stop();
				GameObject.Find("babyzico1").transform.position = GameObject.Find("Bebe1").transform.position;	
				bebe1Movimento = false;
				Bebe2.SetActive(true);
				NumeroBebes++;
			}
			if (bebe2Movimento == true){
				GameObject.Find("particulasBebe2").particleSystem.Stop();
				GameObject.Find("babyzico2").transform.position = GameObject.Find("Bebe2").transform.position;	
				bebe2Movimento = false;
				Bebe3.SetActive(true);
				NumeroBebes++;
			}
			if (bebe3Movimento == true){
				GameObject.Find("particulasBebe3").particleSystem.Stop();
				GameObject.Find("babyzico3").transform.position = GameObject.Find("Bebe3").transform.position;	
				bebe3Movimento = false;
				NumeroBebes++;
			}
		}

	}

	void OnGUI (){
		//GUI.TextArea(new Rect (0,0,120,25), "Bebes Salvos : " + NumeroBebes);
	}

}
