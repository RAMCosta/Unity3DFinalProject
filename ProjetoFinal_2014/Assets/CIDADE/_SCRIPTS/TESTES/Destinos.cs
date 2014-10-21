using UnityEngine;
using System.Collections;

public class Destinos : MonoBehaviour {

	string DestinoAnterior;
	string ColisaoActual;
	int NumeroDestino = 13; 
	int Aceleracao = 11;
	int Velocidade = 10;
	string DestinoActual;
	public GameObject EscolhaDestino;
	public Transform[] destino;
	private NavMeshAgent agente;

	float posicaoAtualX;
	float posicaoAtualY;
	float posicaoAtualZ;
	
	// Use this for initialization
	void Start () {
		EscolhaDestino.SetActive(false);
		DestinoActual = "Destino12";
		DestinoAnterior = "Destino12";
	}
	
	// Update is called once per frame
	void Update () {
	
		if (EscolhaDestino.activeSelf == true) {	// VIRAR DIREITA
			if (Input.GetKey(KeyCode.M))
			{
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino63") {NumeroDestino = 2; }
				
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino1") {NumeroDestino = 3; }
				
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino2") {NumeroDestino = 10; }
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino4") {NumeroDestino = 2; }
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino10") {NumeroDestino = 12; }
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino12") {NumeroDestino = 4; }
				
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino3") {NumeroDestino = 13; }
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino13") {NumeroDestino = 5; }
				
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino4") {NumeroDestino = 14; }
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino14") {NumeroDestino = 6; }
				
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino5") {NumeroDestino = 15; }
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino15") {NumeroDestino = 7; }
				
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino6") {NumeroDestino = 16; }
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino16") {NumeroDestino = 8; }
				
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino7") {NumeroDestino = 17; }
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino17") {NumeroDestino = 9; }
				
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino8") {NumeroDestino = 18; }
				
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino11") {NumeroDestino = 3; }
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino22") {NumeroDestino = 11; }
				
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino10") {NumeroDestino = 19; }
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino19") {NumeroDestino = 12; }
				
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino3") {NumeroDestino = 11; }
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino11") {NumeroDestino = 19; }
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino13") {NumeroDestino = 3; }
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino19") {NumeroDestino = 13; }
				
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino4") {NumeroDestino = 12; }
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino12") {NumeroDestino = 21; }
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino14") {NumeroDestino = 4; }
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino21") {NumeroDestino = 14; }
				
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino5") {NumeroDestino = 13; }
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino13") {NumeroDestino = 27; }
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino15") {NumeroDestino = 5; }
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino27") {NumeroDestino = 15; }
				
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino6") {NumeroDestino = 14; }
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino14") {NumeroDestino = 28; }
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino16") {NumeroDestino = 6; }
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino28") {NumeroDestino = 16; }
				
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino7") {NumeroDestino = 15; }
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino15") {NumeroDestino = 29; }
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino17") {NumeroDestino = 7; }
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino29") {NumeroDestino = 17; }
				
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino8") {NumeroDestino = 16; }
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino16") {NumeroDestino = 30; }
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino18") {NumeroDestino = 8; }
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino30") {NumeroDestino = 18; }
				
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino9") {NumeroDestino = 17; }
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino17") {NumeroDestino = 31;}
				
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino11") {NumeroDestino = 24; }
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino12") {NumeroDestino = 11; }
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino20") {NumeroDestino = 12; }
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino24") {NumeroDestino = 20; }
				
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino19") {NumeroDestino = 25; }
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino25") {NumeroDestino = 21; }
				
				if (DestinoActual == "Destino21" && DestinoAnterior == "Destino13") {NumeroDestino = 20; }
				if (DestinoActual == "Destino21" && DestinoAnterior == "Destino20") {NumeroDestino = 26; }
				
				if (DestinoActual == "Destino22" && DestinoAnterior == "Destino23") {NumeroDestino = 10; }
				if (DestinoActual == "Destino22" && DestinoAnterior == "Destino32") {NumeroDestino = 23; }
				
				if (DestinoActual == "Destino23" && DestinoAnterior == "Destino22") {NumeroDestino = 32; }
				if (DestinoActual == "Destino23" && DestinoAnterior == "Destino32") {NumeroDestino = 24; }
				
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino19") {NumeroDestino = 23; }
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino23") {NumeroDestino = 33; }
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino25") {NumeroDestino = 19; }
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino33") {NumeroDestino = 25; }
				
				if (DestinoActual == "Destino25" && DestinoAnterior == "Destino20") {NumeroDestino = 24; }
				if (DestinoActual == "Destino25" && DestinoAnterior == "Destino26") {NumeroDestino = 20; }
				
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino21") {NumeroDestino = 25; }
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino25") {NumeroDestino = 36; }
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino27") {NumeroDestino = 21; }
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino36") {NumeroDestino = 27; }
				
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino14") {NumeroDestino = 26; }
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino26") {NumeroDestino = 37; }
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino28") {NumeroDestino = 14; }
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino37") {NumeroDestino = 28; }
				
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino15") {NumeroDestino = 27; }
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino27") {NumeroDestino = 38; }
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino38") {NumeroDestino = 29; }
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino29") {NumeroDestino = 15; }
				
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino16") {NumeroDestino = 28; }
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino28") {NumeroDestino = 39; }
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino39") {NumeroDestino = 30; }
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino30") {NumeroDestino = 16; }
				
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino17") {NumeroDestino = 29; }
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino29") {NumeroDestino = 40; }
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino40") {NumeroDestino = 31; }
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino31") {NumeroDestino = 17; }
				
				if (DestinoActual == "Destino31" && DestinoAnterior == "Destino18") {NumeroDestino = 30; }
				if (DestinoActual == "Destino31" && DestinoAnterior == "Destino30") {NumeroDestino = 41; }
				
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino22") {NumeroDestino = 34; }
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino23") {NumeroDestino = 22; }
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino33") {NumeroDestino = 23; }
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino34") {NumeroDestino = 33; }
				
				if (DestinoActual == "Destino33" && DestinoAnterior == "Destino24") {NumeroDestino = 32; }
				if (DestinoActual == "Destino33" && DestinoAnterior == "Destino32") {NumeroDestino = 35; }
				if (DestinoActual == "Destino33" && DestinoAnterior == "Destino35") {NumeroDestino = 24; }
				
				if (DestinoActual == "Destino34" && DestinoAnterior == "Destino35") {NumeroDestino = 32; }
				
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino33") {NumeroDestino = 34; }
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino34") {NumeroDestino = 43; }
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino36") {NumeroDestino = 33; }
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino43") {NumeroDestino = 36; }
				
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino26") {NumeroDestino = 35; }
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino35") {NumeroDestino = 44; }
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino37") {NumeroDestino = 26; }
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino44") {NumeroDestino = 37; }
				
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino27") {NumeroDestino = 36; }
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino36") {NumeroDestino = 47; }
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino38") {NumeroDestino = 27; }
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino47") {NumeroDestino = 38; }
				
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino28") {NumeroDestino = 37; }
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino37") {NumeroDestino = 48; }
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino39") {NumeroDestino = 28; }
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino48") {NumeroDestino = 39; }
				
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino29") {NumeroDestino = 38; }
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino38") {NumeroDestino = 49; }
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino40") {NumeroDestino = 29; }
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino49") {NumeroDestino = 40; }
				
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino30") {NumeroDestino = 39; }
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino39") {NumeroDestino = 50; }
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino41") {NumeroDestino = 30; }
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino50") {NumeroDestino = 41; }
				
				if (DestinoActual == "Destino41" && DestinoAnterior == "Destino31") {NumeroDestino = 40; }
				if (DestinoActual == "Destino41" && DestinoAnterior == "Destino40") {NumeroDestino = 51; }
				
				if (DestinoActual == "Destino42" && DestinoAnterior == "Destino43") {NumeroDestino = 44; }
				if (DestinoActual == "Destino42" && DestinoAnterior == "Destino44") {NumeroDestino = 36; }
				
				if (DestinoActual == "Destino43" && DestinoAnterior == "Destino42") {NumeroDestino = 35; }
				if (DestinoActual == "Destino43" && DestinoAnterior == "Destino45") {NumeroDestino = 42; }
				
				if (DestinoActual == "Destino44" && DestinoAnterior == "Destino36") {NumeroDestino = 42; }
				if (DestinoActual == "Destino44" && DestinoAnterior == "Destino42") {NumeroDestino = 46; }
				
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino43") {NumeroDestino = 64; }
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino46") {NumeroDestino = 43; }
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino52") {NumeroDestino = 46; }
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino64") {NumeroDestino = 52; }
				
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino44") {NumeroDestino = 45; }
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino45") {NumeroDestino = 53; }
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino47") {NumeroDestino = 44; }
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino53") {NumeroDestino = 47; }
				
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino37") {NumeroDestino = 46; }
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino46") {NumeroDestino = 54; }
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino48") {NumeroDestino = 37; }
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino54") {NumeroDestino = 48; }
				
				if (DestinoActual == "Destino48" && DestinoAnterior == "Destino38") {NumeroDestino = 47; }
				if (DestinoActual == "Destino48" && DestinoAnterior == "Destino49") {NumeroDestino = 38; }
				
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino39") {NumeroDestino = 48; }
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino48") {NumeroDestino = 55; }
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino50") {NumeroDestino = 39; }
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino55") {NumeroDestino = 50; }
				
				if (DestinoActual == "Destino50" && DestinoAnterior == "Destino40") {NumeroDestino = 49; }
				if (DestinoActual == "Destino50" && DestinoAnterior == "Destino51") {NumeroDestino = 40; }
				
				if (DestinoActual == "Destino51" && DestinoAnterior == "Destino41") {NumeroDestino = 50; }
				if (DestinoActual == "Destino51" && DestinoAnterior == "Destino50") {NumeroDestino = 56; }
				
				if (DestinoActual == "Destino52" && DestinoAnterior == "Destino53") {NumeroDestino = 45; }
				if (DestinoActual == "Destino52" && DestinoAnterior == "Destino57") {NumeroDestino = 53; }
				
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino46") {NumeroDestino = 52; }
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino52") {NumeroDestino = 58; }
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino54") {NumeroDestino = 46; }
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino58") {NumeroDestino = 54; }
				
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino47") {NumeroDestino = 53; }
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino53") {NumeroDestino = 59; }
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino55") {NumeroDestino = 47; }
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino59") {NumeroDestino = 55; }
				
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino49") {NumeroDestino = 54; }
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino54") {NumeroDestino = 60; }
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino57") {NumeroDestino = 49; }
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino60") {NumeroDestino = 56; }
				
				if (DestinoActual == "Destino56" && DestinoAnterior == "Destino51") {NumeroDestino = 55; }
				if (DestinoActual == "Destino56" && DestinoAnterior == "Destino55") {NumeroDestino = 62; }
				
				if (DestinoActual == "Destino57" && DestinoAnterior == "Destino58") {NumeroDestino = 52; }
				
				if (DestinoActual == "Destino58" && DestinoAnterior == "Destino53") {NumeroDestino = 57; }
				if (DestinoActual == "Destino58" && DestinoAnterior == "Destino65") {NumeroDestino = 59; }
				
				if (DestinoActual == "Destino59" && DestinoAnterior == "Destino54") {NumeroDestino = 58; }
				
				if (DestinoActual == "Destino60" && DestinoAnterior == "Destino55") {NumeroDestino = 59; }
				
				if (DestinoActual == "Destino61" && DestinoAnterior == "Destino56") {NumeroDestino = 60; }
				
				if (DestinoActual == "Destino63" && DestinoAnterior == "Destino62") {NumeroDestino = 1; }	

				this.gameObject.GetComponent<NavMeshAgent>().acceleration = Aceleracao;
				EscolhaDestino.SetActive(false);
				DestinoAnterior = DestinoActual;
			}
			
			if (Input.GetKey(KeyCode.Z))
			    {
				if (DestinoActual == "Destino1" && DestinoAnterior == "Destino2") {NumeroDestino = 63; }
				
				if (DestinoActual == "Destino2" && DestinoAnterior == "Destino3") {NumeroDestino = 1; }
				
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino2") {NumeroDestino = 4; }
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino4") {NumeroDestino = 12; }
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino10") {NumeroDestino = 2; }
				if (DestinoActual == "Destino3" && DestinoAnterior == "Destino12") {NumeroDestino = 10; }
				
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino5") {NumeroDestino = 13; }
				if (DestinoActual == "Destino4" && DestinoAnterior == "Destino13") {NumeroDestino = 3; }
				
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino6") {NumeroDestino = 14; }
				if (DestinoActual == "Destino5" && DestinoAnterior == "Destino14") {NumeroDestino = 4; }
				
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino7") {NumeroDestino = 15; }
				if (DestinoActual == "Destino6" && DestinoAnterior == "Destino15") {NumeroDestino = 5; }
				
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino8") {NumeroDestino = 16; }
				if (DestinoActual == "Destino7" && DestinoAnterior == "Destino16") {NumeroDestino = 6; }
				
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino9") {NumeroDestino = 17; }
				if (DestinoActual == "Destino8" && DestinoAnterior == "Destino17") {NumeroDestino = 7; }
				
				if (DestinoActual == "Destino9" && DestinoAnterior == "Destino18") {NumeroDestino = 8; }
				
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino3") {NumeroDestino = 11; }
				if (DestinoActual == "Destino10" && DestinoAnterior == "Destino11") {NumeroDestino = 22; }
				
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino12") {NumeroDestino = 19; }
				if (DestinoActual == "Destino11" && DestinoAnterior == "Destino19") {NumeroDestino = 10; }
				
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino3") {NumeroDestino = 13; }
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino11") {NumeroDestino = 3; }
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino13") {NumeroDestino = 19; }
				if (DestinoActual == "Destino12" && DestinoAnterior == "Destino19") {NumeroDestino = 11; }
				
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino4") {NumeroDestino = 14; }
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino12") {NumeroDestino = 4; }
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino14") {NumeroDestino = 21; }
				if (DestinoActual == "Destino13" && DestinoAnterior == "Destino21") {NumeroDestino = 12; }
				
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino5") {NumeroDestino = 15; }
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino13") {NumeroDestino = 5; }
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino15") {NumeroDestino = 27; }
				if (DestinoActual == "Destino14" && DestinoAnterior == "Destino27") {NumeroDestino = 13; }
				
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino6") {NumeroDestino = 16; }
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino14") {NumeroDestino = 6; }
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino16") {NumeroDestino = 28; }
				if (DestinoActual == "Destino15" && DestinoAnterior == "Destino28") {NumeroDestino = 14; }
				
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino7") {NumeroDestino = 17; }
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino15") {NumeroDestino = 7; }
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino17") {NumeroDestino = 29; }
				if (DestinoActual == "Destino16" && DestinoAnterior == "Destino29") {NumeroDestino = 15; }
				
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino8") {NumeroDestino = 18; }
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino16") {NumeroDestino = 8; }
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino18") {NumeroDestino = 30; }
				if (DestinoActual == "Destino17" && DestinoAnterior == "Destino30") {NumeroDestino = 16; }
				
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino17") {NumeroDestino = 9; }
				if (DestinoActual == "Destino18" && DestinoAnterior == "Destino31") {NumeroDestino = 17; }
				
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino12") {NumeroDestino = 20; }
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino20") {NumeroDestino = 24; }
				if (DestinoActual == "Destino19" && DestinoAnterior == "Destino24") {NumeroDestino = 11; }
				
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino21") {NumeroDestino = 25; }
				if (DestinoActual == "Destino20" && DestinoAnterior == "Destino25") {NumeroDestino = 19; }
				
				if (DestinoActual == "Destino21" && DestinoAnterior == "Destino20") {NumeroDestino = 13; }
				if (DestinoActual == "Destino21" && DestinoAnterior == "Destino26") {NumeroDestino = 20; }
				
				if (DestinoActual == "Destino22" && DestinoAnterior == "Destino10") {NumeroDestino = 23; }
				if (DestinoActual == "Destino22" && DestinoAnterior == "Destino23") {NumeroDestino = 32; }
				
				if (DestinoActual == "Destino23" && DestinoAnterior == "Destino24") {NumeroDestino = 32; }
				if (DestinoActual == "Destino23" && DestinoAnterior == "Destino32") {NumeroDestino = 22; }
				
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino19") {NumeroDestino = 25; }
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino23") {NumeroDestino = 19; }
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino25") {NumeroDestino = 33; }
				if (DestinoActual == "Destino24" && DestinoAnterior == "Destino33") {NumeroDestino = 23; }
				
				if (DestinoActual == "Destino25" && DestinoAnterior == "Destino20") {NumeroDestino = 26; }
				if (DestinoActual == "Destino25" && DestinoAnterior == "Destino24") {NumeroDestino = 20; }
				
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino21") {NumeroDestino = 27; }
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino25") {NumeroDestino = 21; }
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino27") {NumeroDestino = 36; }
				if (DestinoActual == "Destino26" && DestinoAnterior == "Destino36") {NumeroDestino = 25; }
				
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino14") {NumeroDestino = 28; }
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino26") {NumeroDestino = 14; }
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino28") {NumeroDestino = 37; }
				if (DestinoActual == "Destino27" && DestinoAnterior == "Destino37") {NumeroDestino = 26; }
				
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino15") {NumeroDestino = 29; }
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino27") {NumeroDestino = 15; }
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino29") {NumeroDestino = 38; }
				if (DestinoActual == "Destino28" && DestinoAnterior == "Destino38") {NumeroDestino = 27; }
				
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino16") {NumeroDestino = 30; }
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino28") {NumeroDestino = 16; }
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino30") {NumeroDestino = 39; }
				if (DestinoActual == "Destino29" && DestinoAnterior == "Destino39") {NumeroDestino = 28; }
				
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino17") {NumeroDestino = 31; }
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino29") {NumeroDestino = 17; }
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino31") {NumeroDestino = 40; }
				if (DestinoActual == "Destino30" && DestinoAnterior == "Destino40") {NumeroDestino = 29; }
				
				if (DestinoActual == "Destino31" && DestinoAnterior == "Destino30") {NumeroDestino = 18; }
				if (DestinoActual == "Destino31" && DestinoAnterior == "Destino41") {NumeroDestino = 41; }
				
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino22") {NumeroDestino = 23; }
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino23") {NumeroDestino = 33; }
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino33") {NumeroDestino = 34; }
				if (DestinoActual == "Destino32" && DestinoAnterior == "Destino34") {NumeroDestino = 22; }
				
				if (DestinoActual == "Destino33" && DestinoAnterior == "Destino24") {NumeroDestino = 35; }
				if (DestinoActual == "Destino33" && DestinoAnterior == "Destino35") {NumeroDestino = 32; }
				
				if (DestinoActual == "Destino34" && DestinoAnterior == "Destino32") {NumeroDestino = 35; }
				
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino33") {NumeroDestino = 36; }
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino34") {NumeroDestino = 33; }
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino36") {NumeroDestino = 43; }
				if (DestinoActual == "Destino35" && DestinoAnterior == "Destino43") {NumeroDestino = 34; }
				
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino26") {NumeroDestino = 37; }
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino35") {NumeroDestino = 26; }
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino37") {NumeroDestino = 44; }
				if (DestinoActual == "Destino36" && DestinoAnterior == "Destino44") {NumeroDestino = 35; }
				
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino27") {NumeroDestino = 38; }
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino36") {NumeroDestino = 27; }
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino38") {NumeroDestino = 47; }
				if (DestinoActual == "Destino37" && DestinoAnterior == "Destino47") {NumeroDestino = 36; }
				
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino28") {NumeroDestino = 39; }
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino37") {NumeroDestino = 28; }
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino39") {NumeroDestino = 48; }
				if (DestinoActual == "Destino38" && DestinoAnterior == "Destino48") {NumeroDestino = 37; }
				
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino29") {NumeroDestino = 40; }
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino38") {NumeroDestino = 29; }
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino40") {NumeroDestino = 49; }
				if (DestinoActual == "Destino39" && DestinoAnterior == "Destino49") {NumeroDestino = 38; }
				
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino30") {NumeroDestino = 41; }
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino39") {NumeroDestino = 30; }
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino41") {NumeroDestino = 50; }
				if (DestinoActual == "Destino40" && DestinoAnterior == "Destino50") {NumeroDestino = 39; }
				
				if (DestinoActual == "Destino41" && DestinoAnterior == "Destino40") {NumeroDestino = 31; }
				if (DestinoActual == "Destino41" && DestinoAnterior == "Destino51") {NumeroDestino = 40; }
				
				if (DestinoActual == "Destino42" && DestinoAnterior == "Destino43") {NumeroDestino = 35; }
				if (DestinoActual == "Destino42" && DestinoAnterior == "Destino44") {NumeroDestino = 36; }
				
				if (DestinoActual == "Destino43" && DestinoAnterior == "Destino35") {NumeroDestino = 42; }
				if (DestinoActual == "Destino43" && DestinoAnterior == "Destino42") {NumeroDestino = 45; }
				
				if (DestinoActual == "Destino44" && DestinoAnterior == "Destino42") {NumeroDestino = 36; }
				if (DestinoActual == "Destino44" && DestinoAnterior == "Destino46") {NumeroDestino = 42; }
				
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino43") {NumeroDestino = 46; }
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino46") {NumeroDestino = 52; }
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino52") {NumeroDestino = 64; }
				if (DestinoActual == "Destino45" && DestinoAnterior == "Destino64") {NumeroDestino = 43; }
				
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino44") {NumeroDestino = 47; }
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino45") {NumeroDestino = 44; }
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino47") {NumeroDestino = 53; }
				if (DestinoActual == "Destino46" && DestinoAnterior == "Destino53") {NumeroDestino = 45; }
				
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino37") {NumeroDestino = 48; }
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino46") {NumeroDestino = 37; }
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino48") {NumeroDestino = 54; }
				if (DestinoActual == "Destino47" && DestinoAnterior == "Destino54") {NumeroDestino = 46; }
				
				if (DestinoActual == "Destino48" && DestinoAnterior == "Destino38") {NumeroDestino = 49; }
				if (DestinoActual == "Destino48" && DestinoAnterior == "Destino47") {NumeroDestino = 38; }
				
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino39") {NumeroDestino = 50; }
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino48") {NumeroDestino = 39; }
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino50") {NumeroDestino = 55; }
				if (DestinoActual == "Destino49" && DestinoAnterior == "Destino55") {NumeroDestino = 48; }
				
				if (DestinoActual == "Destino50" && DestinoAnterior == "Destino40") {NumeroDestino = 51; }
				if (DestinoActual == "Destino50" && DestinoAnterior == "Destino49") {NumeroDestino = 40; }
				
				if (DestinoActual == "Destino51" && DestinoAnterior == "Destino50") {NumeroDestino = 41; }
				if (DestinoActual == "Destino51" && DestinoAnterior == "Destino56") {NumeroDestino = 50; }
				
				if (DestinoActual == "Destino52" && DestinoAnterior == "Destino45") {NumeroDestino = 53; }
				if (DestinoActual == "Destino52" && DestinoAnterior == "Destino53") {NumeroDestino = 57; }
				
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino46") {NumeroDestino = 54; }
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino52") {NumeroDestino = 46; }
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino54") {NumeroDestino = 58; }
				if (DestinoActual == "Destino53" && DestinoAnterior == "Destino58") {NumeroDestino = 52; }
				
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino47") {NumeroDestino = 55; }
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino53") {NumeroDestino = 47; }
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino55") {NumeroDestino = 59; }
				if (DestinoActual == "Destino54" && DestinoAnterior == "Destino59") {NumeroDestino = 53; }
				
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino49") {NumeroDestino = 56; }
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino54") {NumeroDestino = 49; }
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino56") {NumeroDestino = 60; }
				if (DestinoActual == "Destino55" && DestinoAnterior == "Destino60") {NumeroDestino = 54; }
				
				if (DestinoActual == "Destino56" && DestinoAnterior == "Destino55") {NumeroDestino = 51; }
				if (DestinoActual == "Destino56" && DestinoAnterior == "Destino61") {NumeroDestino = 55; }
				
				if (DestinoActual == "Destino57" && DestinoAnterior == "Destino52") {NumeroDestino = 58; }
				
				if (DestinoActual == "Destino58" && DestinoAnterior == "Destino53") {NumeroDestino = 59; }
				if (DestinoActual == "Destino58" && DestinoAnterior == "Destino57") {NumeroDestino = 53; }
				if (DestinoActual == "Destino58" && DestinoAnterior == "Destino59") {NumeroDestino = 62; }
				if (DestinoActual == "Destino58" && DestinoAnterior == "Destino62") {NumeroDestino = 67; }
				
				if (DestinoActual == "Destino59" && DestinoAnterior == "Destino54") {NumeroDestino = 60; }
				if (DestinoActual == "Destino59" && DestinoAnterior == "Destino58") {NumeroDestino = 54; }
				
				if (DestinoActual == "Destino60" && DestinoAnterior == "Destino55") {NumeroDestino = 61; }
				if (DestinoActual == "Destino60" && DestinoAnterior == "Destino59") {NumeroDestino = 55; }
				
				if (DestinoActual == "Destino61" && DestinoAnterior == "Destino60") {NumeroDestino = 56; }

				this.gameObject.GetComponent<NavMeshAgent>().acceleration = Aceleracao;
				EscolhaDestino.SetActive(false);
				DestinoAnterior = DestinoActual;
			}
		}
			agente = gameObject.GetComponent<NavMeshAgent>();
			agente.SetDestination (destino[NumeroDestino].position);
	}

		void OnTriggerEnter(Collider collision) {

			if (DestinoActual != collision.gameObject.name) {
				this.gameObject.GetComponent<NavMeshAgent> ().acceleration = 0;
				this.gameObject.GetComponent<NavMeshAgent> ().Stop ();
				posicaoAtualX = this.gameObject.transform.position.x;
				posicaoAtualY = this.gameObject.transform.position.y;
				posicaoAtualZ = this.gameObject.transform.position.z;
				EscolhaDestino.SetActive (true);
				DestinoActual = collision.gameObject.name;
			}
		}
}
