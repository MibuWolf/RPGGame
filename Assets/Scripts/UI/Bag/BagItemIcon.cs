using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemIcon : UIDragDropItem
{
    private UISprite sprite;

    private int itemID;

    void Start()
    {
        base.Start();

        sprite = this.GetComponent<UISprite>();
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        if (surface)
        {
            // 拖到了空格子
            if (surface.tag == TagsUtils.ITEMGRID)
            {
                BagItemGrid myGrid = this.transform.parent.GetComponent<BagItemGrid>();
                BagItemGrid grid = surface.GetComponent<BagItemGrid>();
                grid.setID(myGrid.id, myGrid.count);
                myGrid.clear();
        
            }
            // 拖到里一个已有物品的非空格子上
            else if (surface.tag == TagsUtils.ITEM)
            {
                if (surface == this.gameObject)
                    initPosition();
                else
                {
                    // 交换吧骚年
                    BagItemGrid targetGrid = surface.transform.parent.GetComponent<BagItemGrid>();
                    BagItemGrid curGrid = transform.parent.GetComponent<BagItemGrid>();

                    int curId = curGrid.id;
                    int curCount = curGrid.count;

                    int tatgetId = targetGrid.id;
                    int targetCount = targetGrid.count;

                    curGrid.setID(tatgetId, targetCount);
                    targetGrid.setID(curId, curCount);
                }
            }
            else
            {
                initPosition();
            }
        }
        else
        {
            initPosition();
        }
    }


    private void initPosition()
    {
        this.transform.localPosition = Vector3.zero;
    }

    public void setIconID(int id)
    {
        itemID = id;

        ItemData item = ItemModel.instance.getData(id);

        if(sprite == null)
            sprite = this.GetComponent<UISprite>();

        if (item != null)
        {
            sprite.spriteName = item.icon;
        }

        sprite.transform.localPosition = Vector3.zero;
    }


    public void onMouseOver()
    {
        BagTips.instance.showTips(itemID);
    }


    public void onMouseOut()
    {
        BagTips.instance.closeTips();
    }


    public void clear()
    {
        sprite.spriteName = "";
    }
}