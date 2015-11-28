﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data;

namespace Logica
{
    public class Aeronave
    {

        public Int32 Id { get; set; }
        public String matricula { get; set; }
        public String modelo { get; set; }
        public String fabricante { get; set; }
        public DateTime fechaAlta { get; set; }
        public Int32 cantButacas { get; set; }
        public Int32 espacioKG { get; set; }
        //public Int32 idBaja { get; set; }
        //public DateTime fechaReinicio { get; set; }


        public TipoServicio tipoServicio { get; set; }



        public void Insertate(Int32 cantPasillo, Int32 cantVentanilla)
        {
            Aeronave.Insertar(this, cantPasillo, cantVentanilla);
        }

        public void Actualizate(Int32 cantPasillo, Int32 cantVentanilla)
        {
            Aeronave.Actualizar(this, cantPasillo, cantVentanilla);
        }

        public static int validarIngresos(String fabricante, String modelo, String matricula, String butacasPasillo, String butacasVentanilla, String espacioKG, Int32? idTipoServicio)
        {
            Int32 cantPasillo;
            Int32 cantVentanilla;
            Int32 cantKG;
            int mensaje = 0;

            if ((fabricante == "") || (modelo == "") || (matricula == "") || (butacasPasillo == "") || (butacasVentanilla == "") || (espacioKG == "") || (idTipoServicio == null))
            {
                //Algun campo esta vacio
                mensaje = 1;
            }
            else
            {
                try
                {
                    cantPasillo = Int32.Parse(butacasPasillo);
                    cantVentanilla = Int32.Parse(butacasVentanilla);
                    cantKG = Int32.Parse(espacioKG);
                }
                catch (Exception ex)
                {
                    //Algun campo numerico tiene un valor incorrecto
                    mensaje = 2;
                }
            }
            return mensaje;
        }

        private static void Insertar(Aeronave aeronave, Int32 cantPasillo, Int32 cantVentanilla)
        {
            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {
                con = Data.DataAccess.GetConnection();
                con.Open();
                trans = con.BeginTransaction();

                aeronave.Id = Data.Aeronave.Insertar(aeronave.fechaAlta, aeronave.fabricante, aeronave.modelo, aeronave.matricula,
                      aeronave.espacioKG, aeronave.cantButacas, aeronave.tipoServicio.Id, cantPasillo, cantVentanilla);

                trans.Commit();
                con.Close();
            }
            catch (Exception)
            {
                if (trans != null)
                    trans.Rollback();

                if (con != null)
                    con.Close();

                throw;
            }
        }

        private static void Actualizar(Aeronave aeronave, Int32 cantPasillo, Int32 cantVentanilla)
        {
            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {
                con = Data.DataAccess.GetConnection();
                con.Open();
                trans = con.BeginTransaction();

                Data.Aeronave.Actualizar(aeronave.fechaAlta, aeronave.Id, aeronave.fabricante, aeronave.modelo, aeronave.matricula,
                      aeronave.espacioKG, aeronave.cantButacas, aeronave.tipoServicio.Id, cantPasillo, cantVentanilla);

                trans.Commit();
                con.Close();
            }
            catch (Exception)
            {
                if (trans != null)
                    trans.Rollback();

                if (con != null)
                    con.Close();

                throw;
            }
        }

        public static List<Aeronave> Get(String Matricula, Int32? IdTipoDeServicioSeleccionado, String FabricanteSeleccionado)
        {
            var dt = Data.Aeronave.Get(Matricula, IdTipoDeServicioSeleccionado, FabricanteSeleccionado);
            var aeronaves = new List<Aeronave>(dt.Rows.Count);
            Aeronave aeronave = null;

            foreach (DataRow row in dt.Rows)
            {
                aeronave = new Aeronave();
                aeronave.Id = Int32.Parse(row["id"].ToString());
                aeronave.matricula = row["matricula"].ToString();
                aeronave.modelo = row["modelo"].ToString();
                aeronave.fabricante = row["fabricante"].ToString();
                aeronave.fechaAlta = DateTime.Parse(row["fechaAlta"].ToString());
                aeronave.cantButacas = Int32.Parse(row["cantButacas"].ToString());
                aeronave.espacioKG = Int32.Parse(row["espacioKgEncomiendas"].ToString());
                aeronave.tipoServicio = new TipoServicio(Int32.Parse(row["S_ID"].ToString()), row["S_NOMBRE"].ToString());
                //aeronave.idBaja = Int32.Parse(row["HB_ID"].ToString());
                //aeronave.fechaReinicio = DateTime.Parse(row["HB_FECHAREINICIO"].ToString());

                aeronaves.Add(aeronave);
            }

            dt.Dispose();

            return aeronaves;
        }

        public static DataTable cargarCBFabricantes()
        {
            return Data.Aeronave.cargarCBFabricantes();
        }


        public static Aeronave GetById(Int32 id)
        {
            var aeronave = new Aeronave();

            using (var data = Data.Aeronave.GetById(id))
            {
                aeronave.Id = Int32.Parse(data.Rows[0][data.Columns["Id"].Ordinal].ToString());
                aeronave.matricula = data.Rows[0][data.Columns["matricula"].Ordinal].ToString();
                aeronave.modelo = data.Rows[0][data.Columns["modelo"].Ordinal].ToString();
                aeronave.fabricante = data.Rows[0][data.Columns["fabricante"].Ordinal].ToString();
                aeronave.cantButacas = Int32.Parse(data.Rows[0][data.Columns["cantButacas"].Ordinal].ToString());
                aeronave.espacioKG = Int32.Parse(data.Rows[0][data.Columns["espacioKGEncomiendas"].Ordinal].ToString());
                /* COMO SERIA ESTO????? */
                aeronave.tipoServicio = new TipoServicio(Int32.Parse(data.Rows[0][data.Columns["S_ID"].Ordinal].ToString()), data.Rows[0][data.Columns["S_ID"].Ordinal].ToString());
            }

            return aeronave;
        }

        public void BajateVidaUtil(DateTime fechaActual)
        {
            Aeronave.BajaVidaUtil(this, fechaActual);
        }

        private static void BajaVidaUtil(Aeronave aeronave, DateTime fechaActual)
        {
            Data.Aeronave.BajaVidaUtil(aeronave.Id, fechaActual);
        }

        public void BajateFueraDeServicio(DateTime fechaActual, DateTime fechaReincorporacion)
        {
            Aeronave.BajaFueraDeServicio(this, fechaActual, fechaReincorporacion);
        }

        private static void BajaFueraDeServicio(Aeronave aeronave, DateTime fechaActual, DateTime fechaReincorporacion)
        {
            Data.Aeronave.BajaFueraDeServicio(aeronave.Id, fechaActual, fechaReincorporacion);
        }

    }
}