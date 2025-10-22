using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShangchongGroupController : MonoBehaviour
{
    //需要手动安装的第一个上冲
    public ShangchongItemController shangchong;
    public Action<bool, string> onFinished;

    /// <summary>
    /// 当上冲被放开时调用这个方法，判断是否在正确位置
    /// </summary>
    public void OnShangchongLoose()
    {
        //上冲被拖到了正确的位置
        if(shangchong.CorrectPosition)
        {
            //高亮提示关闭
            CourseEngine.Instance.highlightManager.DisableAll();
            shangchong.enabled = false;
            //结束本环节
            onFinished?.Invoke(shangchong.islefthandle, shangchong.Result);
        }
    }

    public void OnShoulunRotate(float angle)
    {

    }
}
