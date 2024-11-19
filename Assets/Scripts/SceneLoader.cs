using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("RaionFixing");
        Time.timeScale = 1;
    }
    public void loadHome()
    {
        SceneManager.LoadScene("homeScreen");
    }
}
