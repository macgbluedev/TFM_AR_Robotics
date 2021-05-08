using RosMessageTypes.ShMoveitService;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;

public class SHMoveitService : MonoBehaviour
{
    //ROS
    public ROSConnection ros;
    private int nJoints = 29;
    string rosServiceName = "sh_moveit";

    //Scene
    private int gPhase = 0;
    public GameObject robot;
    public Rigidbody cylinder;


    //Joints
    private ArticulationBody[] jointArticulationBodies;

    //Movement
    private readonly float jointWait = 0.1f;
    private readonly float preGraspWait = 3f;
    private readonly float postGraspWait = 1f;

    //Map Joints
    void Awake()
    {
        jointArticulationBodies = new ArticulationBody[nJoints];

        jointArticulationBodies[0] = robot.transform.Find("forearm/wrist").GetComponent<ArticulationBody>();
        jointArticulationBodies[1] = robot.transform.Find("forearm/wrist/palm").GetComponent<ArticulationBody>();
        jointArticulationBodies[2] = robot.transform.Find("forearm/wrist/palm/ffknuckle").GetComponent<ArticulationBody>();
        jointArticulationBodies[3] = robot.transform.Find("forearm/wrist/palm/ffknuckle/ffproximal").GetComponent<ArticulationBody>();
        jointArticulationBodies[4] = robot.transform.Find("forearm/wrist/palm/ffknuckle/ffproximal/ffmiddle").GetComponent<ArticulationBody>();
        jointArticulationBodies[5] = robot.transform.Find("forearm/wrist/palm/ffknuckle/ffproximal/ffmiddle/ffdistal").GetComponent<ArticulationBody>();
        jointArticulationBodies[6] = robot.transform.Find("forearm/wrist/palm/ffknuckle/ffproximal/ffmiddle/ffdistal/fftip").GetComponent<ArticulationBody>();
        jointArticulationBodies[7] = robot.transform.Find("forearm/wrist/palm/mfknuckle").GetComponent<ArticulationBody>();
        jointArticulationBodies[8] = robot.transform.Find("forearm/wrist/palm/mfknuckle/mfproximal").GetComponent<ArticulationBody>();
        jointArticulationBodies[9] = robot.transform.Find("forearm/wrist/palm/mfknuckle/mfproximal/mfmiddle").GetComponent<ArticulationBody>();
        jointArticulationBodies[10] = robot.transform.Find("forearm/wrist/palm/mfknuckle/mfproximal/mfmiddle/mfdistal").GetComponent<ArticulationBody>();
        jointArticulationBodies[11] = robot.transform.Find("forearm/wrist/palm/mfknuckle/mfproximal/mfmiddle/mfdistal/mftip").GetComponent<ArticulationBody>();
        jointArticulationBodies[12] = robot.transform.Find("forearm/wrist/palm/rfknuckle").GetComponent<ArticulationBody>();
        jointArticulationBodies[13] = robot.transform.Find("forearm/wrist/palm/rfknuckle/rfproximal").GetComponent<ArticulationBody>();
        jointArticulationBodies[14] = robot.transform.Find("forearm/wrist/palm/rfknuckle/rfproximal/rfmiddle").GetComponent<ArticulationBody>();
        jointArticulationBodies[15] = robot.transform.Find("forearm/wrist/palm/rfknuckle/rfproximal/rfmiddle/rfdistal").GetComponent<ArticulationBody>();
        jointArticulationBodies[16] = robot.transform.Find("forearm/wrist/palm/rfknuckle/rfproximal/rfmiddle/rfdistal/rftip").GetComponent<ArticulationBody>();
        jointArticulationBodies[17] = robot.transform.Find("forearm/wrist/palm/lfmetacarpal").GetComponent<ArticulationBody>();
        jointArticulationBodies[18] = robot.transform.Find("forearm/wrist/palm/lfmetacarpal/lfknuckle").GetComponent<ArticulationBody>();
        jointArticulationBodies[19] = robot.transform.Find("forearm/wrist/palm/lfmetacarpal/lfknuckle/lfproximal").GetComponent<ArticulationBody>();
        jointArticulationBodies[20] = robot.transform.Find("forearm/wrist/palm/lfmetacarpal/lfknuckle/lfproximal/lfmiddle").GetComponent<ArticulationBody>();
        jointArticulationBodies[21] = robot.transform.Find("forearm/wrist/palm/lfmetacarpal/lfknuckle/lfproximal/lfmiddle/lfdistal").GetComponent<ArticulationBody>();
        jointArticulationBodies[22] = robot.transform.Find("forearm/wrist/palm/lfmetacarpal/lfknuckle/lfproximal/lfmiddle/lfdistal/lftip").GetComponent<ArticulationBody>();
        jointArticulationBodies[23] = robot.transform.Find("forearm/wrist/palm/thbase").GetComponent<ArticulationBody>();
        jointArticulationBodies[24] = robot.transform.Find("forearm/wrist/palm/thbase/thproximal").GetComponent<ArticulationBody>();
        jointArticulationBodies[25] = robot.transform.Find("forearm/wrist/palm/thbase/thproximal/thhub").GetComponent<ArticulationBody>();
        jointArticulationBodies[26] = robot.transform.Find("forearm/wrist/palm/thbase/thproximal/thhub/thmiddle").GetComponent<ArticulationBody>();
        jointArticulationBodies[27] = robot.transform.Find("forearm/wrist/palm/thbase/thproximal/thhub/thmiddle/thdistal").GetComponent<ArticulationBody>();
        jointArticulationBodies[28] = robot.transform.Find("forearm/wrist/palm/thbase/thproximal/thhub/thmiddle/thdistal/thtip").GetComponent<ArticulationBody>();
    }

