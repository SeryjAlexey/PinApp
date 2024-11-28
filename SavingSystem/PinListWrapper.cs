using System.Collections.Generic;

[System.Serializable]
public class PinListWrapper
{
  public List<SavablePin> pins;
  public PinListWrapper(List<SavablePin> pins)
  {
    this.pins = pins;
  }
}