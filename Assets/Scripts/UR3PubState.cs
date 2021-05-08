using RosMessageTypes.Ur3Moveit;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;

public class UR3PubState : MonoBehaviour
{
    //ROS
    public ROSConnection ros;
    private int nJoints = 6;
    public string rosTopic = "robot_state";
    private float timer = 0.0f;
    private float waitTime = 2.0f;

    //Scene
    public GameObject robot;

    //Joints
    private ArticulationBody[] jointArticulationBodies;

    //Map Joints
    void Awake()
    {
        jointArticulationBodies = new ArticulationBody[nJoints];

        jointArticulationBodies[0] = robot.transform.Find("world/base_link/shoulder_link").GetComponent<ArticulationBody>();
        jointArticulationBodies[1] = robot.transform.Find("world/base_link/shoulder_link/upper_arm_link").GetComponent<ArticulationBody>();
        jointArticulationBodies[2] = robot.transform.Find("world/base_link/shoulder_link/upper_arm_link/forearm_link").GetComponent<ArticulationBody>();
        jointArticulationBodies[3] = robot.transform.Find("world/base_link/shoulder_link/upper_arm_link/forearm_link/wrist_1_link").GetComponent<ArticulationBody>();
        jointArticulationBodies[4] = robot.transform.Find("world/base_link/shoulder_link/upper_arm_link/forearm_link/wrist_1_link/wrist_2_link").GetComponent<ArticulationBody>();
        jointArticulationBodies[5] = robot.transform.Find("world/base_link/shoulder_link/upper_arm_link/forearm_link/wrist_1_link/wrist_2_link/wrist_3_link").GetComponent<ArticulationBody>();
    }

    void SendRobotStateMessage()
	{
        UR3Joints jointsMessage = new UR3Joints();

        jointsMessage.joint_00 = jointArticulationBodies[0].xDrive.target;
        jointsMessage.joint_01 = jointArticulationBodies[1].xDrive.target;
        jointsMessage.joint_02 = jointArticulationBodies[2].xDrive.target;
        jointsMessage.joint_03 = jointArticulationBodies[3].xDrive.target;
        jointsMessage.joint_04 = jointArticulationBodies[4].xDrive.target;
        jointsMessage.joint_05 = jointArticulationBodies[5].xDrive.target;

        ros.Send(rosTopic, jointsMessage);
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            SendRobotStateMessage();
            timer = timer - waitTime;
        }
    }
}
