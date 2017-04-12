using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNpc : Npc
{

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
        showBtns(true);
    }

    private void showBtns( bool bOK )
    {
        if (bOK)
        {
            btnOK.SetActive(true);
            btnAccept.SetActive(false);
            btnCancel.SetActive(false);

            lbQuest.text = "任务:\n \n 你已经杀死了" + nCount + " \\ 10 只小野狼。 \n \n 奖励: 1000金币。";
        }
        else
        {
            btnOK.SetActive(false);
            btnAccept.SetActive(true);
            btnCancel.SetActive(true);

            lbQuest.text = "	任务：  保卫村民 \n\n可恶的恶狼偷吃了我们的粮食，\n 帮助我们的村民杀死10只恶狼。\n 带回他们的狼头，我将支付你   \n   1000金币。";
        }
    }

    // 点击取消按钮
    public void onClickCancel()
    {
        tween.PlayReverse();
    }


    // 点击OK按钮
    public void onClickOK()
    {
        // 任务完成
        if (nCount >= 10)
        {
            showBtns(false);

        }
        else
        {
            onClickCloseQuest();
        }
    }
}
