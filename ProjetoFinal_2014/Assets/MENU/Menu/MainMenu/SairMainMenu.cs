using UnityEngine;
using System.Collections;

public class SairMainMenu : MonoBehaviour {

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
		Application.Quit();
	}
}
