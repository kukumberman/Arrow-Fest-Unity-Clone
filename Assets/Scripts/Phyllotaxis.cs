using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour
{
    [SerializeField] private float m_Angle = 137.5f;
    [SerializeField] private float m_Scale = 1;

    public Vector2 Calculate(int index)
    {
        float angle = index * (m_Angle * Mathf.Deg2Rad);
        float scale = m_Scale / 10;
        float radius = scale * Mathf.Sqrt(index);

        Vector2 pos = Vector2.zero;
        pos.x = Mathf.Sin(angle) * radius;
        pos.y = Mathf.Cos(angle) * radius;
        return pos;
    }
}
