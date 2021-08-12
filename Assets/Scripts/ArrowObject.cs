using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowObject : MonoBehaviour
{
    public event Action<ArrowObject> OnHumanCollision = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HumanObstacle>(out var obstacle))
        {
            OnHumanCollision?.Invoke(this);
        }
    }
}
