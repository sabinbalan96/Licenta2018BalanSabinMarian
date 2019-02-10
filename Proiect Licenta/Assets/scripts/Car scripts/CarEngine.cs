using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
// controlul masinii
// capacitatea de a semnaliza automat in viraj si in sensul giratoriu

public class CarEngine : MonoBehaviour {

    public Transform path;

    public WheelCollider front_left;
    public WheelCollider front_right;
    public WheelCollider rear_left;
    public WheelCollider rear_right;
    public GameObject FL;
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;
    public float turnSpeed=5f;
    public float maxSteerAngle = 45f;
    public float maxTorque = 80f;
    public float currentSpeed;
    public float maxSpeed=100f;
    public float maxBrakeTorque = 200f;

    public bool isBraking=false;

    public Vector3 centerOfMass;

    private List<Transform> nodes;
    private int currentNode = 0;

    public Renderer signalLeft;
    public Renderer signalRight;
    public Renderer rearSignalLeft;
    public Renderer rearSignalRight;
    public Material signalON;
    public Material signalOff;

    public bool signalCapability = true;
    public bool smallRoundabout = true;

    [Header("Sensors")]
    public float sensorLength;
    public Vector3 frontSensorPosition= new Vector3(1.2f,0.2f,0.45f);
    public float frontSideSenzorPosition;
    public float frontSensorAngle;

    private bool avoiding=false;
    private float targetSteerAngle = 0;
    bool rightSignalFlag = false;


