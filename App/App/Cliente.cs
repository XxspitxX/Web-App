using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Web.UI.WebControls;

public class Cliente : Conexion
{
    public long IdCliente;
    public string NombreCliente;
    public string DireccionCliente;
    public string TelefonoCliente;

    public Cliente()
    {

    }
    public Cliente(long IdCliente)
    {
        IdCliente = IdCliente;
    }

    public int insertarCliente()
    {
        int valor = 1;
        try
        {
            conexion.Close();

            SqlCommand proin = new SqlCommand();
            Conectar();
            proin.Connection = conexion;
            proin.CommandType = System.Data.CommandType.StoredProcedure;
            proin.CommandText = "insertarCliente";
            proin.Parameters.AddWithValue("@IdCliente", IdCliente);
            proin.Parameters.AddWithValue("@NombreCliente", NombreCliente);
            proin.Parameters.AddWithValue("@DireccionCliente", DireccionCliente);
            proin.Parameters.AddWithValue("@TelefonoCliente", TelefonoCliente);

            SqlDataReader reader = proin.ExecuteReader();
            reader.Close();
            conexion.Close();


        }
        catch (SqlException)
        {
            valor = 0;
        }
        return valor;
    }

    public int modificarCliente()
    {
        int valor = 1;
        try
        {
            conexion.Close();
            SqlCommand proin = new SqlCommand();
            Conectar();
            proin.Connection = conexion;
            proin.CommandType = System.Data.CommandType.StoredProcedure;
            proin.CommandText = "actualizarCliente";
            proin.Parameters.AddWithValue("@IdCliente", IdCliente);
            proin.Parameters.AddWithValue("@NombreCliente", NombreCliente);
            proin.Parameters.AddWithValue("@DireccionCliente", DireccionCliente);
            proin.Parameters.AddWithValue("@TelefonoCliente", TelefonoCliente);

            SqlDataReader reader = proin.ExecuteReader();
            reader.Close();
            conexion.Close();

        }
        catch (SqlException)
        {
            valor = 0;
        }
        return valor;

    }

    public int eliminarCliente()
    {
        int valor = 1;
        try
        {
            conexion.Close();
            SqlCommand proin = new SqlCommand();
            Conectar();
            proin.Connection = conexion;
            proin.CommandType = System.Data.CommandType.StoredProcedure;
            proin.CommandText = "eliminarCliente";
            proin.Parameters.AddWithValue("@IdCliente", IdCliente);
            SqlDataReader reader = proin.ExecuteReader();
            reader.Close();
            conexion.Close();
        }
        catch
        {

        }
        return valor;
    }

    public int consultarCliente(ref TextBox Nombre, ref TextBox Direccion, ref TextBox Telefono)

    {           
            int valor = 1;

            try
            {
                conexion.Close();
                DataTable dt = new DataTable();
                SqlCommand proin = new SqlCommand();
                Conectar();
                proin.Connection = conexion;
                proin.CommandType = System.Data.CommandType.StoredProcedure;
                proin.CommandText = "consultarCliente";
                proin.Parameters.AddWithValue("@IdCliente", IdCliente);
                SqlDataReader reader = proin.ExecuteReader();
                reader.Close();
                SqlDataAdapter ad = new SqlDataAdapter(proin);
                ad.Fill(dt);
                conexion.Close();
                if (dt.Rows.Count > 0 )
                {
                    foreach (DataRow filas in dt.Rows)
                    {
                        Nombre.Text = filas["NombreCliente"].ToString();
                        Direccion.Text = filas["DireccionCliente"].ToString();
                        Telefono.Text = filas["TelefonoCliente"].ToString();
                    }
                }
                else
                {

                }

                reader.Close();
                conexion.Close();
            }
            catch (SqlException)
            {
            }
            return valor;                    
        
    }

}

