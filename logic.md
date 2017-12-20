I. POSITION
1) struct Position							// what we use for coordinates of objects that get printed on the console
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
	
2)  byte right = 0;			//just so the user input is readable to us
	byte left = 1;
    byte down = 2;
    byte up = 3;
			
3)          Position[] directions = new Position[]   	// used for navigating snake*
            {
                new Position(0,1),  //right   >
                new Position(0, -1), //left   <
                new Position(1,0), //down     v
                new Position(-1,0) //top      ^
            };
			
4)  int direction = right;		// must be set like so at beginning of each game so snake starts moving (could in theory be any other direction

II. SNAKE
1)  Queue<Position> snakeElements = new Queue<Position>();			// setting initial coordinates of snake (always leaves from same place)

            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(2, i));
            }
			
2) foreach (Position position in snakeElements)				// printing snake
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("*");
            }
			
3) if (Console.KeyAvailable)				// keeping the snake moving and allowing us to change directions
					{   // negativePoints++; // with each movement
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.A)
                    {
                        if (direction != right)
                        {
                            direction = left;
                        }                        
                    }
                    if (userInput.Key == ConsoleKey.D)
                    {
                        if (direction != left)
                        {
                            direction = right;
                        }
                    }
                    if (userInput.Key == ConsoleKey.W)
                    {
                        if (direction != down)
                        {
                            direction = up;
                        }
                    }
                    if (userInput.Key == ConsoleKey.S)
                    {
                        if (direction != up)
                        {
                            direction = down;
                        }
                    }
                }	
				
4) Position snakeHead = snakeElements.Last();		
   Position nextDirection = directions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row,
                                                     snakeHead.col + nextDirection.col);		
// removes first element of snake (tail) and adds another at last position (new head)
// coordinates of new head form by combining coordinates of old one and the direction in which the snake is heading
// e.g. 
// let's mark head with %
// *******% coordinates of head are (6,14)
//  ******% tail is removed
//  ******* head turns to normal body part
// if direction is down (0,1)
// then new head coordinates are ( 6 + 0 , 14 + 1) = (6, 15)
//  *******
//        %
 
 5) 			if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {   // feeding the snake
                    do 			// create new apple
                    {
                        food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                         randomNumberGenerator.Next(0, Console.WindowWidth));
                    } while (snakeElements.Contains(food) || obstacles.Contains(snakeNewHead));	// until it doesn't land on snake or obstacles
                    lastFoodTime = Environment.TickCount;		// measure time so apple knows when to disappear
                    Console.SetCursorPosition(food.col, food.row);				// print apple
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("@");
                    sleepTime -= 2;				// make snake faster with each apple eaten

                    Position obstacle = new Position();			// create new obstacle each time the snake eats an apple
                    do
                    {
                        obstacle = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                                randomNumberGenerator.Next(0, Console.WindowWidth));
                    } while (snakeElements.Contains(obstacle) || 
                             obstacles.Contains(obstacle) || 
                             (food.row != obstacle.row && food.col != obstacle.col));		// until it doesn't land on snake, 
							 														    	// apple or another obstacle

                    obstacles.Add(obstacle);													// keep track of existing obstacles
                    Console.SetCursorPosition(obstacle.col, obstacle.row);					// print obstacle
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("=");
                }
                else
                {   // if snake doesn't bump into self, borders or obstacles or doesn't eat an apple it just keeps moving
                    Position last = snakeElements.Dequeue();				// removes first element from queue, a.k.a. the tail
                    Console.SetCursorPosition(last.col, last.row);		   // prints a blank space over it to remove from console
                    Console.Write(" ");
                }
				
6) Position last = snakeElements.Dequeue();			// remove old tail and add new head, i.e. keep snake moving
      Console.SetCursorPosition(last.col, last.row);
      Console.Write(" ");
	  Position snakeHead = snakeElements.Last();		
   	  Position nextDirection = directions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row,
                                                     snakeHead.col + nextDirection.col);	
				
III. APPLE
1) int lastFoodTime = 0;							
   int foodDisappearTime = 8000;					// time after which if not eaten the apple disappears
   lastFoodTime = Environment.TickCount;           // number of miliseconds passed since beginning of program
    
 2)  Position food; 		// initializing new apple
		Random randomNumberGenerator = new Random();
            do			// creating a new apple object after the snake has eaten it
            {
                food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                         randomNumberGenerator.Next(0, Console.WindowWidth));
            } while (snakeElements.Contains(food) || obstacles.Contains(food));		// so new apple doesn't fall on snake/obstacles

3)          Console.SetCursorPosition(food.col, food.row);   // printing apple
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
			
4) 				if (Environment.TickCount - lastFoodTime >= foodDisappearTime)     // when time of apple runs out
                {
                    negativePoints += 50; 				// that affects final points negaively

                    Console.SetCursorPosition(food.col, food.row);				// omits "expired" apple 
                    Console.Write(" ");

                    do
                    {
                        food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                         randomNumberGenerator.Next(0, Console.WindowWidth));
                    } while (snakeElements.Contains(food) || obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;
                }
			
			
IV. OBSTACLES
1) List<Position> obstacles = new List<Position>()		// example for readily enerated obstacles - DO NOT USE
            {
                new Position(12, 12),
                new Position(14, 20),
                new Position(7, 7),
                new Position(22, 12),
                new Position(24, 7),
                new Position(20, 7),
            };
			
			
3) foreach (Position obstacle in obstacles)			// printing obstacles on console
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(obstacle.col, obstacle.row);
                Console.Write("=");
            }
			

V. BORDERS
 1) 			if (snakeNewHead.col < 0)			// if no borders exist and snake should show up at opposite end 
                {
                    snakeNewHead.col = Console.WindowWidth - 1;
                }
                if (snakeNewHead.row < 0)
                {
                    snakeNewHead.row = Console.WindowHeight - 1;
                }
                if (snakeNewHead.row >= Console.WindowHeight)
                {
                    snakeNewHead.row = 0;
                }
                if (snakeNewHead.col >= Console.WindowWidth)
                {
                    snakeNewHead.col = 0;
                }
				
2) 				if (snakeNewHead.row < 0 ||           // if all borders are in place and snake hotting them causes death
                snakeNewHead.col < 0 ||
                snakeNewHead.row >= Console.WindowHeight ||
                snakeNewHead.col >= Console.WindowWidth ||
                snakeElements.Contains(snakeNewHead) ||          // use only this and...
	            obstacles.Contains(snakeNewHead))				// ...this if no borders are in place
															   // snake bumps into itself or into an obstacle
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Game over!");
                    int userPoints = (snakeElements.Count - 6) * 100 - negativePoints;
                    userPoints = Math.Max(userPoints, 0);								// so users don't cry if they get negative points
                    Console.WriteLine("Your point are: {0}", userPoints);
                    return;													// END GAME
                }

		
VI. Other
1) int negativePoints = 0; 		// with each movement points are deducted, so the user has to take the shortest route possible
	negativePoints++; 
2) sleepTime -= 0.01;
   Thread.Sleep((int)sleepTime);		// lowers speed so user has a chance to input commands