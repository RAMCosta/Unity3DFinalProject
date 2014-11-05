using UnityEngine;
using System.Collections;

public class TesteGUI : MonoBehaviour {



	public Texture BarraFundo;
	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (Screen.width/10, Screen.height/10, 1.5f*Screen.width/2, Screen.height/10), BarraFundo);
	}
}
