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
    }
    /// <summary>
    /// 全部关闭高亮
    /// </summary>
    public void DisableAll()
    {
        foreach (var item in highlightobjs)
        {
            item.Value.ForEach(obj =>
            {
                obj.DisableOutline();
            });
        }
    }
    /// <summary>
    /// 通过id关闭高亮
    /// </summary>
    /// <param name="ids"></param>
    public void DisableHighlight(params string[] ids)
    {
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
    }
}
