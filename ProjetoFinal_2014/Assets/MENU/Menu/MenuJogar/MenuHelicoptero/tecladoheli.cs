using UnityEngine;
using System.Collections;

public class tecladoheli : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.Android) {
			this.guiText.text = "Touch";
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			this.guiText.text = "Touch";
		} else {
			this.guiText.text = "Teclado";
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
		Application.LoadLevel ("Helicoptero");
	}
}
