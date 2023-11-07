using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveWater : MonoBehaviour
{

    Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();
        StartCoroutine(MoveToPos(0f, 10f, 0f, 9.5f));
    }

    private void Update()
    {

    }

    IEnumerator MoveToPos(float xMin, float xMax, float yMin, float yMax)
    {

        float counter = 0;

        Vector3 target = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), trans.position.z);
        Vector3 startPos = trans.position;

        while (true)
        {
            trans.position = Vector3.Lerp(startPos, target, Mathf.SmoothStep(0f, 1f, counter));
            counter += Time.deltaTime / 10f;
            if (counter >= 1f)
            {
                startPos = target;
                target = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), trans.position.z);
                counter -= 1f;
            }
            yield return null;
        }
    }
}
