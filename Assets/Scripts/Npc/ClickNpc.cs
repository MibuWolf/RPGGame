using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNpc : MonoBehaviour {

    public TweenPosition tween;

    public UILabel lbQuest;
    private int nCount = 0;

    public GameObject btnOK;
    public GameObject btnAccept;
    public GameObject btnCancel;

	// Use this for initialization
	void Start () {
		
	}


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            showQuest();
        }

    }


    private void showQuest()
    {
        tween.gameObject.SetActive(true);
        tween.PlayForward();
    }

    // 关闭按钮
    public void onClickCloseQuest()
    {
        tween.PlayReverse();
    }

    // 点击接受按钮
    public void onClickAccept()
    {
        lbQuest.text = "任务:\n \n 你已经杀死了" + nCount+" \\ 10 只小野狼。 \n \n 奖励: 1000金币。";

        btnOK.SetActive(true);
        btnAccept.SetActive(false);
        btnCancel.SetActive(false);
    }

    // 点击取消按钮
    public void onClickCancel()
    {
        tween.PlayReverse();
    }
}
