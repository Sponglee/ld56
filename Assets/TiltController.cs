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