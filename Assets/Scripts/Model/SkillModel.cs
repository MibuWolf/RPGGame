using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillModel : MonoBehaviour {

    public static SkillModel instance;

    public TextAsset config;

    private Dictionary<int, SkillData> dataDic = new Dictionary<int, SkillData>();

    void Awake()
    {
        if (!instance)
            instance = this;

        initData(config.text);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void initData(string text)
    {
        string[] array = text.Split('\n');

        for (int i = 0; i < array.Length; ++i)
        {
            string data = array[i];
            string[] info = data.Split(',');

            SkillData skill = new SkillData();
            skill.id = int.Parse(info[0]);
            skill.name = info[1];
            skill.icon = info[2];
            skill.info = info[3];
            skill.mp = int.Parse(info[4]);
            skill.jobType = int.Parse(info[5]);
            skill.hitValue = int.Parse(info[6]);

            dataDic.Add(skill.id, skill);
        }
    }


    public SkillData getData(int id)
    {
        SkillData skill = null;

        dataDic.TryGetValue(id, out skill);

        return skill;
    }

}



public class SkillData
{
    // 技能ID
    public int id;
    // 名称
    public string name;
    // Icon
    public string icon;
    // 技能描述
    public string info;
    // 查克拉消耗值
    public int mp;
    // 适用职业类型
    public int jobType;
    // 伤害值
    public int hitValue;
}
