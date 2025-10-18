using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    public Dictionary<string, List<HighlightObj>> highlightobjs = new Dictionary<string, List<HighlightObj>>();

    public void Regist(string id, HighlightObj outline)
    {
        Debug.Log("注册ID" +  id);
        if(highlightobjs.ContainsKey(id))
        {
            highlightobjs[id].Add(outline);
        }
        else
        {
            List<HighlightObj> list = new List<HighlightObj>() { outline };
            highlightobjs.Add(id, list);
        }
    }
    /// <summary>
    /// 通过id高亮
    /// </summary>
    /// <param name="ids"></param>
    public void Highlight(params string[] ids)
    {
        if(CourseManager.instance != null)
        {
            switch (CourseManager.instance.currentMode)
            {
                //演示模式，不会进入到这里
                case CourseMode.Demonstration:
                    break;
                //教学模式和练习模式需要高亮提示
                case CourseMode.Teaching:
                case CourseMode.Exercise:
                    DisableAll();
                    foreach (string id in ids)
                    {
                        Debug.Log("高亮ID" + id);

                        if (highlightobjs.ContainsKey(id))
                        {
                            highlightobjs[id].ForEach(obj =>
                            {
                                obj.EnableOutline();
                            });
                        }
                    }
                    break;
                //评测模式不提示
                case CourseMode.Evaluating:
                    break;
            }
        }

    }
    /// <summary>
    /// 全部关闭高亮
    /// </summary>
    public void DisableAll()
    {
        if (CourseManager.instance != null)
        {
            switch (CourseManager.instance.currentMode)
            {
                //演示模式，不会进入到这里
                case CourseMode.Demonstration:
                    break;
                //教学模式和练习模式关闭所有高亮提示
                case CourseMode.Teaching:
                case CourseMode.Exercise:
                    foreach (var item in highlightobjs)
                    {
                        item.Value.ForEach(obj =>
                        {
                            obj.DisableOutline();
                        });
                    }
                    break;
                //评测模式不提示
                case CourseMode.Evaluating:
                    break;
            }
        }
    }
    /// <summary>
    /// 通过id关闭高亮
    /// </summary>
    /// <param name="ids"></param>
    public void DisableHighlight(params string[] ids)
    {
        if (CourseManager.instance != null)
        {
            switch (CourseManager.instance.currentMode)
            {
                //演示模式，不会进入到这里
                case CourseMode.Demonstration:
                    break;
                //教学模式和练习模式关闭高亮提示
                case CourseMode.Teaching:
                case CourseMode.Exercise:
                    foreach (string id in ids)
                    {
                        if (highlightobjs.ContainsKey(id))
                        {
                            highlightobjs[id].ForEach(obj =>
                            {
                                obj.DisableOutline();
                            });
                        }
                    }
                    break;
                //评测模式不提示
                case CourseMode.Evaluating:
                    break;
            }
        }

    }
}
