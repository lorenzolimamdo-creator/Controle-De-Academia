using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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

                // Pesquisa sequencial
                Console.WriteLine("=== PESQUISA SEQUENCIAL ===");

                int posicao = PesquisaSequencial(alunos, "Carlos");

                if (posicao != -1)
                {
                    Console.WriteLine("Aluno encontrado: " + alunos[posicao]);
                }
                else
                {
                    Console.WriteLine("Aluno nao encontrado.");
                }

                // Exibe a frequência antes da ordenação
                Console.WriteLine("\n=== FREQUENCIA ANTES DA ORDENACAO ===");

                for (int i = 0; i < alunos.Length; i++)
                {
                    Console.WriteLine(alunos[i] + " - " + frequencia[i] + " dias");
                }

                // Ordena os alunos pela frequência
                Console.WriteLine("\n=== ORDENACAO POR BUBBLE SORT ===");

                BubbleSort(alunos, frequencia);

                for (int i = 0; i < alunos.Length; i++)
                {
                    Console.WriteLine(alunos[i] + " - " + frequencia[i] + " dias");
                }

                // Pesquisa binária no vetor já ordenado
                Console.WriteLine("\n=== PESQUISA BINARIA ===");

                int resultado = PesquisaBinaria(frequencia, 4);

                if (resultado != -1)
                {
                    Console.WriteLine("Frequencia encontrada: " + frequencia[resultado] + " dias");
                    Console.WriteLine("Aluno encontrado: " + alunos[resultado]);
                }
                else
                {
                    Console.WriteLine("Frequencia nao encontrada.");
                }

                // Exibe a matriz regular
                Console.WriteLine("\n=== FREQUENCIA SEMANAL ===");

                for (int i = 0; i < alunos.Length; i++)
                {
                    Console.Write(alunos[i] + ": ");

                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(Presenca(frequenciaSemanal[i, j]) + " ");
                    }

                    Console.WriteLine();
                }

                // Exibe a matriz irregular
                Console.WriteLine("\n=== HISTORICO DE TREINOS ===");

                MostrarHistorico(alunos, historicoTreinos);

                // Calcula a média de frequência
                Console.WriteLine("=== MEDIA DE FREQUENCIA ===");

                int[] frequenciaAna =
                {
            frequenciaSemanal[0, 0],
            frequenciaSemanal[0, 1],
            frequenciaSemanal[0, 2],
            frequenciaSemanal[0, 3],
            frequenciaSemanal[0, 4]
        };

                double media = CalcularMedia(frequenciaAna);

                Console.WriteLine("Media de frequencia de " + alunos[0] + ": " + media);

                // Calcula a porcentagem de frequência
                Console.WriteLine("\n=== PORCENTAGEM DE FREQUENCIA ===");

                double porcentagem = CalcularPorcentagem(4, 5);

                Console.WriteLine("Frequencia: " + porcentagem + "%");
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

            // Calcula a média de frequência de um aluno
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
    

