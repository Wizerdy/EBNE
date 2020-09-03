using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum Phase { First, Second, Third };

    [Tooltip("Variable multiplié par la timeScale, plus elle est basse moins le temps s'accélerera vite et inversement - par défaut je l'ai mis à 1.0003." +
        "Vous pouvez regarder dans la console le time scale il est dispo.")]
    public float timeMultiplicator;

    [Tooltip("Coché la case si vous voulez activer les valeurs de la time scale dans la console")]
    public bool activeTimeScaleValue;

    public ScoreManager scoreManager;
    public Phase phase;

    [Header("Third phase")]
    [SerializeField] private Transform thirdParent;
    [SerializeField] private ThirdManager thirdManager;

    [Tooltip("Multiplication du temps max (4 c'est vraiment l'idéal après avoir test un bon nombre de fois).")]
    public float gameMultiplicatorMax;

    private float timeScaleBackup;

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1;

        if(timeMultiplicator == 0)
        {
            timeMultiplicator = 1.0003f;
        }

        phase = Phase.First;
        //StartThird();
    }

    
    void Update()
    {
        if(Time.timeScale <= gameMultiplicatorMax)
        {
            Time.timeScale *= timeMultiplicator;
        }
        
        if (activeTimeScaleValue)
        {
            Debug.Log(Time.timeScale);
        }
    }

    public void StartThird()
    {
        phase = Phase.Third;
        thirdParent.gameObject.SetActive(true);
        //thirdManager.launch();
    }

    public void Restart()
    {
        // Restart
    }

    public void TriggerPause()
    {
        if (Time.timeScale > 0)
        {
            timeScaleBackup = Time.timeScale;
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = timeScaleBackup;
        }
    }
}
