using Microsoft.AspNetCore.Mvc;
using Moq;
using R5.A._08_TD2.Models;
using R5.A._08_TD2.Repositories;

namespace R5.A._08_TD2.Tests
{
    [TestClass]
    public class ProduitsControllerTests
    {
        [TestMethod]
        public async Task GetProduit_IdInexistant_RetourneNotFound()
        {
            var mockRepository = new Mock<IProduitRepository>();

            mockRepository
                .Setup(r => r.GetByIdAsync(999))
                .ReturnsAsync((Produit?)null);

            var controller = new ProduitsController(mockRepository.Object);

            var result = await controller.GetProduit(999);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetProduit_IdExistant_RetourneProduit()
        {
            var produit = new Produit
            {
                IdProduit = 1,
                NomProduit = "G502 HERO",
                IdMarque = 1,
                IdTypeProduit = 1
            };

            var mockRepository = new Mock<IProduitRepository>();

            mockRepository
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(produit);

            var controller = new ProduitsController(mockRepository.Object);

            var result = await controller.GetProduit(1);

            Assert.IsNotNull(result.Value);
            Assert.AreEqual("G502 HERO", result.Value.NomProduit);
        }

        [TestMethod]
        public async Task PostProduit_AppelleAddAsync()
        {
            var produit = new Produit
            {
                NomProduit = "G502 HERO",
                IdMarque = 1,
                IdTypeProduit = 1
            };

            var mockRepository = new Mock<IProduitRepository>();

            mockRepository
                .Setup(r => r.AddAsync(produit))
                .ReturnsAsync(produit);

            var controller = new ProduitsController(mockRepository.Object);

            await controller.PostProduit(produit);

            mockRepository.Verify(
                r => r.AddAsync(produit),
                Times.Once
            );
        }

        [TestMethod]
        public async Task DeleteProduit_IdInexistant_RetourneNotFound()
        {
            var mockRepository = new Mock<IProduitRepository>();

            mockRepository
                .Setup(r => r.GetByIdAsync(999))
                .ReturnsAsync((Produit?)null);

            var controller = new ProduitsController(mockRepository.Object);

            var result = await controller.DeleteProduit(999);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}