using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInvoker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cloud;
    private IEnumerator invoker;

    private void Start()
    {
        invoker = InvokeCloud();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(invoker);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(invoker);
        }
    }

    IEnumerator InvokeCloud()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Instantiate(cloud, new Vector3(2f, 12f, 4f), Quaternion.identity);
        }
    }
}
