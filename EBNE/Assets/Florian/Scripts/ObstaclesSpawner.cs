using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{

    //[Tooltip("Un spawn point par voie à placer au dessus de l'écran")]
    public Transform[] spawnPoints;

    public bool isDarkPart;

    //[Tooltip("Temps entre l'instantiation d'obstacle (+ du random pour pas que ce soit un temps fixe) - par défaut toutes les 3 secondes")]
    //public float timeBtwObstacles;
    public GameObject branche;

    List<int> list = new List<int>();

    Sprite[] obstaclesSprites;

    public GameObject[] deco;
    public Transform[] spDecoLeft;
    public Transform[] spDecoRight;

    void Start()
    {
        obstaclesSprites = Resources.LoadAll<Sprite>("Assets/Obstacles/Outside");

        Spawn();

        /*if(timeBtwObstacles == 0)
        {
            timeBtwObstacles = 3;
        }*/
        
        //StartCoroutine(InstantiateObstacle());
    }

    void Spawn()
    {
        if (!isDarkPart)
        {
            Ponder();
            Deco1();
            Deco2();
        }
        else
        {
            //Ponder();
        }
    }

    void Deco1()
    {
        var rr = Random.Range(0, 2);

        if (rr == 0)
        {
            int random = Random.Range(0, deco.Length);
            int rand2 = Random.Range(0, spDecoLeft.Length);
            //Debug.LogError(random + " .. " + deco.Length + " // " + rand2 + " .. " + spDecoLeft.Length);
            Instantiate(deco[random], spDecoLeft[rand2].transform);
        }
    }

    void Deco2()
    {
        var rr = Random.Range(0, 2);

        if (rr == 0)
        {
            int random = Random.Range(0, deco.Length);
            int rand2 = Random.Range(0, spDecoLeft.Length);
            //Debug.LogError(random + " .. " + deco.Length + " // " + rand2 + " .. " + spDecoLeft.Length);
            GameObject insta = Instantiate(deco[random], spDecoRight[rand2].transform);
            insta.transform.localEulerAngles = new Vector3(180, 0 , 180);
        }
    }

    //void Spawn()
    //{
    //    if (!isDarkPart)
    //    {
    //        list = new List<int>(new int[3]);
    //        var rr = Random.Range(0, 2);
    //        if (rr == 0)
    //        {
    //            Instantiate(branche, spawnPoints[Random.Range(0, spawnPoints.Length)]);
    //        }
    //        else
    //        {
    //            for (int j = 1; j < 3; j++)
    //            {
    //                var Rand = Random.Range(0, 4);

    //                while (list.Contains(Rand))
    //                {
    //                    Rand = Random.Range(0, 4);
    //                }

    //                list[j] = Rand;
    //                if (spawnPoints[j - 1].transform.childCount != 0)
    //                {
    //                    Debug.Log("spawn point plein");
    //                }
    //                else
    //                {
    //                    Instantiate(branche, spawnPoints[j - 1]);
    //                }

    //            }

    //        }
    //    }
    //    else
    //    {
    //        list = new List<int>(new int[3]);
    //        var rr = Random.Range(0, 2);
    //        if (rr == 0)
    //        {
    //            Instantiate(branche, spawnPoints[Random.Range(0, spawnPoints.Length)]);
    //        }
    //        else
    //        {
    //            for (int j = 1; j < 3; j++)
    //            {
    //                var Rand = Random.Range(0, 4);

    //                while (list.Contains(Rand))
    //                {
    //                    Rand = Random.Range(0, 4);
    //                }

    //                list[j] = Rand;
    //                if (spawnPoints[j - 1].transform.childCount != 0)
    //                {
    //                    Debug.Log("spawn point plein");
    //                }
    //                else
    //                {
    //                    Instantiate(branche, spawnPoints[j - 1]);
    //                }

    //            }

    //        }
    //    }
    //}

    private void InstantiareBranche(Transform parent)
    {
        GameObject insta = Instantiate(branche, parent);
        insta.GetComponent<SpriteRenderer>().sprite = obstaclesSprites[Random.Range(0, obstaclesSprites.Length)];
    }

    private void Ponder()
    {
        list = new List<int>(new int[3]);
        var rr = Random.Range(0, 2);
        if (rr == 0)
        {
            InstantiareBranche(spawnPoints[Random.Range(0, spawnPoints.Length)]);
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
                if (spawnPoints[j - 1].transform.childCount != 0)
                {
                    //Debug.Log("spawn point plein");
                }
                else
                {
                    InstantiareBranche(spawnPoints[j - 1]);
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
