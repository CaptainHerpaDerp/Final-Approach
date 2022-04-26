using GXPEngine;
using System;
using System.IO;
using TiledMapParser;

public class Level : GameObject
{

    TiledLoader loader;
    public GameObject tilePosition;
    public string currentLevelPath;

    public Level(String filename)
    {
        currentLevelPath = filename;
        loader = new TiledLoader(filename);
        CreateLevel();

    }

    void CreateLevel(bool includeImageLayers = true)
    {
        Map leveldata = MapParser.ReadMap(currentLevelPath);

        //loading tiled layers
        loader.rootObject = this;
        loader.addColliders = false;
        loader.LoadTileLayers(0);
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        SpawnObjects(leveldata);
        //SpawnTiles(leveldata);
        loader.LoadTileLayers(3);
        loader.LoadObjectGroups();
    }


    void SpawnObjects(Map leveldata)
    {
        if (leveldata.ObjectGroups == null || leveldata.ObjectGroups.Length == 0)
            return;

        ObjectGroup objectGroup = leveldata.ObjectGroups[0];
        if (objectGroup.Objects == null || objectGroup.Objects.Length == 0)
            return;

        foreach (TiledObject obj in objectGroup.Objects)
        {
            switch (obj.Name)
            {
                case "Collider":
                    Console.WriteLine(true);
                    CollisionTile tile = new CollisionTile(obj.Width, obj.Height);
                    tile.x = obj.X;
                    tile.y = obj.Y;
                    AddChild(tile);
                    break;
            }

        }
    }
}