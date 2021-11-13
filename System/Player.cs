using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    [SerializeField] int _carentLevel = 1;
    [SerializeField] TaskGenerator _taskGenerator;
    [SerializeField] TextMeshProUGUI _taskLable;
    [SerializeField] UnityEvent _OnNextLevel;
    [SerializeField] UnityEvent _onEndGame;

    public void StartLevel()
    {
        var taskCard =  _taskGenerator.GenerateNewTask(_carentLevel, OnVictory, OnLoss);

        _taskLable.text = string.Format("Find {0} ", taskCard.name);
    }
   
    public void NextLevel()
    {
        if (_carentLevel > 3)
            _onEndGame?.Invoke();
        else
        {
            _OnNextLevel?.Invoke();
            StartLevel();
        }
    }

    public void OnVictory()
    {
        _carentLevel++;
        Debug.Log("Victory");
        NextLevel();
    }

    public void OnLoss()
    {
        Debug.Log("losing");
    }

    public void Restar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
