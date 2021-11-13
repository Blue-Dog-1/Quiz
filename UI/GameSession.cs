using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] TaskGenerator _taskGenerator;

    public void Restar()
    {
        _taskGenerator.ResetSessionData();
    }
}
