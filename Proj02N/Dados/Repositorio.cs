using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Proj02N.Models;
using System.Data.Entity;

namespace Proj02N.Dados
{
    public class Repositorio
    {
        public static IEnumerable<Clientes> ListarClientes()
        {
            using (var ctx = new CursoAspEntities())
            {
                return ctx.Clientes.ToList();
            }
        }

        public static Clientes BuscarCliente(int Codigo)
        {
            using (var ctx = new CursoAspEntities())
            {
                return ctx.Clientes.FirstOrDefault(p =>
                                  p.Codigo.Equals(Codigo));
            }
        }

        public static void NovoCliente(Clientes Novo)
        {
            using (var ctx = new CursoAspEntities())
            {
                ctx.Clientes.Add(Novo);
                ctx.SaveChanges();
            }
        }

        public static void AlterarCliente(Clientes Alterado)
        {
            using (var ctx = new CursoAspEntities())
            {
                ctx.Entry<Clientes>(Alterado).State =
                                        EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static IEnumerable<Pedidos> ListarPedidos(int CodCliente)
        {
            using (var ctx = new CursoAspEntities())
            {
                var Pesquisa = (from A in ctx.Pedidos
                                where A.CodCliente == CodCliente
                                select A).ToList();

                return Pesquisa;
            }
        }

        public static void NovoPedido(Pedidos Novo)
        {
            using (var ctx = new CursoAspEntities())
            {
                ctx.Pedidos.Add(Novo);
                ctx.SaveChanges();
            }
        }

        public static void ApagarPedido(Pedidos Apagado)
        {
            using (var ctx = new CursoAspEntities())
            {
                ctx.Entry<Pedidos>(Apagado).State =
                                        EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

    }
}