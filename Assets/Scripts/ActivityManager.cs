using UnityEngine;
using System.Collections;

public class ActivityManager : MonoBehaviour {

    private static Animator animator;
    private static GameObject player;
    private static GameObject messageBox;
    private static MessageManager messageMgr;
    private static PlayerAttribute playerAttr;

    public enum E_ActivityType
    {
        eTraining = 0,
        eSleeping = 1,
        eWorking = 2
    }

    public static void ActivityInit(E_ActivityType type)
    {
        if (Activity.isEngage == true)
        {
            messageMgr.SendMessageToBox("活动正在进行");
            return;
        }
        switch (type)
        {
            case E_ActivityType.eTraining:
                TrainingActivity training;
                //总计时多0.5秒便于触发最后一次trig
                training = new TrainingActivity(10.5f, 1);
                training.ActivityStart();
                break;
            case E_ActivityType.eSleeping:
                SleepingActivity sleeping;
                //总计时多0.5秒便于触发最后一次trig
                sleeping = new SleepingActivity(10.5f, 1);
                sleeping.ActivityStart();
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        if (player)
        {
            animator = player.GetComponent<Animator>();
            playerAttr = player.GetComponent<PlayerAttribute>();
        }
        messageBox = GameObject.Find("MessageBox");
        if (messageBox)
        {
            messageMgr = messageBox.GetComponent<MessageManager>();
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

}
