using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScrollTextScript : MonoBehaviour
{
    float charLoadTime = 0.03f;

    public GameObject enemyContainer;

    public GameObject introScroll;
    public Text introText;

    string text1 = "Deforestation is the permanent removal of trees\nto make room for something besides forests." +
        "\n\nWithout forests, we cannot survive. They purify the\nair we breathe, clean the water we drink, and help\nprevent climate change to save the polar bears!" +
        "\n\nForests also offer a home to much of the world's\nmany plants and animals.";

    string text2 = "But, even though forests are crucial to this planet,\nthey are being destroyed through deforestation." +
        "\n\nIt is your job to protect forests from destruction\nto save the planet." +
        "\n\nGood luck! :)";

    bool bold = true;

    int uiClicks = 0;

    public bool firstTree = false;

    public GameManagerScript gameManagerScript;
    public GameObject wave;

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(RevealText(text1));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            switch (uiClicks)
            {
                case 0:
                    uiClicks++;
                    introText.text = "";
                    bold = false;
                    StartCoroutine(RevealText(text2));
                    break;
                case 1:
                    uiClicks++;
                    introScroll.SetActive(false);
                    enemyContainer.SetActive(true);
                    Time.timeScale = 1;
                    wave.SetActive(true);
                    StartCoroutine(gameManagerScript.CountdownRoutine());
                    break;
            }
        }


    }

    IEnumerator RevealText(string text)
    {
        foreach (char c in text)
        {
            if (bold)
            {
                if (introText.text.Length <= 13+6+8)
                {
                    introText.text = "<b><i>" + introText.text.Substring(6, introText.text.Length-14) + c + "</i></b>";
                } else
                {
                    introText.text += c;
                }
            } else
            {
                introText.text += c;
            }
            yield return new WaitForSecondsRealtime(charLoadTime);
        }
        yield break;
    }
}
