using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Model
{
    public class Colors
    {
        private readonly int _capacity;

        public List<Color> AllColors { get; set; }

        private int _nextIndex;

        public Color NextColor
        {
            get
            {
                if (_nextIndex >= _capacity)
                {
                    _nextIndex = 0;
                }
                return AllColors[_nextIndex++];
            }
        }

        public Colors(List<Color> colors)
        {
            _capacity = colors.Count;
            AllColors = colors;
            _nextIndex = 0;
        }
    }
}
