using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableScript : MonoBehaviour
{
    public GameScore gameManager;
    public Sprite sprite;
    private bool destroyed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (destroyed)
                return;
            gameManager.score++;
            AudioController.audioController.PlayEffect(this.name);
            GetComponent<SpriteRenderer>().sprite = sprite;
            destroyed = true;
        }
    } 
}
