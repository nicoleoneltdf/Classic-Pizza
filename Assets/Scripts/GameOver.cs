using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TMP_Text randomPhrase;
    public TMP_Text phraseCreator;
    public TMP_Text puntajeFinal;
    public TMP_Text puntaje;
    public TMP_Text fecha;
    public GameObject hiscore;
    float tiempo;
    bool gameOver;
    float highScore;
    public GameObject spawner;
    public string[] frases;
    public string[] creadorFrase;
    int frase;
    int year;
    

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
        RandomDialogue();
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

    void RandomDialogue() 
    {
        year = Random.Range(1500, 2022);
        fecha.text = year.ToString();
        frase = Random.Range(0, frases.Length);
        randomPhrase.text = frases[frase];
        phraseCreator.text = creadorFrase[frase];
    }
}
