using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] ParticleSystem weapon;
    [SerializeField] ParticleSystem fireball;
    [SerializeField] Material weakMaterial;
    [SerializeField] Material strongMaterial;
    CoinScoreScript scoreScript;

    private bool down;
    private float start;
    private ParticleSystem.EmissionModule weaponEmission;

    void Start()
    {
        weapon.Stop();
        weaponEmission = weapon.emission;
        down = false;
        scoreScript = GetComponent<CoinScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreScript.CheckScore())
        {
            if (Input.GetMouseButtonDown(0))
            {
                scoreScript.DecreaseScore();
                start = Time.time;
                weaponEmission.rateOverTime = 2;
                fireball.GetComponent<Renderer>().material = weakMaterial;
                down = true;
            }
            if (down && Time.time - start > 2.5)
            {
                fireball.GetComponent<Renderer>().material = strongMaterial;
                weaponEmission.rateOverTime = 3;
            }
            if (Input.GetMouseButtonUp(0))
            {
                weapon.Play();
                down = false;
            }
        }
    }
}
