using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScroller : MonoBehaviour
{
  [SerializeField] private float scroll_sensetivity = 1;
  [SerializeField] private float max_camera_size;
  [SerializeField] private float min_camera_size;
  private void Update()
  {
    float mouseScrollDelta = Input.mouseScrollDelta.y;
    if(Camera.main.orthographicSize >= max_camera_size && mouseScrollDelta < 0)
      return;
    if(Camera.main.orthographicSize <= min_camera_size && mouseScrollDelta > 0)
      return;
    Camera.main.orthographicSize -= mouseScrollDelta * scroll_sensetivity;
  }
}
