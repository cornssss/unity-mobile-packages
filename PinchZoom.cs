
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class CanvasPinch : MonoBehaviour
{
  private Vector2 initialTouch1Position;
  private Vector2 initialTouch2Position;
  private float multiplier = 0f;
  float initialDistance, currentDistance, pinchScale;

  private Controller controller;

  private void Awake() {
    controller = FindObjectOfType<Controller>();
  }

  public void InitPinch()
  {
    if (Touch.activeTouches.Count != 2) return;
      {
          // Get the current touch positions
          Vector2 currentTouch1Position = Touch.activeTouches[0].screenPosition;
          Vector2 currentTouch2Position = Touch.activeTouches[1].screenPosition;

          initialTouch1Position = currentTouch1Position;
          initialTouch2Position = currentTouch2Position;
          // Calculate the pinch distance based on the initial and current touch positions
          initialDistance = Vector2.Distance(initialTouch1Position, initialTouch2Position);
          currentDistance = Vector2.Distance(currentTouch1Position, currentTouch2Position);

          // Calculate the pinch scale
          pinchScale = currentDistance / initialDistance;
          multiplier = pinchScale * controller.Zoom;
      }
  }
  public void StartPinch()
  {
    if (Touch.activeTouches.Count != 2) return;
    float initialDistance, currentDistance, pinchScale;
    // Get the current touch positions
    Vector2 currentTouch1Position = Touch.activeTouches[0].screenPosition;
    Vector2 currentTouch2Position = Touch.activeTouches[1].screenPosition;

    // Calculate the pinch distance based on the initial and current touch positions
    initialDistance = Vector2.Distance(initialTouch1Position, initialTouch2Position);
    currentDistance = Vector2.Distance(currentTouch1Position, currentTouch2Position);

    // Calculate the pinch scale
    pinchScale = multiplier/(currentDistance / initialDistance);

    // Apply the pinch scale to your UI elements or perform any other pinch-related logic
    controller.HandleZoom2(pinchScale);
  }
}
