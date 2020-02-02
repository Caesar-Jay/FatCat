using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameScore gameManager;

    private bool chase;
    private float timer;
    private Transform target;
    private float moveTimer;
    private Task task;
    private bool moving;

    void Start()
    {

    }

    void Update()
    {
    }

    IEnumerator Move()
    {
        while (chase)
        {
            timer -= Time.deltaTime;

            if (Physics.Linecast(transform.position, target.position, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag.Equals("Player"))
                {
                    if (hit.distance < 0.25)
                        gameManager.GameOver();

                    transform.position = Vector3.MoveTowards(transform.position, target.position, 0.005f);
                    timer = 3f;
                }
                Debug.DrawRay(transform.position, target.position * hit.distance, Color.yellow);
                Debug.DrawLine(transform.position, target.position, Color.blue);
            }

            if(timer <= 0)
            {
                chase = false;
                AudioController.audioController.SetMusic("Idle");
            }

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Physics.Linecast(transform.position, other.transform.position, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag.Equals("Player"))
                {
                        
                    if(chase == false)
                    {
                        AudioController.audioController.SetMusic("Chase");
                    }

                    chase = true;
                    timer = 3f;
                    target = other.transform;
                    if (task == null || task.Running == false)
                        task = new Task(Move());
                }
                Debug.DrawRay(transform.position, target.position * hit.distance, Color.yellow);
                Debug.DrawLine(transform.position, target.position, Color.blue);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {

            if (Physics.Linecast(transform.position, other.transform.position, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag.Equals("Player"))
                {
                    if (chase == false)
                        AudioController.audioController.SetMusic("Chase");

                    chase = true;
                    timer = 3f;
                    target = other.transform;
                    if (task == null || task.Running == false)
                        task = new Task(Move());
                }
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
            Debug.DrawLine(transform.position, target.position, Color.white);
        }
    }
}
