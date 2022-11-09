using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Models;

namespace BasicBilling.API.DataBase
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
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
                await context.Clients.AddRangeAsync(clients);
                await context.SaveChangesAsync();
            }

            if (context.Bills.Any()) return;
            var bills_cli_1 = new List<Bill>{
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 200,
                Period = 202211,
                Category = "WATER",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 200,
                Period = 202211,
                Category = "ELECTRICITY",
                State = "PAID"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = 202211,
                Category = "SEWER",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = 202212,
                Category = "WATER",
                State = "PAID"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = 202212,
                Category = "ELECTRICITY",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 100,
                Period = 202212,
                Category = "SEWER",
                State = "PAID"
                }
            };
            await context.Bills.AddRangeAsync(bills_cli_1);
            await context.SaveChangesAsync();

            var bills_cli_2 = new List<Bill>{
                new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = 202211,
                    Category = "WATER",
                    State = "PENDING"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = 202211,
                    Category = "ELECTRICITY",
                    State = "PAID"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = 202211,
                    Category = "SEWER",
                    State = "PENDING"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = 202212,
                    Category = "WATER",
                    State = "PAID"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = 202212,
                    Category = "ELECTRICITY",
                    State = "PENDING"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 200,
                    Period = 202212,
                    Category = "SEWER",
                    State = "PAID"
                    }
            };
            await context.Bills.AddRangeAsync(bills_cli_2);
            await context.SaveChangesAsync();

            var bills_cli_3 = new List<Bill>{
                new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = 202211,
                    Category = "WATER",
                    State = "PENDING"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = 202211,
                    Category = "ELECTRICITY",
                    State = "PAID"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = 202211,
                    Category = "SEWER",
                    State = "PENDING"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = 202212,
                    Category = "WATER",
                    State = "PAID"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = 202212,
                    Category = "ELECTRICITY",
                    State = "PENDING"
                    },
                    new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = 300,
                    Period = 202212,
                    Category = "SEWER",
                    State = "PAID"
                    }
            };
            await context.Bills.AddRangeAsync(bills_cli_3);
            await context.SaveChangesAsync();

            var bills_cli_4 = new List<Bill>{
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = 202211,
                Category = "WATER",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = 202211,
                Category = "ELECTRICITY",
                State = "PAID"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = 202211,
                Category = "SEWER",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = 202212,
                Category = "WATER",
                State = "PAID"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = 202212,
                Category = "ELECTRICITY",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 400,
                Period = 202212,
                Category = "SEWER",
                State = "PAID"
                }
            };
            await context.Bills.AddRangeAsync(bills_cli_4);
            await context.SaveChangesAsync();

            var bills_cli_5 = new List<Bill>{
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = 202211,
                Category = "WATER",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = 202211,
                Category = "ELECTRICITY",
                State = "PAID"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = 202211,
                Category = "SEWER",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = 202212,
                Category = "WATER",
                State = "PAID"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = 202212,
                Category = "ELECTRICITY",
                State = "PENDING"
                },
                new Bill{
                Id = Guid.NewGuid(),
                ClientId = 500,
                Period = 202212,
                Category = "SEWER",
                State = "PAID"
                }
            };
            await context.Bills.AddRangeAsync(bills_cli_5);
            await context.SaveChangesAsync();
        }
    }
}