using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace atividade_2_camila_e_ana_laura
{
    internal class Program
    {
        public static class variaveis
        {
            public static string nome, CPF, ctt, alergia, obs, diagnostico, status, numeroquarto, tipo, nomemedico, crm, especialidade, telefone, tiposangue;
            public static int idCliente, pacienteld, medicoresponsavel, leitold, idleito, medicoresponsavelld, idmedico;
            public static DateTime? dataalta {get; set; }
            public static DateTime dataentrada {get; set; }
            public static DateTime Nasci { get; set; }
            public static bool EstaOcupado;
        }
        //Modelar a estrutura de dados e fluxos de controle de um ambiente hospitalar, praticando encapsulamento, listas ligadas/referências simples por ID, manipulate de tipos DateTime para controle de permanência e tratamento de estados de leitos (Livre / Ocupado).
        static void Main(string[] args)
        {
            int opcao = 8;
            while (opcao != 0)
            {
                Console.Clear(); // limpa a tela
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
░██████╗██╗░██████╗████████╗███████╗███╗░░░███╗░█████╗░  ██████╗░███████╗
██╔════╝██║██╔════╝╚══██╔══╝██╔════╝████╗░████║██╔══██╗  ██╔══██╗██╔════╝
╚█████╗░██║╚█████╗░░░░██║░░░█████╗░░██╔████╔██║███████║  ██║░░██║█████╗░░
░╚═══██╗██║░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║██╔══██║  ██║░░██║██╔══╝░░
██████╔╝██║██████╔╝░░░██║░░░███████╗██║░╚═╝░██║██║░░██║  ██████╔╝███████╗
╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝  ╚═════╝░╚══════╝

██╗███╗░░██╗████████╗███████╗██████╗░███╗░░██╗░█████╗░░█████╗░░█████╗░░█████╗░
██║████╗░██║╚══██╔══╝██╔════╝██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗
██║██╔██╗██║░░░██║░░░█████╗░░██████╔╝██╔██╗██║███████║██║░░╚═╝███████║██║░░██║
██║██║╚████║░░░██║░░░██╔══╝░░██╔══██╗██║╚████║██╔══██║██║░░██╗██╔══██║██║░░██║
██║██║░╚███║░░░██║░░░███████╗██║░░██║██║░╚███║██║░░██║╚█████╔╝██║░░██║╚█████╔╝
╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░

██╗░░██╗░█████╗░░██████╗██████╗░██╗████████╗░█████╗░██╗░░░░░░█████╗░██████╗░
██║░░██║██╔══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║░░░░░██╔══██╗██╔══██╗
███████║██║░░██║╚█████╗░██████╔╝██║░░░██║░░░███████║██║░░░░░███████║██████╔╝
██╔══██║██║░░██║░╚═══██╗██╔═══╝░██║░░░██║░░░██╔══██║██║░░░░░██╔══██║██╔══██╗
██║░░██║╚█████╔╝██████╔╝██║░░░░░██║░░░██║░░░██║░░██║███████╗██║░░██║██║░░██║
╚═╝░░╚═╝░╚════╝░╚═════╝░╚═╝░░░░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1 - Cadastrar Paciente");
                Console.WriteLine("2 - Cadastrar Médico");
                Console.WriteLine("3 - Cadastrar Leito");
                Console.WriteLine("4 - Registrar Internação (Admissão)");
                Console.WriteLine("5 - Dar Alta Hospitalar");
                Console.WriteLine("6 - Listar Pacientes Internados");
                Console.WriteLine("7 - Exibir Relatório Geral do Hospital");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        funcao_paciente();
                        break;
                    case 2:
                        funcao_medico();
                        break;
                    case 3:
                        Leito();
                        break;
                    case 4:
                        internacao();
                        break;
                    case 5:
                        alta();
                        break;
                    case 6:
                        listar_pacientes();
                        break;
                    case 7:
                        exibir_relatorio();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine(" Saindo do programa");
                        break;
                }
            }

        }
        static void funcao_paciente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
███████╗██╗░░░██╗███╗░░██╗░█████╗░░█████╗░░█████╗░  ██████╗░░█████╗░░█████╗░██╗███████╗███╗░░██╗████████╗███████╗
██╔════╝██║░░░██║████╗░██║██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗██╔══██╗██╔══██╗██║██╔════╝████╗░██║╚══██╔══╝██╔════╝
█████╗░░██║░░░██║██╔██╗██║██║░░╚═╝███████║██║░░██║  ██████╔╝███████║██║░░╚═╝██║█████╗░░██╔██╗██║░░░██║░░░█████╗░░
██╔══╝░░██║░░░██║██║╚████║██║░░██╗██╔══██║██║░░██║  ██╔═══╝░██╔══██║██║░░██╗██║██╔══╝░░██║╚████║░░░██║░░░██╔══╝░░
██║░░░░░╚██████╔╝██║░╚███║╚█████╔╝██║░░██║╚█████╔╝  ██║░░░░░██║░░██║╚█████╔╝██║███████╗██║░╚███║░░░██║░░░███████╗
╚═╝░░░░░░╚═════╝░╚═╝░░╚══╝░╚════╝░╚═╝░░╚═╝░╚════╝░  ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝");
            
            Console.WriteLine("Nome completo do paciente: ");
            variaveis.nome = Console.ReadLine();

            Console.WriteLine("Registro do paciente: ");
            variaveis.CPF = Console.ReadLine();

            Console.WriteLine("Identificador único: ");
            variaveis.idCliente = int.Parse(Console.ReadLine());

            
            Console.Write("Data de nascimento: ");
            {
                Console.Write("Data inválida! Digite novamente: ");
            }
            Console.Write("Tipo sanguíneo: ");
            variaveis.tiposangue = Console.ReadLine();

            Console.Write("Possui alguma alergia? ");
            variaveis.alergia = Console.ReadLine();

            Console.Write("Telefone: ");
            variaveis.ctt = Console.ReadLine();

            Console.WriteLine("\n Cadastro realizado com sucesso");
            Console.WriteLine("Data de nascimento: " + variaveis.Nasci.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tipo sanguíneo: " + variaveis.tiposangue);
            Console.WriteLine("Alergia: " + variaveis.alergia);
            Console.WriteLine("Contato: " + variaveis.ctt);
            Thread.Sleep(3000);
        }
        static void funcao_medico()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
███████╗██╗░░░██╗███╗░░██╗░█████╗░░█████╗░░█████╗░  ███╗░░░███╗███████╗██████╗░██╗░█████╗░░█████╗░
██╔════╝██║░░░██║████╗░██║██╔══██╗██╔══██╗██╔══██╗  ████╗░████║██╔════╝██╔══██╗██║██╔══██╗██╔══██╗
█████╗░░██║░░░██║██╔██╗██║██║░░╚═╝███████║██║░░██║  ██╔████╔██║█████╗░░██║░░██║██║██║░░╚═╝██║░░██║
██╔══╝░░██║░░░██║██║╚████║██║░░██╗██╔══██║██║░░██║  ██║╚██╔╝██║██╔══╝░░██║░░██║██║██║░░██╗██║░░██║
██║░░░░░╚██████╔╝██║░╚███║╚█████╔╝██║░░██║╚█████╔╝  ██║░╚═╝░██║███████╗██████╔╝██║╚█████╔╝╚█████╔╝
╚═╝░░░░░░╚═════╝░╚═╝░░╚══╝░╚════╝░╚═╝░░╚═╝░╚════╝░  ╚═╝░░░░░╚═╝╚══════╝╚═════╝░╚═╝░╚════╝░░╚════╝░");
           
            Console.WriteLine(" Identificador único");
            variaveis.idmedico = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome do profissional: ");
            variaveis.nomemedico = Console.ReadLine();
            Console.WriteLine("Registro do Conselho Regional de Medicina: ");
            variaveis.crm = Console.ReadLine();
            Console.WriteLine("especialidade: ");
            variaveis.especialidade = Console.ReadLine();
            Console.WriteLine("Telefone de contato rápido: ");
            variaveis.telefone = Console.ReadLine();
            Console.WriteLine("\n Cadastro realizado com sucesso");
            Console.WriteLine("Identificação " + variaveis.idmedico);
            Console.WriteLine("Nome Profissional " + variaveis.nomemedico);
            Console.WriteLine("Registro " + variaveis.crm);
            Console.WriteLine("Contato: " + variaveis.telefone);
            Console.WriteLine("Especialidade: " + variaveis.especialidade);
            Thread.Sleep(3000);
        }
        static void Leito()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
