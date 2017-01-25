using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager:MonoBehaviour
{
    //通用的UI切换方法
    public static GameObject ChangeUI(GameObject gameObject, string targetUIName)
    {
        GameObject root = GameObject.Find("Canvas");
        if (root != null)
        {
            GameObject targetUI = root.transform.Find(targetUIName).gameObject;
            if (targetUI != null)
            {
                gameObject.SetActive(false);
                targetUI.SetActive(true);
                return targetUI;
            }
        }
        return null;
    }
    

    /*public static void ChangeUI(string srcUIName,string desUIName)
    {
        GameObject root = GameObject.Find("Canvas");
        if (root != null)
        {
            GameObject srcUI = root.transform.Find(srcUIName).gameObject;
            GameObject desUI = Resources.Load("AttributeUI")as GameObject;
            Destroy(srcUI);
            desUI = Instantiate(desUI);
            desUI.transform.SetParent(root.transform);
        }
    }
    */

}