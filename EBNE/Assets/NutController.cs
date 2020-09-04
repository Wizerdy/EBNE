using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutController : MonoBehaviour
{
    [SerializeField] private GameObject takenParticle;
    [SerializeField] private GameObject bonusText;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Taken()
    {
        anim.SetTrigger("Taken");
    }

    public void TakenParticle()
    {
        Instantiate(takenParticle, transform.position, transform.rotation);
        Instantiate(bonusText, transform.position, transform.rotation);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
