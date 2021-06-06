using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject introScroll;

    public ScoreScript scoreScript;

    public int waveNum = 1;
    public bool inWave = false;
    public Text waveText;

    public GameObject countdown;
    public Text countdownText;

    public GameObject lumberJack;
    public GameObject bulldozer;
    public GameObject fire;

    public GameObject enemyContainer;

    Coroutine lumberjackSpawning;
    Coroutine bulldozerSpawning;
    Coroutine fireSpawning;

    public bool gameOver = false;

    public AllTreesCheckpoint allTreesCheckpoint;

    int numLumberjacks = 0;
    int numBulldozers = 0;
    int numFires = 0;

    public int remainingLumberjacks;
    public int remainingBulldozers;
    public int remainingFires;

    public bool firstBulldozer;
    public bool firstFire;

    public FirstBulldozerCheckpoint firstBulldozerCheckpoint;
    public FirstFireCheckpoint firstFireCheckpoint;

    private void Start()
    {
        introScroll.SetActive(true);
    }

    void GetEnemyCount()
    {
        numLumberjacks += Random.Range(2, 3);
        if (waveNum >= 3)
        {
            numBulldozers += Random.Range(1, 2);
        }
        if (waveNum >= 7)
        {
            numFires += Random.Range(1, 4);
        }

        remainingLumberjacks = numLumberjacks;
        remainingBulldozers = numBulldozers;
        remainingFires = numFires;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            StopAllCoroutines();

            if (!allTreesCheckpoint.allTreesCompleted)
            {
                allTreesCheckpoint.allTrees = true;
            }
        } else
        {
            if (inWave)
            {
                if (lumberjackSpawning == null && bulldozerSpawning == null && fireSpawning == null) {
                    GetEnemyCount();

                    lumberjackSpawning = StartCoroutine(LumberjackSpawning());
                    bulldozerSpawning = StartCoroutine(BulldozerSpawning());
                    fireSpawning = StartCoroutine(FireSpawning());
                }

                if (remainingLumberjacks == 0 && remainingBulldozers == 0 && remainingFires == 0)
                {
                    inWave = false;
                    waveNum++;
                    waveText.text = "Wave " + waveNum.ToString();

                    scoreScript.score += 10;

                    StopAllCoroutines();
                    lumberjackSpawning = null;
                    bulldozerSpawning = null;
                    fireSpawning = null;

                    StartCoroutine(CountdownRoutine());

                }
            }
        }
    }

    float lumberjackMin = 0.15f;
    float lumberjackMax = 0.6f;
    IEnumerator LumberjackSpawning()
    {
        for (int _ = 0; _ < numLumberjacks; _++)
        {
            float y = Random.Range(-5f, 1.5f);
            Vector3 pos = new Vector3(10, y, 0);
            Instantiate(lumberJack, pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(lumberjackMin, lumberjackMax));
        }
        yield break;
    }

    float bulldozerMin = 0.55f;
    float bulldozerMax = 1f;
    IEnumerator BulldozerSpawning()
    {
        for (int _ = 0; _ < numBulldozers; _++)
        {
            if (!firstBulldozerCheckpoint.firstBulldozerCompleted)
            {
                firstBulldozerCheckpoint.firstBulldozer = true;
            }
            float y = Random.Range(-5f, 1.5f);
            Vector3 pos = new Vector3(15, y, 0);
            Instantiate(bulldozer, pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(bulldozerMin, bulldozerMax));
        }
        yield break;
    }

    float fireMin = 1f;
    float fireMax = 1.3f;
    IEnumerator FireSpawning()
    {
        for (int _ = 0; _ < numFires; _++)
        {
            if (!firstFireCheckpoint.firstFireCompleted)
            {
                firstFireCheckpoint.firstFire = true;
            }
            float y = Random.Range(-5f, 1.5f);
            float x = Random.Range(-11f, 11f);
            Vector3 pos = new Vector3(x, y, 0);
            Instantiate(fire, pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(fireMin, fireMax));
        }
    }

    public IEnumerator CountdownRoutine()
    {
        countdown.SetActive(true);
        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdown.SetActive(true);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdown.SetActive(false);
        inWave = true;
        yield break;
    }

}
