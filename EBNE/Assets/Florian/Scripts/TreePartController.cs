using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePartController : MonoBehaviour
{
    [Tooltip("True = script sur le tree de gauche - False = script sur le tree de droite")]
    public bool wichPart;

    public GameObject centerTree;
    public GameObject leftTree;
    public GameObject rightTree;

    private GameObject endPTransform;

    public List<GameObject> endPlatform = new List<GameObject>();

    //public PlayerController _treeGenerator;

    public void Start()
    {
        //_treeGenerator = FindObjectOfType<PlayerController>();
        //ThePart();
    }

    public void ThePart()
    {
        if (wichPart)
        {
            Left();
        }
        else
        {
            Right();
        }

    }

    void Left()
    {
        Debug.Log("left");
        endPTransform = GameObject.FindWithTag("endPlatform");

        var rr = Random.Range(1, 5 + 1);
        //Debug.Log(rr);

        for (int i = 0; i < rr; i++)
        {
            if (i != rr - 1)
            {
                Instantiate(centerTree, endPTransform.transform.position, Quaternion.identity);
                endPTransform.SetActive(false);

                foreach (GameObject endPlatTransform in GameObject.FindGameObjectsWithTag("endPlatform"))
                {
                    endPlatform.Clear();
                    endPlatform.Add(endPlatTransform);
                    endPTransform = endPlatTransform;
                }
            }
            else
            {
                Instantiate(leftTree, endPTransform.transform.position, Quaternion.identity);
                endPTransform.SetActive(false);
                CallGeneration();
            }

        }
    }

    void Right()
    {
        Debug.Log("right");
        endPTransform = GameObject.FindWithTag("endPlatform");

        var rr = Random.Range(1, 5 + 1);
        //Debug.Log(rr);

        for (int i = 0; i < rr; i++)
        {
            if (i != rr - 1)
            {
                Instantiate(centerTree, endPTransform.transform.position, Quaternion.identity);
                endPTransform.SetActive(false);

                foreach (GameObject endPlatTransform in GameObject.FindGameObjectsWithTag("endPlatform"))
                {
                    endPlatform.Clear();
                    endPlatform.Add(endPlatTransform);
                    endPTransform = endPlatTransform;
                }
            }
            else
            {
                Instantiate(rightTree, endPTransform.transform.position, Quaternion.identity);
                endPTransform.SetActive(false);
                CallGeneration();
            }

        }
    }

    void CallGeneration()
    {
        Debug.Log("generate");
        FindObjectOfType<TreeGenerator>().Generate();
    }
}

