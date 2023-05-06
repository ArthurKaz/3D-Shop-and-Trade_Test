using TMPro;
using UnityEngine;

public class DisappearingMessage : PositionBaseUI
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    public void ShowMessage(string message)
    {
        _textMeshProUGUI.text = message;
        Enable();
        HideUI();
    }
}