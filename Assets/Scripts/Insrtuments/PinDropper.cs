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
    FindAnyObjectByType<PinInstantiator>().instantiateNewPin();
    transform.position = start_position;
  }
  public void OnPointerDown(PointerEventData eventData)
  {
  }
}
