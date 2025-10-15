using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager instance {  get; private set; }

    public PanelBase[] panelBases;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < panelBases.Length; i++)
        {
            panelBases[i].Init();
        }
        OpenPanel<Panel_Home>();
    }
    public T OpenPanel<T>() where T : PanelBase
    {
        for (int i = 0; i < panelBases.Length; i++)
        {
            if (panelBases[i] != null && panelBases[i] is T)
            {
                panelBases[i].Open();
                return (T)panelBases[i];
            }
        }
        return null;
    }
    public void CloseAllApenel()
    {
        foreach (PanelBase panelBase in panelBases)
        {
            panelBase.Close();
        }
    }
}
