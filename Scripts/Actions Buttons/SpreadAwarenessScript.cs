using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpreadAwarenessScript : MonoBehaviour
{
    public ScoreScript scoreScript;
    Button button;

    int cost = 126;

    public Text costText;
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        costText.text = cost.ToString();
    }

    private void Update()
    {
        if (scoreScript.score >= cost)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void SpreadAwareness()
    {
        if (scoreScript.score >= cost)
        {
            scoreScript.score -= cost;
            
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector3 pos = enemy.transform.position;
                float width = Camera.main.orthographicSize * Camera.main.aspect;

                if (pos.x < width)
                {
                    enemy.GetComponent<DestroyEnemy>().DestroyObj();
                }
            }
        }
    }
}
