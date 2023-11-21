
/// <summary>
/// What happens here?
/// 
/// On InitPinch, initial values are stored like position of 2 touches so that
/// the next positions fr each frame has reference to it and make a scale of 
/// zoom.
/// 
/// StartPinch is called every frame where two touches drags on the screen.
/// The method generates a pinch scale value to scale the current camera's 
/// orthographic size.
/// 
/// Most likely, you can use pinch scale variable to change the value of 
/// orthographic size of camera or the distance of it in single axis.
/// </summary>

  //To use PinchZoom, 

  //First, create a UI Panel to the hirarchy,

  //Second, add a trigger events component to the UI Panel

  //Add the following events: OnBeginDrag and OnDrag

  //Lastly,drop the InitPinch to OnBeginDrag and drop StartPinch to OnDrag;


using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

//NOTE: This api uses a EnhancedTouch of New Input System.

public class CanvasPinch : MonoBehaviour
{
  private Vector2 initialTouch1Position;
  private Vector2 initialTouch2Position;
  private float multiplier = 0f;
  float initialDistance, currentDistance, pinchScale;

  private Controller controller;

  private void Awake() {
    //This is not required, you can reference pinchscale to your own scripts
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

          // Calculate the initial pinch scale
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
