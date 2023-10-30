using UnityEngine;

public class Projectile : MonoBehaviour
{
    float _speed;
    Vector3 _direction;
    [SerializeField] float _lifetime = 3;
    float _timeToDie;

    private void OnEnable()
    {
        _timeToDie = Time.time + _lifetime;
    }

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        if(Time.time >= _timeToDie)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            GameManager.Instance.KillPlayer(player);
        }
    }
}
