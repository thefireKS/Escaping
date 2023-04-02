using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    [SerializeField] private GameObject ropeSegment;
    [SerializeField] private int numberOfLinks;

    private void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody2D prevBody = hook;
        for (int i = 0; i < numberOfLinks; i++)
        {
            GameObject newSegment = Instantiate(ropeSegment, transform, true);
            newSegment.transform.position = transform.position;
            HingeJoint2D hingeJoint2D = newSegment.GetComponent<HingeJoint2D>();
            hingeJoint2D.connectedBody = prevBody;

            prevBody = newSegment.GetComponent<Rigidbody2D>();
        }
        prevBody.bodyType = RigidbodyType2D.Static;
        prevBody.transform.rotation = Quaternion.Euler(0f,0f,90f);
    }
}
