using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    [SerializeField] private Transform[] segments;
    [SerializeField] private float angleToOffset = 5f;
    [SerializeField] private float tiltSpeed = 5f;

    [SerializeField] private AnimationCurve segmentCurve;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != default)
        {
            transform.RotateAround(Vector3.forward, Input.GetAxis("Horizontal") * Time.deltaTime * tiltSpeed);
        }

        UpdateSegments();
    }

    private void UpdateSegments()
    {
        for (var i = 0; i < segments.Length; i++)
        {
            var segment = segments[i];

            var localPosition = segment.localPosition;
            var segmentEvaluation = (float)i / segments.Length;
            localPosition =
                new Vector3(
                    segmentCurve.Evaluate(segmentEvaluation) * angleToOffset *
                    (segment.position - transform.position).normalized.x,
                    localPosition.y,
                    localPosition.z);

            segment.localPosition = localPosition;
        }
    }
}