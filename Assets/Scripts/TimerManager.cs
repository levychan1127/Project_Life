using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    private Timer[] tempList;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //If u have many timer 
        //u also can serval frame call one time to save some performance, but the deltaTime u should calculate youself
        //like :(u should define lastTime youself-- float)

        /*
		if(Time.frameCount%5 == 0)
		{
			delta = Time.time - lastTime;
			test.Update(Time.deltaTime);
			lastTime = Time.time;
		}
		*/
        if (Timer.timerList.Count > 0)
        {
            tempList = new Timer[Timer.timerList.Count];
            Timer.timerList.CopyTo(tempList);
            for (int i = 0; i < tempList.Length; i++)
            {
                tempList[i].Update(Time.deltaTime);
            }
        }
    }

    //Some time u may need this to avoid conflict when re-init something , just a tip .
    void OnDestory()
    {

    }

}
