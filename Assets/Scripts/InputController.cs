using UnityEngine;

/// <summary>
/// Simple event based input controller
/// </summary>
public class InputController : SingletonMono<InputController>
{
    public delegate void MouseDown(Vector3 mousePosition);
    public event MouseDown OnMouseDown;

    public delegate void MouseUp(Vector3 mousePosition);
    public event MouseUp OnMouseUp;
    void Update()
    {
        //Left mouse button events
        if (Input.GetMouseButtonDown(0))        
            OnMouseDown?.Invoke(Input.mousePosition);
        
        if (Input.GetMouseButtonUp(0))
            OnMouseUp?.Invoke(Input.mousePosition);
    }
}
