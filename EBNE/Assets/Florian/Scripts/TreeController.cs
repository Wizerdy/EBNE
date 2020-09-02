using System.Collections;
using UnityEngine;

public class TreeController : MonoBehaviour
{

    [Tooltip("La speed des obstacles et de l'arbre doit être la même")]
    public float treeSpeed;

    [Tooltip("Le temps avant de désactiver l'arbre afin de gagner en performance (dès que le joueur change d'arbre idéalement)")]
    public int timeAlive;

    private float _oc;

    void Start()
    {
        _oc = FindObjectOfType<ObstacleController>().fallingSpeed;
        StartCoroutine(CheckSpeedValues());
        StartCoroutine(DesactivateTheTree());
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 1), -treeSpeed * Time.deltaTime);//(oui j'en ai raf)
    }

    IEnumerator CheckSpeedValues()
    {
        yield return new WaitForSeconds(3.5f);
        if (treeSpeed != _oc) Debug.LogError("The fall value (" + _oc + ")" +
             " isn't equal to the treeSpeed (" + treeSpeed + "). Set the fall value to " + treeSpeed + " or the tree speed to " + _oc + ".");
    }

    IEnumerator DesactivateTheTree()
    {
        yield return new WaitForSeconds(timeAlive);
        gameObject.SetActive(false);
    }
}
