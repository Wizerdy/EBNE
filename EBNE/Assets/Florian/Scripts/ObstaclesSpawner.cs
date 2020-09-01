using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    private float timeBtwObstacles;
    public GameObject branche;

    List<int> list = new List<int>();

    void Start()
    {
        timeBtwObstacles = 3;
        StartCoroutine(InstantiateObstacle());
    }

    IEnumerator InstantiateObstacle()
    {
        list = new List<int>(new int[3]);
        timeBtwObstacles += Random.Range(-.25f, .25f);
        //Debug.Log(timeBtwObstacles);
        yield return new WaitForSeconds(timeBtwObstacles);
        var rr = Random.Range(0, 2);
        if(rr == 0)
        {
            Instantiate(branche, spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }
        else
        {
            for (int j = 1; j < 3; j++)
            {
                var Rand = Random.Range(0, 4);

                while (list.Contains(Rand))
                {
                    Rand = Random.Range(0, 4);   
                }

                list[j] = Rand;
                Debug.Log(list[j]);
                Instantiate(branche, spawnPoints[j - 1]);
            }
           
        }
        
        timeBtwObstacles = 2;
        StartCoroutine(InstantiateObstacle());
    }
}
