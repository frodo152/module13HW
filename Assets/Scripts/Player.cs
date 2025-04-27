using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _currentTimer;
    [SerializeField] private float _timerToDead;

    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";
    private KeyCode _jumpKey = KeyCode.Space;

    private float _xInput;
    private float _zInput;

    private bool _isJumping = false;

    [SerializeField] private float _coinsToWin;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private int _coins;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _currentTimer += Time.deltaTime;

        _xInput = Input.GetAxisRaw(HorizontalAxis);
        _zInput = Input.GetAxisRaw(VerticalAxis);

        if (Input.GetKeyDown(_jumpKey))
        {
            _isJumping = true;
        }

        Vector3 force = new Vector3(_xInput, 0, _zInput) * _speed;

        _rigidbody.AddForce(force);

        if (_coins == _coinsToWin)
        {
            ProcessVictory();
        }

        if (_currentTimer >= _timerToDead)
        {
            ProcessDefeat();
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
            _isJumping = false;
        }
    }

    public void AddCoin(int value)
    {
        _coins += value;
    }

    private void ProcessDefeat()
    {
        Debug.Log("¬рем€ вышло! ¬ы не успели собрать все монеты за отведенное врем€!");
        gameObject.SetActive(false);
    }

    private void ProcessVictory()
    {
        Debug.Log("¬ы собрали все монеты за отведенное врем€ и победили!");
        gameObject.SetActive(false);
    }
}