    public void GraspingPhase(int phase)
    {
        SHMoveitServiceRequest request = new SHMoveitServiceRequest();
        request.phase = phase;

        gPhase = phase;
       
        ros.SendServiceMessage<SHMoveitServiceResponse>(rosServiceName, request, TrajectoryResponse);
    }

    //Flow request Moveit Service
    void TrajectoryResponse(SHMoveitServiceResponse response)
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

    private IEnumerator ExecuteTrajectories(SHMoveitServiceResponse response)
    {
        if (response.trajectories != null)
        {
            if (gPhase == 1)
            {
                //FF
                var jointPositions = response.trajectories[0].joint_trajectory.points[0].positions;
                float[] result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                for (int joint = 3; joint < 6; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[0];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;
                    yield return new WaitForSeconds(jointWait);
                }
                yield return new WaitForSeconds(jointWait);

                //MF
                jointPositions = response.trajectories[1].joint_trajectory.points[0].positions;
                result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                for (int joint = 8; joint < 11; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[0];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;
                    yield return new WaitForSeconds(jointWait);
                }
                yield return new WaitForSeconds(jointWait);

                //RF
                jointPositions = response.trajectories[2].joint_trajectory.points[0].positions;
                result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                for (int joint = 13; joint < 16; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[0];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;
                    yield return new WaitForSeconds(jointWait);
                }
                yield return new WaitForSeconds(jointWait);

                //LF
                jointPositions = response.trajectories[3].joint_trajectory.points[0].positions;
                result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                int i = 0;
                for (int joint = 18; joint < 22; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[i];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;
                    i++;
                    yield return new WaitForSeconds(jointWait);
                }
                yield return new WaitForSeconds(jointWait);


                //TH
                jointPositions = response.trajectories[4].joint_trajectory.points[0].positions;
                result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                {
                    var joint1XDrive = jointArticulationBodies[24].xDrive;
                    //joint1XDrive.target = result[joint];
                    joint1XDrive.target = result[1];
                    jointArticulationBodies[24].xDrive = joint1XDrive;
                    yield return new WaitForSeconds(jointWait);
                }

                {
                    var joint1XDrive = jointArticulationBodies[23].xDrive;
                    joint1XDrive.target = result[0];
                    //joint1XDrive.target = 25;
                    jointArticulationBodies[23].xDrive = joint1XDrive;
                    yield return new WaitForSeconds(jointWait);
                }

                i = 2;
                for (int joint = 25; joint < 28; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[i];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;
                    i++;
                    yield return new WaitForSeconds(jointWait);
                }
                yield return new WaitForSeconds(jointWait);


                //Post grasping
                cylinder.isKinematic = false;

                yield return new WaitForSeconds(preGraspWait);

            }
            else if (gPhase == 2)
            {

                //Wrist
                var jointPositions = response.trajectories[0].joint_trajectory.points[0].positions;
                var result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                for (int joint = 0; joint < 2; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[joint];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;

                    yield return new WaitForSeconds(jointWait);
                }


                yield return new WaitForSeconds(postGraspWait);

                //Palm 1
                jointPositions = response.trajectories[1].joint_trajectory.points[0].positions;
                result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                for (int joint = 0; joint < 2; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[joint];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;

                    yield return new WaitForSeconds(jointWait);
                }

                yield return new WaitForSeconds(postGraspWait);

                //Palm 2
                jointPositions = response.trajectories[2].joint_trajectory.points[0].positions;
                result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                for (int joint = 0; joint < 2; joint++)
                {
                    var joint1XDrive = jointArticulationBodies[joint].xDrive;
                    joint1XDrive.target = result[joint];
                    jointArticulationBodies[joint].xDrive = joint1XDrive;

                    yield return new WaitForSeconds(jointWait);
                }
            }
        }
    }
}
