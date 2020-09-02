using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{

    //[Tooltip("Un spawn point par voie à placer au dessus de l'écran")]
    public Transform[] spawnPoints;

    //[Tooltip("Temps entre l'instantiation d'obstacle (+ du random pour pas que ce soit un temps fixe) - par défaut toutes les 3 secondes")]
    //public float timeBtwObstacles;
    public GameObject branche;

    List<int> list = new List<int>();

    void Start()
    {
        Spawn();

        /*if(timeBtwObstacles == 0)
        {
            timeBtwObstacles = 3;
        }*/
        
        //StartCoroutine(InstantiateObstacle());
    }

    void Spawn()
    {
        list = new List<int>(new int[3]);
        var rr = Random.Range(0, 2);
        if (rr == 0)
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
                if(spawnPoints[j - 1].transform.childCount != 0)
                {
                    Debug.Log("spawn point plein");
                }
                else
                {
                    Instantiate(branche, spawnPoints[j - 1]);
                }
                
            }

        }

    }

    /*IEnumerator InstantiateObstacle()
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
                //Debug.Log(list[j]);
                Instantiate(branche, spawnPoints[j - 1]);
            }
           
        }
        
        StartCoroutine(InstantiateObstacle());
    }*/
}
