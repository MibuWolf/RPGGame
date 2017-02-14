using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCartoon : MonoBehaviour {

    // 当前是否播放过
    private bool bPlayed = false;
    // 目标位置
    private float endY = 32.0f;
    private float endZ = -20.0f;

    // 移动速度
    private float speedY = -2.5f;
    private float speedZ = 10.0f;

    private Transform myTransform;

	// Use this for initialization
	void Start ()
    {
        myTransform = transform;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (bPlayed)
            return;

        if (myTransform.position.z < endZ)
        {
            myTransform.Translate(Vector3.forward * Time.deltaTime * speedZ);
            myTransform.Translate(Vector3.up * Time.deltaTime * speedY);
        }
        else
        {
            bPlayed = true;
            myTransform.position = new Vector3(myTransform.position.x, endY, endZ);
        }
	}
}
