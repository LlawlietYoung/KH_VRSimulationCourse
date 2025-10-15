using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUICanvas : MonoBehaviour
{
    public FollowViewUICanvas followViewUICanvas;
    public Text tt_content;
    public bool close = true;
    public Color Normal, Warning, Error;
    public void NormalInfo(string info)
    {
        tt_content.color = Normal;
        GetComponent<Image>().color = Normal;
        ShowContent(info);
    }
    public void WarningInfo(string info)
    {
        tt_content.color = Warning;
        GetComponent<Image>().color = Warning;
        ShowContent(info);
    }
    public void ErrorInfo(string info)
    {
        tt_content.color = Error;
        GetComponent<Image>().color = Error;
        ShowContent(info);
    }
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
