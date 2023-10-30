using UnityEngine;
using UnityEngine.Splines;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] protected int _attackDelay;
    

    protected Animator _animator;
    protected SplineAnimate _splineAnimate;
    protected Collider _collider;

    protected bool _isInCamera;
    protected float _attackTime;

    private void OnEnable()
    {
        _splineAnimate = GetComponent<SplineAnimate>();
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    public void AssignSpline(SplineContainer container, float speed)
    {
        _splineAnimate.Container = container;
        _splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
        _splineAnimate.MaxSpeed = speed;
    }

    private void Update()
    {
        UpdateBehavior();
    }

    public virtual void UpdateBehavior()
    {

        _isInCamera = GeometryUtility.TestPlanesAABB(
            CameraManager.instance._cameraPlanes,
            _collider.bounds);

        if (_splineAnimate.IsPlaying == false && _splineAnimate.ElapsedTime > 0.5f && !_isInCamera)
        {
            Destroy(gameObject);
        }
        else if (_splineAnimate.IsPlaying != true)
            _splineAnimate.Play();

        if (AttackCondition())
        {
            AttackBehavior();
        }
    }

    public virtual void AttackBehavior()
    {
        _attackTime = _attackDelay + Time.time;
    }

    public virtual bool AttackCondition()
    {
        return (Time.time >= _attackTime) && _isInCamera;
    }

}
