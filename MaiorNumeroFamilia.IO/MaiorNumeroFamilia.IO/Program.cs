using System;
using System.Linq;

namespace MaiorNumeroFamilia.IO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número para descobrir o maior de sua família:");

            var numeroEntrada = int.Parse(Console.ReadLine());

            var maiorNumero = ObterMaiorNumeroFamilia(numeroEntrada);

            if (maiorNumero != -1)
                Console.WriteLine(string.Format("\n\nO maior número na família é \"{0}\"", maiorNumero));
            else
                Console.WriteLine("\n\nNão foi possível identificar o maior número da famíla!\n" +
                    "Tente novamente com um número menor.");

            Console.ReadKey();
        }

        private static int ObterMaiorNumeroFamilia(int N)
        {
            var maiorNumero = 0;
            var decimais = new int[] { };
            var numeroStr = N.ToString();

            if (numeroStr.Length == 1)
                return N;

            decimais = numeroStr.ToCharArray()
                .Select(n => (int)Char.GetNumericValue(n)).OrderBy(n => n).ToArray();

            for (int i = 1; i <= (decimais.Length - 1); i++)
            {
                var posicaoAtual = decimais[i];

                for (int n = i - 1; n >= 0; n--)
                {
                    decimais[n + 1] = decimais[n];
                }

                decimais[0] = posicaoAtual;
            }

            maiorNumero = int.Parse(string.Join("", decimais));

            return maiorNumero > 100000000 ? -1 : maiorNumero;
        }
    }
}
