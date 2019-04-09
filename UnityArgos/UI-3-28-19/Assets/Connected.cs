using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Connected : MonoBehaviour {
    public Sprite wifi_white;
    public Sprite wifi_light_blue;
    NetworkClient client;
    

    // Use this for initialization
    void Start()
    {
    }


    public void ConnectToServer()
    {
        ConnectionConfig config = new ConnectionConfig();
        config.AddChannel(QosType.ReliableSequenced);
        config.AddChannel(QosType.UnreliableSequenced);
        //config.PacketSize = 500;
        client = new NetworkClient();
        client.Configure(config, 1000);
        client.RegisterHandler(MsgType.Connect, OnConnected);
        //client.RegisterHandler(MsgType.Disconnect, OnDisconnected);
        client.RegisterHandler(MsgType.Error, OnError);

        client.Connect("127.0.0.1", 3000);
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("CONNECTION IS GOOD");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = wifi_light_blue;
    }

    public void OnError(NetworkMessage netMsg)
    {
        Debug.Log("CONNECTION IS BAD!!!");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = wifi_white;
    }

    // Update is called once per frame
    void Update () {
        /*
        if (Input.GetKeyDown (KeyCode.Tab)) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wifi_white;
        }
        */
       // ConnectToServer();
    }
}
