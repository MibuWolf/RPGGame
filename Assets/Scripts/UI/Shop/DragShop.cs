using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShop : MonoBehaviour {

    public static DragShop instance;

    private bool bShow = false;
    private TweenPosition tween;

    private GameObject buyUI;

    private int curItemID = 0;
    private UILabel lbCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            tween = gameObject.GetComponent<TweenPosition>();
            buyUI = this.gameObject.transform.FindChild("buyCount").gameObject;
            buyUI.SetActive(false);

            GameObject gbInput = buyUI.transform.FindChild("inputCount").gameObject;
            lbCount = gbInput.GetComponentInChildren<UILabel>();

            this.gameObject.SetActive(false);
        }
    }

    // 打开或者关闭当前界面
    public void transState()
    {
        if (bShow)
        {
            tween.PlayReverse();
            tween.AddOnFinished( onFinished );
            bShow = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            tween.PlayForward();
            bShow = true;
        }

    }


    // 关闭当前界面
    public void onClickClose()
    {
        transState();
    }


    // 购买小瓶血瓶
    public void onClickBuy1()
    {
        buyUI.SetActive(true);

        curItemID = 10001;
    }

    // 购买大屏血瓶
    public void onClickBuy2()
    {
        buyUI.SetActive(true);

        curItemID = 10004;
    }

    // 购买蓝屏
    public void onClickBuy3()
    {
        buyUI.SetActive(true);

        curItemID = 10002;
    }


    // 购买道具
    public void onClickBuy()
    {
        int count = int.Parse( lbCount.text );

        for (int i = 0; i < count; ++i)
        {
            Bag.instance.addItem(curItemID);
        }

        buyUI.SetActive(false);
    }


    private void onFinished()
    {
        this.gameObject.SetActive(false);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
