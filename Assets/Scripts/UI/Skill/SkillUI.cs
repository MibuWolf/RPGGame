using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour {

    public static SkillUI instance;

    private TweenPosition tween;
    private bool bShow = false;

    public int[] swordSkills;
    public int[] magicSkills;

    void Awake()
    {
        if (instance == null)
            instance = this;

        tween = this.GetComponent<TweenPosition>();
        this.gameObject.SetActive(false);
    }


    private void Start()
    {
       string job = PlayerPrefs.GetString("Job");

        switch (job)
        {

        }
    }


    public void transformState()
    {
        if (bShow)
        {
            tween.PlayReverse();
            tween.AddOnFinished(onPlayOver);
        }
        else
        {
            this.gameObject.SetActive(true);
            tween.PlayForward();
            bShow = true;
        }
    }


    void onPlayOver()
    {
        bShow = false;
        this.gameObject.SetActive(false);
    }
}
