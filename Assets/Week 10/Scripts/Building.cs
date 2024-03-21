using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject[] buildingParts;

    public float speed = 2f;
    public float delayBetweenParts = 0.5f;



    private void Start()
    {
        StartCoroutine(BuildInBuilding());
    }

    IEnumerator BuildInBuilding()
    {
        foreach (GameObject part in buildingParts)
        {
            StartCoroutine(Scale(part.transform));
            yield return new WaitForSeconds(delayBetweenParts);
        }
    }

    IEnumerator Scale(Transform partTransform)
    {
        Vector3 targetScale = new Vector3(1,1,1);
        float interpolation = 0f;

        while (interpolation < 1)
        {
            interpolation += Time.deltaTime * speed;
            partTransform.localScale = Vector3.Lerp(Vector3.zero, targetScale, interpolation);
            yield return null;
        }
    }
}
