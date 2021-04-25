using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 _forces;

    [SerializeField]
    private InputActionReference _vertical;
    
    [SerializeField]
    private TMP_Text _guide;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private static readonly int Dove = Animator.StringToHash("Dove");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _vertical.action.performed += _ =>
        {
            _guide.gameObject.SetActive(false);
            Dive();
        };
    }

    private void OnEnable()
    {
        _vertical.action.Enable();
    }

    private void OnDisable()
    {
        _vertical.action.Disable();
    }

    private void Update()
    {
    }

    private void Dive()
    {
        _animator.SetTrigger(Dove);
        _rigidbody.velocity = new Vector2(_forces.x, _forces.y);
        _forces.x = -_forces.x;
    }
}
