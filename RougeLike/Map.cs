using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;
using RogueLike.HelpUtilities;


namespace RogueLike
{
    internal class Map
    {
        public Vector2 exitPosition { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public List<Wall> Walls { get; private set; }

        private char[,] mapGrid;
        private GameObjectManager gameObjectManager;
        private int wallNumber;

        private readonly Random random = new Random();

        public Map(GameObjectManager gameObjectManager, int wallNumber, int width = 50, int height = 25)
        {
            this.wallNumber = wallNumber;
            Width = width;
            Height = height;
            mapGrid = new char[width, height];
            this.gameObjectManager = gameObjectManager;
            Walls = new List<Wall>();

            GenerateMap();
        }

        public void GenerateMap()
        {
            for (int i = 1; i < Width - 1; i++)
            {
                CreateWallUnit(new Vector2(i, 0), '-', true);
                CreateWallUnit(new Vector2(i, Height - 1), '-', true);
            }

            for (int i = 1; i < Height - 1; i++)
            {
                CreateWallUnit(new Vector2(0, i), '|', true);
                CreateWallUnit(new Vector2(Width - 1, i), '|', true);
            }

            CreateWallUnit(new Vector2(0, 0), '+', true);
            CreateWallUnit(new Vector2(0, Height - 1), '+', true);
            CreateWallUnit(new Vector2(Width - 1, 0), '+', true);
            CreateWallUnit(new Vector2(Width - 1, Height - 1), '+', true);

            for (int i = 0; i < wallNumber; i++)
            {
                CreateWallUnit(GenerateRandomPosition(), '#', true);
            }

            PlaceExitRandomly();
        }


        public void PlaceExitRandomly()
        {
            int side = random.Next(4);

            switch (side)
            {
                case 0:
                    exitPosition = new Vector2(random.Next(1, Width - 1), 0);
                    break;
                case 1:
                    exitPosition = new Vector2(random.Next(1, Width - 1), Height - 1);
                    break;
                case 2:
                    exitPosition = new Vector2(0, random.Next(1, Height - 1));
                    break;
                case 3:
                    exitPosition = new Vector2(Width - 1, random.Next(1, Height - 1));
                    break;
            }

            gameObjectManager.DestroyGameObject(gameObjectManager.GetGameObjectAtPosition(exitPosition));

            CreateWallUnit(exitPosition, 'E', false);
        }

        public Vector2 GenerateRandomPosition()
        {
            int maxAttempts = 100;
            int attempt = 0;

            while (attempt < maxAttempts)
            {
                int x = random.Next(2, Width - 2);
                int y = random.Next(1, Height - 1);

                Vector2 randomPosition = new Vector2(x, y);

                if (gameObjectManager.IsPositionFree(randomPosition))
                {
                    return randomPosition;
                }

                attempt++;
            }
            return new Vector2(Width - 1, Height - 1);
        }

        private void CreateWallUnit(Vector2 position, char icon, bool isSolid)
        {
            Wall wall = new Wall(position, gameObjectManager, isSolid, icon);
            Walls.Add(wall);
            gameObjectManager.RegisterGameObject(wall);
        }
    }
}
