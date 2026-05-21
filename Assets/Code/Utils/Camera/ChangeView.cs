using System.Linq;
using UnityEngine;

public class ChangeView : MonoBehaviour
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
            float scroll = Input.GetAxis("Mouse ScrollWheel");


            if (Input.GetKeyDown(KeyCode.W) || scroll > 0f)
            {
                lookAt(true);
            }
            if (Input.GetKeyDown(KeyCode.S) || scroll < 0f)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        foreach (Transform t in lookPositions)
        {
            Gizmos.DrawLine(transform.position, t.position);

            Gizmos.DrawSphere(t.position, .25f);
        }
    }
}
