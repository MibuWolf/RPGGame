using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {

    public static Equip instance;

    private TweenPosition tween;

    private bool bShow = false;

    private GameObject headObj;
    private GameObject armorObj;
    private GameObject rHandObj;
    private GameObject lHandObj;
    private GameObject shoeObj;
    private GameObject accessoryObj;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            tween = gameObject.GetComponent<TweenPosition>();
            this.gameObject.SetActive(false);

            headObj = this.transform.Find("Head").gameObject;
            armorObj = this.transform.Find("Armor").gameObject;
            rHandObj = this.transform.Find("RHand").gameObject;
            lHandObj = this.transform.Find("LHand").gameObject;
            shoeObj = this.transform.Find("Shoe").gameObject;
            accessoryObj = this.transform.Find("Accessory").gameObject;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // 开关当前界面
    public void transformState()
    {
        if (bShow)
        {
            tween.PlayReverse();
            tween.AddOnFinished(onFinished);
            bShow = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            tween.PlayForward();
            bShow = true;
        }
    }


    // 设置装备
    public void setEquip(int id)
    {
        ItemData item = ItemModel.instance.getData(id);

        UISprite equipItem = null;

        if (item != null)
        {
            switch (item.type)
            {
                case ItemType.HeadEquip:
                    {
                        equipItem = headObj.GetComponentInChildren<UISprite>();
                    }
                    break;
                case ItemType.ArmorEquip:
                    {
                        equipItem = armorObj.GetComponentInChildren<UISprite>();
                    }
                    break;
                case ItemType.RHand:
                    {
                        equipItem = rHandObj.GetComponentInChildren<UISprite>();
                    }
                    break;
                case ItemType.LHand:
                    {
                        equipItem = lHandObj.GetComponentInChildren<UISprite>();
                    }
                    break;
                case ItemType.Shoe:
                    {
                        equipItem = shoeObj.GetComponentInChildren<UISprite>();
                    }
                    break;
                case ItemType.Accessory:
                    {
                        equipItem = accessoryObj.GetComponentInChildren<UISprite>();
                    }
                    break;
            }

            if (equipItem != null && item != null)
                equipItem.spriteName = item.icon;
        }
    }


    private void onFinished()
    {
        this.gameObject.SetActive(false);
    }

}
