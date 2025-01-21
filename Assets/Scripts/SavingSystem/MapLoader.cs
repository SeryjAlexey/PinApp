using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
  [SerializeField] private PinInstantiator pinInstantiator;
  string path;
  void Start()
  {
    path = Application.persistentDataPath + "data.json";
    if (!File.Exists(path) || File.ReadAllText(path).Length == 0) { return; }
    string json = File.ReadAllText(path);
    List<SavablePin> pin_list = JsonUtility.FromJson<PinListWrapper>(json).pins;
    foreach (SavablePin pin in pin_list)
    {
      Vector3 new_position = new Vector3(pin.position[0], pin.position[1], Camera.main.nearClipPlane);
      Sprite new_image = Resources.Load<Sprite>("Sprites/Images/" + pin.image_name);
      Sprite new_icon = Resources.Load<Sprite>("Sprites/Icons/" + pin.icon_name);
      pinInstantiator.instantiatePin(new_position, pin.name, pin.description, new_image, new_icon, pin.is_saved);
    }
  }
}
