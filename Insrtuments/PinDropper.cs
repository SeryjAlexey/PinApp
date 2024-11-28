using UnityEngine;
using UnityEngine.EventSystems;

public class PinDropper : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
  private Vector3 start_position;
  private void Start()
  {
    start_position = transform.position;
  }
  public void OnDrag(PointerEventData eventData)
  {
    transform.position = eventData.position;
  }
  public void OnPointerUp(PointerEventData eventData)
  {
    foreach (Collider2D area_collider in FindObjectsOfType<Collider2D>())
    {
      if (area_collider.bounds.Contains(transform.position))
      {
        FindAnyObjectByType<PinInstantiator>().instantiatePin(Input.mousePosition, Info.defaut_pin_name, Info.defaut_pin_description, Info.default_pin_image, Info.default_pin_icon, false);
        break;
      }
    }
    transform.position = start_position;
  }
  public void OnPointerDown(PointerEventData eventData)
  {
  }
}
