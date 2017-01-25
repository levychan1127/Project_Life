using UnityEngine;
using System;
using System.Collections;

public class PlayerAttribute : MonoBehaviour{

    private enum playerAttribute
    {

    };
    //角色名
    private string _playerName;
    //等级
    private int _level;
    //攻击力
    private long _atk;
    //血量
    private long _hp;
    //经验
    private long _exp;
    //升级经验上限
    private long[] expLimit = new long[10];
    //年龄
    private int _age;
    //年龄月份
    private float _ageTime;
    //年龄增长计时器使用
    private float ageTimeCount;
    //体力
    private int _energy;
    //体力恢复计时器使用
    private float energyTimeCount;
    //体力上限
    private int _maxEnergy;
    //金钱
    private long _money;


    public string playerName
    {
        get
        {
            return _playerName;
        }
        set
        {
            _playerName = value;
        }
    }
    public int level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }
    public long atk
    {
        get
        {
            return _atk;
        }
        set
        {
            _atk = value;
        }
    }
    public long hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    public long exp
    {
        get
        {
            return _exp;
        }
        set
        {
            _exp = value;
        }
    }
    public int age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }
    public float ageTime
    {
        get
        {
            return _ageTime;
        }
        set
        {
            _ageTime = value;
        }
    }
    public int energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
        }
    }
    public int maxEnergy
    {
        get
        {
            return _maxEnergy;
        }
        set
        {
            _maxEnergy = value;
        }
    }
    public long money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }



    void Start()
    {
        ageTimeCount = 0;
        energyTimeCount = 0;
        _age = 6;
        _ageTime = 0;
        _playerName = "次西瓜的喵";
        _level = 1;
        _atk = _level * 10;
        _hp = _level * 100;
        _exp = 0;
        long[] expInit = {
            5,
            10,
            15,
            20,
            25,
            50,
            60,
            70,
            80,
            100
        };
        expLimit = expInit;
        _maxEnergy = 100;
        _energy = _maxEnergy;

    }

    void Update()
    {
        //超过8/3小时算半月
        if(ageTimeCount > 8*60*60/3)
        {
            IncreaseAgeTime(0.5f);
            ageTimeCount = 0;
        }
        else
        {
            if (Activity.isEngage == false)
            {
                ageTimeCount += Time.deltaTime;
              
                if (_energy < _maxEnergy)
                {
                    //每8分钟恢复一点体力，8小时恢复总计60点体力
                    if (energyTimeCount > 8 * 60 * 60 / 60)
                    {
                        //恢复一点体力
                        energyTimeCount = 0;
                    }
                    else
                    {
                        energyTimeCount += Time.deltaTime;
                    } 
                }
                else
                {
                    //重置体力恢复计时器
                    energyTimeCount = 0;
                }
            }
        }       
    }

    //增加年龄月份，参数为月份
    public void IncreaseAgeTime(float month)
    {
        _ageTime += month;
        if(_ageTime > 12)
        {
            int increaseAge = (int)Math.Floor(_ageTime / 12);
            _ageTime -= increaseAge*12;
            _age += increaseAge;
        }
        return;
    }

    //加体力，可加可减
    public bool IncreaseEnergy(int energy)
    {
        if (energy > 0)
        {
            if (_energy < _maxEnergy)
            {
                _energy += energy;
                if (_energy > _maxEnergy)
                {
                    _energy = _maxEnergy;
                    return true;
                }
                return true;
            }
        }
        else
        {
            if (_energy + energy > 0)
            {
                _energy += energy;
                return true;
            } 
        }  
        return false;
    }

    public void RefreshAttribute()
    {
        _atk = _level * 10;
        _hp = _level * 100;
    }

    public void IncreaseExp(long exp)
    {
        _exp += exp;
        LevelUpCheck();
    }

    public void LevelUpCheck()
    {       
        while (_exp >= expLimit[_level - 1])
        {
            if (expLimit[_level - 1] <= 0) return;
            _exp = _exp - expLimit[_level - 1];
            _level++;
            GameObject messageBox = GameObject.Find("MessageBox");
            if (messageBox)
            {
                MessageManager messageMgr = messageBox.GetComponent<MessageManager>();
                messageMgr.SendMessageToBox("升级啦！");
            }
            RefreshAttribute();
        }
        return;
    }

    public static void GetExp()
    {

    }

}
