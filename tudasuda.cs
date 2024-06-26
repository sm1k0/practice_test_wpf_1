﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_test_wpf_1
{
    //это для жсона, папка helpers
    public class tudasuda

    {
        public static T deser<T>(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }

        public static void ser<T>(string path, T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
        }
    }
}
