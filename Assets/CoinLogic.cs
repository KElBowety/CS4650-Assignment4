using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    private float speed, height, rotation;
    [SerializeField] float lifespan;

    void Start()
    {
        speed = 5f;
        height = 0.25f;
        rotation = 45f;
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * height + 1f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        transform.Rotate(0, rotation * Time.deltaTime, 0);
    }
}

