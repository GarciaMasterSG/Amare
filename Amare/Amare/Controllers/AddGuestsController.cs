using Amare.Data;
using Amare.Models;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddGuestsController : BaseController
    {
        private readonly AddGuests _addGuests;

        public AddGuestsController(AddGuests addGuests)
        {
            _addGuests = addGuests;
        }

        [HttpGet]
        public async Task<GetGuestsDTO> GetGuest()
        {
            var guest = await _addGuests.GetGuest(weddingnCode);

            var guests = guest.Select(guest => new SpecificGuest { GuestName = guest.GuestName, Id = guest.Id }).ToList();

            var tables = guest.GroupBy(tables => tables.TableName).Select(t => new GropedTables
            {
                TableName = t.Key,
                GuestNames = t.Select(guest => guest.GuestName).ToList()
            }).ToList();

            return new GetGuestsDTO
            {
                GuestsList = guests,
                GroupedTables = tables
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddGuestsPost([FromForm] string guest)
        {
            if (guest.Length > 150)
            {
                return BadRequest(new { error = "Guest name cannot exceed 150 characters." });
        }
            int id = await _addGuests.AddGuestsPost(guest, weddingnCode);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _addGuests.DeleteAddGuests(id);

            return Ok();
        }

        [HttpDelete("guesttable/({table})")]
        public async Task<IActionResult> DeleteTable(string tableName)
        {
            await _addGuests.DeleteTable(tableName, weddingnCode);

            return Ok();
        } 


    }
}
