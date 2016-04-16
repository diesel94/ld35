using UnityEngine;
using System.Collections;

public class Triangle : MonoBehaviour
{
    public Color color;
    public BoxCollider2D collider;

    void Awake()
    {
        color = GetComponent<SpriteRenderer>().color;
        collider = GetComponent<BoxCollider2D>();
    }
}
