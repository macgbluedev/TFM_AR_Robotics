using RosMessageTypes.ShMoveitService;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;

public class SHPubState : MonoBehaviour
{
    // ROS Connector
    public ROSConnection ros;
    private float timer = 0.0f;
    private float waitTime = 2.0f;

    public string topicName = "robot_state";

    //Scene
    public GameObject robot;

    // Articulation Bodies
    private ArticulationBody[] jointArticulationBodies;
    //Map Joints
    void Awake()
    {
        jointArticulationBodies = robot.GetComponentsInChildren<ArticulationBody>();
    }

    void SendRobotStateMessage()
    {
        SHJoints joints = new SHJoints();

        joints.joint_00 = jointArticulationBodies[0].xDrive.target;
        joints.joint_01 = jointArticulationBodies[1].xDrive.target;
        joints.joint_02 = jointArticulationBodies[2].xDrive.target;
        joints.joint_03 = jointArticulationBodies[3].xDrive.target;
        joints.joint_04 = jointArticulationBodies[4].xDrive.target;
        joints.joint_05 = jointArticulationBodies[5].xDrive.target;
        joints.joint_06 = jointArticulationBodies[6].xDrive.target;
        joints.joint_07 = jointArticulationBodies[7].xDrive.target;
        joints.joint_08 = jointArticulationBodies[8].xDrive.target;
        joints.joint_09 = jointArticulationBodies[9].xDrive.target;
        joints.joint_10 = jointArticulationBodies[10].xDrive.target;
        joints.joint_11 = jointArticulationBodies[11].xDrive.target;
        joints.joint_12 = jointArticulationBodies[12].xDrive.target;
        joints.joint_13 = jointArticulationBodies[13].xDrive.target;
        joints.joint_14 = jointArticulationBodies[14].xDrive.target;
        joints.joint_15 = jointArticulationBodies[15].xDrive.target;
        joints.joint_16 = jointArticulationBodies[16].xDrive.target;
        joints.joint_17 = jointArticulationBodies[17].xDrive.target;
        joints.joint_18 = jointArticulationBodies[18].xDrive.target;
        joints.joint_19 = jointArticulationBodies[19].xDrive.target;
        joints.joint_20 = jointArticulationBodies[20].xDrive.target;
        joints.joint_21 = jointArticulationBodies[21].xDrive.target;
        joints.joint_22 = jointArticulationBodies[22].xDrive.target;
        joints.joint_23 = jointArticulationBodies[23].xDrive.target;
        joints.joint_24 = jointArticulationBodies[24].xDrive.target;
        joints.joint_25 = jointArticulationBodies[25].xDrive.target;
        joints.joint_26 = jointArticulationBodies[26].xDrive.target;
        joints.joint_27 = jointArticulationBodies[27].xDrive.target;
        joints.joint_28 = jointArticulationBodies[28].xDrive.target;

        ros.Send(topicName, joints);
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
