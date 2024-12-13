using System;
using UnityEngine;

public class ProtectedZone : MonoBehaviour
{
    public event Action<bool> CrookCome;
    public event Action<bool> CrookGone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            CrookCome?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            CrookGone?.Invoke(false);
        }
    }
}