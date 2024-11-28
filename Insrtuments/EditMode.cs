using TMPro;
using UnityEngine;

public class EditMode : MonoBehaviour
{
  [SerializeField] TMP_InputField pin_name;
  [SerializeField] TMP_InputField description;

  public void editPin()
  {
    pin_name.interactable = !pin_name.interactable;
    description.interactable = !description.interactable;
  }
}
