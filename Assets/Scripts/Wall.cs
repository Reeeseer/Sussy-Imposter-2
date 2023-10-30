using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : KillPlayerOnContact
{
    Rigidbody _rb;
    AudioSource _audio;

    public Rigidbody RB { get { return _rb;; } }

    void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponentInChildren<AudioSource>();
        GameManager.Instance.OnPlayerDie += Stop;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            GameManager.Instance.KillPlayer(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            GameManager.Instance.AddScore(1);
            _audio.pitch = 1 + Random.Range(-0.5f, 0.5f);
            _audio.Play();
        }
    }

    void Stop()
    {
        _rb.velocity = Vector3.zero;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDie -= Stop;
    }
}
