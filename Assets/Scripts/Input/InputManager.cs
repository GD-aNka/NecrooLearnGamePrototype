using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

  

    public Vector2 GetMovement()
    { 
        return playerInputActions.Player.Move.ReadValue<Vector2>();
    }

    public bool IsJumpPressed()
    {
        return playerInputActions.Player.Jump.IsPressed();
    }

    public bool isPausePressed()
    {
        return playerInputActions.UI.Pause.WasPressedThisFrame();
    }
    public bool isMouseClicked()
    {
        return playerInputActions.UI.NextDialogue.WasPressedThisFrame();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
        playerInputActions.UI.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Player.Disable();
        playerInputActions.UI.Disable();
    }
}