██╗░░░░░███████╗██╗████████╗░█████╗░
██║░░░░░██╔════╝██║╚══██╔══╝██╔══██╗
██║░░░░░█████╗░░██║░░░██║░░░██║░░██║
██║░░░░░██╔══╝░░██║░░░██║░░░██║░░██║
███████╗███████╗██║░░░██║░░░╚█████╔╝
╚══════╝╚══════╝╚═╝░░░╚═╝░░░░╚════╝░");


            Console.WriteLine(" Identificador único");
            variaveis.idleito = int.Parse(Console.ReadLine());
            Console.WriteLine("Número ou código do quarto/ala: ");
            variaveis.numeroquarto = Console.ReadLine();
            Console.WriteLine("Ex: Enfermaria, Apartamento, UTI: ");
            variaveis.tipo = Console.ReadLine();
            Console.Write("Está ocupado?: ");
            variaveis.EstaOcupado = bool.Parse(Console.ReadLine());
            Thread.Sleep(3000);
        }
        static void internacao()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
██╗███╗░░██╗████████╗███████╗██████╗░███╗░░██╗░█████╗░░█████╗░░█████╗░░█████╗░
██║████╗░██║╚══██╔══╝██╔════╝██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗
██║██╔██╗██║░░░██║░░░█████╗░░██████╔╝██╔██╗██║███████║██║░░╚═╝███████║██║░░██║
██║██║╚████║░░░██║░░░██╔══╝░░██╔══██╗██║╚████║██╔══██║██║░░██╗██╔══██║██║░░██║
██║██║░╚███║░░░██║░░░███████╗██║░░██║██║░╚███║██║░░██║╚█████╔╝██║░░██║╚█████╔╝
╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░");
            
            Console.Write("Código do registro de internação: ");
            variaveis.idCliente = int.Parse(Console.ReadLine());

            Console.Write("Código do paciente: ");
            variaveis.pacienteld = int.Parse(Console.ReadLine());

            Console.Write("Código do médico responsável: ");
            variaveis.medicoresponsavelld = int.Parse(Console.ReadLine());

            Console.Write("Código do leito alocado: ");
            variaveis.leitold = int.Parse(Console.ReadLine());

            Console.Write("Data e hora da entrada (dd/MM/yyyy HH:mm): ");
            variaveis.dataentrada = DateTime.Parse(Console.ReadLine());

            Console.Write("Data e hora da alta (deixe vazio se ainda estiver internado): ");
            string entradaAlta = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entradaAlta))
            {
                variaveis.dataalta = null;
            }
            else
            {
                variaveis.dataalta = DateTime.Parse(entradaAlta);
            }
            Console.Write("Diagnóstico/motivo da entrada: ");
            variaveis.diagnostico = Console.ReadLine();

            Console.Write("Status (Em Internação / Alta Concluída / Transferido): ");
            variaveis.status = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Internação cadastrada com sucesso!");

            Console.WriteLine();
            Console.WriteLine(" DADOS DA INTERNAÇÃO ");
            Console.WriteLine("ID: " + variaveis.idCliente);
            Console.WriteLine("Paciente: " + variaveis.pacienteld);
            Console.WriteLine("Médico responsável: " + variaveis.medicoresponsavel);
            Console.WriteLine("Leito: " + variaveis.leitold);
            Console.WriteLine("Data de entrada: " + variaveis.dataentrada.ToString("dd/MM/yyyy HH:mm"));
            
            if (variaveis.dataalta.HasValue) 
            {
                Console.WriteLine("Data de alta: " + variaveis.dataalta.Value.ToString("dd/MM/yyyy HH:mm"));
            }
            else
            {
                Console.WriteLine("Data de alta: Ainda internado");
            }

            Console.WriteLine("Diagnóstico: " + variaveis.diagnostico);
            Console.WriteLine("Status: " + variaveis.status);

            Console.ResetColor();
            Thread.Sleep(3000);
        }
        static void alta()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"

