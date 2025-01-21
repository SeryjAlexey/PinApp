using UnityEngine;
using UnityEngine.EventSystems;

public class PinMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
  [SerializeField] private float tics_to_drag;
  private float tics = 0;
  private bool is_dragging = false;

  private PinTweener pin_tweener;
  private void Start()
  {
    pin_tweener = GetComponent<PinTweener>();
  }
  public void OnPointerDown(PointerEventData eventData)
  {
    is_dragging = true;
    pin_tweener.IsLocked++;
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (tics < tics_to_drag && is_dragging)
      tics++;
    if (tics >= tics_to_drag)
    {
      Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      transform.position = new Vector3(worldPosition.x, worldPosition.y, Camera.main.nearClipPlane);
    }
  }
  public void OnPointerUp(PointerEventData eventData)
  {
    is_dragging = false;
    tics = 0;
    pin_tweener.IsLocked--;
  }
}
