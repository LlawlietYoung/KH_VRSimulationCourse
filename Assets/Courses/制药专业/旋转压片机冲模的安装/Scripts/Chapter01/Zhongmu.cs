using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Zhongmu : MonoBehaviour
{
    public Transform[] zhongmus;
    public GameObject HandlePanel;
    public Button btn_hit;
    public Button btn_next;
    [SerializeField]
    private ZhongmuItem zhongmuItem;
    private bool canmove = true;

    private int current = 0;
    private int Current
    {
        get => current;
        set
        {
            if (current == value) return;
            if (!zhongmuItem.Canmove) return;
            if (value > current)
            {
                zhongmuItem.Hit();
            }
            current = value;
            if (current == 3)
            {
                
            }
        }
    }
    public Action<bool,string> onfinshed;
    public void StartStep()
    {
        zhongmuItem.gameObject.SetActive(true);
        //高亮提示
        CourseEngine.Instance.highlightManager.Highlight("zhongmu");

        zhongmuItem.GetComponent<XRSimpleInteractable>().enabled = true;
        btn_hit.onClick.AddListener(() =>
        {
            Current++;
        });
        btn_next.onClick.AddListener(() =>
        {
            CourseEngine.Instance.highlightManager.DisableAll();
            foreach (var item in zhongmus)
            {
                item.gameObject.SetActive(true);
                item.DOLocalMoveZ(0, 1);
            }
            
            HandlePanel.SetActive(false);
            if(Current < 3)
            {
                StartCoroutine(HitAll());
            }
            else
            {
                this.Delay(1, () =>
                {
                    onfinshed?.Invoke(Current == 3, "操作记录");
                });
            }
        });
    }
    private IEnumerator HitAll()
    {
        while (Current < 4)
        {
            yield return new WaitForSeconds(1);
            Current++;
        }
        onfinshed?.Invoke(false, "操作记录");
    }
    public void ShowHandlePanel()
    {
        this.Delay(2, () =>
        {
            HandlePanel.SetActive(true);
        });
        zhongmuItem.GetComponent<XRSimpleInteractable>().enabled = false;
        zhongmuItem.Hit();
    }
}
