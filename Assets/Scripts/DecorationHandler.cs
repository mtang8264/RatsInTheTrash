using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class DecorationHandler : MonoBehaviour
{
    public static int toPlace = -1;

    public static GameObject[] trash2;

    public GameObject[] trash;
    public List<Decoration> decorations = new List<Decoration>();

    public bool placing = false;
    public int placingIdx = -1;

    public Texture2D trashcan;

    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/rats.rts"))
        {
            DecorationList temp = Load();
            decorations = temp.list;
        }

        if (decorations.Count > 0)
        {
            for (int i = 0; i < decorations.Count; i++)
            {
                Instantiate(trash[decorations[i].index]).transform.position = new Vector3(decorations[i].position[0], decorations[i].position[1], 5);
                trash[decorations[i].index].GetComponent<Trash>().gotten = true;
            }
        }

        if(toPlace != -1)
        {
            SetObject(toPlace);
            toPlace = -1;
            BeachClicker.over = false;
        }

        trash2 = trash;
    }

    // Update is called once per frame
    void Update()
    {
        if(placing)
        {
            Cursor.SetCursor(trash[placingIdx].GetComponent<Trash>().cursor, new Vector2(50,50), CursorMode.Auto);
            if(BeachClicker.over)
            {
                Cursor.SetCursor(trashcan, new Vector2(50,50), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(null, new Vector2(50,50), CursorMode.Auto);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (placing && Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
            {
                placing = false;
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                decorations.Add(new Decoration(new Vector3(pos.x, pos.y, 5), placingIdx));

                Instantiate(trash[placingIdx]).transform.position = new Vector3(decorations[decorations.Count - 1].position[0], decorations[decorations.Count-1].position[1], 5);

                Save();
            }
        }
    }

    public void SetObject(int index)
    {
        placing = true;
        placingIdx = index;
    }

    void Save()
    {
        DecorationList list = new DecorationList();
        for (int i = 0; i < decorations.Count; i ++)
        {
            list.add(decorations[i]);
        }

        // The file path at which the game saves
        string path = Application.persistentDataPath + "/rats.rts";
        BinaryFormatter bf = new BinaryFormatter();
        // Either creates or overwrites the save file
        FileStream file = File.Create(path);
        // Saves the object to the files
        bf.Serialize(file, list);
        // Closes the file connection
        file.Close();
        // Logs the resulted file
        Debug.Log("Saved to " + path);
    }

    DecorationList Load()
    {
        string path = Application.persistentDataPath + "/rats.rts";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path,FileMode.OpenOrCreate);
        DecorationList list = (DecorationList)bf.Deserialize(file);
        file.Close();
        return list;
    }
}

[System.Serializable]
public class Decoration
{
    public float[] position = new float[3];
    public int index;

    public Decoration(Vector3 p, int i)
    {
        position[0] = p.x;
        position[1] = p.y;
        position[2] = p.z;
        index = i;
    }
}

[System.Serializable] 
public class DecorationList
{
    public List<Decoration> list = new List<Decoration>();

    public void add(Decoration decoration){
        list.Add(decoration);
    }
}