using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Contracts
{
    interface IConsoleSetup
    {
        void SetupConsole();
        void SlowAction(int milliseconds);
    }
}