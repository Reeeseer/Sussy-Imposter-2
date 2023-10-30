using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJay : BasicEnemy
{
    [SerializeField] Transform _projectileSpawn;
    [SerializeField] Projectile _projectilePrefab;
    [SerializeField] float _projectileSpeed;


    public override void AttackBehavior()
    {
        base.AttackBehavior();
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawn.position, Quaternion.identity);
        var targetDir = transform.forward;
        projectile.SetDirection(targetDir);
        projectile.SetSpeed(_projectileSpeed);
    }

    public override void UpdateBehavior()
    {
        base.UpdateBehavior();
        Debug.Log(_attackTime + " - " + name);
        if (AttackCondition())
        {
            AttackBehavior();
        }
    }
}
