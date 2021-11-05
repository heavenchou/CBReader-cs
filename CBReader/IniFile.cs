using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    // 各種 WriteXXX 寫入的版本, 若傳回 0 表示失敗
    public class CIniFile
    {
        string FileName;

        // 這是輸入為 utf8 , 輸出是 ANSI
        // [DllImport("kernel32", CharSet = CharSet.Unicode)] 
        // static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        // [DllImport("kernel32", CharSet = CharSet.Unicode)]
        // static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        [DllImport("kernel32", SetLastError = true)]
        static extern int WritePrivateProfileString(string Section, string Key, byte[] Value, string FilePath);
        [DllImport("kernel32", SetLastError = true)]
        static extern int GetPrivateProfileString(string Section, string Key, byte[] Default, byte[] RetVal, int Size, string FilePath);

        public CIniFile(string file)
        {
            FileName = file;
        }
        // 轉成 utf8
        private static byte[] u8(string s)
        {
            return null == s ? null : Encoding.GetEncoding("utf-8").GetBytes(s);
        }
        public string ReadString(string Section, string Key, string Default)
        {
            // ANSI 的版本
            //var RetVal = new StringBuilder(255);
            //GetPrivateProfileString(Section, Key, Default, RetVal, 255, FileName);
            //return RetVal.ToString();

            byte[] buffer = new byte[1024];
            int count = GetPrivateProfileString(Section, Key, u8(Default), buffer, 255, FileName);
            return Encoding.GetEncoding("utf-8").GetString(buffer, 0, count).Trim();
        }
        public int ReadInteger(string Section, string Key, int Default)
        {
            string s = ReadString(Section, Key, Default.ToString());
            return Convert.ToInt32(s);
        }
        public float ReadFloat(string Section, string Key, float Default)
        {
            string s = ReadString(Section, Key, Default.ToString());
            return (float)Convert.ToDouble(s);
        }
        public bool ReadBool(string Section, string Key, bool Default)
        {
            string s = ReadString(Section, Key, Default == true ? "1" : "0");
            return s == "1";
        }

        // 若傳回 0 表示失敗
        public int WriteString(string Section, string Key, string Value)
        {
            return WritePrivateProfileString(Section, Key, u8(Value), FileName);
        }

        // 若傳回 0 表示失敗
        public int WriteInteger(string Section, string Key, int Value)
        {
            return WritePrivateProfileString(Section, Key, u8(Value.ToString()), FileName);
        }

        // 若傳回 0 表示失敗
        public int WriteFloat(string Section, string Key, float Value)
        {
            return WritePrivateProfileString(Section, Key, u8(Value.ToString()), FileName);
        }

        // 若傳回 0 表示失敗
        public int WriteBool(string Section, string Key, bool Value)
        {
            string b = Value == true ? "1" : "0";
            return WritePrivateProfileString(Section, Key, u8(b), FileName);
        }

        // 若傳回 0 表示失敗
        public int DeleteKey(string Section, string Key)
        {
            return WriteString(Section, Key, null);
        }

        // 若傳回 0 表示失敗
        public int DeleteSection(string Section)
        {
            return WriteString(Section, null, null);
        }
        public bool KeyExists(string Section, string Key)
        {
            return ReadString(Section, Key, "").Length > 0;
        }
    }
}
