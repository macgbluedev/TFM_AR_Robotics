//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Hoap3MoveitService
{
    public class HOAP3Joints : Message
    {
        public const string RosMessageName = "hoap3_moveit_service/HOAP3Joints";

        public double joint_00;
        public double joint_01;
        public double joint_02;
        public double joint_03;
        public double joint_04;
        public double joint_05;
        public double joint_06;
        public double joint_07;
        public double joint_08;
        public double joint_09;
        public double joint_10;
        public double joint_11;
        public double joint_12;
        public double joint_13;
        public double joint_14;
        public double joint_15;
        public double joint_16;
        public double joint_17;
        public double joint_18;
        public double joint_19;
        public double joint_20;
        public double joint_21;
        public double joint_22;
        public double joint_23;
        public double joint_24;
        public double joint_25;
        public double joint_26;
        public double joint_27;
        public double joint_28;
        public double joint_29;
        public double joint_30;
        public double joint_31;
        public double joint_32;
        public double joint_33;

        public HOAP3Joints()
        {
            this.joint_00 = 0.0;
            this.joint_01 = 0.0;
            this.joint_02 = 0.0;
            this.joint_03 = 0.0;
            this.joint_04 = 0.0;
            this.joint_05 = 0.0;
            this.joint_06 = 0.0;
            this.joint_07 = 0.0;
            this.joint_08 = 0.0;
            this.joint_09 = 0.0;
            this.joint_10 = 0.0;
            this.joint_11 = 0.0;
            this.joint_12 = 0.0;
            this.joint_13 = 0.0;
            this.joint_14 = 0.0;
            this.joint_15 = 0.0;
            this.joint_16 = 0.0;
            this.joint_17 = 0.0;
            this.joint_18 = 0.0;
            this.joint_19 = 0.0;
            this.joint_20 = 0.0;
            this.joint_21 = 0.0;
            this.joint_22 = 0.0;
            this.joint_23 = 0.0;
            this.joint_24 = 0.0;
            this.joint_25 = 0.0;
            this.joint_26 = 0.0;
            this.joint_27 = 0.0;
            this.joint_28 = 0.0;
            this.joint_29 = 0.0;
            this.joint_30 = 0.0;
            this.joint_31 = 0.0;
            this.joint_32 = 0.0;
            this.joint_33 = 0.0;
        }

        public HOAP3Joints(double joint_00, double joint_01, double joint_02, double joint_03, double joint_04, double joint_05, double joint_06, double joint_07, double joint_08, double joint_09, double joint_10, double joint_11, double joint_12, double joint_13, double joint_14, double joint_15, double joint_16, double joint_17, double joint_18, double joint_19, double joint_20, double joint_21, double joint_22, double joint_23, double joint_24, double joint_25, double joint_26, double joint_27, double joint_28, double joint_29, double joint_30, double joint_31, double joint_32, double joint_33)
        {
            this.joint_00 = joint_00;
            this.joint_01 = joint_01;
            this.joint_02 = joint_02;
            this.joint_03 = joint_03;
            this.joint_04 = joint_04;
            this.joint_05 = joint_05;
            this.joint_06 = joint_06;
            this.joint_07 = joint_07;
            this.joint_08 = joint_08;
            this.joint_09 = joint_09;
            this.joint_10 = joint_10;
            this.joint_11 = joint_11;
            this.joint_12 = joint_12;
            this.joint_13 = joint_13;
            this.joint_14 = joint_14;
            this.joint_15 = joint_15;
            this.joint_16 = joint_16;
            this.joint_17 = joint_17;
            this.joint_18 = joint_18;
            this.joint_19 = joint_19;
            this.joint_20 = joint_20;
            this.joint_21 = joint_21;
            this.joint_22 = joint_22;
            this.joint_23 = joint_23;
            this.joint_24 = joint_24;
            this.joint_25 = joint_25;
            this.joint_26 = joint_26;
            this.joint_27 = joint_27;
            this.joint_28 = joint_28;
            this.joint_29 = joint_29;
            this.joint_30 = joint_30;
            this.joint_31 = joint_31;
            this.joint_32 = joint_32;
            this.joint_33 = joint_33;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_00));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_01));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_02));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_03));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_04));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_05));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_06));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_07));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_08));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_09));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_10));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_11));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_12));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_13));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_14));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_15));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_16));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_17));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_18));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_19));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_20));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_21));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_22));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_23));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_24));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_25));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_26));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_27));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_28));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_29));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_30));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_31));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_32));
            listOfSerializations.Add(BitConverter.GetBytes(this.joint_33));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.joint_00 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_01 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_02 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_03 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_04 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_05 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_06 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_07 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_08 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_09 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_10 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_11 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_12 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_13 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_14 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_15 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_16 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_17 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_18 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_19 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_20 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_21 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_22 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_23 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_24 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_25 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_26 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_27 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_28 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_29 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_30 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_31 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_32 = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.joint_33 = BitConverter.ToDouble(data, offset);
            offset += 8;

            return offset;
        }

        public override string ToString()
        {
            return "HOAP3Joints: " +
            "\njoint_00: " + joint_00.ToString() +
            "\njoint_01: " + joint_01.ToString() +
            "\njoint_02: " + joint_02.ToString() +
            "\njoint_03: " + joint_03.ToString() +
            "\njoint_04: " + joint_04.ToString() +
            "\njoint_05: " + joint_05.ToString() +
            "\njoint_06: " + joint_06.ToString() +
            "\njoint_07: " + joint_07.ToString() +
            "\njoint_08: " + joint_08.ToString() +
            "\njoint_09: " + joint_09.ToString() +
            "\njoint_10: " + joint_10.ToString() +
            "\njoint_11: " + joint_11.ToString() +
            "\njoint_12: " + joint_12.ToString() +
            "\njoint_13: " + joint_13.ToString() +
            "\njoint_14: " + joint_14.ToString() +
            "\njoint_15: " + joint_15.ToString() +
            "\njoint_16: " + joint_16.ToString() +
            "\njoint_17: " + joint_17.ToString() +
            "\njoint_18: " + joint_18.ToString() +
            "\njoint_19: " + joint_19.ToString() +
            "\njoint_20: " + joint_20.ToString() +
            "\njoint_21: " + joint_21.ToString() +
            "\njoint_22: " + joint_22.ToString() +
            "\njoint_23: " + joint_23.ToString() +
            "\njoint_24: " + joint_24.ToString() +
            "\njoint_25: " + joint_25.ToString() +
            "\njoint_26: " + joint_26.ToString() +
            "\njoint_27: " + joint_27.ToString() +
            "\njoint_28: " + joint_28.ToString() +
            "\njoint_29: " + joint_29.ToString() +
            "\njoint_30: " + joint_30.ToString() +
            "\njoint_31: " + joint_31.ToString() +
            "\njoint_32: " + joint_32.ToString() +
            "\njoint_33: " + joint_33.ToString();
        }
    }
}
