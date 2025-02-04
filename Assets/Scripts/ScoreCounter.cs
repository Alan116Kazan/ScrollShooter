using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _scoreText1;
    [SerializeField] private Text _scoreText2;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        string scoreString = _scoreManager.Score.ToString();
        _scoreText1.text = scoreString;
        _scoreText2.text = scoreString;
    }
}