using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform[] lookPositions;
    private int lookingPos;

    private Transform target;
    private Transform look;

    [SerializeField] float animationTime;
    float t = 0;
    private bool notChanging;

    [SerializeField] AnimationCurve curve;

    private void Start()
    {
        target = lookPositions[1];
    }
    private void Update()
    {
        Resolve();
    }
    private void Resolve()
    {
        if (notChanging)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                look = target;
                if (lookingPos > 0)
                    lookingPos -= 1;
                lookAt(lookPositions[lookingPos]);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                look = target;
                if (lookingPos < lookPositions.Length - 1)
                    lookingPos += 1;
                lookAt(lookPositions[lookingPos]);
            }
            return;
        }

        t += Time.deltaTime;
        Vector3 posToMove = Vector3.Lerp(look.position, target.position, t / animationTime);
        transform.LookAt(posToMove);

        if (t >= animationTime)
        {
            notChanging = true;
            t = 0;
        }
    }
    private void lookAt(Transform pos)
    {
        target = pos;
        notChanging = false;
    }
}
