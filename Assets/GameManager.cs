using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject enemy;
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

    public GameObject gameOverUI;
    public GameObject scoreAndMiss;
    public GameObject scoringUI;
    public GameObject winUI;
    // Update is called once per frame
    void Update()
    {
        currentTime  += Time.deltaTime;
        if (currentTime > intervalTime)
        {
            currentTime = 0;

            float randomRange = Random.Range(min,max);
            Vector3 newPosition = new Vector3(randomRange, transform.position.y, transform.position.z);
            
            GameObject spawnEnemy = Instantiate(enemy,newPosition,Quaternion.Euler(90,0,0));
        }
        if (score > highScore)
        {
            highScore = score;
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
