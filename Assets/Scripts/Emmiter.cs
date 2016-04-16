using UnityEngine;
using System.Collections;

public class Emmiter : MonoBehaviour {

    enum Side
    {
        LEFT,
        RIGHT
    };

    public GameObject circlePrefab;
    public Color[] colors;
    public Transform leftEmiter;
    public Transform rightEmiter;
    public bool isEmitingEnable = true;
    private Side currentSide;

    void Start()
    {
        Invoke("Emit", 1.0f);
    }

    private void ChooseSide()
    {
        currentSide = (Side)Random.Range(0, 2);
    }

    public void Emit()
    {
        if (isEmitingEnable)
        {
            ChooseSide();
            GameObject circleGO = InstCircle();
            Circle circle = circleGO.GetComponent<Circle>();
            circle.Init(ChooseColor(), (currentSide == Side.LEFT ? 1 : -1));
            circle.OnDestroy += Emit;
        }
    }

    private GameObject InstCircle()
    {
        Vector3 position = currentSide == Side.LEFT ? leftEmiter.position : rightEmiter.position;
        position.z = 0;
        return Instantiate(circlePrefab, position, transform.rotation) as GameObject;
    }

    private Color ChooseColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }

}
