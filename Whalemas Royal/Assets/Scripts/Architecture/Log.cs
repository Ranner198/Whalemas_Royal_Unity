using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            coll.gameObject.GetComponent<Rigidbody>().velocity /= 2f;
        }
    }
}
