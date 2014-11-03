using UnityEngine;
using System.Collections;

public class MoedaTrigger : MonoBehaviour {
	
	public static bool Camera2Chegou = false;

	void OnTriggerEnter (Collider collision)
	{
		this.gameObject.SetActive (false);
		Camera2Chegou = true;
	}
}
