using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform coinTransform;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.Instance.AddStar();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinTransform.Rotate(0, 60f * Time.deltaTime, 0, Space.World);
    }
}
