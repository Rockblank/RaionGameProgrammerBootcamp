using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public float min;
    public float max;
    public float intervalTime = 8f;
    [SerializeField]private float currentTime = 0f;
    public TMP_Text scoreUI;
    public TMP_Text highScoreUI;

    public TMP_Text textScore;
    public TMP_Text textMiss;
    float score = 0;
    float highScore = 0;
    float missing = 0;

    public GameObject Kannon;
    public GameObject gameOverUI;
    public GameObject scoreAndMiss;
    public GameObject scoringUI;
    public GameObject winUI;

    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime  += Time.deltaTime;
        if (currentTime > intervalTime)
        {
            currentTime = 0;

            float randomRange = Random.Range(min,max);
            Vector3 newPosition = new Vector3(randomRange, transform.position.y, transform.position.z);
            float randomValue = Random.value;
            GameObject RandomEnemy;
            if (randomValue <= 0.6f)
            {
                RandomEnemy = enemies[0];
            } else if (randomValue <= 0.8f)
            {
                RandomEnemy = enemies[2];
            } else {
                RandomEnemy = enemies[1];
                    }

            GameObject spawnEnemy = Instantiate(RandomEnemy,newPosition,Quaternion.Euler(90,0,0));
        }
        if (score > highScore)
        {
            highScore = score;
        }

        if(score < 0)
        {
            Time.timeScale = 0;
            Kannon.GetComponent<PlayerBehaviour>().enabled = false;
            GameOver();
        }
    }

    public void UpdateScore(float y)
    {
        score += y;
        textScore.text = "Score: "+score;
    }
    public void UpdateMiss(float z)
    {
        missing  += z;
        score -= z;
        textMiss.text = "Missing: "+missing;
        textScore.text = "Score: "+score;
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        scoreAndMiss.SetActive(false);
        ScoringUI();
    }
    public void WinUI()
    {
        winUI.SetActive(true);
        scoreAndMiss.SetActive(false);
        ScoringUI();
    }

    public void ScoringUI()
    {
        scoringUI.SetActive(true);
        scoreUI.text = "your score: "+score;
        highScoreUI.text = "High score: "+highScore;
    }
}
