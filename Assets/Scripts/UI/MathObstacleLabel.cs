using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshPro;

public class MathObstacleLabel : MonoBehaviour
{
    [SerializeField] private Text m_Label = null;
    [SerializeField] private string m_Format = "{0}{1}";

    private MathObstacle m_Obstacle = null;

    private void Awake()
    {
        m_Obstacle = GetComponentInParent<MathObstacle>();
    }

    private void Start()
    {
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        m_Label.text = string.Format(m_Format, GetSymbol(m_Obstacle.Operation), m_Obstacle.Count);
    }

    private string GetSymbol(EMathOperation operation)
    {
        switch (operation)
        {
            case EMathOperation.Add: return "+";
            case EMathOperation.Subtract: return "−";
            case EMathOperation.Multiply: return "×";
            case EMathOperation.Divide: return "÷";
            default: return "$";
        }
    }
}
