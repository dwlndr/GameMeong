using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

public class ManajemenData 
{
    public static string lokasiFile =
        Application.persistentDataPath +
        "/savedata.bin";
    public void save(GameData data)
    {
        BinaryFormatter penerjemah =
            new BinaryFormatter();
        FileStream jembatan = new FileStream(
            lokasiFile, FileMode.Create
            );
        penerjemah.Serialize(jembatan, data);
        jembatan.Close();
    }
    public GameData load()
    {
        GameData data = null;
        if (File.Exists(lokasiFile))
        {
            BinaryFormatter penerjemah =
            new BinaryFormatter();
            FileStream jembatan = new FileStream(
                lokasiFile, FileMode.Open
                );
            data = penerjemah.Deserialize(jembatan)
                as GameData;
            jembatan.Close();
        }
        return data;
    }
}
