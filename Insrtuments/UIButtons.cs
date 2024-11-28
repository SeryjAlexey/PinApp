using UnityEngine;

public class UIButtons : MonoBehaviour
{
  public void Toggle(GameObject object_to_click)
  {
    object_to_click.SetActive(!object_to_click.activeSelf);
  }
}
