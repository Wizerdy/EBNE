using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Tooltip("Variable multiplié par la timeScale, plus elle est basse moins le temps s'accélerera vite et inversement - par défaut je l'ai mis à 1.0003." +
        "Vous pouvez regarder dans la console le time scale il est dispo.")]
    public float timeMultiplicator;

    [Tooltip("Coché la case si vous voulez activer les valeurs de la time scale dans la console")]
    public bool activeTimeScaleValue;

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
        if (activeTimeScaleValue)
        {
            Debug.Log(Time.timeScale);
        }
    }
}