    void Start ()
    { //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
                nodes.Add(pathTransforms[i]);
        }
    }
	
	void FixedUpdate ()
    { //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        Sensors();
        ApplySteer();
        Drive();
        WaypointDistance();
        Braking();
        SmoothSteer();
	}

    void ApplySteer()
    { //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        if (avoiding) return;

        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        relativeVector /= relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude)*maxSteerAngle;
        targetSteerAngle = newSteer;
        WheelsVisuals();
        if (signalCapability)
            TurnSignals(targetSteerAngle);
        else
        {
            signalRight.material = signalOff;
            signalLeft.material = signalOff;
            rearSignalLeft.material = signalOff;
            rearSignalRight.material = signalOff;
}
    }

    void Drive()
    { //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        currentSpeed = 2 * 22 / 7 * rear_left.radius * rear_left.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed && !isBraking)
        {
            rear_left.motorTorque = maxTorque;
            rear_right.motorTorque = maxTorque;
        }
        else
        {
            rear_right.motorTorque = 0;
        }
    }

    void WaypointDistance()
    { //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f && currentNode!=nodes.Count-1)
        {
            currentNode++;
        }
    }

    void Braking()
    { //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        if (isBraking)
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

    void Sensors()
    { //adaptare dupa tutorialele video realizate de EYEmaginary "https://www.youtube.com/channel/UCNNLI9QPXU5wQUUsfDG6n6w"
        RaycastHit hit;
        Vector3 sensorStartPos=transform.position;
        sensorStartPos += transform.forward * frontSensorPosition.x;
        sensorStartPos -= transform.up * frontSensorPosition.y;
        float avoidMultiplier = 0;
        avoiding = false;
       
        //front right
        sensorStartPos += frontSideSenzorPosition * transform.right;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("obstacle"))
            {
                Debug.DrawRay(sensorStartPos, transform.forward * sensorLength, Color.white);
                avoiding = true;
                avoidMultiplier -= 1f;
            }
        }

        //front right angle 
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("obstacle"))
            {
                Debug.DrawRay(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward * sensorLength, Color.white);
                avoiding = true;
                avoidMultiplier -= 0.5f;

            }
        }
        //front left
        sensorStartPos -= frontSideSenzorPosition * transform.right * 2;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("obstacle"))
            {
                Debug.DrawRay(sensorStartPos, transform.forward * sensorLength, Color.white);
                avoiding = true;
                avoidMultiplier += 1f;
            }
        }

        //front left angle
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("obstacle"))
            {
                Debug.DrawRay(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward * sensorLength, Color.white);
                avoiding = true;
                avoidMultiplier += 0.5f;
            }
        }

        //front center
        if (avoidMultiplier == 0)
        {
            if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
            {
                if (hit.collider.CompareTag("obstacle"))
                {
                    Debug.DrawRay(sensorStartPos, transform.forward * sensorLength, Color.white);
                    avoiding = true;
                    if (hit.normal.x < 0)
                        avoidMultiplier += -1;
                    else
                        avoidMultiplier += 1;
                    
                }
            }
        }

        if (avoiding)
        {
            targetSteerAngle = maxSteerAngle * avoidMultiplier;  
            WheelsVisuals();
            GlobalVariables.collision_detected = true;
        }

    }

    void SmoothSteer()
    { //adaptare dupa tutorialele video realizate de EYEmaginary
        front_left.steerAngle = Mathf.Lerp(front_left.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        front_right.steerAngle = Mathf.Lerp(front_right.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }

    void WheelsVisuals()
    { //adaptare dupa tutorialele video realizate de EYEmaginary
        Quaternion flq; //rotation of wheel collider
        Vector3 flv; //position of wheel collider
        front_left.GetWorldPose(out flv, out flq);
        FL.transform.position = flv;
        FL.transform.rotation = flq;

        Quaternion frq; //rotation of wheel collider
        Vector3 frv; //position of wheel collider
        front_right.GetWorldPose(out frv, out frq);
        FR.transform.position = frv;
        FR.transform.rotation = frq;

        Quaternion blq; //rotation of wheel collider
        Vector3 blv; //position of wheel collider
        rear_left.GetWorldPose(out blv, out blq);
        BL.transform.position = blv;
        BL.transform.rotation = blq;

        Quaternion brq; //rotation of wheel collider
        Vector3 brv; //position of wheel collider
        rear_right.GetWorldPose(out brv, out brq);
        BR.transform.position = brv;
        BR.transform.rotation = brq;
    }

    void TurnSignals(float turnAngle)
    {
        //adaptare dupa tutorialele video realizate de Aaron Hibberd "https://www.youtube.com/watch?v=kN7Rx3uPBuU&t=614s"
        if (smallRoundabout)
        {
            if (turnAngle > 19) rightSignalFlag = true;
            if (rightSignalFlag)
            {
                signalRight.material = signalON;
                signalLeft.material = signalOff;
                rearSignalRight.material = signalON;
                rearSignalLeft.material = signalOff;
                float floor = 0f;
                float ceiling = 1f;
                float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
                signalRight.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
                rearSignalRight.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
            }
            else
            {
                signalLeft.material = signalON;
                signalRight.material = signalOff;
                rearSignalLeft.material = signalON;
                rearSignalRight.material = signalOff;
                float floor = 0f;
                float ceiling = 1f;
                float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
                signalLeft.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
                rearSignalLeft.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
            }
        }
        else
        {
            if (turnAngle < -1)
            {
                signalLeft.material = signalON;
                signalRight.material = signalOff;
                rearSignalLeft.material = signalON;
                rearSignalRight.material = signalOff;
                float floor = 0f;
                float ceiling = 1f;
                float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
                signalLeft.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
                rearSignalLeft.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
            }
            else if (turnAngle > 1)
            {
                signalRight.material = signalON;
                signalLeft.material = signalOff;
                rearSignalRight.material = signalON;
                rearSignalLeft.material = signalOff;
                float floor = 0f;
                float ceiling = 1f;
                float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
                signalRight.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
                rearSignalRight.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
            }
            else
            {
                signalRight.material = signalOff;
                signalLeft.material = signalOff;
                rearSignalLeft.material = signalOff;
                rearSignalRight.material = signalOff;
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StopSignalTriger")
        {
            signalCapability = false;
        }
    }
}
