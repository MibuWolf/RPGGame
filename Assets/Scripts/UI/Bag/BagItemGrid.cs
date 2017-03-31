using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemGrid : MonoBehaviour {

    // 道具ID
    public int id = 0;

    // 道具堆叠数
    public int count = 0;

    // 数量lable
    private UILabel lb_count;

    // 道具数据
    private ItemData item;

    // icon预设
    public GameObject iconPrefab;

    private GameObject icon;
	// Use this for initialization
	void Start () {

        lb_count = this.GetComponentInChildren<UILabel>();

        icon = NGUITools.AddChild(this.gameObject, iconPrefab);

        icon.SetActive(false);

    }

    // 设置格子数据
    public void setID(int _id, int _count = 1)
    {
        id = _id;
        count = _count;
        item = ItemModel.instance.getData(id);

        if (item == null || icon == null)
        {
            print("Error : Cannot Find Item which id is " + id);
            return;
        }

        icon.SetActive(true);
        BagItemIcon itemIcon = icon.GetComponent<BagItemIcon>();

        if (icon)
        {
            itemIcon.setIconID(id);
            lb_count.enabled = true;
            lb_count.depth = 5;
            lb_count.text = count.ToString();
        }

    }


    // 道具数据自增
    public void increment()
    {
        count++;
        lb_count.text = count.ToString();
    }


    // 清理格子数据
    public void clear()
    {
        id = 0;
        count = 0;
        item = null;
        lb_count.enabled = false;
        lb_count.text = count.ToString();

        if (icon == null)
            return;

        BagItemIcon iconItem = icon.GetComponent<BagItemIcon>();

        if (iconItem)
        {
            iconItem.clear();
            iconItem.gameObject.SetActive(false);
        }

    }
}
