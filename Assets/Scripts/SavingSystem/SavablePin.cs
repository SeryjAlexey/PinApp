[System.Serializable]
public class SavablePin
{
  public float[] position;
  public string name;
  public string description;
  public string image_name;
  public string icon_name;
  public bool is_saved = false;
  public SavablePin(PinInfo pin)
  {
    position = new float[2];
    position[0] = pin.Position.x;
    position[1] = pin.Position.y;
    name = pin.Name;
    description = pin.Description;
    image_name = pin.Image.name;
    icon_name = pin.Icon.name;
    is_saved = pin.is_saved;
  }
}
