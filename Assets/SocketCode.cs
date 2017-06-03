using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.SocketIO;

public class SocketCode : MonoBehaviour {
	SocketManager manager;
	// Use this for initialization
	void Start () {
		manager = new SocketManager(new Uri("http://localhost:4321/socket.io/"));
		manager.Socket.Once ("connect", OnConnect);
		manager.Socket.On("update location", OnMessage);
	}

	void OnConnect(Socket socket, Packet packet, params object[] args) {
		Debug.Log ("Connect!");
	}

	void OnMessage(Socket socket, Packet packet, params object[] args) {
		Debug.Log(string.Format("Message from {0}: {1}", args[0], args[1]));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
