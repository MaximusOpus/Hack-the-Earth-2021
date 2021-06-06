using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperScript : MonoBehaviour
{
    public ScoreScript scoreScript;
    Button button;
    //public Color boughtColor;

    int cost = 34;

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
        } else
        {
            button.interactable = false;
        } 
    }

    public void BuyPaper()
    {
        if (scoreScript.score >= cost)
        {
            scoreScript.score -= cost;
            scoreScript.scoreWait -= 0.25f;
            //button.image.color = boughtColor;
        }
    }
}
