using RosMessageTypes.Ur3Moveit;
using System.Collections;
using System.Linq;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;

public class UR3MoveitService : MonoBehaviour
{
    //ROS
    public ROSConnection ros;
    private int nJoints = 6;
    string rosServiceName = "ur3_moveit";

    //Scene
    public GameObject robot;
    public GameObject box;
    public GameObject tool;


    //Target
    public GameObject pointTargetPre;
    public GameObject pointTargetPick;
    public GameObject pointTargetPlace;
    public GameObject pointTargetHome;
    private readonly RosMessageTypes.Geometry.Quaternion robotOrientation = new RosMessageTypes.Geometry.Quaternion(0.5, 0.5, -0.5, 0.5);


    //Joints
    private ArticulationBody[] jointArticulationBodies;

    //Movement
    private readonly float jointWait = 0.5f;
    private readonly float poseWait = 1f;

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

    public void RequestPoints()
	{
        UR3MoverServiceRequest request = new UR3MoverServiceRequest();

        request.pre_pose = new RosMessageTypes.Geometry.Pose
        {
            position = new RosMessageTypes.Geometry.Point(
                pointTargetPre.transform.position.z,
                -pointTargetPre.transform.position.x,
                pointTargetPre.transform.position.y
                ),
            orientation = robotOrientation
        };

        request.pick_pose = new RosMessageTypes.Geometry.Pose
        {
            position = new RosMessageTypes.Geometry.Point(
                pointTargetPick.transform.position.z,
                -pointTargetPick.transform.position.x,
                pointTargetPick.transform.position.y
                ),
            orientation = robotOrientation
        };

        request.place_pose = new RosMessageTypes.Geometry.Pose
        {
            position = new RosMessageTypes.Geometry.Point(
                pointTargetPlace.transform.position.z,
                -pointTargetPlace.transform.position.x,
                pointTargetPlace.transform.position.y
                ),
            orientation = robotOrientation
        };

        request.home_pose = new RosMessageTypes.Geometry.Pose
        {
            position = new RosMessageTypes.Geometry.Point(
                pointTargetHome.transform.position.z,
                -pointTargetHome.transform.position.x,
                pointTargetHome.transform.position.y
                ),
            orientation = robotOrientation
        };

        ros.SendServiceMessage<UR3MoverServiceResponse>(rosServiceName, request, TrajectoryResponse);
    }


    //Flow request Moveit Service
    void TrajectoryResponse(UR3MoverServiceResponse response)
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

    private IEnumerator ExecuteTrajectories(UR3MoverServiceResponse response)
    {
        if (response.trajectories != null)
        {
            // For every trajectory plan returned
            for (int poseIndex = 0; poseIndex < response.trajectories.Length; poseIndex++)
            {
				// For every robot pose in trajectory plan
				for (int jointConfigIndex = 0; jointConfigIndex < response.trajectories[poseIndex].joint_trajectory.points.Length; jointConfigIndex++)
				{
				
                    var jointPositions = response.trajectories[poseIndex].joint_trajectory.points[jointConfigIndex].positions;
				    float[] result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                    // Set the joint values for every joint
                    for (int joint = 0; joint < jointArticulationBodies.Length; joint++)
                    {
                        var joint1XDrive = jointArticulationBodies[joint].xDrive;
                        joint1XDrive.target = result[joint];
                        jointArticulationBodies[joint].xDrive = joint1XDrive;
                    }
                    // Wait for robot to achieve pose for all joint assignments
                    yield return new WaitForSeconds(jointWait);
				}
				// Wait for the robot to achieve the final pose from joint assignment
				yield return new WaitForSeconds(poseWait);

                //Pick/Place action
                if (poseIndex == 1)
                {
                    box.GetComponent<Rigidbody>().isKinematic = true;
                    box.transform.parent = tool.transform;
                }
                else if (poseIndex == 3)
                {
                    box.GetComponent<Rigidbody>().useGravity = true;
                    box.GetComponent<Rigidbody>().isKinematic = false;
                    box.transform.parent = null;
                    yield return new WaitForSeconds(poseWait);

                }
            }
        }
    }
}
