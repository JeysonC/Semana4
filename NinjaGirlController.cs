using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaGirlController : MonoBehaviour
{
    private Rigidbody2D _rb; //para que nuestro player avance
    private Animator _animator; //maneja la animación
    public float JumpForce = 10; //para saltar
    public float Velocity = 10;

    private const string ANIMATOR_STATE = "EstadoN"; //para el estado de la animación
    private static readonly int ANIMATION_JUMP = 1; // definimos los estados
    private static readonly int ANIMATION_DEAD = 2;
    private static readonly int ANIMATION_RUN = 0;

    private static readonly int RIGHT = 1; //irá a la derecha

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();//llamamos a rigidbody
        _animator = GetComponent<Animator>();//llamamos al animator
    }

    // Update is called once per frame
    void Update()
    {
        Desplazarse(RIGHT);

        if (Input.GetKeyUp(KeyCode.Space)) //si presionamos flecha espacio
        {

            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            ChangeAnimation(ANIMATION_JUMP);
        }

        

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

    private void Desplazarse(int position)
    {
        _rb.velocity = new Vector2(Velocity * position, _rb.velocity.y);//le decimos que se dezplace
        
        ChangeAnimation(ANIMATION_RUN);
    }

    public void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
}
