using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_SelectMajor : PanelBase
{
    public Button btn_majoritem;
    private List<Button> btn_majoritems = new List<Button>();
    public Transform majoritemparent;
    public override void Init()
    {
        base.Init();
        for (int i = 0; i < CourseManager.instance.courses.majorItems.Count; i++)
        {
            Button major = Instantiate(btn_majoritem, majoritemparent);
            btn_majoritems.Add(major);
            int a = i;
            major.onClick.AddListener(() =>
            {
                Close();
                Panel_CourseList panel_CourseList = PanelManager.instance.OpenPanel<Panel_CourseList>();
                panel_CourseList.InitMajor();
            });
        }
    }
    public override void OnClose()
    {
        
    }

    public override void OnOpen()
    {
        
    }
}
