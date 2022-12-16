using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilities : MonoBehaviour
{
    private Player playerInput;
    private Player.PlayerControllerActions playerControllerActions;
    private bool playerThrow = false;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new Player();
        playerControllerActions = playerInput.PlayerController;
        playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool moveXAxis = playerControllerActions.Throw.triggered;
        if (moveXAxis){
            animator.SetTrigger("Throw");
        }

    }
}
