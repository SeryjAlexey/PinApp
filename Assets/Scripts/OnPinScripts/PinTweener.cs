using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class PinTweener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  [SerializeField] float animation_speed;
  [SerializeField] List<RectTransform> ui_elements_to_show_on_ponter_enter;
  [SerializeField] List<RectTransform> ui_elements_to_show_on_click;

  private int is_locked = 0;

  public int IsLocked { set { is_locked = value; } get { return is_locked; } }
  private void Start()
  {
    List<RectTransform> all_ui = ui_elements_to_show_on_click;
    all_ui.AddRange(ui_elements_to_show_on_ponter_enter);
    foreach(RectTransform rect in all_ui)
      MoveElementLeft(rect, 0);
  }
  public void OnPointerEnter(PointerEventData eventData)
  {
    if (is_locked > 0)
      return;
    foreach (RectTransform rect in ui_elements_to_show_on_ponter_enter)
      MoveElementRight(rect, animation_speed);
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    if (is_locked > 0)
      return;
    foreach (RectTransform rect in ui_elements_to_show_on_ponter_enter)
        MoveElementLeft(rect, animation_speed);
  }

  void MoveElementRight(RectTransform rect, float duration)
  {
    if (rect.localScale.x > 0)
      return;
    rect.DOMoveX(rect.position.x + rect.rect.width / 4, duration);
    rect.DOScaleX(1, duration).OnComplete(() =>
    {
      TextMeshProUGUI text = rect.GetComponentInChildren<TextMeshProUGUI>();
      if (text != null)
        text.DOFade(1, duration);
    }
    );
  }
  void MoveElementLeft(RectTransform rect, float duration)
  {
    if (rect.localScale.x < 1)
      return;
    rect.DOMoveX(rect.position.x - rect.rect.width / 4, duration);
    rect.DOScaleX(0, duration).OnComplete(() =>
    {
      TextMeshProUGUI text = rect.GetComponentInChildren<TextMeshProUGUI>();
      if (text != null)
        text.DOFade(0, 0);
    }
    );
  }
  public void OnClick()
  {
    if(is_locked == 0)
      foreach(RectTransform rect in ui_elements_to_show_on_click)
        MoveElementRight(rect, animation_speed);
    else foreach(RectTransform rect in ui_elements_to_show_on_click)
        MoveElementLeft(rect, animation_speed);
    is_locked += is_locked > 0 ? -1 : 1;
  }
}
