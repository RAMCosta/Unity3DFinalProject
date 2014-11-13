using UnityEngine;
using System.Collections;

public class MatLab_Env_Comando : MonoBehaviour {

	
	public GUIText modo1;
	public GUIText modo2;
	public GUIText ini_estimulo;
	public GUIText ini_calibracao;
	public static int modo1Valor = 80;
	public static int modo2Valor = 81;
	public static int ini_estimuloValor = 82;
	public static int ini_calibracaoValor = 83;
	// Use this for initialization
	void Start ()
	{
		modo1.gameObject.guiText.text = "" + modo1Valor;
		modo2.gameObject.guiText.text = "" + modo2Valor;
		ini_estimulo.gameObject.guiText.text = "" + ini_estimuloValor;
		ini_calibracao.gameObject.guiText.text = "" + ini_calibracaoValor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnMouseDown ()
	{
		if (this.name == "Modo1MenosCmd_Bt") {
			if (modo1Valor == 0) {
				modo1Valor += 1;
			} else {
				modo1Valor--;
				modo1.gameObject.guiText.text = "" + modo1Valor;
			}
		} else if (this.name == "Modo1MaisCmd_Bt") {
			if (modo1Valor == 100) {
				modo1Valor -= 1;
			} else {
				modo1Valor++;
				modo1.gameObject.guiText.text = "" + modo1Valor;
			}
		} else if (this.name == "Modo2MenosCmd_Bt") {
			if (modo2Valor == 0) {
				modo2Valor += 1;
			} else {
				modo2Valor--;
				modo2.gameObject.guiText.text = "" + modo2Valor;
			}
		} else if (this.name == "Modo2MaisCmd_Bt") {
			if (modo2Valor == 100) {
				modo2Valor -= 1;
			} else {
				modo2Valor++;
				modo2.gameObject.guiText.text = "" + modo2Valor;
			}
		} else if (this.name == "InicioEstMenosCmd_Bt") {
			if (ini_estimuloValor == 0) {
				ini_estimuloValor += 1;
			} else {
				ini_estimuloValor--;
				ini_estimulo.gameObject.guiText.text = "" + ini_estimuloValor;
			}
		} else if (this.name == "InicioEstMaisCmd_Bt") {
			if (ini_estimuloValor == 100) {
				ini_estimuloValor -= 1;
			} else {
				ini_estimuloValor++;
				ini_estimulo.gameObject.guiText.text = "" + ini_estimuloValor;
			}
		} else if (this.name == "InicioCaliMenosCmd_Bt") {
			if (ini_calibracaoValor == 0) {
				ini_calibracaoValor -= 1;
			} else {
				ini_calibracaoValor--;
				ini_calibracao.gameObject.guiText.text = "" + ini_calibracaoValor;
			}
		} else if (this.name == "InicioCaliMaisCmd_Bt") {
			if (ini_calibracaoValor == 100) {
				ini_calibracaoValor -= 1;
			} else {
				ini_calibracaoValor++;
				ini_calibracao.gameObject.guiText.text = "" + ini_calibracaoValor;
			}
		}
	}
}
