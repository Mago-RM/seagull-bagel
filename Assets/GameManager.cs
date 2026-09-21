using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float timeLeft = 30f;
    public int score = 0;
    public int scoreToWin = 10;
    public int currentLevel = 1;

    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public AudioSource musicSource;
    
    // Start Panel is shown first [Play / How to Play / Credits]
    public GameObject startPanel;
    public GameObject seagull;

    private bool gameEnded = false;

    public float currentBagelSpeed = 10f;

    //End Panel [Replay / Next Level]
    public GameObject endPanel;
    public TMP_Text endText;

    // Tutorial Panel
    public GameObject tutorialPanel;

    //Credit Panel
    public GameObject creditsPanel;

    //NextLevelPanel
    public GameObject levelTransitionPanel;
    public TMP_Text transitionText;

    //Chnage In Background for Progression Lvls
    public Camera mainCamera;
    public Color level1Sky;
    public Color level2Sky;
    public Color level3Sky;



    void Start()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(false);
        UpdateScoreText();
    }

    public void StartGame(){
        Time.timeScale = 1f;
        startPanel.SetActive(false);
        seagull.SetActive(true);
        currentBagelSpeed = 9f;
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void AddScore()
    {
        if (gameEnded) return;

        score++;
        UpdateScoreText();

        if (score >= scoreToWin)
        {
            WinGame();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Doughnuts: " + score;
    }



/*    public void WinGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        endPanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You win!\nGet ready for Next Level...";

        StartCoroutine(GoToNextLevelAfterDelay());
    }*/

    public void WinGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;


        StartCoroutine(GoToNextLevelAfterDelay());
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
        gameEnded = true;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Lost!";
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GoToNextLevelAfterDelay()
    {
        levelTransitionPanel.SetActive(true);
        transitionText.gameObject.SetActive(true);

        if (currentLevel == 1)
        {
            transitionText.text = "You win!\n\nLevel 2\nBagels are faster!\nCatch 10!";
        }
        else if (currentLevel == 2)
        {
            transitionText.text = "You win!\n\nLevel 3\nAvoid the danger!";
        }
        else
        {
            FinalWin();
            yield break;
        }

        yield return new WaitForSecondsRealtime(5f);

        Time.timeScale = 1f;
        levelTransitionPanel.SetActive(false);

        if (currentLevel == 1)
        {
            StartLevel2();
        }
        else if (currentLevel == 2)
        {
            StartLevel3();
        }
    }

    void StartLevel2()
    {
        currentLevel = 2;
        gameEnded = false;

        score = 0;
        timeLeft = 30f;
        scoreToWin = 10;
        mainCamera.backgroundColor = new Color(0.75f, 0.60f, 0.75f); // orange sunset
        currentBagelSpeed = 10f;

        scoreText.text = "Doughnuts: " + score;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    void StartLevel3()
    {
        currentLevel = 3;
        gameEnded = false;

        score = 0;
        timeLeft = 30f;
        scoreToWin = 10;
        mainCamera.backgroundColor = new Color(0.2f, 0.2f, 0.4f); // dark storm
        currentBagelSpeed = 13f;

        scoreText.text = "Doughnuts: " + score;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    public void FinalWin()
    {
        levelTransitionPanel.SetActive(false);

        Time.timeScale = 0f;

        endPanel.SetActive(true);

        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "YOU BEAT THE GAME!\n\nThanks for playing!";

    }

    public void StartTutorial()
    {
        tutorialPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
        startPanel.SetActive(true);
    }

     public void StartCredits()
    {
        creditsPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}

