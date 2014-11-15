using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System;

public class TCPServer : MonoBehaviour {

	
	public static string comand = "a";
	string ip_address; //= "127.0.0.1";
	int port = 10100;
	Thread listen_thread;
	TcpListener tcp_listener;
	Thread clientThread;
	TcpClient tcp_client;
	bool isTrue = true;
	public GUIStyle LetraDisconectado;
	public GUIStyle LetraConectado;
	public static bool connect = false;
	public GUIText Conectado;
	int numberConnection = 0;
	
	public static bool EnviarComandoMatLabHeli = false;
	public static string mensagemMatLab;
	public static bool RecebeuComando = false;
	
	void Start ()
	{
		
		IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
		
		ip_address = "" + IPHost.AddressList[0].ToString();
		
		IPAddress ip_addy = IPAddress.Parse (ip_address);
		tcp_listener = new TcpListener (ip_addy, port);
		listen_thread = new Thread (new ThreadStart (ListenForClients));
		listen_thread.Start ();
		listen_thread.IsBackground = true;
		Debug.Log ("Espera Clientes .....");
		connect = false;
	}
	
	void Update(){
		if (connect == false) {
			Conectado.guiText.color= Color.red;
			Conectado.guiText.text = "Esperando Clientes...  [" + ip_address + "]";
		} else {
			Conectado.guiText.color= Color.green;
			Conectado.guiText.text = "Conectado";
		}
		
		if (EnviarComandoMatLabHeli == true) {
			SendMessageGetFreq(tcp_client, mensagemMatLab);
			EnviarComandoMatLabHeli = false;

		}
		if (DestinosTCPAnim.novoCmdRecebido == true) {
			DestinosTCPAnim.novoCmdRecebido = false;
			RecebeuComando = false;
			Debug.Log ("Heli - " + DestinosTCPAnim.novoCmdRecebido);
			Debug.Log ("TCP - " + RecebeuComando);
		}
		
	}
	
	private void ListenForClients ()
	{
		this.tcp_listener.Start ();
		
		while (isTrue == true) {
			//blocks until a client has connected to the server
			TcpClient client = this.tcp_listener.AcceptTcpClient ();
			
			//create a thread to handle communication 
			//with connected client
			clientThread = new Thread (new ParameterizedThreadStart (HandleClientComm));
			clientThread.Start (client);
			
			
			numberConnection ++;
			if (numberConnection == 2) {
				connect = true;
				numberConnection = 0;
				Debug.Log("Conexao 2/2.. Pode Jogar");
			} else {
				Debug.Log ("Conexao 1/2.. ");
			}
		}
		
	}
	
	private void HandleClientComm (object client)
	{
		tcp_client = (TcpClient)client;
		NetworkStream client_stream = tcp_client.GetStream ();
		
		
		byte[] message = new byte[4096];
		int bytes_read;
		
		while (isTrue == true) {
			bytes_read = 0;
			//blocks until a client sends a message
			bytes_read = client_stream.Read (message, 0, 4096);
			//Debug.Log(message);
			//a socket error has occured
			if (bytes_read == 0) {
				//client has disconnected
				Debug.Log ("Disconectado");
				connect = false;
				tcp_client.Close ();
				break;
			}
			
			ASCIIEncoding encoder = new ASCIIEncoding ();
			Debug.Log (encoder.GetString (message, 0, bytes_read));
			comand = encoder.GetString (message, 0, bytes_read);
			RecebeuComando = true;
			
			
		}
		
		if (isTrue == false) {
			tcp_client.Close ();
			Debug.Log ("Conexao TCP terminada");
			connect = false;
			clientThread.Abort ();
			listen_thread.Abort ();
			tcp_listener.Stop ();
			Debug.Log ("clientThread: " + clientThread.IsAlive); 
			Debug.Log ("listen_thread: " + clientThread.IsAlive); 
		}
	}
	
	void SendMessageGetFreq(TcpClient client,string message)
	{
		//	byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);
		NetworkStream stream = client.GetStream();
		StreamWriter writer = new StreamWriter(stream);
		writer.WriteLine(message);
		writer.Flush();
	}
	
	void OnApplicationQuit ()
	{
		connect = false;
		try {
			tcp_client.Close ();
			isTrue = false;
		} catch (Exception e) {
			Debug.Log (e.Message);
		}
		
		// You must close the tcp listener
		try {
			tcp_listener.Stop ();
			isTrue = false;
		} catch (Exception e) {
			Debug.Log (e.Message);
		}
		Debug.Log (clientThread.IsAlive); //true (must be false)
	}
}