░█████╗░██╗░░░░░████████╗░█████╗░  ██╗░░██╗░█████╗░░██████╗██████╗░██╗████████╗░█████╗░██╗░░░░░░█████╗░██████╗░
██╔══██╗██║░░░░░╚══██╔══╝██╔══██╗  ██║░░██║██╔══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║░░░░░██╔══██╗██╔══██╗
███████║██║░░░░░░░░██║░░░███████║  ███████║██║░░██║╚█████╗░██████╔╝██║░░░██║░░░███████║██║░░░░░███████║██████╔╝
██╔══██║██║░░░░░░░░██║░░░██╔══██║  ██╔══██║██║░░██║░╚═══██╗██╔═══╝░██║░░░██║░░░██╔══██║██║░░░░░██╔══██║██╔══██╗
██║░░██║███████╗░░░██║░░░██║░░██║  ██║░░██║╚█████╔╝██████╔╝██║░░░░░██║░░░██║░░░██║░░██║███████╗██║░░██║██║░░██║
╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚═╝░░╚═╝  ╚═╝░░╚═╝░╚════╝░╚═════╝░╚═╝░░░░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝");
Console.ResetColor();
            Console.WriteLine("Digite o identificador único: ");
            variaveis.idCliente= int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o seu nome: ");
            variaveis.nome = Console.ReadLine();
            Console.WriteLine("Digite o seu CPF: ");
