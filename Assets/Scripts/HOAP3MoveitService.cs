using RosMessageTypes.Hoap3MoveitService;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;

public class HOAP3MoveitService : MonoBehaviour
{
    //ROS
    public ROSConnection ros;
    string rosServiceName = "hoap3_moveit";

    //Scene
    public GameObject robot;

    //Joints
    private ArticulationBody[] jointArticulationBodies;
    Dictionary<string, ArticulationBody> dicJointAB = new Dictionary<string, ArticulationBody>();

    //Movement
    private readonly float jointWait = 0.1f;

    //Map Joints
    void Awake()
    {
        jointArticulationBodies = robot.GetComponentsInChildren<ArticulationBody>();

        foreach (ArticulationBody aBody in jointArticulationBodies)
		{
            dicJointAB.Add(aBody.name, aBody);
        }
    }

    public void MovementPhase(int phase)
    {
        HOAP3MoverServiceRequest request = new HOAP3MoverServiceRequest();
        request.phase = phase;

        if (phase == 1)
        {
            request.pose = new RosMessageTypes.Geometry.Pose
            {
				position = new RosMessageTypes.Geometry.Point(0.064687, 0.23661, 0.21457),
				orientation = new RosMessageTypes.Geometry.Quaternion(0.23084, 0.10493, 0.92343, -0.28805)
            };

        
        } 
        else if (phase == 2)
		{
            request.pose = new RosMessageTypes.Geometry.Pose
            {
                position = new RosMessageTypes.Geometry.Point(0.043221, -0.24982, 0.21514),
                orientation = new RosMessageTypes.Geometry.Quaternion(0.26439, 0.93194, 0.20268, -0.14316)
            };
        }
        else if (phase == 3)
        {
            request.pose = new RosMessageTypes.Geometry.Pose
            {
                position = new RosMessageTypes.Geometry.Point(-0.045033, 0.077714, -0.24875),
                orientation = new RosMessageTypes.Geometry.Quaternion(0.68226, 0.19911, 0.67399, -0.20154)
            };
        }

        ros.SendServiceMessage<HOAP3MoverServiceResponse>(rosServiceName, request, TrajectoryResponse);
    }


    void TrajectoryResponse(HOAP3MoverServiceResponse response)
    {
        if (response.trajectories != null)
        {
            Debug.Log("Trajectory returned.");
            StartCoroutine(ExecuteTrajectories(response));
        }
        else
        {
            Debug.LogError("No trajectory returned from MoverService.");
        }
    }

    private IEnumerator ExecuteTrajectories(HOAP3MoverServiceResponse response)
    {
        if (response.trajectories != null)
        {

            foreach (var trayectory in response.trajectories)
			{
                int nJointsName = trayectory.joint_trajectory.joint_names.Length;
                string[] jointNames = new string[nJointsName];

                //Get joints names
                for (int i = 0; i <= trayectory.joint_trajectory.joint_names.Length - 1; i++)
				{
                    string nameJoint = trayectory.joint_trajectory.joint_names[i];
                    string subName = nameJoint.Substring(0, nameJoint.Length - 6);
                    int firstIndex = subName.IndexOf("_");

                    if (firstIndex == 1)
                    {
                        subName = subName.Substring(2, subName.Length - 2);
                        int secondIndex = subName.IndexOf("_");

                        jointNames[i] = subName.Substring(secondIndex + 1, subName.Length - secondIndex - 1);
                    }
                    else
                    {
                        jointNames[i] = subName.Substring(firstIndex + 1, subName.Length - firstIndex - 1);
                    }

                }

                //Get points and execute jointDrive
                foreach (var point in trayectory.joint_trajectory.points)
                {
                    var jointPositions = point.positions;
                    float[] angles = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                    for (int i = 0; i <= angles.Length - 1; i++)
                    {
                        var joint = dicJointAB[jointNames[i]];
                        var joint1XDrive = joint.xDrive;
                        joint1XDrive.target = angles[i];
                        joint.xDrive = joint1XDrive;
                        yield return new WaitForSeconds(jointWait);
                    }
                    yield return new WaitForSeconds(jointWait);
                }

            }


        }
    }
}
