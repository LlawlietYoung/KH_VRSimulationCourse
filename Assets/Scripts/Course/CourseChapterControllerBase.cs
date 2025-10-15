using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CourseChapterControllerBase : MonoBehaviour
{
    //当章节开始前的所有准备都做好后开始本章节
    [HideInInspector]
    public bool Prepared = false;

    [HideInInspector]
    public bool finished = false;

    public UnityEvent OnChapterStart;
    public UnityEvent OnChapterEnd;

    public virtual void StartChapter()
    {
        OnChapterStart?.Invoke();

    }
}
