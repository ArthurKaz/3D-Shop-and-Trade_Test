using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUI : MonoBehaviour, UI
{
    [SerializeField] private bool _enableInStart;
    [SerializeField] private Button _hideButton;

    private void Awake()
    {
        Init();
        if (_enableInStart)
        {
            ShowUI();
        }
        else
        {
           Disable();
        }

        if (_hideButton != null)
        {
            _hideButton.onClick.AddListener(HideUI);
        }
    }

    protected virtual void Init()
    {
    }

    public abstract void ShowUI();

    public abstract void HideUI();

    protected void Disable()
    {
        gameObject.SetActive(false);
    }

    protected void Enable()
    {
        gameObject.SetActive(true);
    }
}