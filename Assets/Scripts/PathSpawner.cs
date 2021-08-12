using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    [SerializeField] private PathObject m_Prefab = null;
    [SerializeField] private int m_Count = 5;
    [SerializeField] private int m_DistanceAmount = 5;
    [SerializeField] private float m_Speed = 1;

    private void Start()
    {
        for (int i = 0; i < m_Count; i++)
        {
            Vector3 pos = GetPosition(i);
            var path = Instantiate(m_Prefab, pos, Quaternion.identity, transform);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.back * m_Speed * Time.deltaTime);
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
