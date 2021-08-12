using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowController : MonoBehaviour
{
    public event Action<int> OnCountChanged = null;

    [SerializeField] private int m_Count = 0;
    [SerializeField] private float m_RoadWidth = 2;
    [SerializeField] private float m_HorizontalSpeed = 1;
    [SerializeField] private Vector3 m_Offset = Vector3.zero;

    private ArrowSpawner m_Spawner = null;

    private float m_Horizontal = 0;

    private void Awake()
    {
        m_Spawner = FindObjectOfType<ArrowSpawner>();
    }

    private void Start()
    {
        m_Spawner.Spawn(m_Count);

        ForceChangedEvent();
    }

    private void Update()
    {
        m_Horizontal += Input.GetAxisRaw("Horizontal") * m_HorizontalSpeed * Time.deltaTime;

        float w = m_RoadWidth * 0.5f;
        m_Horizontal = Mathf.Clamp(m_Horizontal, -w, w);
        transform.position = Vector3.right * m_Horizontal + m_Offset;
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
