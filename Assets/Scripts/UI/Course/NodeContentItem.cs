using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeContentItem : MonoBehaviour
{
    public string title
    {
        set
        {
            tt_title.text = value;
        }
    }
    public Text tt_title;
    public Text tt_score;
    public Text tt_content;
    public string content
    {
        set
        {
            tt_content.text = value;
        }
    }
    public void SetScore(float score, bool result)
    {
        tt_score.text = (result ? "<color=green>正确</color>":"<color=red>错误</color>") + "  " + "得分：" + score.ToString("00.0");
    }
}
