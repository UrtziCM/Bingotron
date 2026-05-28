using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallHolder : MonoBehaviour
{
    [SerializeField]
    private Transform[] filas;

    private Transform[] ballSpaces;

    [SerializeField]
    private float velocidadMovimiento = 8f;
    [SerializeField]
    private float velocidadCaida = 5f;

    private void Start()
    {
        ballSpaces = new Transform[filas.Length * 10];

        int index = 0;

        foreach (Transform fila in filas)
        {
            for (int i = 0; i < fila.childCount; i++)
            {
                ballSpaces[index] = fila.GetChild(i);
                index++;
            }
        }
    }

    public void ClearHolder()
    {
        foreach (Transform Ballspace in ballSpaces)
        {
            Destroy(transform.GetChild(0).gameObject);            
        }
    }

    public void PlaceBall(Transform ball, int ballNum)
    {
        if (ballNum < 0 || ballNum >= ballSpaces.Length + 1)
        {
            Debug.LogError("Número de bola fuera de rango");
            return;
        }

        StartCoroutine(MoveBall(ball, ballSpaces[ballNum-1]));
    }

    private IEnumerator MoveBall(Transform ball, Transform finalPos)
    {
        Vector3 posicionArriba = finalPos.position + Vector3.up * 1.0f;

        while (Vector3.Distance(ball.position, posicionArriba) > 0.01f)
        {
            ball.position = Vector3.MoveTowards(
                ball.position,
                posicionArriba,
                velocidadMovimiento * Time.deltaTime
            );

            yield return null;
        }

        ball.position = posicionArriba;

        while (Vector3.Distance(ball.position, finalPos.position) > 0.01f)
        {
            ball.position = Vector3.MoveTowards(
                ball.position,
                finalPos.position,
                velocidadCaida * Time.deltaTime
            );

            yield return null;
        }

        ball.position = finalPos.position;

        ball.SetParent(finalPos);
    }
}
