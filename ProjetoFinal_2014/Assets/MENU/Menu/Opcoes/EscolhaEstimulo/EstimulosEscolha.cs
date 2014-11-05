using UnityEngine;
using System.Collections;

public class EstimulosEscolha : MonoBehaviour 
{
	
	public GUITexture VerSeta1;
	public GUITexture VerSeta2;
	public Texture[] GUIArrow;
	public static int numeroSeta = 1;
	public static string Seta1Usada = "SetaAzul";
	public static string Seta2Usada = "SetaAmarela";
	public static int aux = 0;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnMouseDown ()
	{
		aux++;
		if (aux == 2) {
			GameObject.Find ("MenuPref").GetComponent<PiscarSetas> ().enabled = true;
		}
		if (this.guiTexture.name == "SetaAmarela") {
			if (numeroSeta == 1) {
				VerSeta1.guiTexture.texture = GUIArrow[0];
				numeroSeta = 2;
				Seta1Usada = "SetaAmarela";
			} else {
				VerSeta2.guiTexture.texture = GUIArrow[0];
				numeroSeta = 1;
				Seta2Usada = "SetaAmarela";
			}
			
		}
		if (this.guiTexture.name == "SetaAzul") {
			if (numeroSeta == 1) {
				VerSeta1.guiTexture.texture = GUIArrow[1];
				numeroSeta = 2;
				Seta1Usada = "SetaAzul";
			} else {
				VerSeta2.guiTexture.texture = GUIArrow[1];
				numeroSeta = 1;
				Seta2Usada = "SetaAzul";
			}
			
		}
		if (this.guiTexture.name == "SetaBranca") {
			if (numeroSeta == 1) {
				VerSeta1.guiTexture.texture = GUIArrow[2];
				numeroSeta = 2;
				Seta1Usada = "SetaBranca";
			} else {
				VerSeta2.guiTexture.texture = GUIArrow[2];
				numeroSeta = 1;
				Seta2Usada = "SetaBranca";
			}
			
		}
		if (this.guiTexture.name == "SetaVerde") {
			if (numeroSeta == 1) {
				VerSeta1.guiTexture.texture = GUIArrow[3];
				numeroSeta = 2;
				Seta1Usada = "SetaVerde";
			} else {
				VerSeta2.guiTexture.texture = GUIArrow[3];
				numeroSeta = 1;
				Seta2Usada = "SetaVerde";
			}
			
		}
		if (this.guiTexture.name == "SetaVermelha") {
			if (numeroSeta == 1) {
				VerSeta1.guiTexture.texture = GUIArrow[4];
				numeroSeta = 2;
				Seta1Usada = "SetaVermelha";
			} else {
				VerSeta2.guiTexture.texture = GUIArrow[4];
				numeroSeta = 1;
				Seta2Usada = "SetaVermelha";
			}		
		}
		if (this.guiTexture.name == "SetaCinzenta") {
			if (numeroSeta == 1) {
				VerSeta1.guiTexture.texture = GUIArrow[5];
				numeroSeta = 2;
				Seta1Usada = "SetaCinzenta";
			} else {
				VerSeta2.guiTexture.texture = GUIArrow[5];
				numeroSeta = 1;
				Seta2Usada = "SetaCinzenta";
			}	
		}
		if (this.gameObject.name == "Bt_Definir") {
			aux = 0;
			PiscarSetas.ThreadBlink.Abort();
		}
		
	}
}
