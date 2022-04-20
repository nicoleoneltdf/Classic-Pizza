using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject highscore;
    public GameObject menu;
    public TMP_Text hiscore;
    float puntajeAlto;


    public void HighScore() 
    {
        menu.SetActive(false);
        highscore.SetActive(true);
        puntajeAlto = Mathf.RoundToInt(PlayerPrefs.GetFloat("score"));
        hiscore.text = puntajeAlto.ToString();
    }

    public void Atras() 
    {
        menu.SetActive(true);
        highscore.SetActive(false);
    }

    public void Play() 
    {
        SceneManager.LoadScene(1);      
    }
}
