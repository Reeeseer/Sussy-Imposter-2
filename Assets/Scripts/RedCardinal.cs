using Unity.VisualScripting;
using UnityEngine;

public class RedCardinal : BasicEnemy
{
    [SerializeField] LayerMask _targetMasks;
    [SerializeField] float _flightSpeed;
    Vector3 _target;
    float _alpha = 0;


    public override void AttackBehavior()
    {
        _splineAnimate.Pause();
        _splineAnimate.Container = null;
        _target = transform.position + transform.forward * 25;
    }

    public override void UpdateBehavior()
    {
        base.UpdateBehavior();
        if(_target != Vector3.zero)
        {

            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, _target.x, _alpha),
                transform.position.y,
                transform.position.z);

            _alpha += (Time.deltaTime * _flightSpeed) / 25;
        }
    }

    public override bool AttackCondition()
    {
        return 
            Physics.Raycast(transform.position, transform.forward, 500f, _targetMasks)
            && Time.time > _attackDelay;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if(player != null)
        {
            GameManager.Instance.KillPlayer(player);
        }
    }
}
