using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour {

    private Transform mainRoleTransform;

    // 相机距离目标主角的相对位置向量
    private Vector3 offside;

    private float scrollSpeed = 3.0f;

    private bool bRotation = false;

    private float roationSpeed = 3.0f;

	// Use this for initialization
	void Start () {

        mainRoleTransform = GameObject.FindGameObjectWithTag("Player").transform;

        offside = transform.position - mainRoleTransform.position;


    }
	
	// Update is called once per frame
	void Update ()
    { 
        
        updateOffside();
        updateRotation();
    }


    private void updateRotation()
    {

        if (Input.GetMouseButtonDown(1))
            bRotation = true;

        if (Input.GetMouseButtonUp(1))
            bRotation = false;

        if (bRotation)
        {
            transform.RotateAround(mainRoleTransform.position, mainRoleTransform.up, Input.GetAxis("Mouse X") * roationSpeed);

            Vector3 pos = transform.position;
            Quaternion qua = transform.rotation;

            transform.RotateAround(mainRoleTransform.position, transform.right, -Input.GetAxis("Mouse Y") * roationSpeed);

            if (transform.eulerAngles.x < 0 || transform.eulerAngles.x > 75)
            {
                transform.position = pos;
                transform.rotation = qua;
            }

            offside = transform.position - mainRoleTransform.position;
        }

    }


    private void updateOffside()
    {
        float dis = offside.magnitude - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        dis = Mathf.Clamp(dis, 3, 10);

        offside = offside.normalized * dis;

        transform.position = mainRoleTransform.position + offside;
  
    }

}
