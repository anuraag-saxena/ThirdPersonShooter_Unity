using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum EMode { 
        AWARE,
        UNAWARE
    }

    private EMode m_CurrentMode;
    public EMode CurrentMode {
        get { 
            return m_CurrentMode;
        }
        set {
            if (m_CurrentMode == value)
                return;

            m_CurrentMode = value;

            if (OnModeChanged != null)
                OnModeChanged(value);
        }
    }

    // delegate
    public event System.Action<EMode> OnModeChanged;

    void Awake() { 
        CurrentMode = EMode.UNAWARE;  
    }

    //[ContextMenu("Set Aware")]
    //void SetToAware() { 
    //    CurrentMode = EMode.AWARE;
    //}

    //[ContextMenu("Set UnAware")]
    //void SetToUnAware()
    //{
    //    CurrentMode = EMode.UNAWARE;
    //}
}
