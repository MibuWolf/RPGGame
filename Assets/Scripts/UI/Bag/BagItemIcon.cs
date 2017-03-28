using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemIcon : UIDragDropItem
{
    private UISprite sprite;
    
    void Start()
    {
        base.Start();

        sprite = this.GetComponent<UISprite>();
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        if (surface)
            print(surface.tag);
    }

    public void setIconID(int id)
    {
        ItemData item = ItemModel.instance.getData(id);

        if(sprite == null)
            sprite = this.GetComponent<UISprite>();

        if (item != null)
        {
            sprite.spriteName = item.icon;
        }
    }

    public void clear()
    {
        sprite.spriteName = "";
    }
}