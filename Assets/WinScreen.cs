using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public TMP_Text winnerText;

    void Start()
    {
        Debug.Log("Winner value: " + MyGameManager.winner);
        if (winnerText != null)
        {
            winnerText.text = MyGameManager.winner;
        }
    }

    // Call this from the button in the WinScene
    public void BackToMenu()
    {
        SceneManager.LoadScene("TitleScene"); 
    }
}