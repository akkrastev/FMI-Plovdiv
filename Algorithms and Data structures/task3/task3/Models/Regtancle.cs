using System;
using System.Collections.Generic;
using System.Text;
using task3.Interface;

namespace task3.Models
{
    class Regtancle : IShape
    {
        private double m_a;
        private double m_b;

        public Regtancle(double a, double b)
        {
            this.m_a = a;
            this.m_b = b;
        }

        public double getPerimeter()
        {
            return 2 * (m_a + m_b);
        }
    }
}
