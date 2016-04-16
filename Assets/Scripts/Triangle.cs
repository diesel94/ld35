using UnityEngine;
using System.Collections;

public class Triangle : MonoBehaviour
{
    public enum Direction
    {
        RIGHT,
        LEFT,
        BOTTOM,
        TOP
    };

    public Color color;
    public BoxCollider2D collider;
    public Direction direction;
    public float flyAwaySpeed = 30;
    private bool fly = false;

    void Awake()
    {
        color = GetComponent<SpriteRenderer>().color;
        collider = GetComponent<BoxCollider2D>();
    }

    public void FlyAway()
    {
        StartCoroutine(FlyAwayCoroutine());
    }

    private IEnumerator FlyAwayCoroutine()
    {
        float passedTime = 0.0f;
        Vector3 translateVector = GetTranslateVector();
        while(passedTime < 0.3f)
        {
            passedTime += Time.deltaTime;
            transform.localPosition += translateVector * flyAwaySpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

    private Vector3 GetTranslateVector()
    {
        switch(direction)
        {
            case Direction.RIGHT:
                return Vector3.right;
            case Direction.LEFT:
                return -Vector3.right;
            case Direction.TOP:
                return Vector3.up;
            case Direction.BOTTOM:
                return -Vector3.up;
            default:
                return Vector3.zero;
        }
    }
}
