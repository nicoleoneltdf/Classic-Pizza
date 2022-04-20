using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TMP_Text puntajeFinal;
    public TMP_Text puntaje;
    public GameObject hiscore;
    public float tiempo;
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
       puntaje.text = "SCORE: " + Mathf.RoundToInt(Time.timeSinceLevelLoad * 10).ToString();
    }

    void OnGameOver()
    {
        spawner.SetActive(false);
        gameOverScreen.SetActive(true);
        puntaje.enabled = false;
        tiempo = Time.timeSinceLevelLoad * 10;
        Debug.Log(tiempo);
        puntajeFinal.text = Mathf.RoundToInt(tiempo).ToString();
        gameOver = true;
        if(tiempo > highScore) 
        {
            hiscore.SetActive(true);
            PlayerPrefs.SetFloat("score", tiempo);
        }
    }
}
