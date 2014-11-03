using UnityEngine;
using System.Collections;

public class Creditos : MonoBehaviour
{
		// Use this for initialization
		public GameObject FireActive;

		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.anyKey) {
						Application.LoadLevel ("MainMenu");		
				}
				if (this.gameObject.transform.position.y < 87) {
						this.transform.Translate (new Vector3 (0, 5 * Time.deltaTime, 0));
				} else {
						FireActive.SetActive (true);
				}
		}
}
