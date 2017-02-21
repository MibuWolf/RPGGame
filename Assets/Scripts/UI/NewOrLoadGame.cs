using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrLoadGame : MonoBehaviour {

    public void onNewGame()
    {
        PlayerPrefs.SetInt("isNewGame", 1);

        print("onClick NewGame");
    }


    public void onLoadGame()
    {
        PlayerPrefs.SetInt("isNewGame", 1);

        print("onClick LoadGame");
    }
}
