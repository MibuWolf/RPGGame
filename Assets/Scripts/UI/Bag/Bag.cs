using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

    public static Bag instance = null;

    public List<BagItemGrid> bagItems;

    public UILabel lbCoin;

    private TweenPosition tween;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        tween = this.GetComponent<TweenPosition>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            addItem(Random.Range(10001, 10005));
        }
    }



    public void addItem(int id)
    {
        BagItemGrid itemGrid = null;

        foreach (BagItemGrid grid in bagItems)
        {
            // 当前已经有这个道具了
            if (grid.id == id)
            {
                itemGrid = grid;
                break;
            }
        }

        // 当前背包中已存在该道具
        if (itemGrid)
            itemGrid.increment();
        // 找一个空格子
        else
        {
            foreach (BagItemGrid grid in bagItems)
            {
                // 当前已经有这个道具了
                if ( grid.id <= 0 )
                {
                    itemGrid = grid;
                    break;
                }
            }

            if (itemGrid == null)
            {
                print("Bag is Full Cannot addItem");
            }
            else
            {
                //  GameObject iconObj = NGUITools.AddChild(itemGrid.gameObject, itemIcon);
                //  iconObj.transform.localPosition = Vector3.zero;
                //  itemGrid.setID( id );

                itemGrid.setID(id);
            }
        }
    }


    public void openBag()
    {
        tween.PlayForward();
    }


    public void closeBag()
    {
        tween.PlayReverse();
    }
}
