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


    public void openBag()
    {
        tween.PlayForward();
    }


    public void closeBag()
    {
        tween.PlayReverse();
    }
}
