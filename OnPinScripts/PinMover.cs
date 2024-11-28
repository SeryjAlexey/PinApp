using UnityEngine;
using UnityEngine.EventSystems;

public class PinMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
  [SerializeField] private float tics_to_drag;
  private float tics = 0;
  private bool is_dragging = false;
  public void OnPointerDown(PointerEventData eventData)
  {
    is_dragging = true;
  }
  void FixedUpdate()
  {
    if (tics < tics_to_drag && is_dragging)
      tics++;
    if (tics >= tics_to_drag)
     transform.position = Input.mousePosition;
  }
  public void OnPointerUp(PointerEventData eventData)
  {
    is_dragging = false;
    tics = 0;
  }
}
