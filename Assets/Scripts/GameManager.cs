using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject appleTree;
    public AppleTree tree;
    public GameObject branch;
    public GameObject apple;
    public TextMeshProUGUI roundText;
    public int round = 1;
    public int maxRounds = 4;
    public GameObject gameOverPanel;
    void Start()
    {
        tree.ResetDifficulty();
        appleTree.SetActive(false);
        apple.SetActive(false);
        branch.SetActive(false);
        UpdateRoundText();
    }

    public void NextRound()
    {
        round++;
        if(round > maxRounds)
        {
            GameOver();
        }
        else
        {
            UpdateRoundText();
        }
    }
    void UpdateRoundText()
    {
        roundText.text = "Round "+round;
    }
    public void GameOver()
    {
        roundText.text = "Game Over";
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        tree.ResetDifficulty();
        CancelInvoke();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartGame()
    {
        startScreen.SetActive(false);
        appleTree.SetActive(true);
        apple.SetActive(true);
        branch.SetActive(true);
    }
}