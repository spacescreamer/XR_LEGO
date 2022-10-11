using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class Game : MonoBehaviour
{
    [SerializeField] GameObject gameLoseUI;
    [SerializeField] GameObject gameWinUI;
    bool gameIsOver;
    bool guardDisabled;

    void Start()
    {
        Guard.OnGuardHasSpottedPlayer += GuardDisable;
        Guard.OnGuardHasSpottedPlayer += ShowGameLoseUI;
        FindObjectOfType<Player>().OnReachedEndOfLevel += ShowGameWinUI;
    }


    public void ClickAnyKey()
    {
        if (gameIsOver)
        {
            SceneManager.LoadScene(1);
        }                            
    }

    private void ShowGameWinUI()
    {
       OnGameOver (gameWinUI);
    }

    private void ShowGameLoseUI()
    {
        OnGameOver(gameLoseUI);
    }

    private void OnGameOver(GameObject gameoverUI)
    {
        gameoverUI.SetActive(true);
        gameIsOver = true;
        Guard.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
        FindObjectOfType<Player>().OnReachedEndOfLevel -= ShowGameWinUI;
    }

    private void GuardDisable()
    {
        guardDisabled = true;
    }

}
