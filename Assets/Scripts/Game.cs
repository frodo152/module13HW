using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float _currentTimer;
    [SerializeField] private float _timerToDead;

    [SerializeField] private Player Player;

    [SerializeField] private int _coinsToWin;

    private int _coins;


    private void Update()
    {
        _currentTimer += Time.deltaTime;
        Debug.Log(_currentTimer);

        if (_coins >= _coinsToWin )
        {
            ProcessToVictory();
        }

        if (_currentTimer >= _timerToDead)
        {
            ProcessToLose();
        }
    }

    public void AddCoin(int value)
    {
        _coins += value;
    }

    private void ProcessToVictory()
    {
        Debug.Log("¬ы собрали все монеты за отведенное врем€!");
        _currentTimer = 0;
        Player.gameObject.SetActive(false);
    }

    private void ProcessToLose()
    {
        Debug.Log("¬ы не успели собрать все монеты за отведенное врем€!");
        _currentTimer = 0;
        Player.gameObject.SetActive(false);
    }
}   
