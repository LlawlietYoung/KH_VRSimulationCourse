using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Login : PanelBase
{
    public InputField if_studentid;
    public Button btn_confirm;
    public Button btn_return;
    public override void Init()
    {
        base.Init();
        btn_confirm.onClick.AddListener(() =>
        {
            if(string.IsNullOrEmpty(if_studentid.text))
            {
                return;
            }
            HttpHandler.GetCourseList(if_studentid.text, (result, courselist) =>
            {
                if(result)
                {
                    Close();
                    PanelManager.instance.OpenPanel<Panel_CourseList>();
                }
            });
        });
        btn_return.onClick.AddListener(() =>
        {
            Close();
            PanelManager.instance.OpenPanel<Panel_Home>();
        });
    }
    public override void OnClose()
    {
        
    }

    public override void OnOpen()
    {
        
    }
}
