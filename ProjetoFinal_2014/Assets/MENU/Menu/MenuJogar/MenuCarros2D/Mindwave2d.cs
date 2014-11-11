using UnityEngine;
using System.Collections;

public class Mindwave2d : MonoBehaviour
{

		public GUIText Nota;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
		void OnMouseEnter ()
		{
				this.guiText.color = Color.yellow;
		}
	
		void OnMouseExit ()
		{
				this.guiText.color = Color.white;
		}
	
		void OnMouseDown ()
		{
				if (Application.platform == RuntimePlatform.Android) {
					Nota.gameObject.SetActive(true);
				} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
					Nota.gameObject.SetActive(true);
				} else {
						Application.LoadLevel ("Carros2D_Mindwave");
				}
		}
}
