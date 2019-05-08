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
        public const int distance = 45;
        public const int yDistance = 140;
        public Vector2[] positions;
        public MapPosition(int count, Vector2[] positions)
        {
            this.count = count;
            this.positions = positions;
        }
        public static MapPosition getMapEmptyBoxPosition(int count,int index)
        {
            switch (count)
            {
                case 2:
                    {
                        return new MapPosition(count, new Vector2[]
                        {
                            Position.getPosition(-30,yDistance - distance*index),
                            Position.getPosition(30,yDistance - distance*index)
                        });
                    }
                case 3:
                    {
                        return new MapPosition(count, new Vector2[]
                        {
                            Position.getPosition(-50, yDistance - distance*index),
                            Position.getPosition(0, yDistance - distance*index),
                            Position.getPosition(50, yDistance - distance*index)
                        });
                    }
                case 4:
                    {
                        return new MapPosition(count, new Vector2[]
                        {
                            Position.getPosition(-75, yDistance - distance*index),
                            Position.getPosition(-25, yDistance - distance*index),
                            Position.getPosition(25, yDistance - distance*index),
                            Position.getPosition(75, yDistance - distance*index)
                        });
                    }
                default:
                    return null;
            }
        }
        public static MapPosition getMapWordBoxPosition(int count)
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
                            Position.getPosition(-75, -120),
                            Position.getPosition(0, -40),
                            Position.getPosition(75, -120)
                        });
                    }
                case 4:
                    {
                        return new MapPosition(count, new Vector2[]
                        {
                            Position.getPosition(-60, -40),
                            Position.getPosition(60, -40),
                            Position.getPosition(-60, -140),
                            Position.getPosition(60, -140)
                        });
                    }
                default:
                    return null;
            }
        }
    }
}