variaveis.CPF = Console.ReadLine();
            Console.WriteLine("DIgite o número do seu celular: ");
variaveis.ctt = Console.ReadLine();
            Console.WriteLine("Escreva a data de seu aniversário: ");
variaveis.Nasci = DateTime.Parse(Console.ReadLine()); 
            Console.WriteLine("Possui alguma alergia?: ");
variaveis.alergia = Console.ReadLine();
            Console.WriteLine("Observações: ");
variaveis.obs = Console.ReadLine();
            Console.WriteLine("\nCLiente cadastrado com sucesso");
            Console.WriteLine("\n + " + variaveis.idCliente);
            Console.WriteLine("\n + " + variaveis.nome);
            Console.WriteLine("\n + " + variaveis.CPF);
            Console.WriteLine("\n + " + variaveis.ctt);
            Console.WriteLine("\n + " + variaveis.Nasci);
            Console.WriteLine("\n + " + variaveis.alergia);
            Console.WriteLine("\n + " + variaveis.obs);
            Thread.Sleep(3000);
        }
        static void listar_pacientes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
██╗░░░░░██╗░██████╗████████╗░█████╗░██████╗░
██║░░░░░██║██╔════╝╚══██╔══╝██╔══██╗██╔══██╗
██║░░░░░██║╚█████╗░░░░██║░░░███████║██████╔╝
██║░░░░░██║░╚═══██╗░░░██║░░░██╔══██║██╔══██╗
███████╗██║██████╔╝░░░██║░░░██║░░██║██║░░██║
╚══════╝╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝

██████╗░░█████╗░░█████╗░██╗███████╗███╗░░██╗████████╗███████╗░██████╗
██╔══██╗██╔══██╗██╔══██╗██║██╔════╝████╗░██║╚══██╔══╝██╔════╝██╔════╝
██████╔╝███████║██║░░╚═╝██║█████╗░░██╔██╗██║░░░██║░░░█████╗░░╚█████╗░
██╔═══╝░██╔══██║██║░░██╗██║██╔══╝░░██║╚████║░░░██║░░░██╔══╝░░░╚═══██╗
██║░░░░░██║░░██║╚█████╔╝██║███████╗██║░╚███║░░░██║░░░███████╗██████╔╝
╚═╝░░░░░╚═╝░░╚═╝░╚════╝░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═════╝░

