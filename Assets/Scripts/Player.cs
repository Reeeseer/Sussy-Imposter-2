using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _jumpforce = 10f;
    [SerializeField] float _rotationFactor = 10f;
    [SerializeField] AudioClip[] _audioClips;
    [SerializeField] float _horiztonalSpeed = 2f;
    [SerializeField] bool _canMove = true;

    Rigidbody _rb;
    AudioSource _audio;
    Animator _animator;
    private Collider _collider;
    FixedJoystick _joystick;

    void Start()
    {
        _canMove = true;
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<Collider>();
        _audio.clip = _audioClips[0];
        _joystick = FindObjectOfType<FixedJoystick>();
    }
    void Update()
    {
        if (_canMove)
        {
            float zRot = _rb.velocity.y * _rotationFactor;
            zRot = Mathf.Clamp(zRot, -75, 30);
            transform.rotation = Quaternion.Euler(0, 0, zRot);

            float horizontal = _joystick.Direction.x;
            transform.Translate(new Vector3(horizontal, 0, 0) * _horiztonalSpeed * Time.deltaTime);

            //code for tap screen jump
            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);
            //    if(touch.phase== TouchPhase.Began)
            //    {
            //        Jump();
            //    }
            //}
        }

    }

    //code called by jump button
    public void Jump()
    {
        _audio.pitch = 1 + Random.Range(-0.2f, 0.2f);
        _rb.velocity = Vector3.up * _jumpforce;
        _audio.Play();
        _animator.SetTrigger("Flap");
    }

    public void Die()
    {
        _audio.PlayOneShot(_audioClips[1]);
        _collider.enabled = false;
        _canMove = false;
        StartCoroutine(DieAnimation());
    }

    public IEnumerator DieAnimation()
    {
        LeanTween.rotateAround(gameObject, transform.forward, 1080, 3);
        LeanTween.move(gameObject, transform.position + Vector3.up, 1);
        yield return new WaitForSeconds(1);
        LeanTween.move(this.gameObject, transform.position + Vector3.down * 20, 2);
    }
}
