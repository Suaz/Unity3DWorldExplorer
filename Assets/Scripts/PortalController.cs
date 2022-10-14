using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] public Transform spawnPoint;
    [SerializeField] private PortalController Destination;

    private Player playerInput;
    private Player.SceneControllerActions sceneControllerActions;

    private float isActionPressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new Player();
        sceneControllerActions = playerInput.SceneController;
        playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        isActionPressed = sceneControllerActions.Action1.ReadValue<float>();
        Debug.Log(isActionPressed);
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (isActionPressed > 0)
        {
            Debug.Log("Transporting");
            other.gameObject.transform.position = Destination.spawnPoint.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

}
