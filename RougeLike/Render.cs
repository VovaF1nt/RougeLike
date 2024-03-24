using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;
using RogueLike.UIComponents;

namespace RogueLike
{
    internal class Renderer
    {
        private GameObjectManager gameObjectManager;

        private char[,] mapBuffer;
        private int width;
        private int height;

        private UIManager uiManager;
        private HealthBar healthBar;

        public Renderer(GameObjectManager gameObjectManager, UIManager uiManager)
        {
            this.gameObjectManager = gameObjectManager;
            width = gameObjectManager.Map.Width;
            height = gameObjectManager.Map.Height;
            mapBuffer = new char[width, height];

            this.uiManager = uiManager;
            healthBar = uiManager.HealthBar;
        }

        public void Render()
        {
            Console.Clear();
            UpdateMapBuffer();
            RenderMap();
            RenderHealthBar();
        }

        public void RedenderGameLost()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Рыцарь потерпел порожение. Вам не удалось спасти принцессу.");
            Environment.Exit(0);
        }

        public void RenderGameWon()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Рыцарь сражался до самого конца и выстоял. Он спасёт свою дочь и в королевстве наступит мир!");
            Environment.Exit(0);
        }

        private void RenderMap()
        {
            Console.SetCursorPosition(0, 0);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(mapBuffer[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void UpdateMapBuffer()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mapBuffer[i, j] = ' ';
                }
            }

            for (int i = gameObjectManager.GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = gameObjectManager.GameObjects[i];
                Vector2 position = gameObject.Position;
                char icon = gameObject.Icon;
                if (position.X >= 0 && position.X < width && position.Y >= 0 && position.Y < height)
                {
                    mapBuffer[position.X, position.Y] = icon;
                }
            }
        }

        private void RenderHealthBar()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Health: {healthBar.CurrentHealth} / {healthBar.MaxHealth}");
            Console.ResetColor();
        }
    }
}
