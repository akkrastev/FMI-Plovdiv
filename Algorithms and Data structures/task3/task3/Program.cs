using System;
using System.Collections.Generic;
using task3.Interface;
using task3.Models;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();

            IShape myRect = new Regtancle(3, 4);
            shapes.Add(myRect);

            shapes.Add(new Regtancle(3, 5));
            shapes.Add(new Square( 5));            
            Console.WriteLine(GetListShapePerimeter(shapes));
        }

        static double GetListShapePerimeter(List<IShape> shapes)
        {
            double totalPerimeterSum = 0;
            for (int i = 0; i < shapes.Count; i++)
                totalPerimeterSum += shapes[i].getPerimeter();

            return totalPerimeterSum;
        }
    }
}
