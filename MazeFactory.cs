using System;
using System.Collections.Generic;

namespace Singleton
{
    #region MazeParts
    public enum Direction
    {
        North, South, East, West
    }
}

public class MapSite { }

public class Maze
{
    private List<Room> _rooms;

    public Maze()
    {
        _rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }

    public Room GetRoom(int number)
    {
        return _rooms[number];
    }
}

public class Room : MapSite
{
    private int _number;
    private MapSite[] _sides = new MapSite[4];

    public Room(int number)
    {
        _number = number;
    }

    public void SetSide() { }
}

public class Wall : MapSite
{

}

public class Door : MapSite { }
#endregion

//--------------------------------------

public class MazeFactory
{
    public static MazeFactory Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MazeFactory();
            return _instance;
        }
    }

    private static MazeFactory _instance;

    protected MazeFactory() { }

    public static MazeFactory GetInstance()
    {
        if (_instance == null)
        {
            string _mazeStyle = "Main.GetCurrentMazeStyle()";

            switch (_mazeStyle)
            {
                case "standart": _instance = new MazeFactory(); break;

                case "magic": _instance = new MagicMazeFactory(); break;

                default: _instance = new MazeFactory(); break;
            }
        }

        return _instance;
    }

    public virtual Maze MakeMaze()
    {
        return new Maze();
    }

    public virtual Wall MakeWall()
    {
        return new Wall();
    }

    public virtual Room MakeRoom(int n)
    {
        return new Room(n);
    }

    public virtual Door MakeDoor(Room r1, Room r2)
    {
        return new Door();
    }
}

public class MagicMazeFactory : MazeFactory
{

}

public class CandyMazeFactory : MazeFactory
{
    protected CandyMazeFactory()
    {
    }


}