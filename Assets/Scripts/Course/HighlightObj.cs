using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Outline))]
public class HighlightObj : MonoBehaviour
{
    public string id;
    [HideInInspector]
    public bool doanim = true;
    private Tweener _flash;
    private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }
    private void Start()
    {
        Regist();
    }
    public void Regist()
    {
        CourseEngine.Instance.highlightManager.Regist(id, this);
    }
    public void EnableOutline()
    {
        Debug.Log("¸ßÁÁ");
        _outline.enabled = true;
    }
    public void DisableOutline()
    {
        _outline.enabled = false;
    }
    private void OnEnable()
    {
        DOTween.To(() => _outline.OutlineColor.a, col =>
        {
            Color color = _outline.OutlineColor;
            color.a = col;
            _outline.OutlineColor = color;
        }, 0, 1).SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {
        
    }
}
