using Autofac;
using SnakeGame.Contracts;
using SnakeGame.Engine;
using SnakeGame.IO;
using SnakeGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Client.InjectionConfiguration
{
    class InjectionConfig
    {
        public InjectionConfig(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<GameEngine>().As<IEngine>().SingleInstance();
        }
    }
}