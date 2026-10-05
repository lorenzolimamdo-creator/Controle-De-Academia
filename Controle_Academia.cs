using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vetor com os nomes dos alunos
            string[] alunos = { "Ana", "Bruno", "Carlos", "Daniel", "Eduarda" };

            // Vetor com a quantidade de dias frequentados por cada aluno
            int[] frequencia = { 5, 3, 4, 2, 5 };

            // Matriz regular com a frequência dos alunos de segunda a sexta
            int[,] frequenciaSemanal =
            {
                    { 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 0, 1 },
                    { 1, 1, 1, 0, 1 },
                    { 1, 0, 0, 1, 0 },
                    { 1, 1, 1, 1, 1 }
                };

            // Matriz irregular com o histórico de treinos de cada aluno
            string[][] historicoTreinos =
            {
                    new string[] { "Peito", "Costas", "Pernas" },
                    new string[] { "Peito", "Biceps" },
                    new string[] { "Pernas", "Ombros", "Costas", "Peito" },
                    new string[] { "Pernas" },
                    new string[] { "Peito", "Costas", "Pernas", "Ombros" }
                };

            // Função local que transforma o valor da frequência em texto
            string Presenca(int valor)
            {
                if (valor == 1)
                {
                    return "Presente";
                }

                return "Faltou";
            }

            Console.WriteLine("=== PESQUISA SEQUENCIAL ===");

            // Chamada à função de pesquisa sequencial com retorno do índice do aluno encontrado
            int posicao = PesquisaSequencial(alunos, "Carlos");

            // Exibe o resultado da pesquisa sequencial
            if (posicao != -1)
            {
                Console.WriteLine("Aluno encontrado: " + alunos[posicao] + " index: " + (posicao + 1));
            }
            else
            {
                Console.WriteLine("Aluno nao encontrado.");
            }

            Console.WriteLine("\n=== FREQUENCIA ANTES DA ORDENACAO ===");

            // Exibe a frequência antes da ordenação
            for (int i = 0; i < alunos.Length; i++)
            {
                Console.WriteLine(alunos[i] + " - " + frequencia[i] + " dias");
            }

            Console.WriteLine("\n=== ORDENACAO POR BUBBLE SORT ===");

            // Chamada à função BubbleSort para ordenar os alunos pela frequência (do menos ao mais frequente)
            BubbleSort(alunos, frequencia);

            // Exibe a frequência após a ordenação
            for (int i = 0; i < alunos.Length; i++)
            {
                Console.WriteLine(alunos[i] + " - " + frequencia[i] + " dias");
            }

            Console.WriteLine("\n=== PESQUISA BINARIA ===");

            // Chamada à função de pesquisa binária no vetor já ordenado com retorno do índice da frequência encontrada
            int resultado = PesquisaBinaria(frequencia, 4);

            // Exibe o resultado da pesquisa binária
            if (resultado != -1)
            {
                Console.WriteLine("Frequencia encontrada: " + frequencia[resultado] + " dias");
                Console.WriteLine("Aluno encontrado: " + alunos[resultado] + " index: " + (resultado + 1));
            }
            else
            {
                Console.WriteLine("Frequencia nao encontrada.");
            }

            Console.WriteLine("\n=== FREQUENCIA SEMANAL ===");

            // For que utiliza da função local Presenca para exibir a frequência semanal de cada aluno em texto
            for (int i = 0; i < alunos.Length; i++)
            {
                Console.Write(alunos[i] + ": ");

                for (int j = 0; j < 5; j++)
                {
                    Console.Write(Presenca(frequenciaSemanal[i, j]) + " ");
                }

                Console.WriteLine();
            }

           
            Console.WriteLine("\n=== HISTORICO DE TREINOS ===");

            // Chamada à funcão MostrarHistorico para exibir o histórico de treinos de cada aluno
            MostrarHistorico(alunos, historicoTreinos);
            
            Console.WriteLine("=== MEDIA DE FREQUENCIA ===");

            // Chamada à função CalcularMedia para calcular a média de frequência de todos os alunos com retorno do valor da média
            double media = CalcularMedia(frequencia);

            Console.WriteLine("Media de frequencia dos alunos: " + media);

            Console.WriteLine("\n=== PORCENTAGEM DE FREQUENCIA ===");

            // Chamada à função CalcularPorcentagem para calcular a porcentagem de frequência de um aluno específico (Carlos)
            // com retorno do valor da porcentagem
            double porcentagem = CalcularPorcentagem(4, 5);

            Console.WriteLine("Frequencia do aluno Carlos: " + porcentagem + "%");
        }

        // Pesquisa sequencial por nome no vetor de alunos
        public static int PesquisaSequencial(string[] alunos, string nome)
        {
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == nome)
                {
                    return i;
                }
            }

            return -1;
        }

        // Troca dois valores usando passagem por referência
        public static void Trocar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Ordena os alunos pela frequência usando bubble sort
        public static void BubbleSort(string[] alunos, int[] frequencia)
        {
            for (int i = 0; i < frequencia.Length - 1; i++)
            {
                for (int j = 0; j < frequencia.Length - 1 - i; j++)
                {
                    if (frequencia[j] > frequencia[j + 1])
                    {
                        Trocar(ref frequencia[j], ref frequencia[j + 1]);

                        string temp = alunos[j];
                        alunos[j] = alunos[j + 1];
                        alunos[j + 1] = temp;
                    }
                }
            }
        }

        // Pesquisa binária por uma frequência no vetor já ordenado
        public static int PesquisaBinaria(int[] frequencia, int valor)
        {
            int inicio = 0;
            int fim = frequencia.Length - 1;

            while (inicio <= fim)
            {
                int meio = (inicio + fim) / 2;

                if (frequencia[meio] == valor)
                {
                    return meio;
                }
                else if (frequencia[meio] < valor)
                {
                    inicio = meio + 1;
                }
                else
                {
                    fim = meio - 1;
                }
            }

            return -1;
        }

        // Calcula a média de frequência dos alunos
        public static double CalcularMedia(int[] frequencias)
        {
            int soma = 0;

            for (int i = 0; i < frequencias.Length; i++)
            {
                soma += frequencias[i];
            }

            return (double)soma / frequencias.Length;
        }

        // Exibe o histórico de treinos dos alunos
        public static void MostrarHistorico(string[] alunos, string[][] historicoTreinos)
        {
            for (int i = 0; i < alunos.Length; i++)
            {
                Console.WriteLine("Aluno: " + alunos[i]);

                for (int j = 0; j < historicoTreinos[i].Length; j++)
                {
                    Console.WriteLine("Treino: " + historicoTreinos[i][j]);
                }

                Console.WriteLine();
            }
        }

        // Calcula a porcentagem de frequência usando passagem por valor
        public static double CalcularPorcentagem(int diasPresentes, int totalDias)
        {
            return (double)diasPresentes / totalDias * 100;
        }
    }
}
    

        
