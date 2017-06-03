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
		manager = new SocketManager(new Uri("ws://localhost:4321/socket.io/"));
		Socket root = manager.Socket;
		manager.Socket.Once ("connect", OnSocketConnect);
		manager.Socket.On("location update", OnLocationUpdate);
	}

	public void OnSocketConnect(Socket socket, Packet packet, params object[] args) {
		Debug.Log ("Connect!");
	}

	public void OnLocationUpdate(Socket socket, Packet packet, params object[] args) {
		this.gameObject.GetComponent<GUIText>().text = "GET!!!";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
