using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    //public CameraController OrbitCamera;
    public Transform CameraFollowPoint;

    public MyCharacterController CharacterRed;
    [SerializeField] private Animator animatorRed;


    public MyCharacterController CharacterBlue;
    [SerializeField] private Animator animatorBlue;


    public MyCharacterController Character;
    [SerializeField] private Animator animator;


    private Player playerInput;
    private Player.PlayerControllerActions playerControllerActions;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        if(GameController.Instance.Character == "BLUE")
        {
            CharacterRed.gameObject.SetActive(false);
            CharacterBlue.gameObject.SetActive(true);
            Character = CharacterBlue;
            animator = animatorBlue;
        }
        else
        {
            CharacterRed.gameObject.SetActive(true);
            CharacterBlue.gameObject.SetActive(false);
            Character = CharacterRed;
            animator = animatorRed;
        }

        playerInput = new Player();
        playerControllerActions = playerInput.PlayerController;

        playerInput.PlayerController.Jump.started += Movement_started;
        playerInput.PlayerController.Jump.performed += Movement_performed;
        playerInput.Enable();

    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //}

        HandleCharacterInput();
    }

    private void LateUpdate()
    {
        HandleCameraInput();
    }

    private void HandleCameraInput()
    {
    }

    private void HandleCharacterInput()
    {
        PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

        characterInputs.MoveAxisForward = playerControllerActions.MoveZAxis.ReadValue<float>();
        characterInputs.MoveAxisRight = playerControllerActions.MoveXAxis.ReadValue<float>();
        characterInputs.JumpDown = playerControllerActions.Jump.triggered;
        //characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
        characterInputs.Throw = playerControllerActions.Throw.triggered;
        

        if (characterInputs.MoveAxisForward != 0f || characterInputs.MoveAxisRight != 0f)
        {
            animator.SetBool("Walk Forward", true);
        }
        else
        {
            animator.SetBool("Walk Forward", false);
        }

        if (characterInputs.Throw)
        {
            animator.SetTrigger("Throw");
        }

        // Apply inputs to character
        Character.SetInputs(ref characterInputs);
    }


    private void Movement_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //movementDirection = obj.ReadValue<float>();
        Debug.Log("Movement action started.");
    }
    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Movement action performed.");
    }
    private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //Debug.Log("Movement action canceled.");
    }
}
