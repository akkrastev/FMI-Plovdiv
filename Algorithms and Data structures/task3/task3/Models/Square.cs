using System;
using System.Collections.Generic;
using System.Text;
using task3.Interface;

namespace task3.Models
{
    class Square : IShape
    {
        private double m_a;

        public double getPerimeter()
        {
            return 4 * m_a;
        }

        public Square(double a)
        {
            this.m_a = a;
        }
    }
}
