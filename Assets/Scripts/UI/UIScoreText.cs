using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] string _pointsName = "Score";
    TMP_Text _TMP;

    void Start()
    {
        _TMP = GetComponent<TMP_Text>();

        GameManager.Instance.OnPlayerScoreChange += UpdateScoreText;
    }

    private void UpdateScoreText(int score)
    {
        _TMP.text = _pointsName + ":" + score.ToString();
    }
}
