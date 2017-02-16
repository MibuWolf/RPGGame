using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {

    // 该脚本是否生效（开场动画播放完成后才生效）
    private bool bStart = false;
    // 开始游戏等界面对象
    private GameObject btnContainer;
    // 当前脚本还是否有效
    private bool bValid = true;

    // Use this for initialization
    void Start ()
    {
        btnContainer = this.transform.parent.Find("BtnContainer").gameObject;

        StartCoroutine(WaitForBegin());

    }

    IEnumerator WaitForBegin()
    {
        yield return new WaitForSeconds(4.0F);

        bStart = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (bValid && bStart && Input.anyKey)
        {
            ShowBtnContainer();
        }
	}

    private void ShowBtnContainer()
    {
        bValid = false;

        this.gameObject.SetActive(false);
        btnContainer.SetActive(true);
    }
}
