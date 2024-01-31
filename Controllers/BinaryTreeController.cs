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
    public class BinaryTreeController : Controller
    {
        public BinaryTreeController(BinaryTreeService binaryTreeService)
        {
            BinaryTreeService = binaryTreeService;
        }

        #region Property
        private BinaryTreeService BinaryTreeService { get; }

        #endregion

        [HttpPost()]
        public IActionResult GetMaxDepth([FromBody] TreeNode root)
        {
            int depth = BinaryTreeService.MaxDepth(root);
            return Ok(depth);
        }

    }
}

