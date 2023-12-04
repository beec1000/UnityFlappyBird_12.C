using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _bestScore;

    private int _score;

    private void Awake()
    {
        if (instance == null) instance = this; 
    }

    private void Start()
    {
        _currentScore.text = _score.ToString();
        _bestScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public void ScoreUpdate()
    {
        _score++;
        _currentScore.text = _score.ToString();

        if (_score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", _score);
            _bestScore.text = _score.ToString();
        }
    }

}
