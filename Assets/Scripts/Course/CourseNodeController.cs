using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CourseNodeController : MonoBehaviour
{
    //本节点是否准备好前置工作
    internal bool Prepared;
    //操作过程
    [HideInInspector]
    public StringBuilder handlecontent = new StringBuilder();
    //操作是否正确
    [HideInInspector]
    public bool result = false;

    //是否结束了本届点
    [HideInInspector]
    public bool Finished = false;

    public virtual void StartNode()
    {
        
    }
    public void Appendhandle(string handle)
    {
        handlecontent.Append(handle + ";");
    }
    public void Finish(bool result)
    {
        this.result = result;
        Finished = true;
    }
}
