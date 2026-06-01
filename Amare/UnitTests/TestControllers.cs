using Amare.Controllers;
using Amare.Data;
using Amare.Models;
using LogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using Models;
using Models.Interfaces;
using Moq;
using Xunit;

namespace UnitTests
{
    public class TestControllers : BaseController
    {
        [Fact]
        public async Task TestAddGuestRepository()
        {
            var fakeChallenges = new List<GuestsDTO>()
            {
                new GuestsDTO
                {
                    Id = 1,
                    GuestName = "John Doe",
                    TableName = "Table 1"

                }
            };

            var fakeAddGuest = new Mock<IAddGuest>();

            fakeAddGuest.Setup(x => x.GetGuest(It.IsAny<string>())).ReturnsAsync(fakeChallenges);

            var addGuestBusiness = new AddGuests(fakeAddGuest.Object);

            var controller = new AddGuestsController(addGuestBusiness);

            controller.weddingnCode = "testWedding";

            var result = await controller.GetGuest();

            Assert.IsType<GetGuestsDTO>(result);
             
        }

        [Fact]
        public async Task TestBudgetController()
        {
            var fakeBudget = new List<BudgetDTO>()
            {
                new BudgetDTO
                {
                    Id = 1,
                    MaxBudget = 1000
                }
            };

            var fakeBudgetRepo = new Mock<IBudget>();

            fakeBudgetRepo.Setup(x => x.GetBudget(It.IsAny<string>())).ReturnsAsync(fakeBudget);

            var budgetBusiness = new Budget(fakeBudgetRepo.Object);

            var controller = new BudgetController(budgetBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.GetBudget();

            Assert.IsType<List<BudgetDTO>>(result);
        }

        [Fact]
        public async Task TestChallengesController()
        {
            var fakeChallenges = new List<ChallengesDTO>()
            {
                new ChallengesDTO
                {
                    Id = 1,
                    ChallengeName = "Test Challenge",
                    ChallengePoints = 10,
                    ChallengeDescription = "This is a test challenge."
                }
            };

            var fakeChallengesRepo = new Mock<IChallenges>();

            fakeChallengesRepo.Setup(x => x.GetChallenges(It.IsAny<string>())).ReturnsAsync(fakeChallenges);

            var challengesBusiness = new Challenges(fakeChallengesRepo.Object);

            var controller = new ChallengesController(challengesBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.GetChallenges();

            Assert.IsType<List<ChallengesDTO>>(result);
        }

        [Fact]
        public async Task TestExpensesController()
        {
            var fakeExpenses = new List<ExpensesDTO>()
            {
                new ExpensesDTO
                {
                    Id = 1,
                    ExpenseName = "Test Expense",
                    ExpensePrice = 100
                }
            };

            var fakeExpensesRepo = new Mock<IExpenses>();

            fakeExpensesRepo.Setup(x => x.GetExpenses(It.IsAny<string>())).ReturnsAsync(fakeExpenses);

            var fakeBusiness = new Expenses(fakeExpensesRepo.Object);

            var controller = new ExpensesController(fakeBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.GetExpenses();

            Assert.IsType<List<ExpensesDTO>>(result);
        }

        [Fact]
        public async Task TestLeaderboardController()
        {
            var fakeLeaderboard = new List<UserLeaderboardDTO>()
            {
                new UserLeaderboardDTO
                {
                    UserPoints = 100,
                    Name = "John Doe"
                }
            };

            var fakeLeaderboardRepo = new Mock<ILeaderboard>();

            fakeLeaderboardRepo.Setup(x => x.GetLeaderboard(It.IsAny<string>())).ReturnsAsync(fakeLeaderboard);

            var leaderboardBusiness = new Leaderboard(fakeLeaderboardRepo.Object);

            var controller = new LeaderboardController(leaderboardBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.GetLeaderboard();

            Assert.IsType<List<UserLeaderboardDTO>>(result);
        }

        [Fact]
        public async Task TestLiveFeedController()
        {
            var fakeLiveFeed = new List<LiveFeedGetDTO>()
            {
                new LiveFeedGetDTO
                {
                    Id = 1,
                    UserName = "John Doe",
                    WeddingCode = "weddingCode",
                    Description = "This is a test post."
                }
            };

            var fakeLiveFeedRepo = new Mock<ILiveFeed>();

            fakeLiveFeedRepo.Setup(x => x.GetLiveFeed(It.IsAny<string>())).ReturnsAsync(fakeLiveFeed);

            var liveFeedBusiness = new LiveFeed(fakeLiveFeedRepo.Object);

            var controller = new LiveFeedController(liveFeedBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.LiveFeedGet();

            Assert.IsType<List<LiveFeedGetDTO>>(result);
        }

        [Fact]
        public async Task TestProfileImageController()
        {
            var fakeProfileImage = new List<string>()
            {
                new string ("https://ik.imagekit.io/Garcia5050/test-image.jpg")
            };

            var fakeProfileImageRepo = new Mock<IProfileImage>();

            fakeProfileImageRepo.Setup(x => x.GetProfileImage(It.IsAny<int>())).ReturnsAsync(fakeProfileImage);

            var fakeBusiness = new ProfileImage(fakeProfileImageRepo.Object);

            var controller = new ProfileImageController(fakeBusiness);

            var result = await controller.GetProfileImage();

            Assert.True(result is OkObjectResult || result is BadRequestResult);
        }

        [Fact]
        public async Task TestTasksController()
        {
            var fakeTasks = new List<TasksDTO>()
            {
                new TasksDTO
                {
                    Id = 1,
                    TaskName = "Test Task",
                    TaskDate = DateTime.Now,
                    TaskCompleted = 0
                }
            };

            var fakeTaksRepo = new Mock<ITasks>();

            fakeTaksRepo.Setup(x => x.GetTasks(It.IsAny<string>())).ReturnsAsync(fakeTasks);

            var Business = new Tasks(fakeTaksRepo.Object);

            var controller = new TasksController(Business);

            controller.weddingnCode = "weddingCode";

            var result = await controller.Gettasks();

            Assert.IsType<List<TasksDTO>>(result);
        }

        [Fact]
        public async Task TestVendorsController()
        {
            var fakeVendor = new List<VendorsDTO>()
            {
                new VendorsDTO
                {
                    Id = 1,
                    VendorDescription = "Test Vendor",
                    VendorPrice = 0,
                    VendorType = "Test Type"
                }
            };

            var fakeVendorRepo = new Mock<IVendors>();

            fakeVendorRepo.Setup(x => x.GetVendors(It.IsAny<string>())).ReturnsAsync(fakeVendor);

            var Business = new Vendors(fakeVendorRepo.Object);

            var controller = new VendorsController(Business);

            controller.weddingnCode = "weddingCode";

            var result = await controller.GetVendors();

            Assert.IsType<List<VendorsDTO>>(result);
        }

        [Fact]
        public async Task TestWeddingEvents()
        {
            var fakeWeddingEvents = new List<WeddingEventDTO>()
            {
                new WeddingEventDTO
                {
                    Id = 1,
                    WeddingEventName = "Test",
                    WeddingEventTime = TimeSpan.FromHours(1)
                }
            };

            var fakeWeddingEventRepo = new Mock<IWeddingEvents>();

            fakeWeddingEventRepo.Setup(x => x.GetWeddingEvents(It.IsAny<string>())).ReturnsAsync(fakeWeddingEvents);

            var Business = new WeddingEvents(fakeWeddingEventRepo.Object);

            var controller = new WeddingEventController(Business);

            controller.weddingnCode = "weddingCode";

            var result = await controller.GetWeddingEvents();

            Assert.IsType<List<WeddingEventDTO>>(result);
        }

    }
}
