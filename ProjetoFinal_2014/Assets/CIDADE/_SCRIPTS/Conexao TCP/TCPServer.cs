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
	string ip_address;// = "127.0.0.1";
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
		// IP do dispositivo em que o jogo esta a correr
		IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
		// string com o endereco IP do dispositivo
		ip_address = "" + IPHost.AddressList[0].ToString();
		//	ip_address = "localhost";
		// Criacao do Socket
		IPAddress ip_addy = IPAddress.Parse (ip_address);
		// Criacao de um listener, para poder aceitar pedidos de ligacao
		tcp_listener = new TcpListener (ip_addy, port);
		// Thread que estara a escuta por novos clientes
		listen_thread = new Thread (new ThreadStart (ListenForClients));
		listen_thread.Start ();
		listen_thread.IsBackground = true;
		Debug.Log ("Espera Clientes .....");
		// variavel para controlar noutros scripts a existencia da comunicacao
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
		// Ativar o TCP Listener para ligacao de clientes
		this.tcp_listener.Start ();
		while (isTrue == true) {
			//Espera ate um cliente se conectar com o servidor
			TcpClient client = this.tcp_listener.AcceptTcpClient ();
			//Cria uma Thread para estar a escuta de uma mensagem do cliente
			clientThread = new Thread (new ParameterizedThreadStart (HandleClientComm));
			clientThread.Start (client);
			// Variavel que controla as ligacoes, devido ao MatLab efetuar 2 ligacoes
			// umma no menu principal, e outro numa janela posterior
			numberConnection ++;
			if (numberConnection == 2) {
				connect = true;
				numberConnection = 0;
				Debug.Log("Conexao 2/2.. Pode Jogar");
				break;
			} else {
				Debug.Log ("Conexao 1/2.. ");
			}
		}
		
	}
	
	private void HandleClientComm (object client)
	{	tcp_client = (TcpClient)client; // variavel "tcp_client" recebe o objeto passado por parametro "client"
		NetworkStream client_stream = tcp_client.GetStream (); // Criacao de uma Stream, para ler a mensagem
		byte[] message = new byte[4096];// criacao de um array de bytes para ler a mensagem a receber
		int bytes_read; //Controlar o numero de bytes lidos na mensagem recebida

		while (isTrue == true) {
			bytes_read = 0;
			bytes_read = client_stream.Read (message, 0, 4096); //Bloqueia ate que cliente envie uma mensagem
			//Caso ocorra um errro no Socket, termina a ligacao com o client
			if (bytes_read == 0) {
				Debug.Log ("Disconectado");
				connect = false;
				tcp_client.Close ();
				break;
			}
			ASCIIEncoding encoder = new ASCIIEncoding (); // Descodificacao ASCII da mensagem recebida
			Debug.Log (encoder.GetString (message, 0, bytes_read));
			comand = encoder.GetString (message, 0, bytes_read); // string que guardara com mensagem recebida
			RecebeuComando = true;
		}

	}
	
	void SendMessageGetFreq(TcpClient client,string message)
	{
		NetworkStream stream = client.GetStream(); // criacao de uma stream para envio de mensagem
		StreamWriter writer = new StreamWriter(stream); // Criacao de uma stream de escrita
		writer.WriteLine(message); // Enviar mensagem
		writer.Flush(); // Libertar o buffer
	}
	
	void OnApplicationQuit ()
	{
		try {
		connect = false;
		// Terminar ligacao caso esta seja abortada
			Debug.Log ("Close Streams");

			tcp_client.Close ();
			Debug.Log ("Conexao TCP terminada");
			connect = false;
			Debug.Log ("abort Threads");
			clientThread.Abort ();
		//	clientThread = null;
			listen_thread.Abort ();
			tcp_listener.Stop ();
			Debug.Log ("clientThread: " + clientThread.IsAlive); 
			Debug.Log ("listen_thread: " + clientThread.IsAlive); 

			tcp_client.Close ();

			//Debug.Log (clientThread.IsAlive); //true (must be false)
		} catch (Exception e) {
			Debug.Log (e.Message);
		}
	}
}

