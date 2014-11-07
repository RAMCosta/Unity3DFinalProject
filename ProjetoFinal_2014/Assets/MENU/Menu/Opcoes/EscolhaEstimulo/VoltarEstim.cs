using UnityEngine;
using System.Collections;

public class VoltarEstim : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter ()
	{
		this.guiText.color = Color.yellow;
	}
	
	void OnMouseExit ()
	{
		this.guiText.color = Color.white;
	}
	
	void OnMouseDown ()
	{
		Application.LoadLevel ("MenuOpcoes");
		if (Application.loadedLevel.Equals("EscolherEstimulos_Menuopcoes")) {
			EstimulosEscolha.aux = 0;
			PiscarSetas.ThreadBlink.Abort();
			Application.LoadLevel("MenuOpcoes");
		}
	}
}
