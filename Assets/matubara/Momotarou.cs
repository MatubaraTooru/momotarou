using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Momotarou : MonoBehaviour
{
    [SerializeField, Header("桃太郎の移動スピード")] float _moveSpeed;
    [SerializeField, Header("壁のタグ")] string _walltag;
    [SerializeField, Header("動物たちのタグ")] string _animaltag;
    Rigidbody2D _rb;
    Vector2 _moveDirection = Vector2.right;
    public int AnimalCount { get; private set; } = 0;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(_walltag))
        {
            _moveDirection = -1 * _moveDirection;
        }
        else if(collision.collider.CompareTag(_animaltag))
        {
            AnimalCount++;
        }
    }
    private void Move()
    {
        Vector2 velo = Vector2.zero;
        velo = _moveDirection.normalized * _moveSpeed;
        velo.y = _rb.velocity.y;
        _rb.velocity = velo;
    }
}
