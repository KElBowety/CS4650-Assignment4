using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerChaser = setPlayerChaser();
        GameObject objectChaser = null;

        foreach(GameObject enemy in enemies)
        {
            if(enemy != playerChaser)
            {
                if(objectChaser == null)
                {
                    objectChaser = enemy;

                    objectChaser.GetComponent<AiStateScript>().chasePlayer = false;
                    objectChaser.GetComponent<AiStateScript>().chaseObject = true;
                    objectChaser.GetComponent<AiStateScript>().wander = false;
                }
                else
                {
                    enemy.GetComponent<AiStateScript>().chasePlayer = false;
                    enemy.GetComponent<AiStateScript>().chaseObject = false;
                    enemy.GetComponent<AiStateScript>().wander = true;
                }
            }
        }
    }

    GameObject setPlayerChaser()
    {
        GameObject closest = enemies[0];
        float minDistance = Mathf.Infinity;
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(playerPos, enemy.transform.position);

            if (distance < minDistance)
            {
                closest = enemy;
                minDistance = distance;
            }
        }

        closest.GetComponent<AiStateScript>().chasePlayer = true;
        closest.GetComponent<AiStateScript>().chaseObject = false;
        closest.GetComponent<AiStateScript>().wander = false;

        return closest;
    }
}
