using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFaceCanvas : MonoBehaviour
{
    private Transform ovrheadtran;

    void Update()
    {
        if (!OVRManager.instance)
        {
            return;
        }

        if (ovrheadtran == null)
        {
            ovrheadtran = OVRManager.instance.Head_trans;
        }
        Vector3 target = ovrheadtran.position + new Vector3(ovrheadtran.forward.x, 0, ovrheadtran.forward.z) * 1.5f;

        Quaternion rotate = Quaternion.LookRotation(target - ovrheadtran.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, 2 * Time.deltaTime);
    }
}
