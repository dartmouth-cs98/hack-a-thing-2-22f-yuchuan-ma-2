using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Color randomColor = GetRandomColorWithAlpha();
        GetComponent<Renderer>().material.color = randomColor;
    }

    private Color GetRandomColorWithAlpha() {
        return new Color(
            UnityEngine.Random.Range(0f,1f),
            UnityEngine.Random.Range(0f,1f),
            UnityEngine.Random.Range(0f,1f),
            0.25f
        );
    }
}
