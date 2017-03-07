using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseEnter()
    {
        CursorManager.instance.setCursor(CursorType.NPCTALK);
    }


    private void OnMouseExit()
    {
        CursorManager.instance.setCursor(CursorType.NORMAL);
    }
}
