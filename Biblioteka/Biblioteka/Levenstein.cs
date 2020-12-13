using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{

    public class Levenstein
    {
        public static int distance(string str1, string str2)
        {
            if ((str1 == null) || (str2 == null)) return -1;
            int str1len = str1.Length;
            int str2len = str2.Length;

            if ((str1len == 0) && (str2len == 0)) return 0;
            if (str1len == 0) return str2len;
            if (str2len == 0) return str1len;

            string strnew1 = str1.ToUpper();
            string strnew2 = str2.ToUpper();

            int[,] matrix = new int[str1len + 1, str2len + 1];

            for (int i = 0; i <= str1len; i++) matrix[i, 0] = i;
            for (int j = 0; j <= str2len; j++) matrix[0, j] = j;

            for (int i = 1; i <= str1len; i++)
            {
                for (int j = 1; j <= str2len; j++)
                {
                    int symbEqual = ((strnew1.Substring(i - 1, 1) == strnew2.Substring(j - 1, 1)) ? 0 : 1);

                    int ins = matrix[i, j - 1] + 1;
                    int del = matrix[i - 1, j] + 1;
                    int subst = matrix[i - 1, j - 1] + symbEqual;

                    matrix[i, j] = Math.Min(Math.Min(ins, del), subst);

                    if ((i > 1) && (j > 1) &&
                    (strnew1.Substring(i - 1, 1) == strnew2.Substring(j - 2, 1)) &&
                    (strnew1.Substring(i - 2, 1) == strnew2.Substring(j - 1, 1)))
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + symbEqual);
                    }
                }
            }
            return matrix[str1len, str2len];
        }

        public static string WriteDistance(string firstparam, string secondparam)
        {
            int d = distance(firstparam, secondparam);
            return ("'" + firstparam + "','" + secondparam + "' -> " + d.ToString());
        }
    }
}
