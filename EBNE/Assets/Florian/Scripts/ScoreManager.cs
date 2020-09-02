using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text moneyText;

    private float score;
    private int money;
    [Tooltip("Nombre de score à ajouter lors de l'obtention d'un gland")]
    public float glandIncreScore;
    [Tooltip("La valeur à incrémenter au score chaque frame autrement dit la vitesse à laquelle monte le score")]
    public float increScoreTime;

    void Start()
    {
        score = 0;
        money = 0;
    }

    public void GotGland()
    {
        money++;
        score += glandIncreScore;
        moneyText.text = "" + money;
    }

    private void Update()
    {
        score += increScoreTime;
        scoreText.text = "" + (int)score;
    }
}
