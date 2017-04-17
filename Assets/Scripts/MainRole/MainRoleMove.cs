using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoleMove : MonoBehaviour {

    private MainRoleControl roleControl;
    private CharacterController control;

    private float speed = 4.0f;

    public int state = StateUtils.IDLE;

    private Vector3 helpPos;

    // Use this for initialization
    void Start ()
    {
        roleControl = this.GetComponent<MainRoleControl>();
        control = this.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        checkMoving();
    }


    private void checkMoving()
    {
        float dis = Vector3.Distance(this.transform.position, roleControl.targetPos);

        float height = Mathf.Abs(this.transform.position.y- roleControl.targetPos.y);

        dis -= height;

        if (dis >= 0.1f)
        {
            control.SimpleMove(this.transform.forward * speed);
            state = StateUtils.WALK;
        }
        else
        {
            roleControl.bMoveing = false;
            state = StateUtils.IDLE;
        }
    }
}
