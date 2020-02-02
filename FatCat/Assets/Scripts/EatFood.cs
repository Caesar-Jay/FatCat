using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EatFood : MonoBehaviour
{
    public GameScore gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            var player = other.GetComponentInChildren<PlayerMovement>();

            if (player.movementSpeed > 0.6f)
                player.movementSpeed -= 0.1f;

            player.GetFatter();

            gameManager.score++;
            //gameManager.foodPile = null;
            Destroy(this.gameObject);
        }
    }
}
