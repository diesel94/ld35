using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public static CameraController instance { get; private set; }
    public float shakeTime = 1.0f;
    public float shakeMagnitude = 1.0f;

    void Awake()
    {
        instance = this;
    }

    public void Shake(bool strong)
    {
        StartCoroutine(ShakeCoroutine(strong));
    }

    private IEnumerator ShakeCoroutine(bool strong = false)
    {
        float timePased = 0.0f;
        Vector3 originalPos = transform.position;

        while(timePased < shakeTime)
        {
            timePased += Time.deltaTime;
            float percentTimePased = timePased / shakeTime;
            float dim = 1.0f - Mathf.Clamp01(4.0f * percentTimePased - 3.0f);
            float deltaX = Mathf.PerlinNoise(Random.value, Random.value) * 2 - 1;
            float deltaY = Mathf.PerlinNoise(Random.value, Random.value) * 2 - 1;
            deltaX *= (shakeMagnitude * dim);
            deltaY *= (shakeMagnitude * dim);
            if(strong)
            {
                deltaX *= 3;
                deltaY *= 3;
            }
            Vector3 newPos = new Vector3(originalPos.x + deltaX, originalPos.y + deltaY, originalPos.z);
            transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }
        transform.position = originalPos;
    }
	
}
