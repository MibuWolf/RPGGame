using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    public static CursorManager instance;

    public Texture2D normal;
    public Texture2D npc;
    public Texture2D attack;
    public Texture2D pick;
    public Texture2D locked;

    private Vector2 help = new Vector2(0, 0);
    // Use this for initialization
    void Start () {
		
        if(instance == null)
            instance = this;

    }


    public void setCursor(CursorType type)
    {
        switch (type)
        {
            case CursorType.NORMAL:
                Cursor.SetCursor(normal, help, CursorMode.Auto);
                break;
            case CursorType.NPCTALK:
                Cursor.SetCursor(npc, help, CursorMode.Auto);
                break;
            case CursorType.ATTACK:
                Cursor.SetCursor(attack, help, CursorMode.Auto);
                break;
            case CursorType.PICK:
                Cursor.SetCursor(pick, help, CursorMode.Auto);
                break;
            case CursorType.LOCKED:
                Cursor.SetCursor(locked, help, CursorMode.Auto);
                break;
        }
    }
}
