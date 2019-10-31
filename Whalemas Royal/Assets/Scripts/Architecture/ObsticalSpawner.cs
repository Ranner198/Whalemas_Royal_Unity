using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalSpawner : MonoBehaviour
{
    public List<GameObject> spawnPositions = new List<GameObject>();
    public List<GameObject> spawnableObjects = new List<GameObject>();

    public void Start()
    {
        foreach (GameObject spawnPoint in spawnPositions)
        {
            int rand = GenerateRandom(spawnableObjects.Count-1);
            if (spawnableObjects[rand] != null)
            {
                GameObject temp = Instantiate(spawnableObjects[rand], spawnPoint.transform);
                temp.transform.localPosition = Vector3.zero;

                switch (rand)
                {
                    case 0:
                        temp.transform.localRotation = Quaternion.identity;
                        break;

                    default:
                    case 2:
                    case 1:
                        temp.transform.localRotation = Quaternion.Euler(-172, 180, 90);
                        break;
                }                
                temp.name = spawnableObjects[rand].name;                
            }
            spawnableObjects.RemoveAt(rand);
        }
    }

    public int GenerateRandom(int max)
    {
        return Random.Range(0, max);
    }
}
