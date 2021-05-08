//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Ur3Moveit
{
    public class UR3MoverServiceRequest : Message
    {
        public const string RosMessageName = "ur3_moveit/UR3MoverService";

        public Geometry.Pose pre_pose;
        public Geometry.Pose pick_pose;
        public Geometry.Pose place_pose;
        public Geometry.Pose home_pose;

        public UR3MoverServiceRequest()
        {
            this.pre_pose = new Geometry.Pose();
            this.pick_pose = new Geometry.Pose();
            this.place_pose = new Geometry.Pose();
            this.home_pose = new Geometry.Pose();
        }

        public UR3MoverServiceRequest(Geometry.Pose pre_pose, Geometry.Pose pick_pose, Geometry.Pose place_pose, Geometry.Pose home_pose)
        {
            this.pre_pose = pre_pose;
            this.pick_pose = pick_pose;
            this.place_pose = place_pose;
            this.home_pose = home_pose;
        }


        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(pre_pose.SerializationStatements());
            listOfSerializations.AddRange(pick_pose.SerializationStatements());
            listOfSerializations.AddRange(place_pose.SerializationStatements());
            listOfSerializations.AddRange(home_pose.SerializationStatements());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.pre_pose.Deserialize(data, offset);
            offset = this.pick_pose.Deserialize(data, offset);
            offset = this.place_pose.Deserialize(data, offset);
            offset = this.home_pose.Deserialize(data, offset);

            return offset;
        }

        public override string ToString()
        {
            return "UR3MoverServiceRequest: " +
            "\npre_pose: " + pre_pose.ToString() +
            "\npick_pose: " + pick_pose.ToString() +
            "\nplace_pose: " + place_pose.ToString() +
            "\nhome_pose: " + home_pose.ToString();
        }
    }
}
