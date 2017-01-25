using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttributeUI : MonoBehaviour {
    public Text playerName;
    public Text Level;
    public Text Atk;
    public Text Hp;
    public Text Energy;
    public Text Exp;
    private GameObject player;
    private PlayerAttribute playerAttr;

    // Use this for initialization
    void Start () {

    }
	
    void OnEnable()
    {
        player = GameObject.Find("Player");
        if (player)
        {
            playerAttr = player.GetComponent<PlayerAttribute>();
        }
        playerName.text = "名称： " + playerAttr.playerName;
        Level.text = "等级： " + playerAttr.level;
        Atk.text = "攻击： " + playerAttr.atk;
        Hp.text = "生命： " + playerAttr.hp;
        Energy.text = "体力： " + playerAttr.energy;
        Exp.text = "经验： " + playerAttr.exp;
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void ReturnMainUI()
    {
        UIManager.ChangeUI(gameObject, "MainUI");
    }
}
