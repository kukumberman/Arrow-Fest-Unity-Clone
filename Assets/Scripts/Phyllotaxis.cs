using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour
{
    [SerializeField] private float m_Angle = 137.5f;
    [SerializeField] private float m_Scale = 1;
    [SerializeField] private Vector3 m_Normal = Vector3.forward;

    public Vector3 Calculate(int index)
    {
        float angle = index * (m_Angle * Mathf.Deg2Rad);
        float scale = m_Scale / 10;
        float radius = scale * Mathf.Sqrt(index);

        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Sin(angle) * radius;
        pos.y = Mathf.Cos(angle) * radius;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, m_Normal);
        return rotation * pos;
    }
}
