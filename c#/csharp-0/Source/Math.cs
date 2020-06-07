using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            //return CalcularSeqDeFibonacci(350);
            List<int> fib = new List<int>();
            //a = prox
            int prox = 0;
            //b = ant
            int ant = 1;

            while (prox < 350)
            {
                int vlAtual = prox;
                prox = ant;
                ant = vlAtual + ant;
                fib.Add(vlAtual);
            }
            return fib;
        }

        public bool IsFibonacci(int numberToTest)
        {
            return CalcularSeqDeFibonacci(numberToTest).Contains(numberToTest);
        }

        private List<int> CalcularSeqDeFibonacci(int valorLimite)
        {
            List<int> seqNumerica = new List<int>();
            int proximoVlr = 1;
            int ultimoIdx = 0;
            int penultimoIdx = 0;

            try
            {
                seqNumerica.Add(0);

                do
                {
                    seqNumerica.Add(proximoVlr);

                    ultimoIdx = seqNumerica.LastIndexOf(seqNumerica.Last<int>());
                    penultimoIdx = ultimoIdx - 1;
                    proximoVlr = seqNumerica.ElementAt(penultimoIdx) + seqNumerica.ElementAt(ultimoIdx);

                } while (proximoVlr <= valorLimite);

                return seqNumerica;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
