using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action darrenCaught;

    public void DarrenCaught()
    {
        if (darrenCaught != null)
        {
            darrenCaught();
        }
    }

    [System.Serializable]
    public class Vector3Event : UnityEvent<Vector3>
    {
    }

    public Vector3Event coinTossed;

    public void CoinTossed(Vector3 coinPosition)
    {
        if (coinTossed != null)
        {
            coinTossed.Invoke(coinPosition);
        }
    }
}
