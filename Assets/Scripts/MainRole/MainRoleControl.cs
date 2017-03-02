using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoleControl : MonoBehaviour {

    public GameObject effectPerfab;

    public bool bMoveing;

    public Vector3 targetPos;

    private float waitTime = 0.0f;

    private Vector3 helpVec;

    // Use this for initialization
    void Start () {

        helpVec = new Vector3();
        targetPos = new Vector3();
        targetPos = transform.position;
        bMoveing = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && UICamera.hoveredObject == null )
        {
            bMoveing = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            bMoveing = false;
        }

        waitTime -= Time.deltaTime;

        if (waitTime <= 0.0f && bMoveing)
        {
            waitTime = 0.1f;
            checkRay();
        }

    }

    void checkRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        bool bRay = Physics.Raycast(ray, out hitInfo);

        if (bRay && hitInfo.collider.tag == TagsUtils.GROUND )
        {
            helpVec.x = hitInfo.point.x; helpVec.y = hitInfo.point.y + 0.1f; helpVec.z = hitInfo.point.z;
            GameObject effect = Instantiate(effectPerfab, helpVec, Quaternion.identity);

            targetPos.x = helpVec.x; targetPos.y = transform.position.y; targetPos.z = helpVec.z;

            this.transform.LookAt(targetPos);
        }

    }
}
