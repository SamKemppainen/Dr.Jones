using UnityEngine;

/// <summary>
/// Player controlled character
/// </summary>
public class PlayerCharacter : AgentCharacter
{
    protected override void Awake()
    {
        base.Awake();
        ListenInput(true);
    }

    protected void ListenInput(bool inputActive)
    {
        if (inputActive)
        {
            InputController.Instance.OnMouseDown += InputController_OnMouseDown;
        }
        else
        {
            InputController.Instance.OnMouseDown -= InputController_OnMouseDown;
        }
    }

    private void InputController_OnMouseDown(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(hit.point, hit.point + Vector3.up, Color.green, .1f);
            
            agent.SetDestination(hit.point);
        }
    }
}
