using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNpc : Npc {

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            showDragShop();
        }

    }


    private void showDragShop()
    {
        DragShop.instance.transState();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
