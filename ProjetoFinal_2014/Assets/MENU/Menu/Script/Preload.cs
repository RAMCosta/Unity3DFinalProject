using UnityEngine;
using System.Collections;

public class Preload : MonoBehaviour {

	float originalWidth = 640.0f; 
	float originalHeight = 1136.0f;
	private Vector3 scale;
	public Texture2D progressBarFrente;
	private AsyncOperation async;
	public GUIStyle FontStyle;
	public bool HelicopteroTeclado;
	public bool HelicopteroGusbamp;
	public bool Carros3DTeclado;
	public bool Carros3DGusbamp;
	public bool Carros2DTeclado;
	public bool Carros2DMindwave;
	
	public static float progress;
	
	void OnGUI()
	{
		scale.x = Screen.width/originalWidth; 
		scale.y = Screen.height/originalHeight; 
		scale.z = 1;
		var svMat = GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		if(async!= null)
		{
			progress = async.progress;
			GUI.DrawTexture(new Rect(100, 1000, 500 * Mathf.Clamp01(progress), 75), progressBarFrente);
			GUI.Label(new Rect(200, 950, 300, 100), "" + "A Carregar ... " + (progress*100+10) + " %",FontStyle);
		}

	}

	void OnMouseDown()
	{
		if(HelicopteroTeclado){
			async = Application.LoadLevelAsync("Helicoptero");  
		}
		if(HelicopteroGusbamp){
			async = Application.LoadLevelAsync("HelicopteroEstimulos");  
		}
		if(Carros3DTeclado){
			async = Application.LoadLevelAsync("AutoNavegacaoCarro");  
		}
		if(Carros3DGusbamp){
			async = Application.LoadLevelAsync("Carro3DEstimulos");  
		}
		if(Carros2DTeclado){
			async = Application.LoadLevelAsync("Carros2D");  
		}
		if(Carros2DMindwave){
			async = Application.LoadLevelAsync("Carros2D_Mindwave");  
		}
	}
}