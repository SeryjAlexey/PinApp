using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//THIS SCRIPT GOES ON MAP
public class MapDragger : MonoBehaviour, IDragHandler, IPointerDownHandler
{
  private Vector2 last_cursor_position = Vector2.zero;
  public void OnDrag(PointerEventData eventData)
  {
    Camera.main.transform.position -= (Vector3)(eventData.position - last_cursor_position);
    last_cursor_position = eventData.position;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    last_cursor_position = eventData.position;
  }
}
