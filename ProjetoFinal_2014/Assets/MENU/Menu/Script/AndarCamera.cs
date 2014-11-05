using UnityEngine;
using System.Collections;

public class AndarCamera : MonoBehaviour
{

		// Use this for initialization
		bool AteHelicoptero = true;
		public GameObject Camera1;
		public GameObject Camera2;
		public GameObject Camera3;
		public GameObject Camera4;
		public GameObject NomeJogo;
		public static int aux = 0;
		public GameObject Anel;
		public GameObject SDir1;
		public GameObject SDir2;
		public GameObject SEsq1;
		public GameObject SEsq2;
		public GameObject SFrn1;
		public GameObject SFrn2;

		float time;

		void Start ()
		{
		Camera2.SetActive (false);
		Camera3.SetActive (false);
		Camera4.SetActive (false);
		NomeJogo.SetActive(false);
		Anel.SetActive(false);
		}
	
		// Update is called once per frame
		void Update ()
		{
		time += Time.deltaTime;
		EstimulosSom (time);



		if (Input.anyKey) {
			aux = 0;
			AteHelicoptero=false;
			Application.LoadLevel("MainMenu");		
		}
				if (Camera1.transform.position.z < -125 && AteHelicoptero == true) {
						Camera1.transform.Translate (new Vector3 (0, -1 * Time.deltaTime, 30 * Time.deltaTime));
				} else if (AteHelicoptero == true && MoedaTrigger.Camera2Chegou == false && aux == 0) {
						Camera1.SetActive (false);
						Camera2.SetActive (true);
				} else if (MoedaTrigger.Camera2Chegou == true && aux == 0) {
						Camera2.SetActive (false);
						Camera3.SetActive (true);
						Anel.SetActive(true);
						Camera3.transform.Translate (new Vector3 (0, -1 * Time.deltaTime, 30 * Time.deltaTime));
				}
				if (Camera3.transform.position.y < -98 && Camera3.activeSelf == true) {
						MoedaTrigger.Camera2Chegou = false;
						aux = 1;
						Camera4.SetActive (true);
						Camera3.SetActive (false);
				}
				if (Camera4.activeSelf == true && NavTaxi.chegouTaxi2 == false) {
						Camera4.transform.Rotate (new Vector3 (-7 * Time.deltaTime, 0, 0));
				}
				
				if (NavTaxi.chegouTaxi2 == true) {
						NomeJogo.SetActive(true);
				}
				
		}

	void EstimulosSom(float time){
		if (time>10) {
			SEsq1.SetActive(true);
		}
		if (time>10.2) {
			SEsq1.SetActive(false);
			SEsq2.SetActive(true);
		}
		if (time>10.4 ) {
			SEsq2.SetActive(false);
		}
		if (time>12.3) {
			SDir1.SetActive(true);
		}
		if (time>12.5 ) {
			SDir1.SetActive(false);
			SDir2.SetActive(true);
		}
		if (time>12.7 ) {
			SDir2.SetActive(false);
		}
		if (time>14.6) {
			SFrn1.SetActive(true);
		}
		if (time>14.8 ) {
			SFrn1.SetActive(false);
			SFrn2.SetActive(true);
		}
		if (time>15 ) {
			SFrn2.SetActive(false);
		}
		if (time>16.8) {
			SDir1.SetActive(true);
			SEsq1.SetActive(true);
			SFrn1.SetActive(true);
		}
		if (time>17 ) {
			SDir1.SetActive(false);
			SEsq1.SetActive(false);
			SFrn1.SetActive(false);
			SDir2.SetActive(true);
			SEsq2.SetActive(true);
			SFrn2.SetActive(true);
		}
		if (time>17.2) {
			SDir2.SetActive(false);
			SEsq2.SetActive(false);
			SFrn2.SetActive(false);
		}
	}
}
