using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoBehaviour
{
    protected abstract void Collect(Player player);

    [SerializeField] float _moveSpeed = 1;
    protected float MoveSpeed => _moveSpeed;

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }

    protected virtual void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0, _moveSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            //spawn particles/sfx
            Feedback();

            gameObject.SetActive(false);
        }
    }

    private void Feedback()
    {
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
        }

        if(_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }
}
