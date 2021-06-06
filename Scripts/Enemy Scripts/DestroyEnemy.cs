using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public string enemyType;
    GameManagerScript gameManagerScript;

    public int defaultHP = 1;
    int hp;

    float deathDelay = 0.2f;

    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        gameManagerScript = FindObjectOfType<GameManagerScript>();
        hp = defaultHP;
    }

    private void OnMouseDown()
    {
        rend.color = new Color(103/255f, 185/255f, 129/255f);
        if (--hp == 0)
        {
            DestroyObj();
        }
    }

    private void OnMouseUp()
    {
        rend.color = new Color(1, 1, 1);
    }

    public void DestroyObj()
    {
        GameObject closestTree = GetComponent<TargetTree>().closestTree;
        closestTree.GetComponent<TreeHealth>().attackingEnemies.Remove(gameObject);
        // Destroy(gameObject);
        StartCoroutine(DieRoutine());
    }

    IEnumerator DieRoutine()
    {
        rend.color = new Color(0, 0, 0);
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetBool("attack", false);
        }

        GetComponent<LumberjackMovement>().enabled = false;
        yield return new WaitForSeconds(deathDelay);

        switch (enemyType)
        {
            case "lumberjack":
                gameManagerScript.remainingLumberjacks--;
                break;
            case "bulldozer":
                gameManagerScript.remainingBulldozers--;
                break;
            case "fire":
                gameManagerScript.remainingFires--;
                break;
        }

        Destroy(gameObject);
    }

}
