using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTask
{
    class Graph
    {
        public string Type { get; set; }
        public List<int> Data { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"График: {Type}");
            sb.AppendLine($"Заголовок: {Title}");
            sb.AppendLine($"Цвет: {Color}");
            sb.Append("Данные: ");

            foreach (var d in Data)
                sb.Append(d + " ");

            return sb.ToString();
        }
    }

    interface IGraphBuilder
    {
        void SetType();
        void SetTitle();
        void SetColor();
        void SetData(List<int> data);
        Graph GetResult();
    }

    class LineGraphBuilder : IGraphBuilder
    {
        private Graph graph = new Graph();

        public void SetType()
        {
            graph.Type = "Line Graph";
        }

        public void SetTitle()
        {
            graph.Title = "Линейный график";
        }

        public void SetColor()
        {
            graph.Color = "Blue";
        }

        public void SetData(List<int> data)
        {
            graph.Data = data;
        }

        public Graph GetResult()
        {
            return graph;
        }
    }

    class BarGraphBuilder : IGraphBuilder
    {
        private Graph graph = new Graph();

        public void SetType()
        {
            graph.Type = "Bar Graph";
        }

        public void SetTitle()
        {
            graph.Title = "Столбчатый график";
        }

        public void SetColor()
        {
            graph.Color = "Green";
        }

        public void SetData(List<int> data)
        {
            graph.Data = data;
        }

        public Graph GetResult()
        {
            return graph;
        }
    }

    class PieChartBuilder : IGraphBuilder
    {
        private Graph graph = new Graph();

        public void SetType()
        {
            graph.Type = "Pie Chart";
        }

        public void SetTitle()
        {
            graph.Title = "Круговая диаграмма";
        }

        public void SetColor()
        {
            graph.Color = "Red";
        }

        public void SetData(List<int> data)
        {
            graph.Data = data;
        }

        public Graph GetResult()
        {
            return graph;
        }
    }

    class GraphDirector
    {
        public Graph Build(IGraphBuilder builder, List<int> data)
        {
            builder.SetType();
            builder.SetTitle();
            builder.SetColor();
            builder.SetData(data);

            return builder.GetResult();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int> { 10, 20, 30, 40, 50 };

            GraphDirector director = new GraphDirector();

            Graph line = director.Build(new LineGraphBuilder(), data);
            Console.WriteLine(line);
            Console.WriteLine();

            Graph bar = director.Build(new BarGraphBuilder(), data);
            Console.WriteLine(bar);
            Console.WriteLine();

            Graph pie = director.Build(new PieChartBuilder(), data);
            Console.WriteLine(pie);
        }
    }
}