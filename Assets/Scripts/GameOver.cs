using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TMP_Text puntaje;
    public GameObject hiscore;
    float tiempo;
    bool gameOver;
    float highScore;
    public GameObject spawner;
    void Start()
    {
        tiempo = 0;
        FindObjectOfType<Pizzamovement>().OnPlayerDeath += OnGameOver;
        highScore = PlayerPrefs.GetFloat("score");
    }


    void Update()
    {
        
    }

    void OnGameOver() 
    {
        spawner.SetActive(false);
        tiempo = Time.timeSinceLevelLoad * 10;
        gameOverScreen.SetActive(true);
        puntaje.text = Mathf.RoundToInt(tiempo).ToString();
        gameOver = true;
        if(tiempo > highScore) 
        {
            hiscore.SetActive(true);
            PlayerPrefs.SetFloat("score", tiempo);
        }
    }
}
