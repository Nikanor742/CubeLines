using Supyrb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UISystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject failWindow;
    [SerializeField] private GameObject winWindow;

    Signal startGameSignal;
    Signal gameOverSignal;
    Signal levelWinSignal;

    private void Start()
    {
        startGameSignal = Signals.Get<StartGameSignal>();
        gameOverSignal = Signals.Get<GameOverSignal>();
        levelWinSignal = Signals.Get<LevelWinSIgnal>();

        gameOverSignal.AddListener(OnGameOver);
        levelWinSignal.AddListener(OnLevelWin);
        startButton.onClick.AddListener(OnStartButtonClick);
        retryButton.onClick.AddListener(OnRetryButtonClick);
        nextButton.onClick.AddListener(OnNextButtonClick);
        SetLevelText();
    }

    private void SetLevelText()
    {
        levelText.text = "спнбемэ " + PlayerPrefs.GetInt("LevelUI", 1);
    }

    IEnumerator TimeToShowFailScreen()
    {
        yield return new WaitForSeconds(0.5f);
        failWindow.SetActive(true);
    }

    private void OnGameOver()
    {
        StartCoroutine(TimeToShowFailScreen());
    }

    private void OnLevelWin()
    {
        winWindow.gameObject.SetActive(true);
    }

    private void OnStartButtonClick()
    {
        startButton.gameObject.SetActive(false);
        startGameSignal?.Dispatch();
    }

    private void OnRetryButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnNextButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(OnStartButtonClick);
        retryButton.onClick.RemoveListener(OnRetryButtonClick);
        nextButton.onClick.RemoveListener(OnNextButtonClick);
        gameOverSignal.RemoveListener(OnGameOver);
        levelWinSignal.RemoveListener(OnLevelWin);
    }
}
