using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EscolherMoedas : MonoBehaviour {

	List<int> ListaMoedas = new List<int> ();
	//int[] numeros = new int[11];
	int ValorRandom = 0;
	int contador = 0;
	public GUIStyle TipoLetra;
	public GUIStyle LetraHoras;
	public Texture2D PontuacaoTexture;
	string niceTime;
	float timer;
	// Use this for initialization
	void Start () {
		while (contador<10) {
			ValorRandom = Random.Range (1, 20);
			if (!ListaMoedas.Contains (ValorRandom)) {
				ListaMoedas.Add (ValorRandom);
				GameObject.Find("Coin" + ListaMoedas[contador]).SetActive(false);	
				contador++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
	//	s = System.TimeSpan.FromSeconds((int)Time.timeSinceLevelLoad).ToString();
	}

	void OnGUI(){
		GUI.contentColor = Color.white;

		// Distancia
		GUI.Label(new Rect( 23*Screen.width/30, 10*Screen.height/12, Screen.width/5, Screen.height/4), DestinosHelicoptero.distancia + " m",TipoLetra);

		// Pontuacao
		GUI.DrawTexture(new Rect (Screen.width/30, 10.5f*Screen.height/12, Screen.width/20, Screen.height/16), PontuacaoTexture);
		GUI.Label(new Rect( 3*Screen.width/30, 10*Screen.height/12, Screen.width/5, Screen.height/4), "" + ApanharMoedas.Pontuacao,TipoLetra);

		// Tempo 
		GUI.Label(new Rect( 3*Screen.width/30, Screen.height/12, Screen.width/5, Screen.height/4), "" + niceTime,LetraHoras);
	}
}
