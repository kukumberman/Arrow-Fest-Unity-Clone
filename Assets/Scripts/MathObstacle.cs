using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathObstacle : MonoBehaviour
{
    [SerializeField] private bool m_RandomizeAtStart = false;
    [SerializeField] private EMathOperation m_Type = EMathOperation.Add;
    [SerializeField] private int m_Count = 2;

    public EMathOperation Operation => m_Type;
    public int Count => m_Count;

    private void Awake()
    {
        if (m_RandomizeAtStart)
        {
            GenerateRandomOperation();
        }
    }

    private void GenerateRandomOperation()
    {
        int random = Random.Range(0, 4);
        m_Type = (EMathOperation)random;
    }
}
