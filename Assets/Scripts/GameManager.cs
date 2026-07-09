using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isSTARTED = false;
    public bool isDEAD = false;

    public PlayerController player;

    public GameObject mainMenu;
    public GameObject scoreUI;
    public GameObject healthUI;

    public GameObject gameOver_menu;
    public GameObject versionNewBestScore;
    public GameObject versionNoBestScore;

    public PressStartText pressStartText;

    public int playerHealth = 3;
    public float playerScore  = 0;
    public int bestScore = 000;

    void Awake()
    {
        Instance = this;
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
    }

    void Start()
    {
        isSTARTED = false;
        isDEAD = false;

        player.SetIdle();
        pressStartText.ShowText();

        playerHealth = 3;
        playerScore = 000;

        mainMenu.SetActive(true);
        gameOver_menu.SetActive(false);
        scoreUI.SetActive(false);
        healthUI.SetActive(false);
    }

    void Update()
    {

        if(isSTARTED && ! isDEAD)
        {
            playerScore += Time.fixedDeltaTime;
        }

        if(playerHealth <= 0)
        {
            PlayerDead();
        }   
    }

    public void StartGame()
    {
        isSTARTED = true;
        isDEAD = false;

        mainMenu.SetActive(false);
        scoreUI.SetActive(true);
        healthUI.SetActive(true);

        playerHealth = 3;
        playerScore = 0;

        player.StartRun();
        
        pressStartText.HideText();
    }

    public void PlayerDead()
    {
        isSTARTED = false;
        isDEAD = true;

        mainMenu.SetActive(false);

        scoreUI.SetActive(true);
        healthUI.SetActive(true);

        gameOver_menu.SetActive(true);

        int finalScore = Mathf.RoundToInt(playerScore);
        if (finalScore > bestScore)
        {
            bestScore = finalScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();

            versionNewBestScore.SetActive(true);
            versionNoBestScore.SetActive(false);

        }
        else
        {
            versionNewBestScore.SetActive(false);
            versionNoBestScore.SetActive(true); 
        }

        player.SetIdle();

    }

    public void BackToMainMenu()
    {
        isSTARTED = false;
        isDEAD = false;

        playerHealth = 3;
        playerScore = 0;

        gameOver_menu.SetActive(false);
        mainMenu.SetActive(true);
        scoreUI.SetActive(false);
        healthUI.SetActive(false);
        versionNewBestScore.SetActive(false);
        versionNewBestScore.SetActive(false);
        
        player.SetIdle();

    }
}