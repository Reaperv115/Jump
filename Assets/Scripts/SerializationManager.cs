using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager
{
   public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = getbinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        else
            Debug.Log("directory exists");

        string path = Application.persistentDataPath + "/saves/" + saveName + ".saves";

        FileStream file = File.Create(path);
        formatter.Serialize(file, saveData);
        file.Close();
        return true;
    }

    public static object Load(string path)
    {
        if (!File.Exists(path))
            return null;

        BinaryFormatter formatter = getbinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("failed to load file", path);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter getbinaryFormatter()
    {
        return new BinaryFormatter();
    }
}
