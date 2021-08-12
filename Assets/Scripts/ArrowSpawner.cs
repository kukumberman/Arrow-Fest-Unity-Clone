using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowSpawner : MonoBehaviour
{
    public event Action<ArrowObject> OnArrowSpawned = null;

    [SerializeField] private bool m_DrawGizmo = false;
    [SerializeField] private int m_Count = 10;
    
    [SerializeField] private Phyllotaxis m_Phyllotaxis = null;
    [SerializeField] private ArrowObject m_ArrowPrefab = null;

    private List<ArrowObject> m_Arrows = new List<ArrowObject>();

    public void Spawn(int count)
    {
        m_Count = count;

        // todo: use pool

        for (int i = m_Arrows.Count - 1; i >= 0; i--)
        {
            var arrow = m_Arrows[i];
            m_Arrows.Remove(arrow);
            Destroy(arrow.gameObject);
        }

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = transform.TransformPoint(m_Phyllotaxis.Calculate(i));
            var arrow = Instantiate(m_ArrowPrefab, pos, Quaternion.identity, transform);
            arrow.OnHumanCollision += OnArrowColision;
            m_Arrows.Add(arrow);
            OnArrowSpawned?.Invoke(arrow);
        }
    }

    private void OnArrowColision(ArrowObject arrow)
    {
        arrow.OnHumanCollision -= OnArrowColision;
        m_Arrows.Remove(arrow);
        Destroy(arrow.gameObject);
    }

    #region Bullshit
    //[SerializeField] private float m_Radius = 1;
    //[SerializeField] private float m_RadialDistance = 0.2f;
    //[SerializeField] private float m_RadiusStep = 0.1f;

    /*
    private Vector3 GetPosition(int index)
    {
        float step = 360f / m_Count;
        float angle = index * step * Mathf.Deg2Rad;
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Sin(angle) * m_Radius;
        pos.y = Mathf.Cos(angle) * m_Radius;
        return pos;
    }
    
    private Vector3 GetPositionV2(int index)
    {
        int incremental = CalculatePointsCountOnCircle(2);

        int circleIndex = (index + incremental) / incremental;
        //circle

        int count = CalculatePointsCountOnCircle(circleIndex);

        float step = 360f / count;
        float angle = index * step * Mathf.Deg2Rad;
        float radius = m_RadiusStep * circleIndex;

        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Sin(angle) * radius;
        pos.y = Mathf.Cos(angle) * radius;

        return pos;
    }

    private int CalculatePointsCountOnCircle(int circleIndex)
    {
        float radius = circleIndex * m_RadiusStep;
        float perimeter = 2 * Mathf.PI * radius;
        int count = Mathf.FloorToInt(perimeter / m_RadialDistance);
        return count;
    }
    */
    #endregion

    private void OnDrawGizmos()
    {
        if (!m_DrawGizmo) return;

        if (!m_Phyllotaxis) return;

        Gizmos.color = Color.blue;

        for (int i = 0; i < m_Count; i++)
        {
            Vector3 pos = m_Phyllotaxis.Calculate(i);
            Gizmos.DrawWireSphere(transform.position + pos, 0.02f);
        }
    }
}
