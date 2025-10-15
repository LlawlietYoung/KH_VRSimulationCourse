using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Home : PanelBase
{
    public Button Btn_mode_demonstration,btn_teaching, btn_exercise, btn_evaluating;
    public Dropdown dd_selectmajor;
    public override void Init()
    {
        base.Init();
        for (int i = 0; i < CourseManager.instance.courses.majorItems.Count; i++)
        {
            int a = i;
            dd_selectmajor.options.Add(new Dropdown.OptionData()
            {
                text = CourseManager.instance.courses.majorItems[a].majorName
            });
        }
        dd_selectmajor.onValueChanged.AddListener(v =>
        {
            CourseManager.instance.currentmajorid = v;
        });
        dd_selectmajor.value = CourseManager.instance.currentmajorid;
        dd_selectmajor.RefreshShownValue();
        Btn_mode_demonstration.onClick.AddListener(() =>
        {
            CourseManager.instance.currentMode = CourseMode.Demonstration;
            Close();
            PanelManager.instance.OpenPanel<Panel_CourseList>();
        });
        btn_teaching.onClick.AddListener(() =>
        {
            CourseManager.instance.currentMode = CourseMode.Teaching;
            Close();
            PanelManager.instance.OpenPanel<Panel_CourseList>();
        });
        btn_exercise.onClick.AddListener(() => 
        {
            CourseManager.instance.currentMode = CourseMode.Exercise;
            Close();
            PanelManager.instance.OpenPanel<Panel_CourseList>();
        });
        btn_evaluating.onClick.AddListener(() =>
        {
            CourseManager.instance.currentMode = CourseMode.Evaluating;
            Close();
            PanelManager.instance.OpenPanel<Panel_Login>();
        });
    }
    private void SelectMode(CourseMode courseMode)
    {
        CourseManager.instance.currentMode = courseMode;
        Close();
        PanelManager.instance.OpenPanel<Panel_CourseList>();
    }
    public override void OnClose()
    {
        
    }

    public override void OnOpen()
    {
        
    }
    private void Update()
    {
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Btn_mode_demonstration.onClick.Invoke();
        }
#endif
    }
}
