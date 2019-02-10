using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
    public Transform path;
    public Transform path2;

    private List<Transform> nodes;
    private int currentNode = 0;
    private float targetSteerAngle = 0;
   // public bool isBraking = false;
    public float turnSpeed = 5f;

    public WheelCollider front_left;
    public WheelCollider front_right;
    public WheelCollider rear_left;
    public WheelCollider rear_right;

    public GameObject FL;
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;

    public float topSpeed = 250f;
    public float maxTorque = 300f;
    public float maxSteerAngle = 40f;
    public float currentSpeed;
    public float maxBrakeTorque=2200;
    public Vector3 centerOfMass;

    private float Forward;
    private float Turn;
    private float Brake;

    private Rigidbody rb;

    void Start () {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
                nodes.Add(pathTransforms[i]);
        }
    }
	

	void FixedUpdate () {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        if (GlobalVariables.self_driving) 
        {
            ApplySteer();
            Drive();
            Braking();           
            SmoothSteer();
        }
        else
        {
            Forward = Input.GetAxis("Vertical");
            Turn = Input.GetAxis("Horizontal");
            Brake = Input.GetAxis("Jump");

            front_left.steerAngle = maxSteerAngle * Turn;
            front_right.steerAngle = maxSteerAngle * Turn;

            currentSpeed = 2 * 22 / 7 * front_left.radius * rear_left.rpm * 60 / 1000; //formula for calculating speed in kmph

            if (currentSpeed < topSpeed)
            {
                rear_left.motorTorque = maxTorque * Forward;
                rear_right.motorTorque = maxTorque * Forward;
            }

            rear_left.brakeTorque = maxBrakeTorque * Brake;
            rear_right.brakeTorque = maxBrakeTorque * Brake;
            front_left.brakeTorque = maxBrakeTorque * Brake;
            front_right.brakeTorque = maxBrakeTorque * Brake;
        }
        WaypointDistance();
    }

    void ApplySteer()
    {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        relativeVector /= relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        targetSteerAngle = newSteer;
        //WheelsVisuals();
    }

    void Drive()
    {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        currentSpeed = 2 * 22 / 7 * rear_left.radius * rear_left.rpm * 60 / 1000;
        if (currentSpeed < topSpeed && !GlobalVariables.is_breaking)
        {
            rear_left.motorTorque = maxTorque;
            rear_right.motorTorque = maxTorque;
        }
        else
        {
            //isBraking = true;
            rear_right.motorTorque = 0;
        }
    }

    void WaypointDistance()
    {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f && currentNode != nodes.Count - 1)
        {
            currentNode++;
        }
    }

    void Braking()
    {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        if (GlobalVariables.is_breaking)
        {
            rear_left.brakeTorque = maxBrakeTorque;
            rear_right.brakeTorque = maxBrakeTorque;
        }
        else
        {
            rear_left.brakeTorque = 0;
            rear_right.brakeTorque = 0;
        }

    }
    void SmoothSteer()
    {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        front_left.steerAngle = Mathf.Lerp(front_left.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        front_right.steerAngle = Mathf.Lerp(front_right.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }
    void Update()
    {
        //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        Quaternion flq; //rotation of wheel collider
        Vector3 flv; //position of wheel collider
        front_left.GetWorldPose(out flv, out flq);//get collider position and rotation
        FL.transform.position = flv;
        FL.transform.rotation = flq;

        Quaternion frq; //rotation of wheel collider
        Vector3 frv; //position of wheel collider
        front_right.GetWorldPose(out frv, out frq);//get collider position and rotation
        FR.transform.position = frv;
        FR.transform.rotation = frq;

        Quaternion blq; //rotation of wheel collider
        Vector3 blv; //position of wheel collider
        rear_left.GetWorldPose(out blv, out blq);//get collider position and rotation
        BL.transform.position = blv;
        BL.transform.rotation = blq;

        Quaternion brq; //rotation of wheel collider
        Vector3 brv; //position of wheel collider
        rear_right.GetWorldPose(out brv, out brq);//get collider position and rotation
        BR.transform.position = brv;
        BR.transform.rotation = brq;
    }

}
