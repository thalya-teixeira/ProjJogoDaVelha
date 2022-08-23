using System;

namespace ProjJogoDaVelha
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string jogador1;
            string jogador2;
            string[,] matrizJogo = new string[3, 3];
            int tentativas = 0;

            RegrasDoJogo();
            jogador1 = JogadorEscolhe();
            jogador2 = Jogador2Escolhe(jogador1);
            ModeloMatriz(matrizJogo);
            do
            {
                tentativas++;
                Jogador1Joga(matrizJogo, jogador1); 
                ImprimirJogo(matrizJogo);
                if (CondicaoVitoria(matrizJogo, jogador1) == true) break;
                tentativas++;
                Jogador2joga(matrizJogo, jogador2);
                ImprimirJogo(matrizJogo);
                if(CondicaoVitoria(matrizJogo, jogador2) == true) break;
                if (tentativas > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(">>>>> DEU VELHA! <<<<<");
                    Console.ForegroundColor = ConsoleColor.White;
                    break; //quebra o laço de repetição
                }
            } while (true);
        }
        
        static void RegrasDoJogo()
        {
            Console.WriteLine("\t# JODO DA VELHA # \n");
            Console.WriteLine("Pressione ENTER para as regras do jogo\n");
            Console.ReadKey();
            Console.WriteLine("Cada jogador será representado por uma letra.\nExemplo: Se o 1º jogador escolher o número 1, ele será representado por: X \n\nO jogador 2 será representado por: O ");
            Console.WriteLine("\nO jogador 1 começará escolhendo 1 número entre 0 a 8.\nEm seguida será a vez do jogador 2.");
            Console.WriteLine("\nMODELO DO JOGO:\n\n\tColunas");
            Console.WriteLine("\t 1   2   3");
            Console.WriteLine("Linha 1 [ ] [ ] [ ]");
            Console.WriteLine("Linha 2 [ ] [ ] [ ]");
            Console.WriteLine("Linha 3 [ ] [ ] [ ]");
        }
        static void ImprimirJogo(string[,] matrizJogo) //imprime a matriz como modelo para jogar
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" [{matrizJogo[i, j]}] ");
                }
                Console.WriteLine();
            }
        }
        static string JogadorEscolhe()
        {
            string escolha; //jogador escolhe se quer ser X ou O
            do
            {
                Console.Write("\n1º jogador escolha 1 ou 2:  ");
                escolha = Console.ReadLine();

                if (escolha != "1" && escolha != "2")
                {
                    Console.WriteLine("\nCOMANDO INVÁLIDO! TENTE NOVAMENTE!");
                }

            } while (escolha != "1" && escolha != "2");
            if (escolha == "1")
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }
        static string Jogador2Escolhe(string jogador1)
        {
            if (jogador1 == "X")
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }
        static void ModeloMatriz(string[,] matrizJogo)
        {
            int cont = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) //i linha e j coluna
                {
                    matrizJogo[i, j] = cont.ToString();
                    cont++;
                }
            }
            //imprimir a matriz
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" [{matrizJogo[i, j]}] ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        static void Jogador1Joga(string[,] matrizJogo, string jogador1)
        {
            
            int jogada = -1;

            do
            {
                Console.WriteLine("Informe sua jogada jogador 1");
                try
                {
                    jogada = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Opção inválida!");
                }
                if (jogada < 0 || jogada > 8)
                {
                    Console.WriteLine("Insira um número de 0 a 8");
                }

            } while (jogada < 0 || jogada > 8);

            //insere o valor do jogador 1
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrizJogo[i, j] == jogada.ToString())
                    {
                        matrizJogo[i, j] = jogador1;
                    }
                }
            }

        }
        static bool CondicaoVitoria(string[,] matrizJogo, string jogador)
        {
            //condicoes de vitorias horizontal - vertical - diagonal - PARA JOGADOR 
            if (matrizJogo[0, 0] == matrizJogo[0, 1] && matrizJogo[0, 1] == matrizJogo[0, 2] && matrizJogo[0, 0] == jogador ||
                 matrizJogo[1, 0] == matrizJogo[1, 1] && matrizJogo[1, 1] == matrizJogo[1, 2] && matrizJogo[1, 0] == jogador ||
                 matrizJogo[2, 0] == matrizJogo[2, 1] && matrizJogo[2, 1] == matrizJogo[2, 2] && matrizJogo[2, 0] == jogador ||
                 matrizJogo[0, 0] == matrizJogo[1, 0] && matrizJogo[1, 0] == matrizJogo[2, 0] && matrizJogo[0, 0] == jogador ||
                 matrizJogo[0, 1] == matrizJogo[1, 1] && matrizJogo[1, 1] == matrizJogo[2, 1] && matrizJogo[0, 1] == jogador ||
                 matrizJogo[0, 2] == matrizJogo[1, 2] && matrizJogo[1, 2] == matrizJogo[2, 2] && matrizJogo[0, 2] == jogador ||
                 matrizJogo[0, 0] == matrizJogo[1, 1] && matrizJogo[1, 1] == matrizJogo[2, 2] && matrizJogo[0, 0] == jogador ||
                 matrizJogo[2, 0] == matrizJogo[1, 1] && matrizJogo[1, 1] == matrizJogo[0, 2] && matrizJogo[2, 0] == jogador)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n>>>>> O ganhador foi o jogador: {jogador} <<<<<");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                return false;
            }
            

        }
        static void Jogador2joga(string[,] matrizJogo, string jogador2)
        {
            int jogada = -1;
            do
            {
                Console.WriteLine("Informe sua jogada jogador 2");
                try
                {
                    jogada = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Opção inválida!");
                }
                if (jogada < 0 || jogada > 8)
                {
                    Console.WriteLine("Insira um número de 0 a 8");
                }
            } while (jogada < 0 || jogada > 8);

            for (int i = 0; i < 3; i++) //insere jogada jogador2
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrizJogo[i, j] == jogada.ToString())
                    {
                        matrizJogo[i, j] = jogador2;

                    }
                }
            }
        }

    }
}
