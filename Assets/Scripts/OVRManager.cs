using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRManager : MonoBehaviour
{
    public static OVRManager instance {  get; private set; }

    public Transform Head_trans;
    private void Start()
    {
        instance = this;
    }
}
