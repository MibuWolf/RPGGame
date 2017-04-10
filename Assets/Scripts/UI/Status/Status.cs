using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public static Status instance;

    private TweenPosition tween;

    private bool bShow = false;

    // 攻击力
    private UILabel lbAct;

    // 防御力
    private UILabel lbDef;

    // 速度
    private UILabel lbSpd;

    // 剩余点数
    private UILabel lvPoint;

    // 增加攻击力按钮
    private GameObject btnAct;

    // 增加防御力按钮
    private GameObject btnDef;

    // 增加速度按钮
    private GameObject btnSpd;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        tween = this.GetComponent<TweenPosition>();

        tween.AddOnFinished(onFinshCartoon);
        this.gameObject.SetActive(false);

        initUI();

    }


    private void initUI()
    {
        lbAct = this.transform.Find("lbAct").GetComponent<UILabel>();
        lbDef = this.transform.Find("lbDef").GetComponent<UILabel>();
        lbSpd = this.transform.Find("lbSpd").GetComponent<UILabel>();
        lvPoint = this.transform.Find("lbPoint").GetComponent<UILabel>();

        btnAct = this.transform.Find("btnAct").gameObject;
        btnDef = this.transform.Find("btnDef").gameObject;
        btnSpd = this.transform.Find("btnSpd").gameObject;

        GameObject player = GameObject.FindGameObjectWithTag(TagsUtils.PLAYER);
        AttributeModel attribute = player.GetComponent<AttributeModel>();

        print(attribute.attack);
        print(attribute.defense);
        print(attribute.speed);
        print(attribute.point);
        lbAct.text = attribute.attack.ToString();
        lbDef.text = attribute.defense.ToString();
        lbSpd.text = attribute.speed.ToString();
        lvPoint.text = attribute.point.ToString();

        if (attribute.point > 0)
        {
            btnAct.SetActive( true );
            btnDef.SetActive(true);
            btnSpd.SetActive(true);
        }
        else
        {
            btnAct.SetActive(false);
            btnDef.SetActive(false);
            btnSpd.SetActive(false);
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void changeState()
    {
        if (bShow)
        {
            closeStatus();
        }
        else
        {
            openStatus();
        }
    }


    void openStatus()
    {
        tween.PlayForward();
        bShow = true;
        this.gameObject.SetActive(true);
    }


    void closeStatus()
    {
        tween.PlayReverse();
        bShow = false;
    }

    private void onFinshCartoon()
    {
        if (!bShow)
            this.gameObject.SetActive(false);
    }
}
