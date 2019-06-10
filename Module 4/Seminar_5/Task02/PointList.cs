using System;
using System.Collections;
using System.Collections.Generic;

namespace Task02
{
    public class PointList : IEnumerable<Point>
    {
        List<Point> list;
        
        public PointList()
        {
            list = new List<Point>();
        }

        public void Add(Point p)
        {
            list.Add(p);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return ((IEnumerable<Point>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Point>)list).GetEnumerator();
        }
    }
}
