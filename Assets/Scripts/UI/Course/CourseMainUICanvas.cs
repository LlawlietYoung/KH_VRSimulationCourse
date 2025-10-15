using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourseMainUICanvas : MonoBehaviour
{
    public FollowViewUICanvas followViewUICanvas;
    public Text tt_content;
    public bool close = true;
    public void ShowContent(string content)
    {
        close = false;
        tt_content.text = content;
        followViewUICanvas.Open();
        this.Delay(3, () =>
        {
            Close();
        });
    }

    public void Close()
    {
        followViewUICanvas.Close();
        close = true;
    }
}
