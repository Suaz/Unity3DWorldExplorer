using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDecorator : MonoBehaviour
{
    [SerializeField] bool allowDecoration = true;
    [SerializeField] GameObject[] decorations;
    [SerializeField] GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        if (allowDecoration && decorations.Length > 0)
        {
            int i = Random.Range(0, decorations.Length);
            if (Random.Range(0, decorations.Length * 3) < decorations.Length)
            {
                Debug.Log(this.transform);
                Instantiate(decorations[i], new Vector3(model.transform.position.x, 0.5f, model.transform.position.z), model.transform.rotation);
            }
        }
    }
}
