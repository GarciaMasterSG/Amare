using Amare.Controllers;
using Amare.Data;
using Amare.Models;
using DataLayer;
using LogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using Models;
using Models.Interfaces;
using Moq;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace UnitTests
{
    public class TestControllers : BaseController
    {
        [Fact]
        public async Task TestAddGuestRepository()
        {
            var fakeChallenges = new List<GuestsDomain>()
            {
                new GuestsDomain
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
            var fakeBudget = new List<BudgetDomain>()
            {
                new BudgetDomain
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

            Assert.IsType<List<BudgetDomain>>(result);
        }

        [Fact]
        public async Task TestChallengesController()
        {
            var fakeChallenges = new List<ChallengesDomain>()
            {
                new ChallengesDomain
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

            Assert.IsType<List<ChallengesDomain>>(result);
        }

        [Fact]
        public async Task TestExpensesController()
        {
            var fakeExpenses = new List<ExpensesDomain>()
            {
                new ExpensesDomain
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

            Assert.IsType<List<ExpensesDomain>>(result);
        }

        [Fact]
        public async Task TestLeaderboardController()
        {
            var fakeLeaderboard = new List<UserLeaderboardDomain>()
            {
                new UserLeaderboardDomain
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

            Assert.IsType<List<UserLeaderboardDomain>>(result);
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
        /*
        [Fact]
        public async Task TestProfileImageController()
        {
            var fakeProfileImage = new List<string>()
            {
                new string ("https://ik.imagekit.io/Garcia5050/test-image.jpg")
            };

            var fakeProfileImageRepo = new Mock<IProfileImage>();

            fakeProfileImageRepo.Setup(x => x.GetProfileImage(It.IsAny<ProfileImageDTO>())).ReturnsAsync(fakeProfileImage);

            var fakeBusiness = new ProfileImage(fakeProfileImageRepo.Object);

            var controller = new ProfileImageController(fakeBusiness);

            var result = await controller.GetProfileImage();

            Assert.True(result is OkObjectResult || result is BadRequestResult);
        }*/ 

        [Fact]
        public async Task TestTasksController()
        {
            var fakeTasks = new List<TasksDomain>()
            {
                new TasksDomain
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

            var result = await controller.GetTasks();

            Assert.IsType<List<TasksDomain>>(result);
        }

        [Fact]
        public async Task TestVendorsController()
        {
            var fakeVendor = new List<VendorsDomain>()
            {
                new VendorsDomain
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

            Assert.IsType<List<VendorsDomain>>(result);
        }

        [Fact]
        public async Task TestWeddingEvents()
        {
            var fakeWeddingEvents = new List<WeddingEventDomain>()
            {
                new WeddingEventDomain
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

            Assert.IsType<List<WeddingEventDomain>>(result);
        }

        // Testing the database lenght types 

        [Fact]
        public async Task AddGuestsLenghtErrorTest()
        {

            var fakeGuest = new GuestsDomain
            {
                Id = 1,
                GuestName = new string('a', 151),
                TableName = "Table 1",
                WeddingCode = "weddingCode"
            };

            var fakeAddGuestRepo = new Mock<IAddGuest>();

            fakeAddGuestRepo.Setup(x => x.AddGuestsPost(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(1);

            var addGuestBusiness = new AddGuests(fakeAddGuestRepo.Object);

            var controller = new AddGuestsController(addGuestBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.AddGuestsPost(fakeGuest.GuestName);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task ExpenseLengthErrorTest()
        {
            var fakeExpense = new ExpensesDomain
            {
                ExpenseName = new string('a', 101),
                ExpensePrice = 100,
                Id = 1,
            };

            var fakeExpenseRepo = new Mock<IExpenses>();

            fakeExpenseRepo.Setup(x => x.PostExpenses(It.IsAny<ExpensesDomain>(), It.IsAny<string>())).ReturnsAsync(1);

            var expensesBusiness = new Expenses(fakeExpenseRepo.Object);

            var controller = new ExpensesController(expensesBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.PostExpense(fakeExpense);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task LiveFeedLenghtErrorTest()
        {
            var fakePost = new LiveFeedPostDTO
            {
                Description = new string('a', 301),
                FileName = "test.jpg",
                PhotoFeed = null
            };

            var fakeLiveFeedRepo = new Mock<ILiveFeed>();

            fakeLiveFeedRepo.Setup(x => x.PostLiveFeed(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var liveFeedBusiness = new LiveFeed(fakeLiveFeedRepo.Object);

            var controller = new LiveFeedController(liveFeedBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.PostLiveFeed(fakePost);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task VendorControllerLenghtError()
        {
            var fakevendor = new VendorsDomain
            {
                VendorName = new string('a', 151),
                VendorDescription = new string('a', 301),
                VendorPrice = 100,
                VendorType = "Test Type",
                Id = 1
            };

            var fakeVendorRepo = new Mock<IVendors>();

            fakeVendorRepo.Setup(x => x.PostVendors(It.IsAny<VendorsDomain>(), It.IsAny<string>())).ReturnsAsync(1);

            var fakeBusiness = new Vendors(fakeVendorRepo.Object);

            var controller = new VendorsController(fakeBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.PostVendors(fakevendor);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task ChallengeControllerLenghtError()
        {
            var fakeChallenge = new ChallengesDomain
            {
                Id = 1,
                ChallengeName = new string('a', 151),
                ChallengeDescription = new string('a', 301),
                ChallengePoints = 10,
            };

            var fakeChallengesRepo = new Mock<IChallenges>();

            fakeChallengesRepo.Setup(x => x.ChallengesPost(It.IsAny<ChallengesDomain>(), It.IsAny<string>())).ReturnsAsync(1);

            var challengesBusiness = new Challenges(fakeChallengesRepo.Object);

            var controller = new ChallengesController(challengesBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.ChallengesPost(fakeChallenge);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task WeddingEventLenghtError()
        {
            var fakeWeddingEvent = new WeddingEventDomain
            {
                Id = 1,
                WeddingEventName = new string('a', 151),
                WeddingEventTime = TimeSpan.FromHours(1)
            };

            var fakeWeddingEventRepo = new Mock<IWeddingEvents>();

            fakeWeddingEventRepo.Setup(x => x.WeddingEventPost(It.IsAny<WeddingEventDomain>(), It.IsAny<string>())).ReturnsAsync(1);

            var fakeBusiness = new WeddingEvents(fakeWeddingEventRepo.Object);

            var controller = new WeddingEventController(fakeBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.WeddingEventPost(fakeWeddingEvent);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task TaskControllerLenghtError()
        {
            var fakeTask = new TasksDomain
            {
                Id = 1,

                TaskName = new string('a', 151),

                TaskCompleted = 0,

                TaskDate = DateTime.Now
            };

            var fakeTaskRepo = new Mock<ITasks>();

            fakeTaskRepo.Setup(x => x.TasksPost(It.IsAny<TasksDomain>(), It.IsAny<string>())).ReturnsAsync(1);

            var fakeBusiness = new Tasks(fakeTaskRepo.Object);

            var controller = new TasksController(fakeBusiness);

            controller.weddingnCode = "weddingCode";

            var result = await controller.TasksPost(fakeTask);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

