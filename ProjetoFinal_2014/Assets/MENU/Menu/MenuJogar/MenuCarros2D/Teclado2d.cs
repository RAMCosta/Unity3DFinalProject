using UnityEngine;
using System.Collections;

public class Teclado2d : MonoBehaviour {

	public GUIText Teclado;
	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.Android) {
			Teclado.guiText.text = "Touch";
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Teclado.guiText.text = "Touch";
		} else {
			Teclado.guiText.text = "Teclado";
		}
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
		Application.LoadLevel ("Carros2D");
	}
}
