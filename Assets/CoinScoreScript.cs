using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScoreScript : MonoBehaviour
{
    int score;
    [SerializeField] Text text;

    void Start()
    {
        score = 5;
        UpdateScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            score++;
            UpdateScore();
            Destroy(other.gameObject);
        }
    }

    void UpdateScore()
    {
        text.text = "MP: " + score;
    }

    public void DecreaseScore()
    {
        score--;
        UpdateScore();
    }

    public bool CheckScore()
    {
        if(score > 0)
        {
            return true;
        }
        return false;
    }
}
