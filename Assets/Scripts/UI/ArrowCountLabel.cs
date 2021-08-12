using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;

public class ArrowCountLabel : MonoBehaviour
{
    [SerializeField] private Text m_Label = null;

    private ArrowController m_ArrowController = null;

    private Camera m_Camera = null;

    private void Awake()
    {
        m_ArrowController = FindObjectOfType<ArrowController>();

        m_Camera = Camera.main;
    }

    private void OnEnable()
    {
        m_ArrowController.OnCountChanged += OnCountChanged;
    }

    private void OnDisable()
    {
        m_ArrowController.OnCountChanged -= OnCountChanged;
    }

    private void Update()
    {
        transform.position = m_Camera.WorldToScreenPoint(m_ArrowController.transform.position);
    }

    private void OnCountChanged(int count)
    {
        m_Label.text = $"{count}";
    }
}
