using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MessageManager : MonoBehaviour {

    public Text messageText_0;
    public Text messageText_1;
    public Text messageText_2;
    public Text messageText_3;
    public Text messageText_4;
    public Text messageText_5;
    private Text[] messageText = new Text[6];
    private Queue<string> messageList;
    public Vector3 basePosition;
    public float height;
    private GameObject root;

    public void SendMessageToBox(string str)
    {
        int n = messageList.Count;
        if (n < 6)
        {
            messageText[n].text = str;
            messageList.Enqueue(str);
        }
        else
        {
            messageList.Dequeue();
            for(int i = 0; i < 5; i++)
            {
                messageText[i].text = messageText[i+1].text;
            }
            messageText[n-1].text = str;
            messageList.Enqueue(str);
        }
    }



	// Use this for initialization
	void Start () {
        root = GameObject.Find("MessageBox");
        messageList = new Queue<string>();
        messageText[0] = messageText_0;
        messageText[1] = messageText_1;
        messageText[2] = messageText_2;
        messageText[3] = messageText_3;
        messageText[4] = messageText_4;
        messageText[5] = messageText_5;
        for(int i = 0; i < 6; i++)
        {
            messageText[i].text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
