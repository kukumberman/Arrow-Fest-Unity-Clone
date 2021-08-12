using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    [SerializeField] private int m_Count = 5;
    [SerializeField] private int m_DistanceAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 GetPosition(int index)
    {
        return Vector3.forward * (index * m_DistanceAmount);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < m_Count; i++)
        {
            Gizmos.DrawWireSphere(GetPosition(i), 0.1f);
        }
    }
}
