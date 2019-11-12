using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponentInChildren<Text>().color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponentInChildren<Text>().color = Color.white;
    }
}