using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ByA;
using Entidades;
using Entidades.Security;
using System.Web.Security;
using DAL;


namespace BLL.Security
{
    public class gesUsuarios
    {
        //Entities ctx;
        public trdEntities ctx { get; set; }

        ByARpt byaRpt = new ByARpt();

        //public DateTime? GetUsuarios(string usuario)
        //{
        //    DateTime? ultAct = ctx.my_aspnet_users.Select(t => t.lastActivityDate).FirstOrDefault();
        //    return ultAct;
        //}
        public List<USUARIOS_DTO> GetUsuarios(string filtro)
        {
          
            List<USUARIOS_DTO> lst = new List<USUARIOS_DTO>();
            ctx = new trdEntities();
           
            List<my_aspnet_membership> lstO = ctx.my_aspnet_membership.ToList();

            Mapper.CreateMap<my_aspnet_membership, USUARIOS_DTO>()
                   .ForMember(dest => dest.USERNAME, opt => opt.MapFrom(src => ctx.my_aspnet_users.Where(t => t.id == src.userId).FirstOrDefault().name))
                   .ForMember(dest => dest.TERCERO, opt => opt.MapFrom(src => GetTercero(ctx.my_aspnet_users.Where(t => t.id == src.userId).FirstOrDefault().name)))
                   .ForMember(dest => dest.LASTACTIVITYDATE, opt => opt.MapFrom(src => ctx.my_aspnet_users.Where(t => t.id == src.userId).FirstOrDefault().lastActivityDate))
                   .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => ctx.my_aspnet_users.Where(t => t.id == src.userId).FirstOrDefault().lastActivityDate));


                Mapper.Map(lstO, lst);
                
