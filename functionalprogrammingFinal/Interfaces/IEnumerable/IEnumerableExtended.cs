using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace functionalprogrammingFinal.Interfaces.IEnumerable
{
    public class IEnumerableExtended : IEnumerable<XElement>
    {
        IEnumerable<XElement> Content;

        public IEnumerator<XElement> GetEnumerator()
        {
            foreach (XElement element in Content)
            {
                yield return element;
            }
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (XElement element in Content)
            {
                yield return element;
            }
        }

        public IEnumerableExtended()
        {
            Content = new List<XElement>();
        }

        public IEnumerableExtended(IEnumerable<XElement> baseMap)
        {
            Content = baseMap;
        }

        public IEnumerableExtended Property(string PropertyName) => new IEnumerableExtended(
            Content.Where(Node => Node.Name == PropertyName));

        public IEnumerableExtended Property(string PropertyName, string FilteredValue) => new IEnumerableExtended(
            Content.Where(
                Node => Node.Name == PropertyName &&
                new IEnumerableExtended(Node.Descendants()).
                    Property("Id").ToString() == FilteredValue));

        public int ToInt() => Content.FirstOrDefault() == null ?
            -1 : int.Parse(Content.First().Value);

        override public string ToString() => Content.FirstOrDefault()?.Value;

    }
}
