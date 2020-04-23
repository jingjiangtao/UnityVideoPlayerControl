using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class SliderControl : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Slider slider;
    public bool isSliderControl = false;

    public virtual void OnBeginDrag(PointerEventData eventData) { }

    public virtual void OnDrag(PointerEventData eventData) { }

    public virtual void OnEndDrag(PointerEventData eventData) { }

    public virtual void OnPointerDown(PointerEventData eventData) { }

    public virtual void OnPointerUp(PointerEventData eventData) { }
}

