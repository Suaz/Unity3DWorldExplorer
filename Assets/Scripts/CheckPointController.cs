using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
	// Start is called before the first frame update
		[SerializeField] GameObject glow;
	[SerializeField] bool active; 
	[SerializeField] AudioSource audio;
   
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		glow.SetActive(false);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DyingValidator validator = other.gameObject.GetComponent<DyingValidator>();
	        validator.SetCheckPoint(this.transform);
	        glow.SetActive(true);
	        audio.Play();
        }
        
    }
}
