﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : MonoBehaviour {

    public TextAsset config;

    public static ItemModel instance;

    private Dictionary<int, ItemData> dataDic = new Dictionary<int, ItemData>();

    private void Awake()
    {
        if (!instance)
            instance = this;

        initData(config.text);
    }


    private void initData( string text )
    {
        string[] array = text.Split('\n');

        for (int i = 0; i < array.Length; ++i)
        {
            string data = array[i];
            string[] info = data.Split(',');

            ItemData item = new ItemData();
            item.id = int.Parse(info[0]);
            item.name = info[1];
            item.icon = info[2];

            switch (int.Parse(info[3]))
            {
                case 0:
                    item.type = ItemType.Drag;
                    break;
                case 1:
                    item.type = ItemType.HeadEquip;
                    break;
                case 2:
                    item.type = ItemType.ArmorEquip;
                    break;
                case 3:
                    item.type = ItemType.RHand;
                    break;
                case 4:
                    item.type = ItemType.LHand;
                    break;
                case 5:
                    item.type = ItemType.Shoe;
                    break;
                case 6:
                    item.type = ItemType.Accessory;
                    break;
            }
            
            item.value = int.Parse(info[4]);
            item.price = int.Parse(info[5]);

            dataDic.Add(item.id, item );
        }
    }


    public ItemData getData(int id)
    {
        ItemData item = null;

        dataDic.TryGetValue(id,out item);

        return item;
    }
}


public enum ItemType
{
    Drag,
    HeadEquip,
    ArmorEquip,
    RHand,
    LHand,
    Shoe,
    Accessory
}


public class ItemData
{
    // 道具ID
    public int id;
    // 道具类型
    public ItemType type;
    // 名称
    public string name;
    // Icon
    public string icon;
    // 属性值
    public int value;
    // 价格
    public int price;
}
