using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public int player1Lives = 5;
    public int player2Lives = 5;

    public TMP_Text player1LivesText;
    public TMP_Text player2LivesText;

    public void DamagePlayer(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Lives--;
            if (player1Lives < 0) player1Lives = 0;
        }
        else if (playerNumber == 2)
        {
            player2Lives--;
            if (player2Lives < 0) player2Lives = 0;
        }

        UpdateUI();
        CheckGameOver();
    }

    void UpdateUI()
    {
        if (player1LivesText != null) player1LivesText.text = "P1 Lives: " + player1Lives;
        if (player2LivesText != null) player2LivesText.text = "P2 Lives: " + player2Lives;
    }


void CheckGameOver()
{
    if (player1Lives == 0)
    {
        Debug.Log("Player 2 Wins!");
        MyGameManager.winner = "Player 2 Wins!"; 
        SceneManager.LoadScene("WinScene");  
    }
    else if (player2Lives == 0)
    {
        Debug.Log("Player 1 Wins!");
        MyGameManager.winner = "Player 1 Wins!";
        SceneManager.LoadScene("WinScene");
    }
}
}