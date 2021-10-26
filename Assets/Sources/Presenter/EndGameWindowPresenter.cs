using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameWindowPresenter : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _scoreLabel;

    public void Show(int score, Action onReloadClick)
    {
        _scoreLabel.text = $"You Score - {score}";

        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(() => onReloadClick());

        gameObject.SetActive(true);
    }
}