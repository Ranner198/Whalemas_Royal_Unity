using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advertistments : MonoBehaviour
{
    public List<GameObject> adSigns = new List<GameObject>();
    public GameObject ad1, ad2;    
    public void Start()
    {
        Quaternion rotation = Quaternion.Euler(-82.771f, -180, 90);
        int rand = GenerateRandom(adSigns.Count-1), rand2 = GenerateRandom(adSigns.Count-1);
        GameObject temp = Instantiate(adSigns[rand], ad1.transform.position, rotation);
        temp.transform.SetParent(transform);        
        temp = Instantiate(adSigns[rand2], ad2.transform.position, rotation);
        temp.transform.SetParent(transform);
    }

    public int GenerateRandom(int max)
    {
        return Random.Range(0, max);
    }
}

