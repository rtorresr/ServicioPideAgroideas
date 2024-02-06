using Application.Common.Models;
using Application.Common.Repositories.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Repositories.Servicios
{
    public class SunatRepository : ISunatRepository
    {
        public DatosPrincipalesSunat GetDatosBasicos(string ruta, string nroRuc)
        {
            try
            {
                DatosPrincipalesSunat objDp = new DatosPrincipalesSunat();

                XDocument xdoc = XDocument.Load(ruta + "DatosPrincipales?numruc=" + nroRuc);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDp.ddp_ubigeo = (string)item.Element("ddp_ubigeo");
                    objDp.cod_dep = (string)item.Element("cod_dep");
                    objDp.desc_de = (string)item.Element("desc_dep");
                    objDp.cod_prov = (string)item.Element("cod_prov");
                    objDp.desc_prov = (string)item.Element("desc_prov");
                    objDp.cod_dist = (string)item.Element("cod_dist");
                    objDp.desc_dist = (string)item.Element("desc_dist");
                    objDp.ddp_ciiu = (string)item.Element("ddp_ciiu");
                    objDp.desc_ciiu = (string)item.Element("desc_ciiu");
                    objDp.ddp_estado = (string)item.Element("ddp_estado");
                    objDp.desc_estado = (string)item.Element("desc_estado");
                    objDp.ddp_fecact = (string)item.Element("ddp_fecact");
                    objDp.ddp_fecalt = (string)item.Element("ddp_fecalt");
                    objDp.ddp_fecbaj = (string)item.Element("ddp_fecbaj");
                    objDp.ddp_identi = (string)item.Element("ddp_identi");
                    objDp.desc_identi = (string)item.Element("desc_identi");
                    objDp.ddp_lllttt = (string)item.Element("ddp_lllttt");
                    objDp.ddp_nombre = (string)item.Element("ddp_nombre");
                    objDp.ddp_nomvia = (string)item.Element("ddp_nomvia");
                    objDp.ddp_numer1 = (string)item.Element("ddp_numer1");
                    objDp.ddp_inter1 = (string)item.Element("ddp_inter1");
                    objDp.ddp_nomzon = (string)item.Element("ddp_nomzon");
                    objDp.ddp_refer1 = (string)item.Element("ddp_refer1");
                    objDp.ddp_flag22 = (string)item.Element("ddp_flag22");
                    objDp.desc_flag22 = (string)item.Element("desc_flag22");
                    objDp.ddp_numreg = (string)item.Element("ddp_numreg");
                    objDp.desc_numreg = (string)item.Element("desc_numreg");
                    objDp.ddp_numruc = (string)item.Element("ddp_numruc");
                    objDp.ddp_tipvia = (string)item.Element("ddp_tipvia");
                    objDp.desc_tipvia = (string)item.Element("desc_tipvia");
                    objDp.ddp_tipzon = (string)item.Element("ddp_tipzon");
                    objDp.desc_tipzon = (string)item.Element("desc_tipzon");
                    objDp.ddp_tpoemp = (string)item.Element("ddp_tpoemp");
                    objDp.desc_tpoemp = (string)item.Element("desc_tpoemp");

                    if (item.Element("esActivo") != null && item.Element("esHabido") != null)
                    {
                        objDp.esActivo = (bool)item.Element("esActivo");
                        objDp.esHabido = (bool)item.Element("esHabido");
                    }
                    else
                    {
                        objDp.esActivo = false;
                        objDp.esHabido = false;
                    }
                }

                return objDp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DatosPrincipalesSunat GetDatosPrincipales(string ruta, string nroRuc)
        {
            try
            {
                DatosPrincipalesSunat objDp = new DatosPrincipalesSunat();

                XDocument xdoc = XDocument.Load(ruta + "DatosPrincipales?numruc=" + nroRuc);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDp.ddp_ubigeo = (string)item.Element("ddp_ubigeo");
                    objDp.cod_dep = (string)item.Element("cod_dep");
                    objDp.desc_de = (string)item.Element("desc_dep");
                    objDp.cod_prov = (string)item.Element("cod_prov");
                    objDp.desc_prov = (string)item.Element("desc_prov");
                    objDp.cod_dist = (string)item.Element("cod_dist");
                    objDp.desc_dist = (string)item.Element("desc_dist");
                    objDp.ddp_ciiu = (string)item.Element("ddp_ciiu");
                    objDp.desc_ciiu = (string)item.Element("desc_ciiu");
                    objDp.ddp_estado = (string)item.Element("ddp_estado");
                    objDp.desc_estado = (string)item.Element("desc_estado");
                    objDp.ddp_fecact = (string)item.Element("ddp_fecact");
                    objDp.ddp_fecalt = (string)item.Element("ddp_fecalt");
                    objDp.ddp_fecbaj = (string)item.Element("ddp_fecbaj");
                    objDp.ddp_identi = (string)item.Element("ddp_identi");
                    objDp.desc_identi = (string)item.Element("desc_identi");
                    objDp.ddp_lllttt = (string)item.Element("ddp_lllttt");
                    objDp.ddp_nombre = (string)item.Element("ddp_nombre");
                    objDp.ddp_nomvia = (string)item.Element("ddp_nomvia");
                    objDp.ddp_numer1 = (string)item.Element("ddp_numer1");
                    objDp.ddp_inter1 = (string)item.Element("ddp_inter1");
                    objDp.ddp_nomzon = (string)item.Element("ddp_nomzon");
                    objDp.ddp_refer1 = (string)item.Element("ddp_refer1");
                    objDp.ddp_flag22 = (string)item.Element("ddp_flag22");
                    objDp.desc_flag22 = (string)item.Element("desc_flag22");
                    objDp.ddp_numreg = (string)item.Element("ddp_numreg");
                    objDp.desc_numreg = (string)item.Element("desc_numreg");
                    objDp.ddp_numruc = (string)item.Element("ddp_numruc");
                    objDp.ddp_tipvia = (string)item.Element("ddp_tipvia");
                    objDp.desc_tipvia = (string)item.Element("desc_tipvia");
                    objDp.ddp_tipzon = (string)item.Element("ddp_tipzon");
                    objDp.desc_tipzon = (string)item.Element("desc_tipzon");
                    objDp.ddp_tpoemp = (string)item.Element("ddp_tpoemp");
                    objDp.desc_tpoemp = (string)item.Element("desc_tpoemp");

                    if (item.Element("esActivo") != null && item.Element("esHabido") != null)
                    {
                        objDp.esActivo = (bool)item.Element("esActivo");
                        objDp.esHabido = (bool)item.Element("esHabido");
                    }
                    else
                    {
                        objDp.esActivo = false;
                        objDp.esHabido = false;
                    }
                }

                return objDp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DatosSecundariosSunat GetDatosSecundarios(string ruta, string nroRuc)
        {
            try
            {
                DatosSecundariosSunat objDs = new DatosSecundariosSunat();

                XDocument xdoc = XDocument.Load(ruta + "DatosSecundarios?numruc=" + nroRuc);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDs.dds_califi = (string)item.Element("dds_califi");
                    objDs.dds_comext = (string)item.Element("dds_comext");
                    objDs.desc_comext = (string)item.Element("desc_comext");
                    objDs.dds_consti = (string)item.Element("dds_consti");
                    objDs.dds_contab = (string)item.Element("dds_contab");
                    objDs.desc_contab = (string)item.Element("desc_contab");
                    objDs.dds_docide = (string)item.Element("dds_docide");
                    objDs.desc_docide = (string)item.Element("desc_docide");
                    objDs.dds_nrodoc = (string)item.Element("dds_nrodoc");
                    objDs.dds_domici = (string)item.Element("dds_domici");
                    objDs.desc_domici = (string)item.Element("desc_domici");
                    objDs.dds_fecact = (string)item.Element("dds_fecact");
                    objDs.desc_factur = (string)item.Element("desc_factur");
                    objDs.dds_fecnac = (string)item.Element("dds_fecnac");
                    objDs.dds_asient = (string)item.Element("dds_asient");
                    objDs.dds_ficha = (string)item.Element("dds_ficha");
                    objDs.dds_nfolio = (string)item.Element("dds_nfolio");
                    objDs.dds_inicio = (string)item.Element("dds_inicio");
                    objDs.dds_licenc = (string)item.Element("dds_licenc");
                    objDs.dds_nacion = (string)item.Element("dds_nacion");
                    objDs.dds_nomcom = (string)item.Element("dds_nomcom");
                    objDs.dds_numruc = (string)item.Element("dds_numruc");
                    objDs.dds_orient = (string)item.Element("dds_orient");
                    objDs.desc_orient = (string)item.Element("desc_orient");
                    objDs.dds_paispa = (string)item.Element("dds_paispa");
                    objDs.dds_pasapo = (string)item.Element("dds_pasapo");
                    objDs.dds_patron = (string)item.Element("dds_patron");
                    objDs.dds_sexo = (string)item.Element("dds_sexo");
                    objDs.desc_sexo = (string)item.Element("desc_sexo");
                    objDs.dds_telef1 = (string)item.Element("dds_telef1");
                    objDs.dds_telef2 = (string)item.Element("dds_telef2");
                    objDs.dds_telef3 = (string)item.Element("dds_telef3");
                    objDs.dds_numfax = (string)item.Element("dds_numfax");

                }

                return objDs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DomicilioLegalSunat GetDomicilioLegal(string ruta, string nroRuc)
        {
            try
            {
                DomicilioLegalSunat objDomLeg = new DomicilioLegalSunat();

                XDocument xdoc = XDocument.Load(ruta + "DomicilioLegal?numruc=" + nroRuc);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDomLeg.getDomicilioLegalReturn = (string)item.Element("getDomicilioLegalReturn");

                }

                return objDomLeg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RepLegalesSunat GetRepLegales(string ruta, string nroRuc)
        {
            try
            {
                RepLegalesSunat objRepleg = new RepLegalesSunat();

                XDocument xdoc = XDocument.Load(ruta + "RepLegales?numruc=" + nroRuc);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objRepleg.cod_depar = (string)item.Element("cod_depar");
                    objRepleg.num_ord_suce = (string)item.Element("num_ord_suce");
                    objRepleg.cod_cargo = (string)item.Element("cod_cargo");
                    objRepleg.rso_cargoo = (string)item.Element("rso_cargoo");
                    objRepleg.rso_vdesde = (string)item.Element("rso_vdesde");
                    objRepleg.rso_docide = (string)item.Element("rso_docide");
                    objRepleg.desc_docide = (string)item.Element("desc_docide");
                    objRepleg.rso_nrodoc = (string)item.Element("rso_nrodoc");
                    objRepleg.rso_fecact = (string)item.Element("rso_fecact");
                    objRepleg.rso_fecnac = (string)item.Element("rso_fecnac");
                    objRepleg.rso_nombre = (string)item.Element("rso_nombre");
                    objRepleg.rso_numruc = (string)item.Element("rso_numruc");
                }

                return objRepleg;
            }
            catch (Exception ex)
            {                
                return null;
            }
        }
    }
}
