using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    GameObject prefab;
    [SerializeField] float frequency;

    void Start()
    {
        prefab = Resources.Load("GoldCoin") as GameObject;
        InvokeRepeating("Spawn", 0, frequency);
    }

    void Spawn()
    {
        GameObject spawned = Instantiate(prefab, new Vector3(Random.Range(-24, 24), 5f, Random.Range(-24, 24)), Quaternion.identity);
    }
}
