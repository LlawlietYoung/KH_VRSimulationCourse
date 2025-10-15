using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class LuosiGroup : MonoBehaviour
{
    //共三个档位，0表示
    [SerializeField]
    private int currentshelves = 0;
    private int CurrentShelves
    {
        get => currentshelves;
        set
        {
            if (!canmove) return;
            if (value > 3) return;
            if (value < 0) return;
            if (currentshelves == value) return;
            if (value > currentshelves)
            {
                animator.SetTrigger("Out");
            }
            if (value < currentshelves)
            {
                animator.SetTrigger("In");
            }
            currentshelves = value;
            DontMove();
        }
    }

    public Animator animator;
    public Transform[] losies;
    public Transform HandlePanel;
    public Button btn_out, btn_in;
    public Button btn_next;
    private bool canmove = true;
    //会有两个节点用到这个步骤，要结束两次
    public Action<bool,string> onfinish, onfinish1;

    public bool StartStep()
    {
        CourseEngine.Instance.highlightManager.Highlight("luosi");
        foreach (var item in losies)
        {
            item.GetComponentInChildren<XRSimpleInteractable>().enabled = true;
        }
        return true;
    }
    public void ShowHandle()
    {
        foreach (var item in losies)
        {
            item.GetComponentInChildren<XRSimpleInteractable>().enabled = false;
        }
        HandlePanel.gameObject.SetActive(true);
        btn_out.onClick.AddListener(() =>
        {
            CurrentShelves++;
        });
        btn_in.onClick.AddListener(() => 
        {
            CurrentShelves--;
        });
        btn_next.onClick.AddListener(() =>
        {
            onfinish?.Invoke(true, "操作结果");
            CourseEngine.Instance.highlightManager.DisableAll();
            HandlePanel.gameObject.SetActive(false);
        });
    }

    public void CanMove()
    {
        canmove = true;
    }
    public void DontMove()
    {
        canmove = false;
    }
    private void Update()
    {
        //测试
        if (Input.GetKeyDown(KeyCode.RightArrow)) CurrentShelves++;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) CurrentShelves--;
    }

    /// <summary>
    /// 拧紧
    /// </summary>
    public void Ningjin()
    {
        StartCoroutine(NingjinIE());
    }
    private IEnumerator NingjinIE()
    {
        while (true)
        {
            CurrentShelves--;
            if (CurrentShelves == 0) break;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
        onfinish1?.Invoke(true, "操作结果");
    }
}
