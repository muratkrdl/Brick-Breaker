using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI liveText;

    public int level = 1;
    public int score = 0;
    public int lives = 3;

    public bool isWin = false;

    Brick[] bricks;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        bricks = FindObjectsOfType<Brick>();
    }

    void Start() 
    {
        NewGame();
        scoreText.text = score.ToString();
        liveText.text = lives.ToString();
    }

    void Update() 
    {
        isWin = CheckWin();

        if(isWin)
        {
            Time.timeScale = 0;
        }    
    }

    void NewGame()
    {
        this.score = 0;
        this.lives = 3;
    }

    void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void DecreaseLive()
    {
        lives--;
        liveText.text = lives.ToString();

        if(lives <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public bool CheckWin()
    {
        foreach (var brick  in bricks)
        {
            if(brick.enabled == true)
            {
                return false;
            }
        }
        return true;
    }

}
