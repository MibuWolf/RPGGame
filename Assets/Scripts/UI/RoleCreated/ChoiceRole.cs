using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceRole : MonoBehaviour {


    // 所有职业预设供外部编辑
    public GameObject[] allJobs;

    // 名字输入框
    public UIInput nameInput;

    // 当前选中的职业索引
    private int index = 0;

    // 为每个职业预设创建的角色实例
    private GameObject[] sllRoles;

    // 职业总数
    private int count = 0;
	// Use this for initialization
	void Start ()
    {
        count = allJobs.Length;

        sllRoles = new GameObject[count];

        for (int i = 0; i < count; ++i)
        {
            GameObject obj = Instantiate<GameObject>( allJobs[i], this.transform.position, this.transform.rotation);

            sllRoles[i] = obj;
        }

        showRole();
    }
	
	// Update is called once per frame
	private void showRole ()
    {
        if (count < 0)
            return;

        if (index < 0)
            index = count - 1;

        if (index >= count)
            index = 0;

        for (int i = 0; i < count; ++i)
        {
            sllRoles[i].SetActive(false);
        }

        sllRoles[index].SetActive(true);
    }


    public void onNextRole()
    {
        index++;

        showRole();
    }


    public void onPervRole()
    {
        index--;

        showRole();
    }


    public void onClickOk()
    {
        string name = nameInput.value;

        if ( name == null || name == "" )
            return;

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetInt("job", index);
    }
}
