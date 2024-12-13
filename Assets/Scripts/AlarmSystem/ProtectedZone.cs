using System;
using UnityEngine;

public class ProtectedZone : MonoBehaviour
{
    public event Action CrookCome;
    public event Action CrookGone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            CrookCome?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            CrookGone?.Invoke();
        }
    }
}