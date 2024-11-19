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

    public TMP_Text textScore;
    public TMP_Text textMiss;
    float score = 0;
    float missing = 0;

    public GameObject gameOverUI;
    public GameObject scoreAndMiss;
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
            
            GameObject spawnEnemy = Instantiate(enemy,newPosition,Quaternion.identity);
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
    }
    public void WinUI()
    {
        winUI.SetActive(true);
        scoreAndMiss.SetActive(false);
    }
}
