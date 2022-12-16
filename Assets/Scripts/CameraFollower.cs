using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform red;
    [SerializeField] Transform blue;
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 Offset;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.Character == "BLUE")
        {
            this.transform.position = blue.position + Offset;
        }
        else
        {
            this.transform.position = red.position + Offset;
        }
    }
}
