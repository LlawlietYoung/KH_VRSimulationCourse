//using Sirenix.OdinInspector;
//using Sirenix.OdinInspector.Demos;
//using Sirenix.OdinInspector.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class CourseModel
{
    //[BoxGroup("课程信息")]
    //[HorizontalGroup("课程信息/Split", LabelWidth = 80)]
    //[BoxGroup("课程信息/课程名称", showLabel: true)]
    public string CourseName;
    //[BoxGroup("课程信息/当课程开始时", showLabel: true)]
    public UnityEvent OnCourseStart;

    //准备好开始章节时才开始章节
    [HideInInspector]
    public bool Prepared = false;

    //[BoxGroup("课程信息/当课程结束时", showLabel: true)]
    public UnityEvent OnCourseFinish;

    //[BoxGroup("章节信息")]
    //[ListDrawerSettings(ListElementLabelName = "ChapterTitle")]
    public List<CourseChapter> chapters;
}
[Serializable]
public class CourseChapter
{
    //[BoxGroup("章节控制器")]
    public CourseChapterControllerBase controller;

    //[BoxGroup("当章节开始时")]
    //public UnityEvent OnChapterStart;
    //[BoxGroup("当章节结束时")]
    //public UnityEvent OnChapterFinish;

    //[BoxGroup("课程信息/Split/章节", showLabel: true)]
    //[BoxGroup("章节标题")]
    public string ChapterTitle;
    //[ListDrawerSettings(ListElementLabelName = "Content")]
    //[BoxGroup("操作步骤")]
    public List<CourseNode> nodes;
}
[Serializable]
public class CourseNode
{
    //[BoxGroup("节点控制器")]
    public CourseNodeController controller;
    //[BoxGroup("步骤内容")]
    public string Content;
    //[BoxGroup("当步骤开始时")]
    //public UnityEvent OnNodeStart;
    //[BoxGroup("当步骤结束时")]
    //public UnityEvent OnNodeFinish;
    //当节点开始前的所有准备都做好后开始本节点
    [HideInInspector]
    public bool Prepared = false;
    [HideInInspector]
    public bool Finish = false;



    [HideInInspector]
    public string handlecontent = "未作答";
    [HideInInspector]
    public bool result = false;
    [HideInInspector]
    public float score = 0;
}
