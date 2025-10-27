using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ShangchongGroupController : MonoBehaviour
{
    //需要手动安装的第一个上冲
    public ShangchongItemController shangchong;
    public GameObject step1hint;

    public Action<bool, string> onFinished01,onFinished02;


    public ZhuanlunItemmControllerr zhuanlunItemmControllerr;
    public Transform zhuandongmozu;

    private int currentstep = -1;
    public void StartStep1()
    {
        currentstep = 1;
        shangchong.gameObject.SetActive(true);
        shangchong.SetStep(currentstep);
        CourseEngine.Instance.highlightManager.Highlight("shangchong");
        if(CourseManager.instance.currentMode != CourseMode.Evaluating)
        {
            step1hint.SetActive(true);
        }
    }
    
    /// <summary>
    /// 当上冲被放开时调用这个方法，判断是否在正确位置
    /// </summary>
    public void OnShangchongLoose()
    {
        //第一步中使用
        if(currentstep == 1)
        {
            this.Delay(0.1f, () =>
            {
                Debug.Log(shangchong.CorrectPosition);
                //上冲被拖到了正确的位置
                if (shangchong.CorrectPosition)
                {
                    //高亮提示关闭
                    CourseEngine.Instance.highlightManager.DisableAll();
                    //shangchong.enabled = false;
                    step1hint.SetActive(false);
                    //结束本环节
                    onFinished01?.Invoke(shangchong.islefthandle, shangchong.Result);
                }
            });
        }
    }


    private int current = 0;
    private bool isLeftGrabShangchong = false;
    private bool isRightGrabZhuanlun = false;
    private List<(float, float)> angles = new List<(float, float)>()
    {
        (-30f,-20f),(-60f,-40f),(-90f,-60f)
    };
    private Coroutine cor_rotate;
    public GameObject HandlePanelPoint_step02_chongjing;
    public Button btn_confirm, btn_cancel;
    public GameObject step2hint01, step2hint02;

    public void StartStep2()
    {
        currentstep = 2;
        shangchong.SetStep(currentstep);
        step2hint01.SetActive(true);
        step2hint02.SetActive(true);
        zhuanlunItemmControllerr.enabled = true;
        CourseEngine.Instance.highlightManager.Highlight("shangchong", "zhuanlun");
        zhuanlunItemmControllerr.OnRotate += OnShoulunRotate;
        btn_confirm.onClick.AddListener(() =>
        {
            HandlePanelPoint_step02_chongjing.gameObject.SetActive(false);
            //下一步
            EndStep2();
        });
        btn_cancel.onClick.AddListener(() =>
        {
            HandlePanelPoint_step02_chongjing.gameObject.SetActive(false);
            //继续操作

        });
    }
    /// <summary>
    /// 第二步判断是不是左手触发上冲
    /// </summary>
    /// <param name="args"></param>
    public void OnShangchongGrabbed_step2(SelectEnterEventArgs args)
    {
        if (currentstep == 2)
        {
            isLeftGrabShangchong = (args.interactorObject.transform.GetComponentInParent<ActionBasedController>() && args.interactorObject.transform.GetComponentInParent<ActionBasedController>().modelParent.name.Contains("Left"));
            if (isLeftGrabShangchong) CheckStartRotate();
        }
    }
    /// <summary>
    /// 第二部判断是不是右手触发转轮
    /// </summary>
    /// <param name="args"></param>
    public void OnZhuanlunGrabbed_step2(SelectEnterEventArgs args)
    {
        if (currentstep == 2)
        {
            isRightGrabZhuanlun = (args.interactorObject.transform.GetComponentInParent<ActionBasedController>() && args.interactorObject.transform.GetComponentInParent<ActionBasedController>().modelParent.name.Contains("Right"));
            if (!isRightGrabZhuanlun) CheckStartRotate();
        }
    }
    /// <summary>
    /// 当两个手都正确触发时开始转动
    /// </summary>
    private void CheckStartRotate()
    {
        if(isLeftGrabShangchong && isRightGrabZhuanlun)
        {
            cor_rotate = StartCoroutine(Rotate());
        }
    }
    private IEnumerator Rotate()
    {
        while(current < 3)
        {
            zhuanlunItemmControllerr.transform.DOLocalRotate(new Vector3(0, 90, angles[current].Item1), 1);
            zhuandongmozu.transform.DOLocalRotate(new Vector3(0, angles[current].Item1, 0), 1);
            yield return new WaitForSeconds(3);
            current++;
        }
        //直接结束，显示其他上冲
        cor_rotate = null;
        EndStep2();
    }
    public void OnShangChongOrZhuanlunLoose()
    {
        if(currentstep == 2)
        {
            if(cor_rotate != null)
            {
                StopCoroutine(cor_rotate);
                this.Delay(1, () =>
                {
                    //提示是否继续
                    HandlePanelPoint_step02_chongjing.SetActive(true);
                });
            }
        }
    }
    public void OnShoulunRotate(float delta)
    {
        zhuandongmozu.Rotate(Vector3.up, delta * 10);
    }

    private void EndStep2()
    {
        CourseEngine.Instance.highlightManager.DisableAll();
        HandlePanelPoint_step02_chongjing.SetActive(false);
        step2hint01.SetActive(false);
        step2hint02.SetActive(false);

        onFinished02.Invoke(isRightGrabZhuanlun && isLeftGrabShangchong && current == 2, (isRightGrabZhuanlun ? "右手" : "左手") + "操作转轮；" + (isLeftGrabShangchong ? "左手" : "右手") + "操作冲杆颈" + "冲颈杆" + (current == 2 ? "" : "未") + "接触平行轨");
    }
}
