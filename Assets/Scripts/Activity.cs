using UnityEngine;
using System.Collections;

public class Activity{

    public GameObject player;
    public PlayerAttribute playerAttr;
    public GameObject messageBox;
    public MessageManager messageMgr;
    public Animator animator;

    protected static bool _isEngage;
    public static bool isEngage
    {
        get
        {
            return _isEngage;
        }
    }
    protected float timeLimit;
    protected float interval;
    protected Timer activityTimer;
    protected Timer intervalTimer;

    public Activity(float activitySec,float intervalSec)
    {
        timeLimit = activitySec;
        interval = intervalSec;
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

    //活动开始时执行的方法
    public virtual bool ActivityStart()
    {
        _isEngage = true;
        activityTimer = new Timer(timeLimit);
        intervalTimer = new Timer(interval);
        activityTimer.trig += ActivityEnd;
        intervalTimer.trig += ActivityFunc;
        activityTimer.Start();
        intervalTimer.Start();
        return true;
    }

    //每次间隔执行的方法
    public virtual void ActivityFunc()
    {
        intervalTimer = new Timer(interval);
        intervalTimer.trig += ActivityFunc;
        intervalTimer.Start();
    }

    //活动结束时执行的方法
    public virtual void ActivityEnd()
    {
        _isEngage = false;
        intervalTimer.Stop();
    }

}
public class TrainingActivity : Activity
{
    //对父类初始化
    public TrainingActivity(float activitySec, float intervalSec) : base(activitySec, intervalSec) { }
    
    //活动开始时执行的方法
    public override bool ActivityStart()
    {
        int activityCost = 20;
        if (playerAttr.energy >= activityCost)
        {
            playerAttr.IncreaseEnergy(-activityCost);
            _isEngage = true;
            intervalTimer = new Timer(interval);
            activityTimer = new Timer(timeLimit);
            intervalTimer.trig += ActivityFunc;
            activityTimer.trig += ActivityEnd;            
            intervalTimer.Start();
            activityTimer.Start();           
            return true;
        }
        messageMgr.SendMessageToBox("体力不足！");
        return false;
    }

    //每次间隔执行的方法
    public override void ActivityFunc()
    {

        //每次具体执行的事
        animator.SetTrigger("fight");
        long increaseExp = 1;
        messageMgr.SendMessageToBox("获得经验:" + increaseExp);
        playerAttr.IncreaseExp(increaseExp);

        //设置下一轮计时器
        intervalTimer = new Timer(interval);
        intervalTimer.trig += ActivityFunc;
        intervalTimer.Start();
    }

    //活动结束时执行的方法
    public override void ActivityEnd()
    {
        _isEngage = false;
        intervalTimer.Stop();
    }
}

public class SleepingActivity : Activity
{
    //对父类初始化
    public SleepingActivity(float activitySec, float intervalSec) : base(activitySec, intervalSec) { }
    
    //活动开始时执行的方法
    public override bool ActivityStart()
    {
        if (playerAttr.energy < playerAttr.maxEnergy)
        {
            _isEngage = true;
            activityTimer = new Timer(timeLimit);
            intervalTimer = new Timer(interval);
            activityTimer.trig += ActivityEnd;
            intervalTimer.trig += ActivityFunc;
            activityTimer.Start();
            intervalTimer.Start();
            return true;
        }
        messageMgr.SendMessageToBox("体力已达上限！");
        return false;
    }

    //每次间隔执行的方法
    public override void ActivityFunc()
    {
        //每次具体执行的事
        int increaseEnergy = 1;
        playerAttr.IncreaseEnergy(increaseEnergy);
        messageMgr.SendMessageToBox("恢复体力:" + increaseEnergy);

        //设置下一轮计时器
        intervalTimer = new Timer(interval);
        intervalTimer.trig += ActivityFunc;
        intervalTimer.Start();
    }

    //活动结束时执行的方法
    public override void ActivityEnd()
    {
        _isEngage = false;
        intervalTimer.Stop();
    }
}
