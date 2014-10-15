using UnityEngine;
using System.Collections;

public class ControloCiclosHertz : MonoBehaviour {

	
	// Use this for initialization
	public GameObject SetaCimaAmarela;
	public GameObject SetaCimaPreta;
	public GameObject SetaBaixoAmarela;
	public GameObject SetaBaixoPreta;
	double frequenciaSetaCima;
	double frequenciaSetaBaixo;
	double frequenciaSetaEsquerda;
	double frequenciaSetaDireita;
	
	public static float Timer8Hz = 0.200f;
	public static float Timer12Hz = 0.1f;
	
	
	public static int freq1 = 10; //frequencia 1
	public static int freq2 = 20; //frequencia 2 
	
	public static int dim1;  // intervalo em milisegundo de freq1
	public static int dim2;  // intervalo em milisegundo de freq2
	
	public static int frames1=0;  // intervalo em milisegundo de freq1
	public static int frames2=0;  // intervalo em milisegundo de freq2
	void Start () {
		
		SetaCimaAmarela.SetActive (true);
		SetaCimaPreta.SetActive (true);
		SetaBaixoAmarela.SetActive (true);
		SetaBaixoPreta.SetActive (true);
		dim1 = 1000 / (2* freq1);
		dim2 = 1000 / (2* freq2);
		
	}
	
	static int imagens = 0;
	// Update is called once per frame
	void Update () {
		//long milisegundos = DateTime.Now.Millisecond;
		//long testesegundos = DateTime.Now.Millisecond;
		
		//	if(ModoVisualAnim.visualmodo==true){
		// ------------------------------------------- SETA BAIXO 5Hzs -----------------------------------------------
		//if (PiscarDireita==true) {
		//if (milisegundos % 124 < 62) {
		/*		Timer8Hz = (Time.time * 1000) / (7.0f * 2f); 
			int t5hz = (int)(Timer8Hz);
			if (t5hz % 2 == 0) {
				SetaBaixoAmarela.SetActive (false);
		Debug.Log ("Time = " + Timer8Hz + " frame " + t5hz + "activo");
			}else {
				SetaBaixoAmarela.SetActive (true);	
		Debug.Log ("Time = " + Timer8Hz + " frame " + t5hz + "INactivo");
			  	}
	*/
		frames1++;
		if ((frames1/3) % 2 == 0) {
			SetaBaixoAmarela.SetActive (false);
			//	Debug.Log ("Time = " + Timer8Hz + " frame " + t5hz + "activo");
		}else {
			SetaBaixoAmarela.SetActive (true);	
			//	Debug.Log ("Time = " + Timer8Hz + " frame " + t5hz + "INactivo");
		}
		
		
		//}
		// ------------------------------------------- SETA CIMA 8 Hertz-----------------------------------------------
		//if (PiscarEsquerda == true) {
		//if (milisegundos % 82 < 41) {
		Timer12Hz = (Time.time * 1000) / (12.0f * 2f); 
		int t12hz = (int)(Timer12Hz);
		frames2++;
		if ((frames2/2) % 2 == 0) {
			//if (t12hz % 2 == 0) {
			SetaCimaPreta.SetActive (false);;
			//Debug.Log ("Time = " + Timer12Hz + " frame " + t12hz + "activo");
		}else {
			SetaCimaPreta.SetActive (true);	
			//Debug.Log ("Time = " + Timer12Hz + " frame " + t12hz + "INactivo");
		}
		//}
		//}
		
		
	}
}
