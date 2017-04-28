using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour {

    private int id;
    private SkillData data;

    // 技能Icon
    private UISprite icon;
    // 技能名称
    private UILabel lbName;
    // 技能描述
    private UILabel lbInfo;


    private void Awake()
    {
        icon = this.transform.Find("icon").GetComponent<UISprite>();
        lbName = this.transform.Find("icon").GetComponent<UILabel>();
        lbInfo = this.transform.Find("icon").GetComponent<UILabel>();
    }


    public void setSkill(int skillID)
    {
        id = skillID;
        data = SkillModel.instance.getData(id);

        if (data == null)
            return;

        icon.spriteName = data.icon;
        lbName.text = data.name;
        lbInfo.text = data.info;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
