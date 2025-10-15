using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhongmuItem : MonoBehaviour
{
    private bool canmove = true;
    public bool Canmove
    {
        get { return canmove; }
        set { canmove = value; }
    }
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void CanMove()
    {
        Canmove = true;
    }
    public void DontMove()
    {
        Canmove = false;
    }
    public void Hit()
    {
        if(canmove) animator.SetTrigger("Hit");
    }
}
