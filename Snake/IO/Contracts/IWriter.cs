using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string value);

        void Write(string value);
    }
}
