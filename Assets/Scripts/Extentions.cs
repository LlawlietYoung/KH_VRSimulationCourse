using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions 
{
    public static void Delay(this MonoBehaviour mono, float delay ,Action action)
    {
        mono.StartCoroutine(DelayIE(delay, action));
    }
    private static IEnumerator DelayIE(float delay ,Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
