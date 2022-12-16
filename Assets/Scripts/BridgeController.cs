using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject nextBridge;
    [SerializeField] bool Keept = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(nextBridge)
                nextBridge.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( !Keept && other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator DisableBridge()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
