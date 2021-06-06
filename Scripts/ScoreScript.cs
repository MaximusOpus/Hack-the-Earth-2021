using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    [System.NonSerialized]
    public float scoreWait = 2f;

    public GameManagerScript gameManagerScript;

    IEnumerator scoreEnumerator;

    public Text scoreText;

    private void Start()
    {
        scoreEnumerator = IncreaseScore();
        StartCoroutine(scoreEnumerator);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if (gameManagerScript.gameOver)
        {
            StopCoroutine(scoreEnumerator);
        }
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreWait);
            score++;
        }
    }
}
