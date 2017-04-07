using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTips : MonoBehaviour {

    public static BagTips instance;

    private UILabel lbDes;

    void Awake()
    {
        instance = this;

        lbDes = this.GetComponentInChildren<UILabel>();

        this.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void showTips( int id )
    {
        string sDes = "";

        Vector3 mousePos = Input.mousePosition;
        mousePos.x = mousePos.x + 116;
        mousePos.y = mousePos.y - 58;
        this.transform.position = UICamera.currentCamera.ScreenToWorldPoint(mousePos);

        if (lbDes == null)
            return;

        ItemData item = ItemModel.instance.getData(id);

        if (item == null)
            return;

        sDes = "名称:  " + item.name + "\n";
        sDes += "价格:  " + item.price + "\n";

        lbDes.text = sDes;

        this.gameObject.SetActive(true);
    }


    public void closeTips()
    {
        this.gameObject.SetActive(false);
    }
}
