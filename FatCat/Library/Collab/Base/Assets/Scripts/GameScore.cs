using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public int score;
    public GameObject foodPile;
    public EatFood eatFoodScript;
    public SpawnerScript spawner;
    Text scoreText;

    private float timer = 1;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void GameOver()
    {
        // gameOver
    }

    void Update()
    {
        if (foodPile == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1;
                var food = spawner.SpawnFood();
                food.GetComponent<EatFood>().gameManager = this;
                foodPile = food;
            }
        }

        scoreText.text = "Score: " + score;

    }
}
