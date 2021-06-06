using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public List<GameObject> attackingEnemies;

    public int hp = 5;

    public Sprite tree4;
    public Sprite tree3;
    public Sprite tree2;
    public Sprite tree1;
    SpriteRenderer rend;

    HealthbarScript healthbar;

    FirstTreeCheckpoint firstTreeCheckpoint;

    private void Start()
    {
        firstTreeCheckpoint = FindObjectOfType<FirstTreeCheckpoint>();

        rend = GetComponent<SpriteRenderer>();
        healthbar = GameObject.Find("Healthbar").GetComponent<HealthbarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Max(hp, 0);
        switch (hp)
        {
            case 4:
                rend.sprite = tree4;
                break;
            case 3:
                rend.sprite = tree3;
                break;
            case 2:
                rend.sprite = tree2;
                break;
            case 1:
                rend.sprite = tree1;
                break;
            case 0:
                foreach (GameObject enemy in attackingEnemies)
                {
                    LumberjackAttack attack = enemy.GetComponent<LumberjackAttack>();
                    
                    if (attack.attackEnumerator != null)
                    {
                        StopCoroutine(attack.attackEnumerator);
                        attack.attackEnumerator = null;
                    }

                    if (enemy.GetComponent<Animator>() != null)
                    {
                        enemy.GetComponent<Animator>().SetBool("attack", false);
                    }

                    if (healthbar.hp > 1)
                    {
                        enemy.GetComponent<TargetTree>().FindClosestTree(gameObject);
                    }
                }
                healthbar.hp--;

                if (!firstTreeCheckpoint.firstTreeCompleted)
                {
                    firstTreeCheckpoint.firstTree = true;
                }

                Destroy(gameObject);
                break;
        }
    }
}
