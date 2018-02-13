using Autofac;
using SnakeGame.Client.InjectionConfiguration;
using SnakeGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            var injectionConfig = new InjectionConfig(builder);
            var container = builder.Build();
            var gameEngine = container.Resolve<IEngine>();
            gameEngine.Start();
        }
    }
}