using UnityEngine;

public class PinInstantiator : MonoBehaviour
{
  public void instantiatePin(Vector3 position, string name, string description, Sprite image, Sprite icon, bool is_saved)
  {
    GameObject new_pin_object = Instantiate(Info.placed_pin_prefab, transform);
    PinInfo new_pin = new_pin_object.GetComponent<PinInfo>();

    new_pin.Name = name;
    new_pin.Description = description;
    new_pin.Image = image;
    new_pin.Icon = icon;
    new_pin.Position = position;
    new_pin.is_saved = is_saved;
    new_pin.Position = position;
  }
}
