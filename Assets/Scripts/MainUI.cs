using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MainUI : MonoBehaviour {

    private GameObject player;
    private PlayerAttribute playerAttr;
    // Use this for initialization
    void Start () {
        //LoadClick();
        player = GameObject.Find("Player");
        if (player)
        {
            playerAttr = player.GetComponent<PlayerAttribute>();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LevelUpClick()
    {
        playerAttr.LevelUpCheck();
    }

    public void TrainingClick()
    {
        ActivityManager.ActivityInit(ActivityManager.E_ActivityType.eTraining);
        //GameObject button = gameObject.transform.Find("Training").gameObject;
    }

    public void SaveClick()
    {
        GameDataManager gameDataManager = gameObject.AddComponent<GameDataManager>();
        gameDataManager.Save();
    }

    public void LoadClick()
    {
        GameDataManager gameDataManager = gameObject.AddComponent<GameDataManager>();
        gameDataManager.Load();
        playerAttr.level = gameDataManager.gameData.PlayerLevel;
        playerAttr.RefreshAttribute();
    }

    public void SleepingClick()
    {
        ActivityManager.ActivityInit(ActivityManager.E_ActivityType.eSleeping);
    }

    public void OpenAttributeUI()
    {
        UIManager.ChangeUI(gameObject, "AttributeUI");
    }
}
