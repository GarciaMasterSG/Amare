using Amare.Models;
using LogicLayer;
using Models;
using Models.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class TestBusiness
    {
        [Fact]
        public async Task AddGuestBusinessTest()
        {
            var fakeGuest = new List<GuestsDomain>()
            {
                new GuestsDomain
                {
                    Id = 4,
                    GuestName = "Jose",
                    TableName = "Jose",
                    WeddingCode = "123"
                }
            };

            var fakeAddGuestRepository = new Mock<IAddGuest>();

            fakeAddGuestRepository.Setup(x => x.GetGuest(It.IsAny<string>())).ReturnsAsync(fakeGuest);

            var fakeBusiness = new AddGuests(fakeAddGuestRepository.Object);

            var result = await fakeBusiness.GetGuest("123");

            Assert.IsType<List<GuestsDomain>>(result);
        }

        [Fact]
        public async Task BudgetBusinessTest()
        {
            var fakeBudget = new List<BudgetDomain>
            {
                new BudgetDomain{
                    Id = 4,
                    MaxBudget = 1,
                    WeddingCode = "123"
                }
            };

            var fakeBudgetRepository = new Mock<IBudget>();

            fakeBudgetRepository.Setup(x => x.GetBudget(It.IsAny<string>())).ReturnsAsync(fakeBudget);

            var fakeBusiness = new Budget(fakeBudgetRepository.Object);

            var result = await fakeBusiness.GetBudget("123");

            Assert.IsType<List<BudgetDomain>>(result);
        }

        [Fact]
        public async Task ChallengesBusinessTest()
        {
            var fakeChallenges = new List<ChallengesDomain>
            {
                new ChallengesDomain
                {
                    Id = 4,
                    ChallengeName = "123",
                    ChallengeDescription = "123",
                    ChallengePoints = 123
                }
            };

            var fakeChallengeRepo = new Mock<IChallenges>();

            fakeChallengeRepo.Setup(x => x.GetChallenges(It.IsAny<string>())).ReturnsAsync(fakeChallenges);

            var fakeBusiness = new Challenges(fakeChallengeRepo.Object);

            var result = await fakeBusiness.GetChallenges("123");

            Assert.IsType<List<ChallengesDomain>>(result);
        }

        [Fact]
        public async Task ExpensesBusinessTest()
        {
            var fakeExpense = new List<ExpensesDomain>
            {
                new ExpensesDomain
                {
                    Id = 4,
                    ExpenseName = "123",
                    ExpensePrice = 100,
                }
            };

            var fakeExpenseRepo = new Mock<IExpenses>();

            fakeExpenseRepo.Setup(x => x.GetExpenses(It.IsAny<string>())).ReturnsAsync(fakeExpense);

            var fakeBusiness = new Expenses(fakeExpenseRepo.Object);

            var result = await fakeBusiness.GetExpenses("123");

            Assert.IsType<List<ExpensesDomain>>(result);
        }

        [Fact]
        public async Task LeaderboardBusinessTest()
        {
            var fakeLeaderboard = new List<UserLeaderboardDomain>
            {
                new UserLeaderboardDomain
                {
                    Name = "123",
                    UserPoints = 123,
                }
            };

            var fakeLeaderboardRepo = new Mock<ILeaderboard>();

            fakeLeaderboardRepo.Setup(x => x.GetLeaderboard(It.IsAny<string>())).ReturnsAsync(fakeLeaderboard);

            var fakeBusiness = new Leaderboard(fakeLeaderboardRepo.Object);

            var result = await fakeBusiness.GetLeaderboard("123");

            Assert.IsType<List<UserLeaderboardDomain>>(result);
        }

        [Fact]
        public async Task LiveFeedBusinessTest()
        {
            var fakeLiveFeed = new List<LiveFeedGetDTO>
            {
                new LiveFeedGetDTO
                {
                    Id = 4,
                    UserName = "123",
                    Description = "123",
                    PhotoFeed = "123",
                    WeddingCode = "123",
                }
            };

            var fakeLivefeedRepo = new Mock<ILiveFeed>();

            fakeLivefeedRepo.Setup(x => x.GetLiveFeed(It.IsAny<string>())).ReturnsAsync(fakeLiveFeed);

            var fakeBusiness = new LiveFeed(fakeLivefeedRepo.Object);

            var result = await fakeBusiness.GetLiveFeed("123");

            Assert.IsType<List<LiveFeedGetDTO>>(result);
        }

        [Fact]
        public async Task TasksBusinessTest()
        {
            var fakeTask = new List<TasksDomain>()
            {
                new TasksDomain
                {
                    Id = 1,
                    TaskName = "123",
                    TaskCompleted = 0,
                    TaskDate = DateTime.Now
                }
            };

            var fakeTasksRepo = new Mock<ITasks>();

            fakeTasksRepo.Setup(x => x.GetTasks(It.IsAny<string>())).ReturnsAsync(fakeTask);

            var fakeBusiness = new Tasks(fakeTasksRepo.Object);

            var result = await fakeBusiness.GetTasks("123");

            Assert.IsType<List<TasksDomain>>(result);         
        }

        [Fact]
        public async Task VendorBusinessTest()
        {
            var fakeVendor = new List<VendorsDomain>
            {
                new VendorsDomain
                {
                    Id = 1,
                    VendorName = "123",
                    VendorDescription = "123",
                    VendorPrice = 100,
                    VendorType = "123",
                    Hired = 0
                }
            };

            var fakeVendorsRepo = new Mock<IVendors>();

            fakeVendorsRepo.Setup(x => x.GetVendors(It.IsAny<string>())).ReturnsAsync(fakeVendor);

            var fakeBusiness = new Vendors(fakeVendorsRepo.Object);

            var result = await fakeBusiness.GetVendors("123");

            Assert.IsType<List<VendorsDomain>>(result);
        }

        [Fact]
        public async Task WeddingEventBusinessTest()
        {
            var fakeWeddingEvent = new List<WeddingEventDomain>
            {
                new WeddingEventDomain
                {
                    Id = 1,
                    WeddingEventName = "123",
                    WeddingEventTime = TimeSpan.FromSeconds(1)
                }
            };

            var fakeWeddingEventRepo = new Mock<IWeddingEvents>();

            fakeWeddingEventRepo.Setup(x => x.GetWeddingEvents(It.IsAny<string>())).ReturnsAsync(fakeWeddingEvent);

            var fakeBusiness = new WeddingEvents(fakeWeddingEventRepo.Object);

            var result = await fakeBusiness.GetWeddingEvents("123");

            Assert.IsType<List<WeddingEventDomain>>(result);

        }
    }
}
