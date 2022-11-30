using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// �n�C�X�R�A�̍X�V�����邽�߂̃N���X
/// </summary>
public static class HighScoreSave
{
    /// <summary>
    /// �����ɐ��l��n��Json�`���ŕۑ�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public static void OnSave<T>(T data)
    {
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savedata.json"))
        {
            string json = JsonUtility.ToJson(data);
            writer.Write(json);
            //writer.Flush();
            writer.Close();
        }
    }
    /// <summary>
    /// ����������ϐ��������ɐݒ肷�邱�Ƃœ����^��Json�t�@�C�����琔�l��������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static T OnLoad<T>(T data)
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                string read = "";
                read = reader.ReadLine();
                reader.Close();
                return data = JsonUtility.FromJson<T>(read);
            }
        }
        catch
        {
            Debug.LogWarning("�f�[�^������܂���B");
            return data = (T)(object)0;
        }
    }
}