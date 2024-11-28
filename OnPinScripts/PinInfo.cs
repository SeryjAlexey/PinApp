using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinInfo : MonoBehaviour
{
  [SerializeField] private new TextMeshProUGUI name;
  [SerializeField] private TextMeshProUGUI name_placeholder;
  [SerializeField] private TextMeshProUGUI description_placeholder;
  [SerializeField] private TextMeshProUGUI description;
  [SerializeField] private Image image;
  [SerializeField] private Image icon;

  public string Name { get { return name.text; } set { name_placeholder.text = value; } }
  public Vector3 Position { get { return transform.position; } set { transform.position = value; } }
  public Sprite Image { get { return image.sprite; } set { image.sprite = value; } }
  public Sprite Icon { get { return icon.sprite; } set { icon.sprite = value; } }
  public string Description { get { return description.text; } set { description_placeholder.text = value; } }
  public bool is_saved = false;

  
}
