using Microsoft.EntityFrameworkCore;
using PrimerParcial.DAL.Scripts;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrimerParcial.BLL
{
     public class ProductosBLL
    {
        
            public static bool Guardar(Productos Producto)
            {
                bool paso = false;
                Context db = new Context();
                try
                {
                    if (db.Productos.Add(Producto) != null)
                        paso = db.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }

                return paso;
            }
            public static bool Modificar(Productos Producto)
            {

                bool paso = false;
                Context db = new Context();

                try
                {

                    db.Entry(Producto).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
                return paso;
            }

            public static bool Eliminar(int id)
            {
                bool paso = false;
                Context db = new Context();

                try
                {
                    var eliminar = db.Productos.Find(id);
                    db.Entry(eliminar).State = EntityState.Deleted;

                    paso = (db.SaveChanges() > 0);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {

                    db.Dispose();
                }
                return paso;
            }
            public static Productos Buscar(int id)
            {
                Productos Producto = new Productos();
                Context db = new Context();
               
                try
                {
                    Producto = db.Productos.Find(id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
                return Producto;

            }

            public static List<Productos> GetList(Expression<Func<Productos, bool>> Producto)
            {
                List<Productos> Lista = new List<Productos>();
                Context db = new Context();
                try
                {
                    Lista = db.Productos.Where(Producto).ToList();
                }
                catch (Exception)
                {
                    throw;
                }

                finally
                {
                    db.Dispose();
                }
                return Lista;

            }

        }

    }



