using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    // Start is called before the first frame update
    private Player playerInput;
    private Player.PlayerControllerActions playerControllerActions;
    public Vector3 movementInput;
    public float jumping ;

    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private Transform baseTransform;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private GameObject model;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;


    
    void Start()
    {
        playerInput = new Player();
        playerControllerActions = playerInput.PlayerController;
        playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveXAxis = playerControllerActions.MoveXAxis.ReadValue<float>();
        float moveZAxis = playerControllerActions.MoveZAxis.ReadValue<float>();
        jumping = playerControllerActions.Jump.ReadValue<float>();

        movementInput = new Vector3(moveXAxis, 0f, moveZAxis);

        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(movementInput) * speed;
        rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);
        if(moveVector.x!=0 || moveVector.z != 0)
        {
            animator.SetBool("Walk Forward", true);
        }
        else
        {
            animator.SetBool("Walk Forward", false);
        }
        RotateModel();
        if (jumping > 0)
        {
            if(Physics.CheckSphere(baseTransform.position, 0.1f,FloorMask))
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void RotateModel()
    {
        if (movementInput.x == 0 && movementInput.z > 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (movementInput.x > 0 && movementInput.z > 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }

        if (movementInput.x > 0 && movementInput.z == 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        if (movementInput.x > 0 && movementInput.z < 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
        }

        if (movementInput.x == 0 && movementInput.z < 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (movementInput.x<0 && movementInput.z < 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, -135, 0));
        }

        if (movementInput.x < 0 && movementInput.z == 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }

        if (movementInput.x < 0 && movementInput.z > 0)
        {
            model.transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));
        }
    }
}