            //lstF=lst.Where(u=>u.USERNAME.Contains(filtro) || u.TERCERO.ToUpper().Contains(filtro.ToUpper())).ToList();
            return lst.OrderBy(t => t.LASTACTIVITYDATE).ToList();
                
           
            
        }
        
         
        private string GetTercero(string username)
        {
            if (username == "")
            {
                fc_terceros t = ctx.fc_terceros.Where(ter => ter.terceroId == username).FirstOrDefault();
                return t.nombre;
            }
            else {
                return "";
            }
            
            
        }

        public List<ModuloRoles> GetRoles(string Modulo,string UserName)
        {
            ctx = new trdEntities();

            List<ModuloRoles> lm = ctx.fc_menu.Where(t => t.fc_modulo == Modulo && t.fc_menuid != t.fc_padreid).OrderBy(t=>t.fc_posicion)
                .Select(t => new ModuloRoles
                {
                    Modulo = t.fc_modulo,
                    Roles = t.fc_roles,
                  Titulo = t.fc_titulo
                }).Distinct().ToList();
            foreach (ModuloRoles item in lm)
            {
                if (item.Roles != null)
                {
                    item.hasRol = Roles.IsUserInRole(UserName, item.Roles);
                }
              
            }
            return lm;
        }

        public ByARpt GuardarRoles(List<ModuloRoles> lst, string UserName)
        {
            string msg = "";
            
                foreach (ModuloRoles item in lst)
                {
                    bool hasRoolAnt = Roles.IsUserInRole(UserName, item.Roles);
                    if (item.hasRol != hasRoolAnt)//Si cambio
                    {
                        try { 
                             if (item.hasRol)
                             {
                                Roles.AddUserToRole(UserName, item.Roles);
                                msg += String.Format("Se Asignó el Rol {0} - [ {1} ]</br>", item.Titulo, item.Roles);
                             }
                             else {
                                Roles.RemoveUserFromRole(UserName, item.Roles);
                                msg += String.Format("Se Retiró el Rol {0} - [ {1} ]</br>", item.Titulo, item.Roles);
                              }
                        }
                        catch (Exception ex)
                        {
                            msg = ex.Message;
                            
                        }
                    }
                }
                if (String.IsNullOrEmpty(msg))
                {
                    byaRpt.Mensaje =  "No realizó ningun cambio de Roles al usuario";
                }
                else {
                    byaRpt.Mensaje = msg;
                }
                
                byaRpt.Error = false;
            //GuardarRolesUsuarios
            return byaRpt;
        }

        public List<ListBoxJq> GetRolesLB(string Modulo)
        {
            ctx = new trdEntities();

            List<ListBoxJq> lm = ctx.fc_menu.Where(t => t.fc_modulo == Modulo)
                .Select(t => new ListBoxJq
                { group = t.fc_modulo,
                    value = t.fc_roles,
                  label = t.fc_titulo,
                }).Distinct().ToList();
            foreach(ListBoxJq item in lm){
                item.hasRol = Roles.IsUserInRole("admin", item.value);
            }
            
            return lm;
        }
        
        public ByARpt ActivarUsuario(USUARIOS_DTO Reg) {
            try
            {
                MembershipUser usr = Membership.GetUser(Reg.USERNAME);
                usr.IsApproved = true;
                Membership.UpdateUser(usr);
                byaRpt.Error = false;
                byaRpt.Mensaje = "Se Activo el usuario";
            }
            catch(Exception ex) {
                byaRpt.Error = true;
                byaRpt.Mensaje = ex.Message;
            }
            return byaRpt;
            
        }

        public ByARpt Forzar_Cambio_Clave(USUARIOS_DTO Reg)
        {
	        try {
                string rst = Membership.GetUser(Reg.USERNAME).ResetPassword();
                Membership.GetUser(Reg.USERNAME).ChangePassword(rst, Reg.Password);
                byaRpt.Mensaje = "Se realizó el cambio de contraseña";
                byaRpt.Error = false;
	        } catch (Exception ex) {
                byaRpt.Mensaje = "Error de App:" + ex.Message;
                byaRpt.Error = true;
	        } 

            return byaRpt;
        }

        public ByARpt InactivarUsuario(USUARIOS_DTO Reg) {
            try
            {
                MembershipUser usr = Membership.GetUser(Reg.USERNAME);
                usr.IsApproved = false;
                Membership.UpdateUser(usr);
                byaRpt.Error = false;
                byaRpt.Mensaje = "Se Inactivo el usuario";
            }
            catch (Exception ex)
            {
                byaRpt.Error = true;
                byaRpt.Mensaje = ex.Message;
            }
            return byaRpt;
        }

        public ByARpt DesbloquearUsuario(USUARIOS_DTO Reg) {
            
            try
            {
                Membership.GetUser(Reg.USERNAME).UnlockUser();
                byaRpt.Error = false;
                byaRpt.Mensaje = "Se desbloqueo el usuario";
            }
            catch (Exception ex)
            {
                byaRpt.Error = true;
                byaRpt.Mensaje = ex.Message;
            }
            return byaRpt;
        }

        public List<USUARIOS_DTO> GetUsuariosEnLinea()
        {
            /*
            List<USUARIOS_DTO> lst = new List<USUARIOS_DTO>();
            
            ctx = new trdEntities ();

            List<my_aspnet_membership> lstO = ctx.my_aspnet_membership.ToList();
            Mapper.CreateMap<my_aspnet_membership, USUARIOS_DTO>();
              //  .ForMember(dest => dest.USERNAME, opt => opt.MapFrom(src => src.my .USERNAME))
               // .ForMember(dest => dest.LASTACTIVITYDATE, opt => opt.MapFrom(src => src.ORA_ASPNET_USERS.LASTACTIVITYDATE))
               // .ForMember(dest => dest.TERCERO, opt => opt.MapFrom(src => GetTercero(src.ORA_ASPNET_USERS.USERNAME)));
            foreach(my_aspnet_membership item in lstO){
                if (Membership.GetUser(item.ORA_ASPNET_USERS.USERNAME).IsOnline) {
                    USUARIOS_DTO itemDTO = new USUARIOS_DTO();
                    Mapper.Map(item, itemDTO);
                    lst.Add(itemDTO);
                }
            }
             * */
            return new List<USUARIOS_DTO>(); //lst.OrderBy(t => t.LASTACTIVITYDATE).ToList();

        }

        public ByARpt InsUsuarios(USUARIOS_DTO Reg) { 
            MembershipCreateStatus status=default(MembershipCreateStatus);
            string Msg="";
            try
            {
                Membership.CreateUser(Reg.USERNAME, Reg.Password);
                switch (status) {
                        case MembershipCreateStatus.DuplicateEmail:
                                Msg = Msg + "Correo Eléctronico Duplicado";
                                break;
                        case MembershipCreateStatus.DuplicateProviderUserKey:
                                Msg = Msg + "Duplicado User Key";
                                break;
                        case MembershipCreateStatus.DuplicateUserName:
                                Msg = Msg + "Duplicado Nombre de Usuario (Username)";
                                break;
                        case MembershipCreateStatus.InvalidAnswer:
                                Msg = Msg + "Respuesta Inválida";
                                break;
                        case MembershipCreateStatus.InvalidEmail:
                                Msg = Msg + "Correo Electrónico Inválido";
                                break;
                        case MembershipCreateStatus.InvalidPassword:
                                Msg = Msg + "Contraseña Inválida";
                                break;
                        case MembershipCreateStatus.InvalidProviderUserKey:
                                Msg = Msg + "Provider User Key Inválido ";
                                break;
                        case MembershipCreateStatus.InvalidQuestion:
                                Msg = Msg + "Pregunta Iválida";
                                break;
                        case MembershipCreateStatus.InvalidUserName:
                                Msg = Msg + "Nombre de Usuario (Username) Inválido";
                                break;
                        case MembershipCreateStatus.ProviderError:
                                Msg = Msg + "Nombre de Usuario (Username) Inválido";
                                break;
                        case MembershipCreateStatus.Success:
                                byaRpt.Error = false;
                                Msg = "Se creo el Usuario ID [" + Reg.USERNAME + "]";
                                break;
                        case MembershipCreateStatus.UserRejected:
                                Msg = Msg + "Error: UserRejected en el Proveedor";
                                break;
                }
                byaRpt.Mensaje = Msg;                
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                byaRpt.Error = true;
                byaRpt.Mensaje =Msg;
                return byaRpt;
            }
            return byaRpt;
        }
       

    }

}
