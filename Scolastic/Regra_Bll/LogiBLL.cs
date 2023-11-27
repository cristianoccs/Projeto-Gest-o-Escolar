using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Scolastic.Modelos;
using Scolastic.Dados_Dal;

namespace Scolastic.Regra_Bll
{
    public class LogiBLL
    {
        LogiDal clsdados = new LogiDal();

        public DataTable Logar(LogiInformation obje)
        {
            return clsdados.D_logar(obje);
        }

        public DataTable buscar_login(LogiInformation obje)
        {
            return clsdados.D_buscar_login(obje);
        }

        public DataTable Lista_login(string filtro)
        {
            return clsdados.D_lista_login(filtro);
        }
        public void incluir_login(LogiInformation obje)
        {
            if (obje.logim.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (obje.senha.Equals(""))
            { throw new Exception("A SENHA É OBRIGATORIA"); }

            if (obje.id_tipo.Equals(""))
            {
                throw new Exception("o tipo é obriatorio!");
            }

            if (obje.Num_matric.Equals(""))
            {
                throw new Exception("o tipo é obriatorio!");
            }


            LogiDal incluir_D = new LogiDal();
            incluir_D.D_inclui_login(obje);

        }
        public void alterar_login(LogiInformation obje)
        {
            if (obje.logim.Trim().Length == 0) //trim tira todos os espaço
            { throw new Exception(" o nome é obriatorio"); }

            if (obje.senha.Equals(""))
            { throw new Exception("A SENHA É OBRIGATORIA"); }

            if (obje.id_tipo.Equals(""))
            {
                throw new Exception("Tipo do Usuario");
            }


            LogiDal Alterar_D = new LogiDal();
            Alterar_D.D_alterar_login(obje);








        }
        public void excluir(int Codigo)
        {
            if (Codigo < 1)
            {
                throw new Exception("Seleciona o usuario antes de excluilo");

            }

            LogiDal Excluir_D = new LogiDal();
            Excluir_D.D_excluir_login(Codigo);
        }


    }
}
