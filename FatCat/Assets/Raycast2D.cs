//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Raycast2D : MonoBehaviour
//{

//    public class finalDeteced = 

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        //precompute our ray settings
//        Vector3 start = transform.position;
//        Vector3 direction = (finalDetected.transform.position - transform.position).normalized;
//        float distance = detectionOptions.detectionRange;

//        //draw the ray in the editor
//        Debug.DrawRay(start, direction * distance, Colors.Red);

//        //do the ray test
//        RaycastHit2D sightTest = Physics2D.Raycast(start, direction, distance);
//        if (sightTest.collider != null)
//        {
//            if (sightTest.collider.gameObject != gameObject)
//            {
//                finalDetected = null;
//                Debug.Log("Rigidbody collider is: " + sightTest.collider);
//            }
//        }

//    }
//}
