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
                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-  n°1 -_-_-_-_-_-_-_-_-_-\n");
                var requeteEmployes = from EMPLOYE in oracleContexte.EMPLOYEs
                                      select EMPLOYE;
                var lesEmployes = requeteEmployes.ToList();

                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }

                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-  n°2 -_-_-_-_-_-_-_-_-_-\n");

                var unCodeProjet = "PR1";
                var requeteEmployesProjet = from EMPLOYE in oracleContexte.EMPLOYEs
                                            where EMPLOYE.CODEPROJET.TrimEnd() == unCodeProjet
                                            select EMPLOYE;
                lesEmployes = requeteEmployesProjet.ToList();
                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }

                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-  n°3 -_-_-_-_-_-_-_-_-_-\n");
                var unId = 33;
                var requeteEmployesId = from EMPLOYE in oracleContexte.EMPLOYEs
                                       where EMPLOYE.NUMEMP == unId
                                       select EMPLOYE;
                var employeId = requeteEmployesId.FirstOrDefault();
                if (employeId != null)
                {
                    Console.WriteLine(employeId.NOMEMP + " - " + employeId.PRENOMEMP + " - " + employeId.SALAIRE);
                }
                else
                {
                    Console.WriteLine("L'employé numéro " + unId + " n'existe pas.");
                }

                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-  Jointure 1 -_-_-_-_-_-_-_-_-_-\n");

                var requete = from s in oracleContexte.SEMINAIREs
                              join COUR in oracleContexte.COURS on s.CODECOURS equals COUR.CODECOURS
                              select s;
                var lesSeminaires = requete.ToList();
                foreach (var unSeminaire in lesSeminaires)
                {
                    Console.WriteLine(unSeminaire.CODESEMI + " - " + unSeminaire.CODECOURS + " - " + unSeminaire.COUR.LIBELLECOURS);
                    
                }

                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-  Jointure 2 -_-_-_-_-_-_-_-_-_-\n");

                var requeteCour = from s in oracleContexte.COURS
                              join SEMINAIRE in oracleContexte.COURS on s.CODECOURS equals SEMINAIRE.CODECOURS
                              select s;

                var lesCours = requeteCour.ToList();
                foreach (var unCour in lesCours)
                {
                    Console.WriteLine(unCour.CODECOURS + " - " + unCour.LIBELLECOURS + " - " + unCour.NBJOURS);
                    foreach (var unSeminaire in unCour.SEMINAIREs)
                    {
                        Console.WriteLine(unSeminaire.DATEDEBUTSEM);
                    }
                }

                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-  Regroupement 1 -_-_-_-_-_-_-_-_-_-\n");

                var employeProjet = from emp in oracleContexte.EMPLOYEs
                                    group emp by emp.CODEPROJET into groupeEmployes
                                    select new
                                    {
                                        Projet = groupeEmployes.Key,
                                        Nombre = groupeEmployes.Count()
                                    };
                foreach (var ligne in employeProjet.ToList())
                {
                    Console.WriteLine(ligne.Projet + " - " + ligne.Nombre);
                }
                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-  Regroupement 2 -_-_-_-_-_-_-_-_-_-\n");


                var employeNomProjet = from emp in oracleContexte.EMPLOYEs
                                    join prj in oracleContexte.PROJETs on emp.CODEPROJET equals prj.CODEPROJET
                                    group emp by new { prj.CODEPROJET, prj.NOMPROJET } into groupeEmployes
                                    select new
                                    {
                                        Projet = groupeEmployes.Key.CODEPROJET,
                                        Nom = groupeEmployes.Key.NOMPROJET,
                                        Nombre = groupeEmployes.Count()
                                    };
                foreach (var ligne in employeNomProjet.ToList())
                {
                    Console.WriteLine(ligne.Projet + " - " + ligne.Nom + " - " + ligne.Nombre);
                }

            }
            Console.ReadLine();
        }
    }
}
