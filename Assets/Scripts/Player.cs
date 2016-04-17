using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameObject trianglesRoot;
    public float rotationTime = 0.5f;
    public static Dictionary<Color, Triangle> triangles;
    private bool rotationLock = false;

    void Start()
    {
        SetTriangles();
        GameManager.instance.OnLose += Die;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }

    void SetTriangles()
    {
        triangles = new Dictionary<Color, Triangle>();
        foreach(Transform triangleTrans in trianglesRoot.GetComponentInChildren<Transform>())
        {
            Triangle triangle = triangleTrans.GetComponent<Triangle>();
            triangles[triangle.color] = triangle;
        }
    }

    void RotateLeft()
    {
        if (!rotationLock)
        {
            StartCoroutine(RotateCoroutine(1));
        }
    }

    void RotateRight()
    {
        if (!rotationLock)
        {
            StartCoroutine(RotateCoroutine(-1));
        }
    }

    IEnumerator RotateCoroutine(int direction)
    {
        rotationLock = true;

        Vector3 currentEuler = transform.eulerAngles;
        Vector3 targetEuler = currentEuler;
        targetEuler.z += (direction * 90);
        float timePassed = 0.0f;

        while(timePassed < rotationTime)
        {
            timePassed += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(currentEuler, targetEuler, timePassed/rotationTime);
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = targetEuler;

        rotationLock = false;
    }

    public void Die()
    {
        rotationLock = true;
        foreach(var triangle in triangles.Values)
        {
            triangle.FlyAway();
        }
    }
}
