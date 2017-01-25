using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Text;

public class FileReadTest : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Read()
    {
        try
        {
            FileStream aFile = new FileStream(@"D:\Unity3D\Project_G\Assets\Config\NPCConfigInfo.txt", FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            string strLine = sr.ReadLine();
            while (strLine != null)
            {
                Debug.Log(strLine);
                Console.WriteLine(strLine);
                strLine = sr.ReadLine();
            }
            sr.Close();
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
            return;
        }
    }

}
