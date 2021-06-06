using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackAttack : MonoBehaviour
{
    public bool startAttack = false;

    public IEnumerator attackEnumerator;

    public float attackWait = 0.75f;
    public int attackDmg = 1;

    GameObject treeToAttack;

    // Update is called once per frame
    void Update()
    {
        if (startAttack)
        {
            startAttack = false;
            treeToAttack = GetComponent<TargetTree>().closestTree;
            attackEnumerator = Attack();
            StartCoroutine(attackEnumerator);
        }
    }

    IEnumerator Attack()
    {
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetBool("attack", true);
        }
        TreeHealth treeHealth = treeToAttack.GetComponent<TreeHealth>();
        while (true)
        {
            yield return new WaitForSeconds(attackWait);
            treeHealth.hp -= attackDmg;
        }
    }
}