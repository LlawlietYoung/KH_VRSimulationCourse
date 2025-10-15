using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterTitleItem : MonoBehaviour
{
    public string title
    {
        set
        {
            tt_title.text = value;
        }
    }
    public Text tt_title;
}
