using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackMovement : MonoBehaviour
{

    TargetTree targetTree;
    LumberjackAttack lumberjackAttack;

    // Start is called before the first frame update
    void Start()
    {
        targetTree = GetComponent<TargetTree>();
        lumberjackAttack = GetComponent<LumberjackAttack>();
    }

    public float speed = 5f;
    public float minDistFromTree = 1f;
    // Update is called once per frame
    void Update()
    {
        
        if (targetTree.closestTree == null)
        {
            return;
        }

        if (Vector3.Distance(transform.position, targetTree.closestTree.transform.position) > minDistFromTree)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetTree.closestTree.transform.position, step);
        } else
        {
            if (lumberjackAttack.attackEnumerator == null)
            {
                lumberjackAttack.startAttack = true;
            }
        }
    }
}
