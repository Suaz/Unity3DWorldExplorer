using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;


public class WiningController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject WiningPanel;
    [SerializeField] TextMeshProUGUI starCounter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StringBuilder s = new StringBuilder("");
            s.AppendFormat("Conseguiste {0} monedas", GameController.Instance.stars);

            WiningPanel.SetActive(true);
            starCounter.SetText(s);
        }
    }
}
