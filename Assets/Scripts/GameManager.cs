using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text CurScore;

    public Text TopScore;

    public GameObject GameOverPanel;

    public static GameManager Instance;

    private float beginTime;
    private bool gameOver = false;
    private string topScoreKey = "TopScore";

    // Use this for initialization

    void Start ()
	{
	    Instance = this;
	    beginTime = Time.time;

	    if (PlayerPrefs.HasKey(topScoreKey))
	    {
	        UpdateTopScoreText(PlayerPrefs.GetInt(topScoreKey));
	    }
	    else UpdateTopScoreText(0);
    }

    // Update is called once per frame
	void Update ()
	{
	    if (gameOver && Input.GetKeyDown(KeyCode.R))
	    {
	        RestartGame();
	    }

	    UpdateScore();
	}

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScore()
    {
        CurScore.text = string.Format("Score: {0}", GetCurScore());
    }

    private int GetCurScore()
    {
        return (int)(Time.time - beginTime);
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;

        GameOverPanel.SetActive(true);
       

        if (PlayerPrefs.HasKey(topScoreKey))
        {
            var prevTopScore = PlayerPrefs.GetInt(topScoreKey);
            if (GetCurScore() > prevTopScore)
            {
                UpdateTopScore();
            }
        }
        else
        {
            UpdateTopScore();
        }
    }

    private void UpdateTopScore()
    {
        var newTopScore = GetCurScore();
        PlayerPrefs.SetInt(topScoreKey, newTopScore);

        UpdateTopScoreText(newTopScore);
    }

    private void UpdateTopScoreText(int topScore)
    {
        TopScore.text = string.Format("Top score: {0}", topScore);
    }
}
