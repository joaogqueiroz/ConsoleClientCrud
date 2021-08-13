using Projeto04.Entities;
using Projeto04.Repositories;
using System;

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n PROJECT - CRUD SQLSERVER\n");
                Console.WriteLine("\n (1) - Insert Client");
                Console.WriteLine("\n (2) - Update Client");
                Console.WriteLine("\n (3) - Delete Client");
                Console.WriteLine("\n (4) - Consult Client");
                Console.WriteLine("\n (5) - Consult Client By Id");
                Console.WriteLine("\n (6) - Consult Client By Birth Date");
                Console.WriteLine("\n (0) - Exit");
                Console.WriteLine("Please, inform the desired option ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        var clientInsert = new Client();
                        Console.WriteLine("\n Client Registration");
                        clientInsert.IdClient = Guid.NewGuid();
                        Console.WriteLine("\n Client Name: ");
                        clientInsert.Name = Console.ReadLine();
                        Console.WriteLine("\n Client Email: ");
                        clientInsert.Email = Console.ReadLine();
                        Console.WriteLine("\n Client Birth Date: ");
                        clientInsert.BirthDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("\n Client Doc: ");
                        clientInsert.Doc = Console.ReadLine();

                        var clientRepositoryInsert = new ClientRepository();
                        clientRepositoryInsert.Insert(clientInsert);
                        Console.WriteLine("\n Client registred successfully ");
                        Console.ReadKey();
                        Console.Clear();                        
                        Main(args);// back to beginning!

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n Client Update ");
                        Console.WriteLine("\n Client Id:  ");
                        var clientIDUpdate = Guid.Parse(Console.ReadLine());
                        var clientRepositoryUpdate = new ClientRepository();
                        var clientUpdate = clientRepositoryUpdate.ConsultByID(clientIDUpdate);
                        // Check if client exists
                        if (clientUpdate != null)
                        {
                            Console.WriteLine("\n Client Name: ");
                            clientUpdate.Name = Console.ReadLine();
                            Console.WriteLine("\n Client Email: ");
                            clientUpdate.Email = Console.ReadLine();
                            Console.WriteLine("\n Client Birth Date: ");
                            clientUpdate.BirthDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("\n Client Doc: ");
                            clientUpdate.Doc = Console.ReadLine();

                            //Updating client in database
                            clientRepositoryUpdate.Alter(clientUpdate);
                            Console.WriteLine("\n Client updated successfully ");
                            Console.ReadKey();
                            Console.Clear();
                            Main(args);// back to beginning!
                        }
                        else 
                        {
                            Console.WriteLine("Client not found!");
                            Console.ReadKey();
                            Console.Clear();
                            Main(args);// back to beginning!
                        }


                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n Client Update ");
                        Console.WriteLine("\n Client Id:  ");
                        var clientIDDelete = Guid.Parse(Console.ReadLine());
                        var clientRepositoryDelete = new ClientRepository();
                        var clientDelete = clientRepositoryDelete.ConsultByID(clientIDDelete);
                        // Check if client exists
                        if (clientDelete != null)
                        {
                            Console.WriteLine($"\n Do you really want to delete {clientDelete.Name} ? (Y,N): ");
                            var answer = Console.ReadLine();
                            if (true)
                            {
                                //Deleting client in database
                                clientRepositoryDelete.Delete(clientDelete);
                                Console.WriteLine("\n Client deleted successfully ");
                                Console.ReadKey();
                                Console.Clear();
                                Main(args);// back to beginning!

                            }

                        }
                        else
                        {
                            Console.WriteLine("Client not found!");
                            Console.ReadKey();
                            Console.Clear();
                            Main(args);// back to beginning!
                        }
                        break;
                    case 4:
                        var clientRepositoryConsult = new ClientRepository();
                        Console.Clear();
                        Console.WriteLine("\n Consulting Clients");
                        Console.WriteLine("\n");
                        foreach (var item in clientRepositoryConsult.Consult())
                        {

                            Console.WriteLine("Client ID: " + item.IdClient);
                            Console.WriteLine("Client Name: " + item.Name);
                            Console.WriteLine("Client Email:" + item.Email);
                            Console.WriteLine("Client Doc:" + item.Doc);
                            Console.WriteLine("Client BirthDate:" + item.BirthDate);
                            Console.WriteLine("\n");
                            
                        }
                        Console.WriteLine("\n Clients Consulted successfully ");
                        Console.ReadKey();
                        Console.Clear();
                        Main(args);// back to beginning!
                        break;

                    case 5:
                        var clientRepositoryConsultByID = new ClientRepository();
                        Console.Clear();
                        Console.WriteLine("\n Client ID: \n ");
                        var clientIDConsult = Guid.Parse(Console.ReadLine());
                        var itemById = clientRepositoryConsultByID.ConsultByID(clientIDConsult);
                        Console.WriteLine("Client ID: " + itemById.IdClient);
                        Console.WriteLine("Client Name: " + itemById.Name);
                        Console.WriteLine("Client Email:" + itemById.Email);
                        Console.WriteLine("Client Doc:" + itemById.Doc);
                        Console.WriteLine("Client BirthDate:" + itemById.BirthDate);
                        Console.WriteLine("\n");
                        Console.ReadKey();
                        Console.Clear();
                        Main(args);// back to beginning!

                        break;

                    case 6:
                        var clientRepositoryConsultBirthDate = new ClientRepository();
                        Console.Clear();
                        Console.WriteLine("\n Min Date: \n ");
                        var minDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("\n Max Date: \n ");
                        var maxDate = DateTime.Parse(Console.ReadLine());
                        foreach (var item in clientRepositoryConsultBirthDate.ConsultByBirthDate(minDate, maxDate))
                        {

                            Console.WriteLine("Client ID: " + item.IdClient);
                            Console.WriteLine("Client Name: " + item.Name);
                            Console.WriteLine("Client Email:" + item.Email);
                            Console.WriteLine("Client Doc:" + item.Doc);
                            Console.WriteLine("Client BirthDate:" + item.BirthDate);
                            Console.WriteLine("\n");

                        }
                        Console.WriteLine("\n");
                        Console.ReadKey();
                        Console.Clear();
                        Main(args);// back to beginning!
                        break;
                    default:
                        Console.WriteLine("\n Closing program");
                        break;
                }

            }
            catch (Exception e )
            {

                Console.WriteLine("\n Erro: " + e.Message);
            }
            
        }
    }
}
