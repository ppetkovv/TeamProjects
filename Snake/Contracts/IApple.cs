using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Contracts
{
    public interface IApple
    {
        int AppleRowPosition { get; }
        int AppleColPosition { get; }
        void Print();
    }
}