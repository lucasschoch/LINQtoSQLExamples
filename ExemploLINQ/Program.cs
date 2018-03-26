using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //SelecSimplesUm();
            //SelectSimplesDois();
            //Orderby();
            //Where();
            //Count();
            //InnerJoin();
            //LeftJoin();
            //RightJoin();
            //FullJoin();
        }

        private static void FullJoin()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var full = from pessoas in ctx.Pessoas
                           join alunos in ctx.Alunos
                           on pessoas.ID equals alunos.IdPessoa
                           into j1
                           from alunosFull in j1.DefaultIfEmpty()
                           select new
                           {
                               ID = pessoas.ID != null ? pessoas.ID : alunosFull.IdPessoa,
                               Nome = pessoas.PrimeiroNome != null ? pessoas.PrimeiroNome : string.Empty,
                               Cargo = alunosFull.Cargo != null ? alunosFull.Cargo : string.Empty
                               //pode adicionar todas as propriedades aqui, seguindo a mesma lógica
                           };

                foreach (var item in full)
                {
                    Console.WriteLine("Primeiro Nome: {0} - ID: {1} = Cargo: {2}."
                                      , item.Nome
                                      , item.ID
                                      , item.Cargo);
                }
            }
            Console.ReadLine();
        }

        private static void RightJoin()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var right = from a in ctx.Alunos
                           join p in ctx.Pessoas on a.IdPessoa equals p.ID into j1
                           from j2 in j1.DefaultIfEmpty()
                           select new { IdPessoa = a.IdPessoa, Nome = j2.PrimeiroNome, Cargo = a.Cargo };

                foreach (var item in right)
                {
                    Console.WriteLine("Primeiro Nome: {0} - ID: {1} = Cargo: {2}."
                                      , item.Nome
                                      , item.IdPessoa
                                      , item.Cargo);
                }
            }
            Console.ReadLine();
        }

        private static void LeftJoin()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var left = from p in ctx.Pessoas
                            join a in ctx.Alunos on p.ID equals a.IdPessoa into j1
                            from j2 in j1.DefaultIfEmpty()
                            select new { IdPessoa = p.ID, Nome = p.PrimeiroNome, Cargo = j2.Cargo };

                foreach (var item in left)
                {
                    Console.WriteLine("Primeiro Nome: {0} - ID: {1} = Cargo: {2}."
                                      , item.Nome
                                      , item.IdPessoa
                                      , item.Cargo);
                }
            }
            Console.ReadLine();
        }

        private static void InnerJoin()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var inner = from p in ctx.Pessoas
                            join a in ctx.Alunos
                            on p.ID equals a.IdPessoa
                            select new
                            {
                                p.PrimeiroNome,
                                p.UltimoNome,
                                a.Cargo,
                                a.Empresa
                            };

                foreach (var item in inner)
                {
                    Console.WriteLine("Primeiro Nome: {0} - Ultimo Nome: {1} = Cargo: {2} - Empresa: {3}."
                                      , item.PrimeiroNome
                                      , item.UltimoNome
                                      , item.Cargo
                                      , item.Empresa);
                }
            }
            Console.ReadLine();
        }

        private static void Count()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                string parametro = "Lucas";
                var total = (from p in ctx.Pessoas
                             where p.PrimeiroNome == parametro
                             select p).Count();

                Console.WriteLine("A quantidade de pessoas chamadas {0} em nosso banco de dados é: {1}."
                                  , parametro
                                  , total);
            }
            Console.ReadLine();
        }

        private static void Where()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var ordenados = from p in ctx.Pessoas
                                where p.UltimoNome == "Schoch" || p.PrimeiroNome == "Arã"
                                orderby p.PrimeiroNome
                                select p;
                foreach (var item in ordenados)
                {
                    Console.WriteLine("Primeiro Nome: {0} - Endereço: {1}"
                                      , item.PrimeiroNome
                                      , item.Endereco);
                }
            }
            Console.ReadLine();
        }

        private static void Orderby()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var ordenados = from p in ctx.Pessoas
                                orderby p.PrimeiroNome
                                select p;
                foreach (var item in ordenados)
                {
                    Console.WriteLine("Primeiro Nome: {0} - Endereço: {1}"
                                      , item.PrimeiroNome
                                      , item.Endereco);
                }
            }
            Console.ReadLine();
        }

        private static void SelectSimplesDois()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var retorno = from p in ctx.Pessoas
                              select new { p.PrimeiroNome, p.UltimoNome };

                foreach (var item in retorno)
                {
                    Console.WriteLine("Primeiro Nome: {0} - Segundo Nome: {1}"
                                      , item.PrimeiroNome
                                      , item.UltimoNome);
                }
            }
            Console.ReadLine();
        }

        private static void SelecSimplesUm()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var retorno = from p in ctx.Pessoas
                              select p;

                foreach (var item in retorno)
                {
                    Console.WriteLine("Primeiro Nome: {0} - Segundo Nome: {1}"
                                      , item.PrimeiroNome
                                      , item.UltimoNome);
                }
            }
            Console.ReadLine();
        }
    }
}
