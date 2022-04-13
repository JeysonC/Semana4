using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludController : MonoBehaviour
{
    
    private Animator _animator; //maneja la animación
    private const string ANIMATOR_STATE = "EstadoN"; //para el estado de la animación
    private static readonly int ANIMATION_DEAD = 2;
    private Rigidbody2D _rb; //para que nuestro player avance


    void Start()
    {
        _animator = GetComponent<Animator>();//llamamos al animator
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "ZH")
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            ChangeAnimation(ANIMATION_DEAD);

        }
        else if (tag == "ZM")
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            ChangeAnimation(ANIMATION_DEAD);
        }
    }
    public void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
}
