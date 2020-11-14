using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaModelo
{
    public class DProducto
    {
        private int _IdProducto;
        private string _Nombre;
        private int _Precio;
        private string _Tipo;

        public int IdProducto
        {
            get => _IdProducto;
            set => _IdProducto = value;
        }
        public string Nombre
        {
            get => _Nombre;
            set => _Nombre = value;
        }
        public int Precio
        {
            get => _Precio;
            set => _Precio = value;
        }
        public string Tipo
        {
            get => _Tipo;
            set => _Tipo = value;
        }

        public DProducto() { }

        public DProducto(int idproducto, string nombre, float precio, string tipo) 
        {
            this._IdProducto = idproducto;
            this._Nombre = nombre;
            this._Precio = precio;
            this._Tipo = tipo;
        }

        public string Insertar(DProducto producto)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TablaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = @idproducto;
                parIdProducto.SqlDbType = SqlDbType.Int;
                parIdProducto.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdProducto);
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = @nombre;
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = producto.Nombre;
                cmd.Parameters.Add(parNombre);
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = @nombre;
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = producto.Nombre;
                cmd.Parameters.Add(parNombre);
                SqlParameter parPrecio = new SqlParameter();
                parPrecio.ParameterName = @precio;
                parPrecio.SqlDbType = SqlDbType.Int;
                parPrecio.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parPrecio);
                SqlParameter parTipo = new SqlParameter();
                parTipo.ParameterName = @tipo;
                parTipo.SqlDbType = SqlDbType.VarChar;
                parTipo.Size = 50;
                parTipo.Value = producto.Tipo;
                cmd.Parameters.Add(parTipo);
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se realizó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if(SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }
            return rpta;
        }

        public string Modificar (DProducto producto)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TablaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = @idproducto;
                parIdProducto.SqlDbType = SqlDbType.Int;
                parIdProducto.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdProducto);
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = @nombre;
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = producto.Nombre;
                cmd.Parameters.Add(parNombre);
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = @nombre;
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = producto.Nombre;
                cmd.Parameters.Add(parNombre);
                SqlParameter parPrecio = new SqlParameter();
                parPrecio.ParameterName = @precio;
                parPrecio.SqlDbType = SqlDbType.Int;
                parPrecio.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parPrecio);
                SqlParameter parTipo = new SqlParameter();
                parTipo.ParameterName = @tipo;
                parTipo.SqlDbType = SqlDbType.VarChar;
                parTipo.Size = 50;
                parTipo.Value = producto.Tipo;
                cmd.Parameters.Add(parTipo);
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "Producto no fue modificado";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }
            return rpta;
        }

        public string Eliminar (DProducto producto)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TablaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = "@idproducto";
                parIdProducto.SqlDbType = SqlDbType.Int;
                parIdProducto.Value = producto.IdProducto;
                cmd.Parameters.Add(parIdProducto);
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }
            return rpta;
        }

        public DataTable Consultar()
        {
            DataTable DtResultado = new DataTable("tblProducto");
            SqlConnection SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_C_TablaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dat = new SqlDataAdapter(cmd);
                Dat.Fill(DtResultado);
            }
            catch
            {
                DtResultado = null;
            }
            return DtResultado;
        }

    }
}