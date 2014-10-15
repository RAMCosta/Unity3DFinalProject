using UnityEngine;
using System.Collections;

public class VerficarFramesActual : MonoBehaviour {
	float timeA;
	public int fps;
	public int lastFPS;
	public GUIStyle textStyle;
	// Use this for initialization
	void Start () {
		timeA = Time.timeSinceLevelLoad;
		DontDestroyOnLoad (this);
		Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Time.timeSinceLevelLoad+" "+timeA);
		if(Time.timeSinceLevelLoad  - timeA <= 1)
		{
			fps++;
		}
		else
		{
			lastFPS = fps + 1;
			timeA = Time.timeSinceLevelLoad;
			fps = 0;
		}
	}
	void OnGUI()
	{
		GUI.TextArea(new Rect (0,0,120,25), ""+lastFPS,textStyle);
		//GUI.Label(new Rect( 450,5, 30,30),""+lastFPS,textStyle);
	}
}
