using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {

    private Animation animation;
    private MainRoleMove move;
	// Use this for initialization
	void Start () {
        animation = this.GetComponent<Animation>();
        move = this.GetComponent<MainRoleMove>();

        PlayerPrefs.SetString("Job", "Sword");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (move.state == StateUtils.IDLE)
        {
            animation.CrossFade(PlayerPrefs.GetString("Job")+"-"+"Idle");
        }

        if (move.state == StateUtils.WALK)
        {
            animation.CrossFade(PlayerPrefs.GetString("Job") + "-" + "Run");
        }
    }
}
