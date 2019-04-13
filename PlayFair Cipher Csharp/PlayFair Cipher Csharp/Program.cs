using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayFair_Cipher_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Te shenohet mesazhi:");
            string Text = Console.ReadLine();
            Console.WriteLine("Mesazhi origjinal: " + Text);
            string plainText = Playfair.plain(Text);
            Console.WriteLine("Mesazhi i rregulluar: " + plainText);
            string key ="abcdefghiklmnopqrstuvwxyz";
            string cipherText = Playfair.Enkriptim(key, plainText);
            Console.WriteLine("Mesazhi i enkriptuar: " + cipherText);
            plainText = Playfair.Dekriptimi(key, cipherText);
            Console.WriteLine("Mesazhi i dekriptuar: "+plainText);
            Console.ReadLine();
        }
    }
    public class Playfair
    {

        public static string plain(string Text)
        {
            int length = Text.Length;
            Text = Text.ToLower();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                char c = Text[i];

                if (sb.Length % 2 == 1 && sb[sb.Length - 1] == c)
                {
                    sb.Append('x');
                }
                sb.Append(c);
                
            }
            if (sb.Length % 2 == 1)
            {
                sb.Append('x');
            }

            return sb.ToString();
        }

        public static string Enkriptim(string key, string plainText)
        {
            int length = plainText.Length;
            char a, b;
            int a_pozita, b_pozita, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2)
            {
                a = plainText[i];
                Console.WriteLine("\nKjo eshte a=plainttext[i]: " + a);
                b = plainText[i + 1];
                Console.WriteLine("\nKjo eshte b=plainttext[i+1]: " + b);


                a_pozita = key.IndexOf(a);
                Console.WriteLine("\nKjo eshte a_pozita: " + a_pozita);

                b_pozita = key.IndexOf(b);
                Console.WriteLine("\nKjo eshte b_pozita: " + b_pozita);

                a_row = a_pozita / 5;
                Console.WriteLine("\nKjo eshte a_row: " + a_row);

                b_row = b_pozita / 5;
                Console.WriteLine("\nKjo eshte b_row: " + b_row);

                a_col = a_pozita % 5;
                Console.WriteLine("\nKjo eshte a_col: " + a_col);

                b_col = b_pozita % 5;
                Console.WriteLine("\nKjo eshte b_col: " + b_col);


                if (a_row == b_row)
                {
                    if (a_col == 4)
                    {
                        sb.Append(key[a_pozita - 4]);
                        sb.Append(key[b_pozita + 1]);
                    }
                    else if (b_col == 4)
                    {
                        sb.Append(key[a_pozita + 1]);
                        sb.Append(key[b_pozita - 4]);
                    }
                    else
                    {
                        sb.Append(key[a_pozita + 1]);
                        sb.Append(key[b_pozita + 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 4)
                    {
                        sb.Append(key[a_pozita - 20]);
                        sb.Append(key[b_pozita + 5]);
                    }
                    else if (b_row == 4)
                    {
                        sb.Append(key[a_pozita + 5]);
                        sb.Append(key[b_pozita - 20]);
                    }
                    else
                    {
                        sb.Append(key[a_pozita + 5]);
                        sb.Append(key[b_pozita + 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }
        public static string Dekriptimi(string key, string cipherText)
        {
            int length = cipherText.Length;
            char a, b;
            int a_pozita, b_pozita, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2)
            {
                a = cipherText[i];
                b = cipherText[i + 1];

                a_pozita = key.IndexOf(a);
                b_pozita = key.IndexOf(b);
                a_row = a_pozita / 5;
                b_row = b_pozita / 5;
                a_col = a_pozita % 5;
                b_col = b_pozita % 5;

                if (a_row == b_row)
                {
                    if (a_col == 0)
                    {
                        sb.Append(key[a_pozita + 4]);
                        sb.Append(key[b_pozita - 1]);
                    }
                    else if (b_col == 0)
                    {
                        sb.Append(key[a_pozita - 1]);
                        sb.Append(key[b_pozita + 4]);
                    }
                    else
                    {
                        sb.Append(key[a_pozita - 1]);
                        sb.Append(key[b_pozita - 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 0)
                    {
                        sb.Append(key[a_pozita + 20]);
                        sb.Append(key[b_pozita - 5]);
                    }
                    else if (b_row == 0)
                    {
                        sb.Append(key[a_pozita - 5]);
                        sb.Append(key[b_pozita + 20]);
                    }
                    else
                    {
                        sb.Append(key[a_pozita - 5]);
                        sb.Append(key[b_pozita - 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }
    }
}
