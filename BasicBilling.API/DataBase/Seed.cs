using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Models;

namespace BasicBilling.API.DataBase
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Clients.Any())
            {
                var clients = new List<Client>
            {
                new Client
                {
                    Id = 100,
                    Name = "Joseph Carlton"
                },
                new Client
                {
                    Id = 200,
                    Name = "Maria Juarez"
                },
                new Client
                {
                    Id = 300,
                    Name = "Albert Kenny"
                },
                new Client
                {
                    Id = 400,
                    Name = "Jessica Phillips"
                },
                new Client
                {
                    Id = 500,
                    Name = "Charles Johnson"
                }
            };
                context.Clients.AddRange(clients);
                context.SaveChanges();
            }

            if (context.Bills.Any()) return;
            var bills_cli_1 = new List<Bill>{
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 200,
                Period = "202211",
                Amount = 20,
                Category = "WATER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 200,
                Period = "202211",
                Amount = 20,
                Category = "ELECTRICITY"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = "202211",
                Amount = 10,
                Category = "SEWER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = "202212",
                Amount = 10,
                Category = "WATER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = "202212",
                Amount = 10,
                Category = "ELECTRICITY"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = "202212",
                Amount = 10,
                Category = "SEWER"
                }
            };
            context.Bills.AddRange(bills_cli_1);
            context.SaveChanges();

            var bills_cli_2 = new List<Bill>{
                new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = "202211",
                    Amount = 20,
                    Category = "WATER"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = "202211",
                    Amount = 20,
                    Category = "ELECTRICITY"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = "202211",
                    Amount = 20,
                    Category = "SEWER"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = "202212",
                    Amount = 20,
                    Category = "WATER"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = "202212",
                    Amount = 20,
                    Category = "ELECTRICITY"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = "202212",
                    Amount = 20,
                    Category = "SEWER"
                    }
            };
            context.Bills.AddRange(bills_cli_2);
            context.SaveChanges();

            var bills_cli_3 = new List<Bill>{
                new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = "202211",
                    Amount = 30,
                    Category = "WATER"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = "202211",
                    Amount = 30,
                    Category = "ELECTRICITY"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = "202211",
                    Amount = 30,
                    Category = "SEWER"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = "202212",
                    Amount = 30,
                    Category = "WATER"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = "202212",
                    Amount = 30,
                    Category = "ELECTRICITY"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = "202212",
                    Amount = 30,
                    Category = "SEWER"
                    }
            };
            context.Bills.AddRange(bills_cli_3);
            context.SaveChanges();

            var bills_cli_4 = new List<Bill>{
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = "202211",
                Amount = 40,
                Category = "WATER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = "202211",
                Amount = 40,
                Category = "ELECTRICITY"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = "202211",
                Amount = 40,
                Category = "SEWER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = "202212",
                Amount = 40,
                Category = "WATER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = "202212",
                Amount = 40,
                Category = "ELECTRICITY"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = "202212",
                Amount = 40,
                Category = "SEWER"
                }
            };
            context.Bills.AddRange(bills_cli_4);
            context.SaveChanges();

            var bills_cli_5 = new List<Bill>{
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = "202211",
                Amount = 50,
                Category = "WATER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = "202211",
                Amount = 50,
                Category = "ELECTRICITY"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = "202211",
                Amount = 50,
                Category = "SEWER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = "202212",
                Amount = 50,
                Category = "WATER"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = "202212",
                Amount = 50,
                Category = "ELECTRICITY"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = "202212",
                Amount = 50,
                Category = "SEWER"
                }
            };
            context.Bills.AddRange(bills_cli_5);
            context.SaveChanges();
        }
    }
}