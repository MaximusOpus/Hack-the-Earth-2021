using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllTreesCheckpoint : MonoBehaviour
{
    public GameObject endFade;

    float charLoadTime = 0.03f;

    Coroutine currentCoroutine;

    int firstTreeClicks = 0;
    public bool allTrees = false;
    public bool allTreesCompleted = false;
    public GameObject firstTreeScroll;
    public Text allTreesUIText;
    string allTreesText = "All of the trees have\nbeen cleared." +
        "\n\nSadly, your efforts\nwere not enough to\nprevent deforestation." +
        "\n\nIf you cannot protect\nthe forests, ALL\nrainforests on Earth\nwill be destroyed in\nonly 78 years.";
    string allTreesText2 = "This empty wasteland\nwill be the future of\nEarth." +
        "\n\nThe only way to\nprevent this from\nhappening is to fight\nagainst deforestation" +
        "\n\nin this game" +
        "\n\nand in life. ";

    bool restart; 

    // Update is called once per frame
    void Update()
    {
        if (allTrees)
        {
            Time.timeScale = 0;
            firstTreeScroll.SetActive(true);
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(RevealText(allTreesUIText, allTreesText));
            }

            if (Input.GetMouseButtonDown(1))
            {
                switch (firstTreeClicks)
                {
                    case 0:
                        firstTreeClicks++;
                        currentCoroutine = StartCoroutine(RevealText(allTreesUIText, allTreesText2));
                        break;
                    case 1:
                        firstTreeScroll.SetActive(false);
                        allTreesCompleted = true;
                        allTrees = false;
                        Time.timeScale = 1;
                        currentCoroutine = null;
                        StartCoroutine(FinalWords());
                        break;
                }
            }
        }

        if (restart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator RevealText(Text uiText, string text)
    {
        uiText.text = "";
        foreach (char c in text)
        {
            uiText.text += c;
            yield return new WaitForSecondsRealtime(charLoadTime);
        }
        yield break;
    }

    IEnumerator RevealText(Text uiText, string text, float charLoadTime)
    {
        uiText.text = "";
        foreach (char c in text)
        {
            uiText.text += c;
            yield return new WaitForSecondsRealtime(charLoadTime);
        }
        yield break;
    }

    public Text endText;
    string text1 = "If deforestation continues...";
    string text2 = "humanity will not survive.";
    string text3 = "YOU have to change something." +
        "\nProtect the forests." +
        "\nSave us from ourselves.";


    IEnumerator FinalWords()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        endFade.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);

        StartCoroutine(RevealText(endText, text1, charLoadTime * 2));
        yield return new WaitForSecondsRealtime(3f);
        StartCoroutine(RevealText(endText, text2, charLoadTime * 2));
        yield return new WaitForSecondsRealtime(4f);
        StartCoroutine(RevealText(endText, text3, charLoadTime * 2));
        restart = true;
        yield break;
    }
}
