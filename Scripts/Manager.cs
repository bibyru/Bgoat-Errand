using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] int nextlevel;
    [SerializeField] GameObject PauseMenu;

    [SerializeField] GameObject Score;
    [SerializeField] GameObject Countdown;
    [SerializeField] GameObject ShrubsGot;
    [SerializeField] GameObject HeartsLeft;
    [SerializeField] GameObject Goat;

    [SerializeField] AudioSource Win;
    [SerializeField] AudioSource Lose;

    float initime = 300;
    public int shrubcount = 0;
    public int heartcount = 0;
    public int score;
    bool win = false;

    float finishlevel = 3;

    private void Start()
    {
        score = ManagerKeepScore.keptscore;
        UpdateScore();
        
        win = false;

        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (win == false)
        {
            initime -= Time.deltaTime;
            UpdateTimer();

            if (initime <= 0)
            {
                PlayerDied();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(!PauseMenu.activeSelf);
            }
        }
        else
        {
            if (finishlevel >=0)
            {
                finishlevel -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(nextlevel);
            }
        }
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene("Level0");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void PlayerDied()
    {
        Lose.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerWin()
    {
        Win.Play();
        win = true;

        score += (int)initime * 2 + shrubcount * 5 + heartcount * 2;
        ManagerKeepScore.keptscore = score;
        UpdateScore();
        
        initime = 0;
        shrubcount = 0;
        heartcount = 0;
        UpdateTimer();
        UpdateHeart();
        UpdateShrubs();
    }

    private void UpdateTimer()
    {
        Countdown.GetComponent<Text>().text = string.Format("{0:000}", initime);
    }

    private void UpdateShrubs()
    {
        ShrubsGot.GetComponent<Text>().text = string.Format("{0:00}", shrubcount);
    }

    private void UpdateHeart()
    {
        HeartsLeft.GetComponent<Text>().text = heartcount.ToString();
    }

    private void UpdateScore()
    {
        Score.GetComponent<Text>().text = string.Format("{0:000000}", score);
    }

    public void AddScore(int add)
    {
        score += add;
        UpdateScore();
    }

    public void AddShrub()
    {
        shrubcount++;
        UpdateShrubs();
    }

    public void AddHeart()
    {
        heartcount++;
        UpdateHeart();

        if (heartcount-1 == 0)
        {
            Goat.GetComponent<GoatAnimations>().Weregoat();
        }
    }

    public void UseHeart()
    {
        heartcount--;

        if (heartcount == -1)
        {
            PlayerDied();
            return;
        }

        UpdateHeart();

        if (heartcount == 0)
        {
            Goat.GetComponent<GoatAnimations>().Weregoat();
        }
    }
}
