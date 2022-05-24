using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using COMFORTABLE_COOK.Models;

namespace COMFORTABLE_COOK
{
    public class BaseDeDatos
    {
        public Usuario Autenticado(string correo, string clave)
        {
            OdbcCommand command = new OdbcCommand($@"SELECT * FROM Usuarios WHERE correo='{correo}' AND clave='{clave}';");
            
            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        var _id = reader.GetValue(0);
                        if (_id != null && Convert.ToInt32(_id) > 0)
                        {
                            return new Usuario()
                            {
                                IdUsuario = reader.GetInt32(0),
                                Correo = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool GuardarUsuario(string correo, string clave)
        {
            OdbcCommand command = new OdbcCommand($@"INSERT INTO Usuarios (correo,clave) VALUES ('{correo}','{clave}');");

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }

        public bool GuardarReceta(string nombre, string descripcion, int idUsuario)
        {
            OdbcCommand command = new OdbcCommand($@"INSERT INTO Recetas (Nombre, Descripcion,Idusuario) 
            VALUES ('{nombre}','{descripcion}',{idUsuario});");

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }

        public bool EditarReceta(string nombre, string descripcion, int idReceta)
        {
            OdbcCommand command = new OdbcCommand($@"UPDATE Recetas 
            SET Nombre='{nombre}', Descripcion='{descripcion}' WHERE Id={idReceta};");

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }

        public bool EliminarReceta(int idReceta)
        {
            OdbcCommand command = new OdbcCommand($@"DELETE FROM Recetas WHERE Id={idReceta};");

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }

        public List<Receta> ConsultarRecetas(int idUsuario)
        {
            OdbcCommand command = new OdbcCommand($@"SELECT Id, Nombre, Descripcion, Idusuario FROM Recetas WHERE Idusuario={idUsuario};");
            List<Receta> recetas = new List<Receta>();

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        Receta receta = new Receta
                        {
                            IdReceta = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            IdUsuario = reader.GetInt32(3)
                        };

                        recetas.Add(receta);

                    }
                    else {
                        return new List<Receta>();
                    }
                }
            }
            return recetas;
        }

        public Receta ConsultarRecetaPorId(int idReceta)
        {
            OdbcCommand command = new OdbcCommand($@"SELECT Id, Nombre, Descripcion, Idusuario FROM Recetas WHERE Id={idReceta};");
            
            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        Receta receta = new Receta
                        {
                            IdReceta = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            IdUsuario = reader.GetInt32(3)
                        };

                        return receta;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public List<Receta> ConsultarRecetasFavoritas(int idUsuario)
        {
            OdbcCommand command = new OdbcCommand($@"SELECT Id, Nombre, Descripcion, Idusuario FROM Recetas WHERE Idusuario={idUsuario} AND esFavorito={true};");
            List<Receta> recetasfav = new List<Receta>();

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        Receta receta = new Receta
                        {
                            IdReceta = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            IdUsuario = reader.GetInt32(3)
                        };

                        recetasfav.Add(receta);

                    }
                    else
                    {
                        return new List<Receta>();
                    }
                }
            }
            return recetasfav;
        }

        public bool MarcarFavorito(int idReceta)
        {
            OdbcCommand command = new OdbcCommand($@"UPDATE Recetas SET esFavorito={true} WHERE Id={idReceta};");

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }

        public bool EliminarFavorito(int idReceta)
        {
            bool estado= false;
            OdbcCommand command = new OdbcCommand($@"UPDATE Recetas SET esFavorito={estado} WHERE Id={idReceta};");

            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd = 123; "))
            {
                command.Connection = connection;
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }


    }

}