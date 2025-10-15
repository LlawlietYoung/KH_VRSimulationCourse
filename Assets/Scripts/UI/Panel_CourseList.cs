using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_CourseList : PanelBase
{
    public Button btn_courseitem;
    public List<Button> tg_coursetypes = new List<Button>();
    public Transform courseitemparent;
    public Button btn_return;
    public override void Init()
    {
        base.Init();
        btn_return.onClick.AddListener(() =>
        {
            Close();
            PanelManager.instance.OpenPanel<Panel_Home>();
        });
    }
    /// <summary>
    /// 打开某个专业的课程
    /// </summary>
    /// <param name="majorindex"></param>
    public void InitMajor()
    {
        foreach (var item in tg_coursetypes)
        {
            DestroyImmediate(item.gameObject);
        }
        tg_coursetypes.Clear();
        
        for (int i = 0; i < CourseManager.instance.currentMajor.courseItems.Count; i++)
        {
            Button btn_course = Instantiate(btn_courseitem, courseitemparent);
            btn_course.GetComponentInChildren<Text>().text = CourseManager.instance.currentMajor.courseItems[i].Name;
            btn_course.GetComponentInChildren<Image>().sprite = CourseManager.instance.currentMajor.courseItems[i].sp_icon;
            tg_coursetypes.Add(btn_course);
            int a = i;
            btn_course.onClick.AddListener(() =>
            {
                Close();
                if (CourseManager.instance.currentMode == CourseMode.Demonstration)
                {
                    PanelManager.instance.OpenPanel<Panel_Demonstration>();
                }
                else CourseManager.instance.OpenCourse(a);
            });
        }
    }
    public override void OnClose()
    {
        foreach (var item in tg_coursetypes)
        {
            DestroyImmediate(item.gameObject);
        }
        tg_coursetypes.Clear();
    }

    public override void OnOpen()
    {
        InitMajor();
    }
}
