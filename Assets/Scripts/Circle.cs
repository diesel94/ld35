using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class Circle : MonoBehaviour
{
    public System.Action OnDestroy;
    public LayerMask playerMask;
    public float moveSpeed = 100;
    private int direction = 1;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D myCollider;
    private TrailRenderer trialRenderer;
    private Triangle targetTriangle;
    private bool needToCheckColl = true;
    private bool isBoostEnable = true;

    void Awake()
    {
        myCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trialRenderer = GetComponent<TrailRenderer>();
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
        Boost();
        Move();
    }

    public void Init(Color color, int direction)
    {
        this.spriteRenderer.color = color;
        this.targetTriangle = Player.triangles[color];
        this.trialRenderer.material.color = color;
        this.direction = direction;
    }

    void CheckIfNeedToDestroy()
    {
        if(Physics2D.IsTouchingLayers(myCollider, playerMask))
        {
            needToCheckColl = false;
            if(Physics2D.IsTouching(myCollider, targetTriangle.collider))
            {
                GameManager.instance.Win(!isBoostEnable);
            }
            else
            {
                GameManager.instance.Lose();
            }
            OnDestroy();
            Destroy(gameObject);
        }
    }

    void Boost()
    {
        if (isBoostEnable && Input.GetKeyDown(KeyCode.Space))
        {
            isBoostEnable = false;
            moveSpeed *= 3;
            trialRenderer.time *= 3;
        }
    }

    void Move()
    {
        transform.Translate(transform.right * direction * moveSpeed * Time.deltaTime);
    }
}
