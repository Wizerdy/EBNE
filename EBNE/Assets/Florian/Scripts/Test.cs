using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   
    int Lenght = 6;
    List<int> list = new List<int>();

    void Start()
    {
        list = new List<int>(new int[Lenght]);

        for (int j = 1; j < Lenght; j++)
        {
            var Rand = Random.Range(1, 6);

            while (list.Contains(Rand))
            {
                Rand = Random.Range(1, 6);
            }

            list[j] = Rand;
            Debug.Log(list[j]);
        }

    }
}
