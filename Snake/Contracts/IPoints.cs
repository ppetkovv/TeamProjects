using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Contracts
{
    interface IPoints
    {
        int PositivePoints { get; set; }
        int NegativePoints { get; set; }
        int SnakeInitialLength { get; }
        int AllPoints { get; }
    }
}