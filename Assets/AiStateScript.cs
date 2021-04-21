using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiStateScript : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public bool chasePlayer, chaseObject, wander;
    bool stunned, wanderEnter;
    [SerializeField] AnimationClip scream;
    Vector3 pos;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        chasePlayer = false;
        chaseObject = false;
        wander = false;
        wanderEnter = false;
        stunned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasePlayer)
        {
            ChasePlayer();
        }
        else if (chaseObject)
        {
            ChaseObject();
        }
        else if (wander)
        {
            animator.SetBool("chasingPlayer", false);
            animator.SetBool("chasingObject", false);
            animator.SetBool("wandering", true);
            SetWander();
        }
    }

    void ChasePlayer()
    {
        wanderEnter = false;

        animator.SetBool("chasingPlayer", true);
        animator.SetBool("chasingObject", false);
        animator.SetBool("wandering", false);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Running Crawl"))
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        else
        {
            agent.ResetPath();
        }
    }

    void ChaseObject()
    {
        wanderEnter = false;

        animator.SetBool("chasingPlayer", false);
        animator.SetBool("chasingObject", true);
        animator.SetBool("wandering", false);

        agent.SetDestination(GameObject.FindGameObjectWithTag("Coin").transform.position);
    }

    void SetWander()
    {
        if(agent.remainingDistance < 0.5f)
        {
            wanderEnter = false;
        }
        if (!wanderEnter)
        {
            wanderEnter = true;
            pos = new Vector3(Random.Range(-24, 24), 0, Random.Range(-24, 24));
            agent.SetDestination(pos);
        }
    }

    public void AddStun()
    {
        if (!stunned)
        {
            stunned = true;
            agent.speed = 0.5f;
            animator.speed = 0.5f;
            Invoke("RemoveStun", 4f);
        }
    }

    void RemoveStun()
    {
        stunned = false;
        agent.speed = 1;
        animator.speed = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }
}
