using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Position
    {
        public static Vector2 getPosition(int x, int y)
        {
            return new Vector2(x, y);
        }
    }
    public class MapPosition
    {
        public int count;
        public Vector2[] positions;
        public MapPosition(int count, Vector2[] positions)
        {
            this.count = count;
            this.positions = positions;
        }
        public static MapPosition getMapPosition(int count)
        {
            switch (count)
            {
                case 2:
                    {
                        return new MapPosition(count, new Vector2[]
                        {
                            Position.getPosition(-60,-80),
                            Position.getPosition(60,-80)
                        });
                    }
                case 3:
                    {
                        return new MapPosition(count, new Vector2[]
                        {
                            Position.getPosition(-75, -110),
                            Position.getPosition(0, -30),
                            Position.getPosition(75, -110)
                        });
                    }
                default:
                    return null;
            }
        }
    }
}
