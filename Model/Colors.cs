using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Model
{
    public class Colors
    {
        /// <summary>
        /// Количство элементов списка.
        /// </summary>
        private readonly int _count;

        /// <summary>
        /// Список с доступными цветами.
        /// </summary>
        public List<Color> AllColors { get; set; }

        /// <summary>
        /// Индекс на следующий цвет.
        /// </summary>
        private int _nextIndex;

        /// <summary>
        /// Возвращает следующий цвет.
        /// </summary>
        public Color NextColor
        {
            get
            {
                if (_nextIndex >= _count)
                {
                    _nextIndex = 0;
                }
                return AllColors[_nextIndex++];
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Colors"/>.
        /// </summary>
        /// <param name="colors">Список цветов.</param>
        public Colors(List<Color> colors)
        {
            _count = colors.Count;
            AllColors = colors;
            _nextIndex = 0;
        }
    }
}
