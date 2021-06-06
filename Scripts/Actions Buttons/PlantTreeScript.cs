using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantTreeScript : MonoBehaviour
{
    public ScoreScript scoreScript;
    Button button;
    //public Color boughtColor;

    public GameObject treePrefab;
    public HealthbarScript healthbarScript;

    int cost = 65;

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

    public void PlantTree()
    {
        if (scoreScript.score >= cost)
        {
            scoreScript.score -= cost;
            healthbarScript.hp++;
            Instantiate(treePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //button.image.color = boughtColor;
        }
    }
}
