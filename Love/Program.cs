using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace test
{

    class EText
    {
        int x, X, y, index, k, l;
        string s;
        ConsoleColor[] cl;
        ConsoleColor cl1, cl2;
        Random r;
        int iColor, nColor;
        public EText(string s, int x, int y)
        {
            this.x = x;
            this.y = y;
            X = x;
            k = 0;
            this.s = s;
            l = s.Length;
            index = l - 1;
            cl = new ConsoleColor[] { ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Green };
            nColor = cl.Length;
            cl1 = ConsoleColor.Black;
            cl2 = ConsoleColor.Cyan;
            r = new Random();
            iColor = 0;
        }
        public void ve()
        {

            Console.SetCursorPosition(X, y);
            for (int i = k; i < l; i++)
            {
                Console.ForegroundColor = cl1;
                if (i == index)
                {
                    Console.ForegroundColor = cl2;
                }
                //Console.OutputEncoding = System.Text.Encoding.Unicode; 
                Console.Write(s[i]);

            }

            if (index == k)
            {
                k++;
                X++;
                index = l;
            }
            if (k == l - 1)
            {
                k = 0;
                X = x;
                cl1 = cl2;
                cl2 = cl[iColor];
                iColor++;
                if (iColor == nColor)
                {
                    iColor = 0;
                }
            }
            index--;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
                Image Picture = Image.FromFile("../../../image/yeuem.png");
                Console.SetWindowSize((Picture.Width * 2), (Picture.Height * 2));
                FrameDimension Dimension = new FrameDimension(Picture.FrameDimensionsList[0]);
                int FrameCount = Picture.GetFrameCount(Dimension);
                int Left = Console.WindowLeft, Top = Console.WindowTop;
                char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
                Picture.SelectActiveFrame(Dimension, 0);
                for (int i = 0; i < Picture.Height; i++)
                {
                    for (int xy = 0; xy < Picture.Width; xy++)
                    {
                        Color Color = ((Bitmap)Picture).GetPixel(xy, i);
                        int Gray = (Color.R + Color.G + Color.B) / 3;
                        int Index = (Gray * (Chars.Length - 1)) / 255;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Chars[Index]);
                    }
                    Console.Write('\n');
                }
                Console.SetCursorPosition(1, Top);
                Thread.Sleep(3000);
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nBấm N để tiếp tục...");
                Console.ReadKey();
                Console.Clear();
            Console.CursorVisible = false;
                string[] str = new string[] {"                              __                                              ",
                                         "                    _____    /0/                                              ",
                                         "                   /00\\00\\  /0/                                               ",
                                         "                  /00/ \\00\\ ‾‾                                            ___ ",
                                         "                  ‾‾‾   ‾‾‾                                              |000|",
                                         "  ___________    ____________      ____     ___   ___      ___   ___      _|0|",
                                         " |00000000000|  |000000000000|    |0000\\   |000| |000|    |000| |000|    |000|",
                                         " |00000000000|  |000000000000|    |00000\\  |000| |000|    |000| |000|    |000|",
                                         "  ‾‾‾|000|‾‾‾   |000|‾‾‾‾|000|    |000000\\ |000| |000|____|000| |000|    |000|",
                                         "     |000|      |000|    |000|    |000|000\\|000| |000000000000| |000|    |000|",
                                         "     |000|      |000|    |000|    |000|\\000|000| |000000000000| |000|    |000|",
                                         "     |000|      |000|____|000|    |000| \\000000| |000|‾‾‾‾|000| |000|____|000|",
                                         "     |000|      |000000000000|    |000|  \\00000| |000|    |000| |000000000000|",
                                         "     |000|      |000000000000|    |000|   \\0000| |000|    |000| |000000000000|",
                                         "      ‾‾‾        ‾‾‾‾‾‾‾‾‾‾‾‾      ‾‾‾     ‾‾‾‾   ‾‾‾      ‾‾‾   ‾‾‾‾‾‾‾‾‾‾‾‾ "};
                int n = str.Length;

                EText[] ET = new EText[n];
                int x, y;
                x = 1;
                y = 1;
                for (int i = 0; i < n; i++)
                {
                    ET[i] = new EText(str[i], x, y + i);
                }

                while (true)
                {
                    while (true)
                    {
                        foreach (EText et in ET)
                        {
                            et.ve();
                        }
                    }

                }
           
        }
    }
}