using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

public class ClienteTCP : MonoBehaviour {

	
	Thread SocketListen;
	int comando;
	TcpClient client;
	NetworkStream stm;
	byte[] receivebytes = new byte[1024];
	//private float velocidade= 0.05f;
	long WaitingTime = 1000;
	long milliseconds;
	
	void Start () {
		IPAddress ipad = IPAddress.Parse("127.0.0.1");
		client = new TcpClient();
		client.Connect (ipad, 10100);
		stm = client.GetStream();
		milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
		WaitingTime = milliseconds + WaitingTime;
		SocketListen = new Thread (UpdateCommand);
		SocketListen.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		/*int bytesreceived = stm.Read (receivebytes, 0, 1024);
		//char[] chars = new char[bytesreceived];
		string str = Encoding.ASCII.GetString (receivebytes, 0, bytesreceived);
		Debug.Log (str);*/
	}
	
	void UpdateCommand(){
		while(true){
			Debug.Log("Espera Comando ......");
			
			int bytesreceived = stm.Read (receivebytes, 0, 1024);
			//char[] chars = new char[bytesreceived];
			string str = Encoding.ASCII.GetString (receivebytes, 0, bytesreceived);
			Debug.Log (str);
		}
	}
}
