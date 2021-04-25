using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance;
    public float PersonalBest { get; private set; }

    public float Result
    {
        get => _result;
        set
        {
            _result = value;
            if (value > PersonalBest)
            {
                PersonalBest = value;
            }
        }
    }

    public bool Success
    {
        get => _success;
        set
        {
            _success = value;
            SceneManager.LoadScene($"game-over");
        }
    }

    private float _result;
    private static GameManager _instance;
    private bool _success;

    private void Awake()
    {
        if (_instance != null
            && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);
    }
}
