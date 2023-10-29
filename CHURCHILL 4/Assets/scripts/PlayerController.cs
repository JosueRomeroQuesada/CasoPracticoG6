using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoState<PlayerController>
{


    [Header("Tank")]
    [SerializeField]
    Transform barrel;

    [Header("Movement")]
    [SerializeField]
    float speed = 8.5f;

    [Header("Animation")]
    [SerializeField]
    Animator animator;

    [Header("Combat")]
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform[] firePoints;

    [SerializeField]
    [Range(0.1f, 1.0f)]
    float fireRate = 0.3f;

    [SerializeField]
    Animator[] wheelAnimators;


    Rigidbody2D _rb;

    Camera CAMERA;

    Vector2 _direction;
    Vector2 _mousePosition;

    float _fireTimer;

    protected override void Awake()
    {
        base.Awake();
        CAMERA = Camera.main;
        _rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _mousePosition = CAMERA.ScreenToWorldPoint(Input.mousePosition);
        HandheldBarrelRotation();


        _fireTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _fireTimer <= 0.0f)
        {
            Shoot();
            _fireTimer = fireRate;
        }

    }



    void FixedUpdate()
    {
        if (_direction.sqrMagnitude == 0)
        {
            return;
        }
        if (animator != null)
        {
            animator.SetFloat("Horizontal", _direction.x);
            animator.SetFloat("Vertical", _direction.y);
            animator.SetFloat("Speed", _direction.sqrMagnitude);

        }
        if (wheelAnimators.Length > 0)
        {
            foreach (Animator wheelAnimator in wheelAnimators)
            {
                wheelAnimator.SetFloat("Speed", _direction.sqrMagnitude);

            }
        }

        _rb.MovePosition(_rb.position + _direction * speed * Time.fixedDeltaTime);
        HandleRotation();
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }


    }

    void HandleRotation()
    {
        float angle =
             _direction.x > 0 && _direction.y == 0
             ? 90.0f
             : _direction.x > 0 && _direction.y > 0
                  ? 45.0f
                   : _direction.x > 0 && _direction.y < 0
                     ? 135.0f
                     : _direction.x == 0 && _direction.y < 0
                         ? 180.0f
                             : _direction.x < 0 && _direction.y < 0
                             ? 225.0f
                                 : _direction.x < 0 && _direction.y == 0
                                 ? 270.0f
                                     : _direction.x < 0 && _direction.y > 0
                                     ? 315.0f
                                     : 0.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -angle));



    }

    void HandheldBarrelRotation()
    {
        float angle =
            Mathf.Atan2(_mousePosition.y - barrel.position.y,
            _mousePosition.x - barrel.position.x) * Mathf.Rad2Deg - 90.0f;
        barrel.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
    }
    
}
