using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float Air
    {
        get => _air;
        set
        {
            _air += value;
            _air = Mathf.Clamp(_air, 0, _capacity);
        }
    }

    [SerializeField]
    [Range(0f, 100f)]
    private float _capacity = 100f;

    [SerializeField]
    private float _processing;

    [SerializeField]
    private float _maxDepth;

    [SerializeField]
    private AnimationCurve _modifier;

    [SerializeField]
    private Transform _reference;

    [SerializeField]
    private Image _airRemaining;

    [SerializeField]
    private TMP_Text _consumeRate;

    private float _air;
    private float _depth;
    private float _rate;

    private void Awake()
    {
        _air = _capacity;
    }

    private void Start()
    {
        StartCoroutine(Breathe());
    }

    private void Update()
    {
        var gameManager = GameManager.Instance;
        var normalized = _air / _capacity;

        if (normalized <= 0)
        {
            GameManager.Instance.Success = false;
            return;
        }

        _depth = Vector2.Distance(transform.position, _reference.position);
        gameManager.Result = _depth;

        _airRemaining.fillAmount = normalized;
        _consumeRate.text = $"Consume Rate: {_rate.ToString("n2", CultureInfo.InvariantCulture)}x";
    }

    private IEnumerator Breathe()
    {
        while (true)
        {
            var normalized = _depth / _maxDepth;
            _rate = 1 + _modifier.Evaluate(normalized);
            _air -= _rate * _processing;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