");
            Console.WriteLine("Digite o identificador único: ");
            variaveis.idCliente = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o seu nome: ");
            variaveis.pacienteld = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Médico responsavel: ");
            variaveis.medicoresponsavel = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número do leito alocado: ");
            variaveis.leitold = int.Parse(Console.ReadLine());
            Console.WriteLine("Escreva a data de entrada: ");
            variaveis.dataentrada =DateTime.Parse (Console.ReadLine());
            Console.WriteLine("Data e hora da alta: ");
            variaveis.dataalta = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Diagnostico: ");
            variaveis.diagnostico = Console.ReadLine();
            Console.WriteLine("Status: ");
            variaveis.status = Console.ReadLine();
            Console.WriteLine("\nCLiente cadastrado com sucesso");
            Console.WriteLine("\n + " + variaveis.idCliente);
            Console.WriteLine("\n + " + variaveis.pacienteld);
            Console.WriteLine("\n + " + variaveis.medicoresponsavel);
            Console.WriteLine("\n + " + variaveis.leitold);
            Console.WriteLine("\n + " + variaveis.dataentrada);
            Console.WriteLine("\n + " + variaveis.dataalta);
            Console.WriteLine("\n + " + variaveis.diagnostico);
            Console.WriteLine("\n + " + variaveis.status);
            Thread.Sleep(3000);
        }
        static void exibir_relatorio()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
██████╗░███████╗██╗░░░░░░█████╗░████████╗░█████╗░██████╗░██╗░█████╗░  ░██████╗░███████╗██████╗░░█████╗░██╗░░░░░
██╔══██╗██╔════╝██║░░░░░██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗██║██╔══██╗  ██╔════╝░██╔════╝██╔══██╗██╔══██╗██║░░░░░
██████╔╝█████╗░░██║░░░░░███████║░░░██║░░░██║░░██║██████╔╝██║██║░░██║  ██║░░██╗░█████╗░░██████╔╝███████║██║░░░░░
██╔══██╗██╔══╝░░██║░░░░░██╔══██║░░░██║░░░██║░░██║██╔══██╗██║██║░░██║  ██║░░╚██╗██╔══╝░░██╔══██╗██╔══██║██║░░░░░
██║░░██║███████╗███████╗██║░░██║░░░██║░░░╚█████╔╝██║░░██║██║╚█████╔╝  ╚██████╔╝███████╗██║░░██║██║░░██║███████╗
╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝░╚════╝░  ░╚═════╝░╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝
");
            Console.ResetColor();
            Console.WriteLine("Relatório paciente");
            Console.WriteLine("Data de nascimento: " + variaveis.Nasci.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tipo sanguíneo: " + variaveis.tiposangue);
            Console.WriteLine("Alergia: " + variaveis.alergia);
            Console.WriteLine("Contato: " + variaveis.ctt);
            Console.WriteLine("Relatório cadastro médico");
            Console.WriteLine("Identificação " + variaveis.idmedico);
            Console.WriteLine("Nome Profissional " + variaveis.nomemedico);
            Console.WriteLine("Registro " + variaveis.crm);
            Console.WriteLine("Contato: " + variaveis.telefone);
            Console.WriteLine("Especialidade: " + variaveis.especialidade);
            Console.WriteLine(" DADOS DA INTERNAÇÃO ");
            Console.WriteLine("ID: " + variaveis.idCliente);
            Console.WriteLine("Paciente: " + variaveis.pacienteld);
            Console.WriteLine("Médico responsável: " + variaveis.medicoresponsavel);
            Console.WriteLine("Leito: " + variaveis.leitold);
            Console.WriteLine("Data de entrada: " + variaveis.dataentrada.ToString("dd/MM/yyyy HH:mm"));
            Console.WriteLine("\nAlta hospitalar");
            Console.WriteLine("\n + " + variaveis.idCliente);
            Console.WriteLine("\n + " + variaveis.nome);
            Console.WriteLine("\n + " + variaveis.CPF);
            Console.WriteLine("\n + " + variaveis.ctt);
            Console.WriteLine("\n + " + variaveis.Nasci);
            Console.WriteLine("\n + " + variaveis.alergia);
            Console.WriteLine("\n + " + variaveis.obs);
            Console.WriteLine("Listar pacientes");
            Console.WriteLine("\n + " + variaveis.idCliente);
            Console.WriteLine("\n + " + variaveis.pacienteld);
            Console.WriteLine("\n + " + variaveis.medicoresponsavel);
            Console.WriteLine("\n + " + variaveis.leitold);
            Console.WriteLine("\n + " + variaveis.dataentrada);
            Console.WriteLine("\n + " + variaveis.dataalta);
            Console.WriteLine("\n + " + variaveis.diagnostico);
            Console.WriteLine("\n + " + variaveis.status);
            Thread.Sleep(3000);
        }
    }
}
     


























