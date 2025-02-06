using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Model
{
    public class Pictures
    {
        public static int[,] ConvertImageToArray(string imagePath)
        {
            Bitmap bitmap = new Bitmap(imagePath);

            int width = bitmap.Width;
            int height = bitmap.Height;

            int[,] pixelArray = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Получаем цвет пикселя
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Преобразуем цвет в целое число (ARGB)
                    // Мы используем ARGB, где:
                    // A = альфа (прозрачность), R = красный, G = зеленый, B = синий
                    int colorValue = (pixelColor.A << 24) | (pixelColor.R << 16) | (pixelColor.G << 8) | pixelColor.B;

                    // Записываем значение в массив
                    pixelArray[y, x] = colorValue;
                }
            }

            return pixelArray;
        }
    }
}
