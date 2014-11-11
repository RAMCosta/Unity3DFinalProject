using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;

public class tcpClient : MonoBehaviour {

	// Use this for initialization
	float cordY  = 0;
	int value;
	TcpClient client;
	NetworkStream stm;
	byte[] receivebytes = new byte[1024];
	//private float velocidade= 0.05f;
	int atencaoAGORA = 0;
	long WaitingTime = 1000;
	long milliseconds;

	void Start () {
		IPAddress ipad = IPAddress.Parse("127.0.0.1");
		client = new TcpClient();
		client.Connect (ipad, 10000);
		stm = client.GetStream();
		milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
		WaitingTime = milliseconds + WaitingTime;
	}
	
	// Update is called once per frame
	void Update () {
		int bytesreceived = stm.Read (receivebytes, 0, 1024);
		//char[] chars = new char[bytesreceived];
		string str = Encoding.ASCII.GetString (receivebytes, 0, bytesreceived);

		int.TryParse (str,out value);
		//transform.Translate (Time.deltaTime * value, 0, Time.deltaTime );
		if (value != 0) { 
			Debug.Log (value);
			atencaoAGORA = value;
			cordY = transform.position.y; // cordenada actual do Carro
			//  cordY = cordY + value;   // cordenada para onde ira o Carro
			cordY = (float)(((value*5.557126)/100) -2.778563);
			SetTransformY(cordY);
		}
		milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
		if (milliseconds > WaitingTime) {
			milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
			WaitingTime = 1000;
			WaitingTime = milliseconds + WaitingTime;
			GameObject.Find("Atencao").guiText.text = "Atençao : " + atencaoAGORA + "/100";
		}

	}
	void SetTransformY(float Cordenada){
		//transform.position = new Vector3(transform.position.x, Cordenada, transform.position.z);	
		//Debug.Log (value);
		//((value*5..557126)/100) - -2.778563
		//if (value < 60) {
		this.transform.position = new Vector2 (-7, Cordenada);
		/*} else {
			this.transform.Translate(Vector3.forward * Time.deltaTime);
			this.transform.position = new Vector2 (-7, transform.position.y + velocidade);
		}*/
	}

	/*void BarraAtencao(){
		//GUI.Box(new Rect(10,10, Screen.width / 2 / (100 / atencaoAGORA), 20), atencaoAGORA + "/" + 100);
		GUI.Label(new Rect (10,4,100,100), atencaoAGORA + "/100");
		}*/
	}
