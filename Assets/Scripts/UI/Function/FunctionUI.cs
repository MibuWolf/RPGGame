using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionUI : MonoBehaviour {

    public void onClickBag()
    {
        Bag.instance.changeState();
    }

    public void onClickSkill()
    {

    }

    public void onClickEquip()
    {

    }

    public void onClickSetting()
    {

    }

    public void onClickStatus()
    {
        Status.instance.changeState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Bag.instance.addItem(Random.Range(10001, 10005));
        }
    }
}
