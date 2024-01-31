using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_coding.Models;
using test_coding.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_coding.Controllers
{
    [Route("api/[controller]")]
    public class ReverceController : Controller
    {
        public ReverceController(ReverceService reverceService)
        {
            ReverceService = reverceService;
        }

        #region Property
        private ReverceService ReverceService {get;}
        #endregion

        #region Method
        [HttpPost()]
        public IActionResult ReverseLinkedList([FromBody] int[] values)
        {
            var head = ReverceService.BuildList(values);
            var reversedHead = ReverceService.ReverseList(head);
            return Ok(LinkedListToArray(reversedHead));
        }

        private List<int> LinkedListToArray(Node head)
        {
            var values = new List<int>();
            var current = head;
            while (current != null)
            {
                values.Add(current.Value);
                current = current.Next;
            }
            return values;
        }

        #endregion
    }
}

