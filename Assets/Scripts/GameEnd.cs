using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _message;

    [SerializeField]
    private TMP_Text _stats;

    [SerializeField]
    private Button _button;

    private void Awake()
    {
        var gameManager = GameManager.Instance;

        _message.text = gameManager.Success
            ? $"You won!"
            : $"Game over!";

        _stats.text =
            $"Best: {gameManager.PersonalBest.ToString("n2", CultureInfo.InvariantCulture)}M\t "
            + $"Current: {gameManager.Result.ToString("n2", CultureInfo.InvariantCulture)}M";

        _button.onClick.AddListener(() => SceneManager.LoadScene("game"));
    }
}
