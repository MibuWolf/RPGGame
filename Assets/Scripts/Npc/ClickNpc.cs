using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNpc : MonoBehaviour {

    public TweenPosition tween;

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

    public void onClickCloseQuest()
    {
        tween.PlayReverse();
    }
}
