using System.Collections;
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

        ItemData data = getData(11001);

        if (data != null)
            print(data.name);
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

            switch (int.Parse(info[2]))
            {
                case 0:
                    item.type = ItemType.Drag;
                    break;
                case 1:
                    item.type = ItemType.Equip;
                    break;
            }
            
            item.value = int.Parse(info[3]);
            item.price = int.Parse(info[4]);

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
    Equip
}


public class ItemData
{
    // 道具ID
    public int id;
    // 道具类型
    public ItemType type;
    // 名称
    public string name;
    // 属性值
    public int value;
    // 价格
    public int price;
}
