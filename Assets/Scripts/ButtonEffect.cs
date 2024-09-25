using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI textLabel;

    public Color hoverColor;
    public Color normalColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        textLabel.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textLabel.color = normalColor;
    }
}
