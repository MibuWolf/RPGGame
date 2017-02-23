using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoleControl : MonoBehaviour {

    private Vector3 helpVec;

    public GameObject effectPerfab;

	// Use this for initialization
	void Start () {

        helpVec = new Vector3();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
        }

    }
}
