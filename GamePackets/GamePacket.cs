using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GameServer.Networking
{
    public abstract class GamePacket
    {
        public static void Config(Type connectionType)
        {
            GamePacket.加密字节 = 129;
            GamePacket.封包处理方法 = new Dictionary<Type, MethodInfo>();

            #region Reader

            Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>> ReaderDictionary = new Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>>();
            
            ReaderDictionary[typeof(bool)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return Convert.ToBoolean(br.ReadByte());
            };

            ReaderDictionary[typeof(byte)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadByte();
            };
            
            ReaderDictionary[typeof(sbyte)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadSByte();
            };
            
            ReaderDictionary[typeof(byte[])] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                int num = (int)((wfa.Length != 0) ? wfa.Length : (br.ReadUInt16() - 4));
                if (num > 0)
                {
                    return br.ReadBytes(num);
                }
                return new byte[0];
            };
            
            ReaderDictionary[typeof(short)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadInt16();
            };
            
            ReaderDictionary[typeof(ushort)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadUInt16();
            };
            
            ReaderDictionary[typeof(int)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadInt32();
            };
            
            ReaderDictionary[typeof(uint)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadUInt32();
            };

            ReaderDictionary[typeof(long)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadInt32();
            };

            ReaderDictionary[typeof(ulong)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadUInt32();
            };

            ReaderDictionary[typeof(string)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                byte[] bytes = br.ReadBytes((int)wfa.Length);
                return Encoding.UTF8.GetString(bytes).Split(new char[1], StringSplitOptions.RemoveEmptyEntries)[0];
            };
            
            ReaderDictionary[typeof(Point)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                Point point = new Point((int)br.ReadUInt16(), (int)br.ReadUInt16());
                return ComputingClass.协议坐标转点阵坐标(wfa.Reverse ? new Point(point.Y, point.X) : point);
            };
            GamePacket.封包字段读取表 = ReaderDictionary;
            #endregion

            #region Writer

            Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>> WriterDictionary = new Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>>();
            
            WriterDictionary[typeof(bool)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((bool)obj);
            };
            
            WriterDictionary[typeof(byte)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((byte)obj);
            };
            
            WriterDictionary[typeof(sbyte)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((sbyte)obj);
            };
            
            WriterDictionary[typeof(byte[])] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write(obj as byte[]);
            };
            
            WriterDictionary[typeof(short)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((short)obj);
            };
            
            WriterDictionary[typeof(ushort)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((ushort)obj);
            };
            
            WriterDictionary[typeof(int)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((int)obj);
            };
            
            WriterDictionary[typeof(uint)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((uint)obj);
            };

            WriterDictionary[typeof(long)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((long)obj);
            };

            WriterDictionary[typeof(ulong)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((ulong)obj);
            };

            WriterDictionary[typeof(string)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                string text3 = obj as string;
                if (text3 != null)
                {
                    bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                    bw.Write(Encoding.UTF8.GetBytes(text3));
                }
            };
            
            WriterDictionary[typeof(Point)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                Point point = ComputingClass.点阵坐标转协议坐标((Point)obj);
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                if (wfa.Reverse)
                {
                    bw.Write((ushort)point.Y);
                    bw.Write((ushort)point.X);
                    return;
                }
                bw.Write((ushort)point.X);
                bw.Write((ushort)point.Y);
            };
            
            WriterDictionary[typeof(DateTime)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write(ComputingClass.TimeShift((DateTime)obj));
            };
            GamePacket.封包字段写入表 = WriterDictionary;
            #endregion

            GamePacket.服务器封包类型表 = new Dictionary<ushort, Type>();
            GamePacket.服务器封包编号表 = new Dictionary<Type, ushort>();
            GamePacket.服务器封包长度表 = new Dictionary<ushort, ushort>();
            GamePacket.客户端封包类型表 = new Dictionary<ushort, Type>();
            GamePacket.客户端封包编号表 = new Dictionary<Type, ushort>();
            GamePacket.客户端封包长度表 = new Dictionary<ushort, ushort>();

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(GamePacket)))
                {
                    PacketInfoAttribute 封包描述 = type.GetCustomAttribute<PacketInfoAttribute>();
                    if (封包描述 != null)
                    {
                        if (封包描述.Source == PacketSource.Client)
                        {
                            GamePacket.客户端封包类型表[封包描述.Id] = type;
                            GamePacket.客户端封包编号表[type] = 封包描述.Id;
                            GamePacket.客户端封包长度表[封包描述.Id] = 封包描述.Length;
                            GamePacket.封包处理方法[type] = connectionType.GetMethod("处理封包", new Type[]
                            {
                                type
                            });
                        }
                        else
                        {
                            GamePacket.服务器封包类型表[封包描述.Id] = type;
                            GamePacket.服务器封包编号表[type] = 封包描述.Id;
                            GamePacket.服务器封包长度表[封包描述.Id] = 封包描述.Length;
                        }
                    }
                }
            }
            string text = "";
            foreach (KeyValuePair<ushort, Type> keyValuePair in GamePacket.服务器封包类型表)
            {
                text += string.Format("{0}\t{1}\t{2}\r\n", keyValuePair.Value.Name, keyValuePair.Key, GamePacket.服务器封包长度表[keyValuePair.Key]);
            }
            string text2 = "";
            foreach (KeyValuePair<ushort, Type> keyValuePair2 in GamePacket.客户端封包类型表)
            {
                text2 += string.Format("{0}\t{1}\t{2}\r\n", keyValuePair2.Value.Name, keyValuePair2.Key, GamePacket.客户端封包长度表[keyValuePair2.Key]);
            }
            File.WriteAllText("./ServerPackRule.txt", text);
            File.WriteAllText("./ClientPackRule.txt", text2);
        }


        public virtual bool 是否加密 { get; set; }


        public GamePacket()
        {

            this.是否加密 = true;

            this.封包类型 = base.GetType();
            this.封包属性 = this.封包类型.GetCustomAttribute<PacketInfoAttribute>();

            if (this.封包属性.Source == PacketSource.Server)
            {
                this.封包编号 = GamePacket.服务器封包编号表[this.封包类型];
                this.封包长度 = GamePacket.服务器封包长度表[this.封包编号];
                return;
            }
            this.封包编号 = GamePacket.客户端封包编号表[this.封包类型];
            this.封包长度 = GamePacket.客户端封包长度表[this.封包编号];
        }


        public byte[] 取字节(bool forceNoEncrypt = false)
        {
            byte[] result;
            using (MemoryStream memoryStream = (this.封包长度 == 0) ? new MemoryStream() : new MemoryStream(new byte[(int)this.封包长度]))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    foreach (FieldInfo fieldInfo in this.封包类型.GetFields())
                    {
                        WrappingFieldAttribute 字段描述 = fieldInfo.GetCustomAttribute<WrappingFieldAttribute>();
                        if (字段描述 != null)
                        {
                            Type fieldType = fieldInfo.FieldType;
                            object value = fieldInfo.GetValue(this);
                            Action<BinaryWriter, WrappingFieldAttribute, object> action;
                            if (GamePacket.封包字段写入表.TryGetValue(fieldType, out action))
                            {
                                action(binaryWriter, 字段描述, value);
                            }
                        }
                    }
                    binaryWriter.Seek(0, SeekOrigin.Begin);
                    binaryWriter.Write(this.封包编号);
                    if (this.封包长度 == 0)
                    {
                        binaryWriter.Write((ushort)memoryStream.Length);
                    }
                    byte[] array = memoryStream.ToArray();
                    if (this.是否加密 && !forceNoEncrypt)
                    {
                        result = GamePacket.加解密(array);
                    }
                    else
                    {
                        result = array;
                    }
                }
            }
            return result;
        }


        private void 填封包(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream))
                {
                    foreach (FieldInfo fieldInfo in this.封包类型.GetFields())
                    {
                        WrappingFieldAttribute 字段描述 = fieldInfo.GetCustomAttribute<WrappingFieldAttribute>();
                        if (字段描述 != null)
                        {
                            Type fieldType = fieldInfo.FieldType;
                            Func<BinaryReader, WrappingFieldAttribute, object> func;
                            if (GamePacket.封包字段读取表.TryGetValue(fieldType, out func))
                            {
                                fieldInfo.SetValue(this, func(binaryReader, 字段描述));
                            }
                        }
                    }
                }
            }
        }


        public static GamePacket GetPacket(byte[] inData, out byte[] restOfBytes)
        {
            restOfBytes = inData;
            if (inData.Length < 2)
            {
                return null;
            }
            ushort packetID = BitConverter.ToUInt16(inData, 0);
            Type type;

            if (!客户端封包类型表.TryGetValue(packetID, out type))
            {
                throw new Exception(string.Format("封包组包失败! 封包编号:{0:X4}", packetID));
                return null;
            }
            ushort num2;
            if (!客户端封包长度表.TryGetValue(packetID, out num2))
            {
                throw new Exception(string.Format("获取封包长度失败! 封包编号:{0:X4}", packetID));
                return null;
            }
            if (num2 == 0 && inData.Length < 4)
            {
                return null;
            }
            num2 = ((num2 == 0) ? BitConverter.ToUInt16(inData, 2) : num2);
            if (inData.Length < (int)num2)
            {
                return null;
            }
            GamePacket GamePacket = (GamePacket)Activator.CreateInstance(type);
            byte[] dataPacket = inData.Take((int)num2).ToArray<byte>();
            if (GamePacket.是否加密)
            {
                GamePacket.加解密(dataPacket);
            }
            GamePacket.填封包(dataPacket);
            restOfBytes = inData.Skip((int)num2).ToArray<byte>();
            return GamePacket;
        }


        public static byte[] 加解密(byte[] data)
        {
            for (int i = 4; i < data.Length; i++)
            {
                data[i] ^= GamePacket.加密字节;
            }
            return (byte[])data;
        }


        public static byte 加密字节;


        public static Dictionary<Type, MethodInfo> 封包处理方法;


        public static Dictionary<ushort, Type> 服务器封包类型表;


        public static Dictionary<ushort, Type> 客户端封包类型表;


        public static Dictionary<Type, ushort> 服务器封包编号表;


        public static Dictionary<Type, ushort> 客户端封包编号表;


        public static Dictionary<ushort, ushort> 服务器封包长度表;


        public static Dictionary<ushort, ushort> 客户端封包长度表;


        public static Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>> 封包字段读取表;


        public static Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>> 封包字段写入表;


        public readonly Type 封包类型;

        public readonly PacketInfoAttribute 封包属性;

        private readonly ushort 封包编号;


        private readonly ushort 封包长度;

        public override string ToString()
        {
            var fields = 封包类型.GetFields(BindingFlags.Public);
            var validFieldTypes = new string[] { "string", "int", "uint", "ushort", "short" };

            var sb = new StringBuilder();

            sb.Append($"[{封包类型.Name}] {{");

            foreach (var field in fields)
            {
                if (validFieldTypes.Contains(field.FieldType.Name))
                    sb.Append($"{field.Name}:{field.GetValue(this)}");
            }

            sb.Append('}');

            return sb.ToString();
        }
    }
}
