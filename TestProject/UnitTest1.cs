using Microsoft.AspNetCore.Mvc;
using Moq;
using TravelGuruServer.Controllers;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task GetComments_Returns_OkResult_With_Comments()
        {
            int trouteId = 123;
            var mockRoutesRepository = new Mock<IRouteRespositories>();
            var mockCommentRepositories = new Mock<ICommentRespositories>();
            var expectedComments = new List<Comment>
            {
                new Comment { commentId = 1, commentText = "Comment 1", commentRating = 4, commentDate = DateTime.Parse("2022-01-01"), UserName = "User1", TRouterouteId = trouteId },
                new Comment { commentId = 2, commentText = "Comment 2", commentRating = 5, commentDate = DateTime.Parse("2022-02-01"), UserName = "User2", TRouterouteId = trouteId }
            };

            mockRoutesRepository.Setup(r => r.GetRouteAsync(trouteId)).ReturnsAsync(new TRoute());
            mockCommentRepositories.Setup(c => c.GetCommentsAsync(trouteId)).ReturnsAsync(expectedComments);

            var controller = new CommentController(mockRoutesRepository.Object, mockCommentRepositories.Object);
            var result = await controller.GetComments(trouteId);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetComments_Returns_NoContent_When_Route_Does_Not_Exist()
        {
            int trouteId = 123;
            var mockRoutesRepository = new Mock<IRouteRespositories>();
            var mockCommentRepositories = new Mock<ICommentRespositories>();
            var expectedComments = new List<Comment>
    {
        new Comment { commentId = 1, commentText = "Comment 1", commentRating = 4, commentDate = DateTime.Parse("2022-01-01"), UserName = "User1", TRouterouteId = trouteId },
        new Comment { commentId = 2, commentText = "Comment 2", commentRating = 5, commentDate = DateTime.Parse("2022-02-01"), UserName = "User2", TRouterouteId = trouteId }
    };
            mockRoutesRepository.Setup(repo => repo.GetRouteAsync(2))
                .ReturnsAsync(new TRoute());
            var controller = new CommentController(mockRoutesRepository.Object, mockCommentRepositories.Object);
            var result = await controller.GetComments(trouteId);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

    }
}