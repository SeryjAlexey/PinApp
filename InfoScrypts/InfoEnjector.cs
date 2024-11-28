using System.Linq;
using UnityEngine;

public class InfoEnjector : MonoBehaviour
{
  public Sprite default_pin_image;
  public Sprite default_pin_icon;
  public string defaut_pin_name;
  public string defaut_pin_description;

  public GameObject placed_pin_prefab;
  private void Awake()
  {
    Info.defaut_pin_description = defaut_pin_description;
    Info.default_pin_icon = default_pin_icon;
    Info.default_pin_image = default_pin_image;
    Info.defaut_pin_name = defaut_pin_name;
    Info.placed_pin_prefab = placed_pin_prefab;

    Info.resources = Resources.LoadAll<Sprite>("Sprites").ToList();
  }
}
