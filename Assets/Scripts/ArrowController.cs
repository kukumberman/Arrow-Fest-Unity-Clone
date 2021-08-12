using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowController : MonoBehaviour
{
    public event Action<int> OnCountChanged = null;

    [SerializeField] private int m_Count = 0;

    private ArrowSpawner m_Spawner = null;

    private void Awake()
    {
        m_Spawner = FindObjectOfType<ArrowSpawner>();
    }

    private void Start()
    {
        ForceChangedEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MathObstacle>(out var obstacle))
        {
            UpdateCount(obstacle);

            ForceChangedEvent();

            m_Spawner.Spawn(m_Count);
        }
    }

    private void ForceChangedEvent()
    {
        OnCountChanged?.Invoke(m_Count);
    }

    private void UpdateCount(MathObstacle obstacle)
    {
        switch (obstacle.Operation)
        {
            case EMathOperation.Add: m_Count += obstacle.Count;
                break;
            case EMathOperation.Divide: m_Count /= obstacle.Count;
                break;
            case EMathOperation.Multiply: m_Count *= obstacle.Count;
                break;
            case EMathOperation.Subtract: m_Count -= obstacle.Count;
                break;
        }
    }
}
