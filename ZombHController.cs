using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombHController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;//llamamos al Sprite Renderer
    private Animator _animator; //maneja la animación
    private const string ANIMATOR_STATE = "EstadoZH"; //para el estado de la animación
    private static readonly int ANIMATION_WALK = 0;
    void Start()
    {
        _animator = GetComponent<Animator>();//llamamos al animator
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.flipX = true;//para que mire a la izquierda
        ChangeAnimation(ANIMATION_WALK);
    }
    public void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
}
