using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTree : MonoBehaviour
{

    public GameObject closestTree;

    private void Start()
    {
        FindClosestTree();
    }

    public void FindClosestTree(GameObject excludeTree = null)
    {
        Vector3 pos = transform.position;

        float closestDist = Mathf.Infinity;
        GameObject[] allTrees = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject tree in allTrees)
        {
            if (tree == excludeTree)
            {
                continue;
            }

            float distToTree = Vector3.Distance(pos, tree.transform.position);
            if (distToTree < closestDist)
            {
                closestDist = distToTree;
                closestTree = tree;
            }
        }
        closestTree.GetComponent<TreeHealth>().attackingEnemies.Add(gameObject);
    }
}
