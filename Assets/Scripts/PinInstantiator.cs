using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class PinInstantiator : MonoBehaviour
{
  [SerializeField] private Transform pin_parent;

  [SerializeField] private GameObject default_pin_prefab;

  [SerializeField] private string default_pin_name;
  [SerializeField] private string default_pin_description;
  [SerializeField] private Sprite default_pin_image;
  [SerializeField] private Sprite default_pin_icon;
  public void instantiatePin(Vector3 position, string name, string description, Sprite image, Sprite icon, bool is_saved)
  {
    GameObject new_pin_object = Instantiate(default_pin_prefab, pin_parent);

    PinInfo new_pin = new_pin_object.GetComponent<PinInfo>();
    new_pin.Name = name;
    new_pin.Description = description;
    new_pin.Image = image;
    new_pin.Icon = icon;
    new_pin.Position = new Vector3(position.x, position.y, Camera.main.nearClipPlane);
    new_pin.is_saved = is_saved;
  }
  public void instantiateNewPin()
  {
    instantiatePin
      (Camera.main.ScreenToWorldPoint(Input.mousePosition),
      default_pin_name, 
      default_pin_description, 
      default_pin_image, 
      default_pin_icon, 
      false);
  }
}
