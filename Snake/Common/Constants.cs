using SnakeGame.Contracts;
using SnakeGame.Models;
using System.Collections.Generic;

namespace SnakeGame.Common
{
    public static class Constants
    {
        public static IDictionary<string, IPosition> positionsByIndex = new Dictionary<string, IPosition>(){
            { "right" , new Position(0,1)},
            { "left" , new Position(0, -1)},
            { "down",new Position(1,0)},
            { "up", new Position(-1,0)},
        };
        
        public const string GameOver = "Game over!!!";
        public const string InvalidCommand = "Invalid command!";
        public const string InvalidGameMode = "Please enter valid game mode: ";
        public const string InvalidApplesState = "Cannot eat more than one apple!";
        public const string GameLevel = "LEVEL";
        public const string GameStartPreparation = "The game will start in: ";
        public const string GameMode = @"Please choose from one of the game modes:
                                            Press 1 for   W     OR 2 for        UP
                                                        A S D             LEFT DOWN RIGHT
Game Mode: ";
    }
}