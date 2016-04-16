using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CircleCollider2D))]
public class Circle : MonoBehaviour
{
    public Action OnDestroy;
    public LayerMask playerMask;
    public float moveSpeed = 100;
    private int direction = 1;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D myCollider;
    private Triangle targetTriangle;
    private bool needToCheckColl = true;

    void Awake()
    {
        myCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (needToCheckColl)
        {
            CheckIfNeedToDestroy();
        }
    }

    void Update()
    {
        Move();
    }

    public void Init(Color color, int direction)
    {
        this.spriteRenderer.color = color;
        this.targetTriangle = Player.triangles[color];
        this.direction = direction;
    }

    void CheckIfNeedToDestroy()
    {
        if(Physics2D.IsTouchingLayers(myCollider, playerMask))
        {
            needToCheckColl = false;
            if(Physics2D.IsTouching(myCollider, targetTriangle.collider))
            {
                GameManager.instance.Win();
            }
            else
            {
                GameManager.instance.Lose();
            }
            OnDestroy();
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.Translate(transform.right * direction * moveSpeed * Time.deltaTime);
    }
}
