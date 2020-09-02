using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Tooltip("Variable multiplié par la timeScale, plus elle est basse moins le temps s'accélerera vite et inversement - par défaut je l'ai mis à 1.0003." +
        "Vous pouvez regarder dans la console le time scale il est dispo.")]
    public float timeMultiplicator;

    void Start()
    {
        Time.timeScale = 1;

        if(timeMultiplicator == 0)
        {
            timeMultiplicator = 1.0003f;
        }
    }

    
    void Update()
    {
        Time.timeScale *= timeMultiplicator;
        Debug.Log(Time.timeScale);
    }
}
