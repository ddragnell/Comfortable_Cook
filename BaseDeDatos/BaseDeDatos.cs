namespace BaseDeDatos
{
    using System.Data.Odbc;
    public class BaseDeDatos
    {
        public bool Autenticado(string correo)
        {
            OdbcCommand command = new OdbcCommand($@"SELECT id,correo,clave FROM Usuarios WHERE correo={correo};");
            using (OdbcConnection connection = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=C:\\Users\\Andres Felipe\\Documents\\Comfortable_cook.accdb; Uid = Admin; Pwd =123; "))
            {
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var person = reader.GetString(0);
                    }
                };
            }
            return false;
        }

    }
}