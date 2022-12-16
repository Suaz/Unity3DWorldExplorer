using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyFireball());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DestroyFireball()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
