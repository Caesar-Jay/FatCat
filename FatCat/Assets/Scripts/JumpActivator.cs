using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpActivator : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Jumpable"))
        {
            GetComponent<JumpScript>().jumpPos = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Jumpable"))
        {
            var jumpPos = GetComponent<JumpScript>().jumpPos;
            if (jumpPos != null && jumpPos == other.transform)
                GetComponent<JumpScript>().jumpPos = null;
        }
    }

}
