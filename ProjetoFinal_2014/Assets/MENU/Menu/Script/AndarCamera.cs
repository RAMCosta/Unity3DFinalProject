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

		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
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
						Camera3.transform.Translate (new Vector3 (0, -1 * Time.deltaTime, 30 * Time.deltaTime));
				}
				if (Camera3.transform.position.y < -88 && Camera3.activeSelf == true) {
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
}
