using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkController : MonoBehaviour
{
	[SerializeField] Vector3[] points;
	[SerializeField] NavMeshAgent agent;
    [SerializeField] Transform caster;
    [SerializeField] Transform playerRed;
    [SerializeField] Transform playerBlue;
    [SerializeField] Transform player;
    [SerializeField] Animator animator;

    bool hunting = false;
    bool dead = false;

    int currentIndex = 0;
    void Start()
    {
        if (GameController.Instance.Character == "RED")
        {
            player = playerRed;
        }
        else
        {
            player = playerBlue;
        }
        Patroll();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hunting && ! dead)
        {
            float distance = Vector3.Distance(agent.transform.position, points[currentIndex]);
            if (distance < 0.5f)
            {
                currentIndex++;
                if (currentIndex >= points.Length)
                { currentIndex = 0; }
                Patroll();
            }
        }
        
        CheckPlayer();

        if (animator)
        {
            float velocity = agent.velocity.magnitude;
            animator.SetBool("Walk Forward", velocity > 0);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i], 0.2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        }
    }

    private void OnCollisionStay(Collision collision)
    {
    }

    void Patroll()
    {
        agent.destination = points[currentIndex];
    }

    void CheckPlayer()
    {
        if (dead)
            return;

        Ray myRay = new Ray(caster.position,
            (new Vector3(player.position.x,
            caster.position.y,
            player.position.z) - caster.position).normalized);
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                hunting = true;
                agent.destination = player.position;
            }

            else
            {
                hunting = false;
                Patroll();
            }
        }
        else
        {
            hunting = false;
            Patroll();
        }
    }

    public void Die()
    {
        dead = true;
        agent.isStopped = true;
    }
}
