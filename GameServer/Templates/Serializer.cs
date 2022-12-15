using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Newtonsoft.Json;

namespace GameServer.Templates
{

    public static class Serializer
    {
        static Serializer()
        {
            JsonOptions = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            var dictionary = new Dictionary<string, string>
            {
                ["Assembly-CSharp"] = "GameServer"
            };

            TypesOfSkill = dictionary;
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(SkillTask)))
                {
                    TypesOfSkill[type.Name] = type.FullName;
                }
            }
        }
        /// <summary>
        /// 文本数据文件反序列化
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="文件夹"></param>
        /// <returns></returns>
        public static TItem[] Deserialize<TItem>(string 文件夹) where TItem : class, new()
        {
            var output = new ConcurrentBag<TItem>();

            if (Directory.Exists(文件夹))
            {
                FileInfo[] files = new DirectoryInfo(文件夹).GetFiles();

                Parallel.ForEach(files, file =>
                {
                    try
                    {
                        string text = File.ReadAllText(file.FullName);
                        foreach (KeyValuePair<string, string> keyValuePair in TypesOfSkill)
                        {
                            text = text.Replace(keyValuePair.Key, keyValuePair.Value);
                        }
                        var obj = JsonConvert.DeserializeObject<TItem>(text, JsonOptions);

                        if (obj != null)
                        {
                            output.Add(obj);
                        }
                    }
                    catch (Exception ex)
                    {
                        MainForm.添加系统日志($"Error loading file '{file.FullName}', Ex: {ex.Message}");
                    }

                });

            }
            return output.ToArray();
        }
        /// <summary>
        /// 压缩字节
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] data)
        {
            using var memoryStream = new MemoryStream();
            using var deflaterOutputStream = new DeflaterOutputStream(memoryStream);

            deflaterOutputStream.Write(data, 0, data.Length);
            deflaterOutputStream.Close();

            return memoryStream.ToArray();
        }
        /// <summary>
        /// 解压字节
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            Stream baseInputStream = new MemoryStream(data);
            MemoryStream memoryStream = new MemoryStream();
            new InflaterInputStream(baseInputStream).CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
        /// <summary>
        /// 备份文件夹
        /// </summary>
        /// <param name="源目录"></param>
        /// <param name="文件名"></param>
        public static void SaveBackup(string 源目录, string 文件名)
        {
            if (!Directory.Exists(源目录))
                return;
            new FastZip().CreateZip(文件名, 源目录, false, "");
        }

        private static readonly JsonSerializerSettings JsonOptions;
        private static readonly Dictionary<string, string> TypesOfSkill;
    }
}
