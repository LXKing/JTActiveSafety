﻿using JT808.Protocol.Extensions.JTActiveSafety.MessageBody;
using JT808.Protocol.Extensions.JTActiveSafety.Metadata;
using JT808.Protocol.Formatters;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.JTActiveSafety.Formatters
{
    public class JT808_0x0200_0x65_Formatter : IJT808MessagePackFormatter<JT808_0x0200_0x65>
    {
        public JT808_0x0200_0x65 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0200_0x65 jT808_0X0200_0X65 = new JT808_0x0200_0x65();
            jT808_0X0200_0X65.AttachInfoId = reader.ReadByte();
            jT808_0X0200_0X65.AttachInfoLength = reader.ReadByte();
            jT808_0X0200_0X65.AlarmId = reader.ReadUInt32();
            jT808_0X0200_0X65.FlagState = reader.ReadByte();
            jT808_0X0200_0X65.AlarmOrEventType = reader.ReadByte();
            jT808_0X0200_0X65.AlarmLevel = reader.ReadByte();
            jT808_0X0200_0X65.Fatigue = reader.ReadByte();
            jT808_0X0200_0X65.Retain = reader.ReadArray(4).ToArray();
            jT808_0X0200_0X65.Speed = reader.ReadByte();
            jT808_0X0200_0X65.Altitude = reader.ReadUInt16();
            jT808_0X0200_0X65.Latitude = (int)reader.ReadUInt32();
            jT808_0X0200_0X65.Longitude = (int)reader.ReadUInt32();
            jT808_0X0200_0X65.AlarmTime = reader.ReadDateTime6();
            jT808_0X0200_0X65.VehicleState = reader.ReadUInt16();
            jT808_0X0200_0X65.AlarmIdentification = JT808_AlarmIdentificationProperty_Formatter.Instance.Deserialize(ref reader, config);
            return jT808_0X0200_0X65;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0200_0x65 value, IJT808Config config)
        {
            writer.WriteByte(value.AttachInfoId);
            writer.WriteByte(value.AttachInfoLength);
            writer.WriteUInt32(value.AlarmId);
            writer.WriteByte(value.FlagState);
            writer.WriteByte(value.AlarmOrEventType);
            writer.WriteByte(value.AlarmLevel);
            writer.WriteByte(value.Fatigue);
            if (value.Retain.Length != 4)
            {
                throw new ArgumentOutOfRangeException($"{nameof(JT808_0x0200_0x65.Retain)} length==4");
            }
            writer.WriteArray(value.Retain);
            writer.WriteByte(value.Speed);
            writer.WriteUInt16(value.Altitude);
            writer.WriteUInt32((uint)value.Latitude);
            writer.WriteUInt32((uint)value.Longitude);
            writer.WriteDateTime6(value.AlarmTime);
            writer.WriteUInt16(value.VehicleState);
            JT808_AlarmIdentificationProperty_Formatter.Instance.Serialize(ref writer, value.AlarmIdentification, config);
        }
    }
}
