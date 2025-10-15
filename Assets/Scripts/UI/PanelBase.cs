using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public abstract class PanelBase : MonoBehaviour
{
    private CanvasGroup _canvasgroup;
    private CanvasGroup canvasgroup => _canvasgroup ? _canvasgroup : gameObject.GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();

    public virtual void Init()
    {
        gameObject.SetActive(false);
        canvasgroup.blocksRaycasts = false;
        canvasgroup.alpha = 0;
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
        canvasgroup.DOFade(1, 0.3f).OnComplete(() =>
        {
            canvasgroup.blocksRaycasts = true;
            OnOpen();
        });
    }
    public virtual void Close()
    {
        canvasgroup.blocksRaycasts = false;
        canvasgroup.DOFade(0, 0.3f).OnComplete(() =>
        {
            gameObject.SetActive(false);
            OnClose();
        });
    }
    public abstract void OnOpen();
    public abstract void OnClose();
}
