using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator Animator => _animator;
    public Vector3 Movement => _movement;
    public float TurnSpeed => _turnSpeed;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Vector3 _movement;
    [SerializeField]
    private float _turnSpeed;
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private Quaternion _rotation = Quaternion.identity;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        _turnSpeed = 20.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, _turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(_rotation);
    }
}
