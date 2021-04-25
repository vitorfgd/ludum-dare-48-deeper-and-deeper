using System.Globalization;
using TMPro;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    [SerializeField]
    private float _tolerance;

    [SerializeField]
    private Transform _progressLine;

    [SerializeField]
    private TMP_Text _score;

    private Transform _progressLineTransform;

    private void Start()
    {
        _progressLineTransform = _progressLine.transform;
        _progressLineTransform.position = new Vector2(
            _progressLineTransform.position.x,
            GameManager.Instance.PersonalBest
        );
    }

    private void Update()
    {
        var gameManager = GameManager.Instance;
        
        _progressLine.gameObject.SetActive(!(gameManager.PersonalBest < _tolerance));
        _progressLineTransform.position = new Vector2(_progressLineTransform.position.x, gameManager.PersonalBest);
        _score.text = $"Personal Best: {gameManager.PersonalBest.ToString("n2", CultureInfo.InvariantCulture)}";
    }
}
