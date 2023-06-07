
// Import necessary dependencies for testing
using Xunit;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBridgeApi.Controllers;
using CodeBridgeApi.Models;
using Sieve.Services;
using Sieve.Models;


namespace CodeBridge.Test
{

    // Test class for DogController
    public class DogControllerTests
    {

        [Fact]
        public async Task GetAllDogs_ReturnsExpectedDogs()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DogDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new DogDbContext(options))
            {
                // Prepare the test data
                context.Dogs.AddRange(
                    new Dog
                    {
                        Name = "Neo",
                        Color = "red & amber",
                        Tail_Length = "22",
                        Weight = "32"
                    },
                    new Dog
                    {
                        Name = "Jessy",
                        Color = "black & white",
                        Tail_Length = "7",
                        Weight = "14"
                    });

                await context.SaveChangesAsync();
            }

            using (var context = new DogDbContext(options))
            {
                // Act
                var controller = new DogController(context, null); // Pass null for the SieveProcessor dependency
                var response = await controller.GetAllDogs(null);

                // Assert
                Assert.NotNull(response);

                var okObjectResult = Assert.IsType<OkObjectResult>(response);
                var resultDogs = await (okObjectResult.Value as IQueryable<Dog>).ToListAsync();

                Assert.NotNull(resultDogs);
                // Additional assertions based on your specific scenario
            }
        }



        // Simple test method for GetPing
        [Fact]
        public void GetPing_IsReturnValid()
        {

            // Arrange
            var controller = new DogController(null, null);

            // Act
            var result = controller.GetPing();

            // Assert
            Assert.Equal("Dogs house service. Version 1.0.1", result);
        }

        // Test method for CreateDogAsync when same name is already exist
        [Fact]
        public async Task CreateDogAsync_IsReturnsConflict_WhenDogNameExists()
        {
            // Arrange
            var model = new DogCreateModel
            {
                Name = "Dudu",
                Color = "Brown",
                Tail_Length = "10",
                Weight = "20"
            };

            var existingDog = new Dog
            {
                Name = "Dudu",
                Color = "Black",
                Tail_Length = "5",
                Weight = "15"
            };

            var contextOptions = new DbContextOptionsBuilder<DogDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDogDatabase")
                .Options;

            using (var context = new DogDbContext(contextOptions))
            {
                // Seed the in-memory database with an existing dog
                await context.Dogs.AddAsync(existingDog);
                await context.SaveChangesAsync();

                var controller = new DogController(context, null);

                // Act
                var result = await controller.CreateDogAsync(model);

                // Assert
                var conflictResult = Assert.IsType<ConflictObjectResult>(result.Result);
                Assert.Equal("A dog with the same name already exists.", conflictResult.Value);
            }
        }


        // Test method for CreateDogAsync when name doesnt exist
        [Fact]
        public async Task CreateDogAsync_IsReturnsCreatedDog_WhenOk()
        {
            // Arrange
            var model = new DogCreateModel
            {
                Name = "Rex",
                Color = "Brown",
                Tail_Length = "10",
                Weight = "20"
            };

            var contextOptions = new DbContextOptionsBuilder<DogDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDogDatabase")
                .Options;

            using (var context = new DogDbContext(contextOptions))
            {
                var controller = new DogController(context, null);

                // Act
                var result = await controller.CreateDogAsync(model);

                // Assert
                var dogResult = Assert.IsType<ActionResult<Dog>>(result);
                var createdDog = Assert.IsType<Dog>(dogResult.Value);
                Assert.Equal(model.Name, createdDog.Name);
                Assert.Equal(model.Color, createdDog.Color);
                Assert.Equal(model.Tail_Length, createdDog.Tail_Length);
                Assert.Equal(model.Weight, createdDog.Weight);
            }
        }




        

    }
}
