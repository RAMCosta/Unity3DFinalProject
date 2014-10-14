using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	float posicaoX;
	float posicaoY;
	float largura = 150f;
	float altura = 70f;
	// Use this for initialization
	void Start () {
		posicaoX=Screen.width/2 - largura/2;
		posicaoY=Screen.height/2 - altura/2 - 100;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		bool BotaoJogar = GUI.Button(new Rect(posicaoX, posicaoY, largura, altura), "JOGAR");
		bool BotaoSair = GUI.Button(new Rect(posicaoX, posicaoY+100, largura, altura), "SAIR");
		if(BotaoJogar == true){
			Application.LoadLevel("Estrada_Android");
		}
		if(BotaoSair == true){
			Application.Quit();
		}
	}
}
