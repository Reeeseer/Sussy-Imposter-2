using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int _score;
    [SerializeField] float _skyboxSpeed;
    public static GameManager Instance;

    public event Action<int> OnPlayerScoreChange;
    public event Action OnPlayerDie;
    public event Action BulletHellStart;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this);

        _skyboxSpeed = 3f;
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _skyboxSpeed);
    }

    public void AddScore(int score)
    {
        _score += score;
        Debug.Log(_score);
        OnPlayerScoreChange(_score);
    }
    public void KillPlayer(Player player)
    {
        StartCoroutine(Death());
        player.Die();
        _skyboxSpeed = 0;
        OnPlayerDie();
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
    public void StartBulletHell()
    {
        BulletHellStart();
    }

}
