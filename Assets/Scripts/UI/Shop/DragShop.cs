using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShop : MonoBehaviour {

    public static DragShop instance;

    private bool bShow = false;
    private TweenPosition tween;

    private GameObject buyUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            tween = gameObject.GetComponent<TweenPosition>();
            this.gameObject.SetActive(false);
            buyUI = this.gameObject.transform.FindChild("buyCount").gameObject;
            buyUI.SetActive(false);
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
    }

    // 购买大屏血瓶
    public void onClickBuy2()
    {

    }

    // 购买蓝屏
    public void onClickBuy3()
    {

    }

    // 显示隐藏购买界面
    private void changeBuyUI()
    {

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
