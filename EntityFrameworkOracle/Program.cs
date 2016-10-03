using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkOracle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (OracleEntities oracleContexte= new OracleEntities())
            {
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-  n°1 -_-_-_-_-_-_-_-_-_-");
                var requeteEmployes = from EMPLOYE in oracleContexte.EMPLOYEs
                                      select EMPLOYE;
                var lesEmployes = requeteEmployes.ToList();

                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }

                Console.WriteLine("-_-_-_-_-_-_-_-_-_-  n°2 -_-_-_-_-_-_-_-_-_-");

                var unCodeProjet = "PR1";
                var requeteEmployesProjet = from EMPLOYE in oracleContexte.EMPLOYEs
                                            where EMPLOYE.CODEPROJET.TrimEnd() == unCodeProjet
                                            select EMPLOYE;
                lesEmployes = requeteEmployesProjet.ToList();
                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }

                Console.WriteLine("-_-_-_-_-_-_-_-_-_-  n°3 -_-_-_-_-_-_-_-_-_-");
                var unId = 3;
                var requeteEmployesId = from EMPLOYE in oracleContexte.EMPLOYEs
                                       where EMPLOYE.NUMEMP == unId
                                       select EMPLOYE;
                var employeId = requeteEmployesId.First();
                Console.WriteLine(employeId.NOMEMP + " - " + employeId.PRENOMEMP + " - " + employeId.SALAIRE);

                Console.WriteLine("-_-_-_-_-_-_-_-_-_-  n°4 -_-_-_-_-_-_-_-_-_-");


            }
            Console.ReadLine();
        }
    }
}
