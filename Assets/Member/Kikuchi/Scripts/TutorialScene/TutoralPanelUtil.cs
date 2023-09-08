using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutoralPanelUtil : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject tutoralPanelTwo;

    public void OnPointerDown(PointerEventData eventData)
    {
        tutoralPanelTwo.SetActive(true);
    }
}
