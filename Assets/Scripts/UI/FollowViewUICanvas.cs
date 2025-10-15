using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public class FollowViewUICanvas : MonoBehaviour
{
    private Transform ovrheadtran;

    private bool following = true;

    private CanvasGroup canvasgroup;
    private CanvasGroup _CanvasGroup => canvasgroup ? canvasgroup : GetComponent<CanvasGroup>();

    public Text tt_content;

    [SerializeField]
    private float distance = 2;
    protected virtual void Start()
    {
        if(ovrheadtran) GetComponent<Canvas>().worldCamera = ovrheadtran.GetComponent<Camera>();

    }
    protected virtual void Update()
    {
        if (!OVRManager.instance)
        {
            return;
        }
        if (ovrheadtran == null)
        {
            ovrheadtran = OVRManager.instance.Head_trans;
        }
        else if (following)
        {
            Vector3 target = ovrheadtran.position + new Vector3(ovrheadtran.forward.x, 0, ovrheadtran.forward.z) * distance;
            //target.y = 1.6f;
            transform.position = Vector3.Slerp(transform.position, target, 2 * Time.deltaTime);
            Quaternion rotate = Quaternion.LookRotation(target - ovrheadtran.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, 2 * Time.deltaTime);
        }
        //if (OVRInput.Get(OVRInput.Button.Four))
        //{
        //    following = !following;
        //}
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        _CanvasGroup.DOFade(1, 0.3f);
    }

    public virtual void Close()
    {
        _CanvasGroup.DOFade(0, 0.3f).OnComplete(()=>
        {
            gameObject.SetActive(false);
        });
    }
}
