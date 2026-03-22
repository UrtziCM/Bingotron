using System.Linq;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform[] lookPositions;
    private int lookingPos = 0;

    private Transform target;
    private Transform look;

    [SerializeField] float animationTime;
    float t = 0;
    private bool notChanging = true;

    [SerializeField] AnimationCurve curve;

    private void Start()
    {
        target = lookPositions[0];
        look = lookPositions[0];
        transform.LookAt(look);
    }
    private void Update()
    {
        if (notChanging)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                lookAt(true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                lookAt(false);
            }
        }

        Resolve();
    }
    private void Resolve()
    {
        if (notChanging) return;

        t += Time.deltaTime;

        Vector3 posToMove = Vector3.Lerp(look.position, target.position, curve.Evaluate(t/animationTime));
        transform.LookAt(posToMove);

        if (t >= animationTime)
        {
            notChanging = true;
            t = 0;
        }
    }
    private void lookAt(bool up)
    {
        if (up)
            if (lookingPos > 0) lookingPos -= 1;
            else return;
        else
            if (lookingPos < lookPositions.Length - 1) lookingPos += 1;
            else return;

        look = target;
        target = lookPositions[lookingPos];
        notChanging = false;
    }
}
