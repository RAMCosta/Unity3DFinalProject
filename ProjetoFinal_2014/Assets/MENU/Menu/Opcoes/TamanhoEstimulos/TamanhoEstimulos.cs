using UnityEngine;
using System.Collections;

public class TamanhoEstimulos : MonoBehaviour {

	public GameObject PequenoCima;
	public GameObject EstimuloPequeno;

	public GameObject MedioCima;
	public GameObject EstimuloMedio;

	public GameObject GrandeCima;
	public GameObject EstimuloGrande;

	public static string Size = "Medio";
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (this.name == "Bt_PequenoCima") {
			PequenoCima.SetActive (false);
			EstimuloPequeno.SetActive (true);
			MedioCima.SetActive(true);
			EstimuloMedio.SetActive (false);
			GrandeCima.SetActive(true);
			EstimuloGrande.SetActive(false);
			Size = "Pequeno";
		} else if (this.name == "Bt_MedioCima") {
			MedioCima.SetActive (false);
			EstimuloMedio.SetActive (true);
			PequenoCima.SetActive(true);
			EstimuloPequeno.SetActive (false);
			GrandeCima.SetActive(true);
			EstimuloGrande.SetActive(false);
			Size = "Medio";
		} else if (this.name == "Bt_GrandeCima") {
			GrandeCima.SetActive (false);
			EstimuloGrande.SetActive (true);
			PequenoCima.SetActive(true);
			EstimuloPequeno.SetActive (false);
			MedioCima.SetActive(true);
			EstimuloMedio.SetActive(false);
			Size = "Grande";
		} 

	}
}
