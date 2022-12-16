using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilling : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] EnemyWalkController walkController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Debug.Log("DYING");
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(PrepareDie());
    }


    IEnumerator PrepareDie()
    {
        animator.SetTrigger("Die");
        walkController.Die();
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
