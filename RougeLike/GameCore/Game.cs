﻿using Microsoft.VisualBasic;
using RogueLike.Input;
using RogueLike.UIComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RogueLike.GameCore
{

    public class Game
    {



        private static readonly Random random = new Random();

        private int enemyNumber = random.Next(1, 3);
        private int shootingEnemyNumber = random.Next(1, 2);
        private int wallNumber = random.Next(50, 100);

        public GameState gameState { get; private set; }

        GameObjectManager gameObjectManager;
        UIManager uiManager;
        Renderer renderer;
        InputManager input;
        InputHandler inputHandler;
        GameLoop gameLoop;




        public Game()
        {
            gameObjectManager = new GameObjectManager(enemyNumber, shootingEnemyNumber, wallNumber);
            uiManager = new UIManager(gameObjectManager);
            renderer = new Renderer(gameObjectManager, uiManager);
            input = new InputManager();
            inputHandler = new InputHandler(gameObjectManager.Player, input);

            gameState = GameState.Playing;

            gameObjectManager.OnPlayerDestroyed += OnPlayerDiedCallback;
            gameObjectManager.OnPlayerReachedExit += OnPlayerReachedExitCallback;

            gameLoop = new GameLoop(Update, 24);
            gameLoop.Start();
        }

        public void Update(double deltaTime)
        {

            switch (gameState)
            {
                case GameState.Playing:
                    input.ReadInput();
                    renderer.Render();
                    gameObjectManager.Update(deltaTime);
                    break;
                case GameState.PlayerLost:
                    renderer.RedenderGameLost();
                    gameLoop.Stop();
                    break;
                case GameState.PlayerWon:
                    renderer.RenderGameWon();
                    gameLoop.Stop();
                    break;
            }
        }

        private void OnPlayerDiedCallback()
        {
            gameState = GameState.PlayerLost;
        }

        private void OnPlayerReachedExitCallback()
        {
            gameState = GameState.PlayerWon;
        }
    }
}