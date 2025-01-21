using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PinSaverAndDeleter : MonoBehaviour
{
  private string path;
  void Start()
  {
    path = Application.persistentDataPath + "data.json";
  }
  public void DeletePin()
  {
    PinInfo pin_info = transform.GetComponent<PinInfo>();
    if (pin_info.is_saved)
      DeleteFromSave();
    Destroy(gameObject);
  }

  public void SavePin()
  {
    PinInfo pin_info = transform.GetComponent<PinInfo>();
    if (pin_info.is_saved)
      DeleteFromSave();
    List<SavablePin> pin_list;
    if (File.Exists(path) && File.ReadAllText(path).Length > 0)
    {
      string json = File.ReadAllText(path);
      pin_list = JsonUtility.FromJson<PinListWrapper>(json).pins;
    }
    else pin_list = new List<SavablePin>();
    SavablePin savable_pin = new SavablePin(pin_info)
    {
      is_saved = true
    };
    pin_info.is_saved = true;
    pin_list.Add(savable_pin);
    string jsonOutput = JsonUtility.ToJson(new PinListWrapper(pin_list), true);
    File.WriteAllText(path, jsonOutput);
  }


  private void DeleteFromSave()
  {
    PinInfo pin_info = transform.GetComponent<PinInfo>();
    Debug.Log(pin_info.Name);
    string json = File.ReadAllText(path);
    List<SavablePin> pin_list = JsonUtility.FromJson<PinListWrapper>(json).pins;
    SavablePin savable_pin = new SavablePin(pin_info);
    if (pin_list.Count == 1)
    {
      File.WriteAllText(path, "");
      return;
    }
    for (int i = 0; i < pin_list.Count; i++)
    {
      if (pin_list[i].name == savable_pin.name)
      {
        pin_list.RemoveAt(i);
        break;
      }
    }
    string jsonOutput = JsonUtility.ToJson(new PinListWrapper(pin_list), true);
    File.WriteAllText(path, jsonOutput);
  }
}
