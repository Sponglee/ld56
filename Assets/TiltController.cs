using System;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    [SerializeField] private SpringJoint[] segments;
    [SerializeField] private float tiltTreshold = 45;
    [SerializeField] private GroundChecker groundChecker;

    private bool isBroken = false;

    private void Awake()
    {
        groundChecker.groundHit += CheckTilt;
    }

    private void OnDestroy()
    {
        groundChecker.groundHit -= CheckTilt;
    }

    public void TiltUp()
    {
        transform.rotation = Quaternion.identity;

        for (int i = 0; i < segments.Length; i++)
        {
            var segmentTransform = segments[i].transform;

            segmentTransform.localRotation = Quaternion.identity;
        }
    }

    public void TiltSideways()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);

        for (int i = 0; i < segments.Length; i++)
        {
            var segmentTransform = segments[i].transform;

            segmentTransform.localRotation = Quaternion.Euler(-90, 0f, 0);
        }
    }

    private void CheckTilt()
    {
        if (isBroken) return;

        for (int i = segments.Length - 1; i >= 0; i--)
        {
            var segment = segments[i];
            var body = segment.GetComponent<Rigidbody>();
            segment.breakForce = 0;
            body.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }

        isBroken = true;
    }
}